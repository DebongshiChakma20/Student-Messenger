using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Messenger
{
    public partial class AdminUpdate : Form
    {
        private Client client;
        public AdminUpdate(Client client)
        {
            InitializeComponent();

            this.client = client;

            Console.WriteLine("AdminUpdate received client: " + this.client);

            client.MessageReceived += adminUpdateMessageReceived;
        }

        private void btnAdminUpdateSearch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending admin search...");
            Console.WriteLine("Client object: " + client);
            Console.WriteLine("Client connected: " + client.IsConnected);


            string searchId = tbxUpdateSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchId))
            {
                MessageBox.Show("Please enter a User ID to search.");
                return;
            }

            flpAdminSearch.Controls.Clear();
            updatePanel.Visible = false;

            client.Send($"ADMIN_SEARCH_USER:{searchId}");
        }

        private void adminUpdateMessageReceived(string message)
        {
            this.Invoke(() =>
            {
                if (message.StartsWith("ADMIN_USER:"))
                {
                    string data = message.Substring("ADMIN_USER:".Length);
                    string[] parts = data.Split('|', 3);
                    if (parts.Length == 3)
                    {
                        AddUserToSearchPanel(parts[0], parts[1], parts[2]);

                    }
                }
                else if (message == "ADMIN_SEARCH_END")
                {
                    if (flpAdminSearch.Controls.Count == 0)
                    {
                        MessageBox.Show("No users found.");
                    }
                }
                else if (message == "ADMIN_UPDATE_SUCCESS")
                {
                    MessageBox.Show("User Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updatePanel.Visible = false;
                }
                else if (message == "ADMIN_UPDATE_FAILED")
                {
                    MessageBox.Show("Failed to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void AddUserToSearchPanel(string userId, string userName, string password)
        {
            Panel userPanel = new Panel();
            userPanel.Width = flpAdminSearch.Width - 10;
            userPanel.Height = 60;
            userPanel.BorderStyle = BorderStyle.Fixed3D;

            Label userLabel = new Label();
            userLabel.Text = $"ID: {userId}     Name: {userName}";
            userLabel.AutoSize = true;

            userLabel.Location = new Point(10, 20);
            userPanel.Controls.Add(userLabel);

            userPanel.Cursor = Cursors.Hand;

            userPanel.Click += (sender, e) =>
            {
                ShowUpdatePanel(userId, userName, password);
            };

            userLabel.Cursor = Cursors.Hand;

            userLabel.Click += (sender, e) =>
            {
                ShowUpdatePanel(userId, userName, password);
            };
            flpAdminSearch.Controls.Add(userPanel);

        }

        private void ShowUpdatePanel(string userId, string userName, string password)
        {
            updatePanel.Visible = true;

            tbxIdUpdate.Text = userId;
            tbxNameUpdate.Text = userName;
            tbxPassUpdate.Text = password;

        }

        private void btnFinalAdminUpdate_Click(object sender, EventArgs e)
        {
            string userId = tbxIdUpdate.Text.Trim();

            string username = tbxNameUpdate.Text.Trim();

            string password = tbxPassUpdate.Text.Trim();

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");

                return;
            }

            client.Send($"ADMIN_UPDATE_USER:{userId}|{username}|{password}");
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            client.MessageReceived -= adminUpdateMessageReceived;

            base.OnFormClosed(e);
        }
    }
}
