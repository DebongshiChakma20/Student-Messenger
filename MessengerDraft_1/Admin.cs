using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger
{
    public partial class Admin : Form
    {
        private Client client;

        public Admin(string userId, Client client)
        {
            lblATitle.BackColor = Color.Transparent;
            lblAdmibYUId.BackColor = Color.Transparent;
            lblchat.BackColor = Color.Transparent;
            InitializeComponent();
            this.client = client;

            client.MessageReceived += adminMessageReceived;
        }



        private void btnAdminDelete_Click(object sender, EventArgs e)
        {
            AdminDelete ad = new AdminDelete(client);
            ad.Show();
        }

        private void btnAdminUpdate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Admin client connected: " + client);
            Console.WriteLine("Client connected: " + client.IsConnected);
            AdminUpdate au = new AdminUpdate(client);
            au.Show();
        }

        private void btnbackAddUser_Click(object sender, EventArgs e)
        {
            logForm lgForm = new logForm();
            lgForm.Show();
            this.Close();
        }

        private void btnAdminSearch_Click(object sender, EventArgs e)
        {
            string userId = tbxAdminUserSearch.Text.Trim();

            if(string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Please enter a user ID to search.");
                return;
            }
            dgvHistory.Rows.Clear();

            client.Send($"ADMIN_CHAT_HISTORY:{userId}");
        }

        public void adminMessageReceived(string message)
        {
            this.Invoke(() =>
            {
                if (message.StartsWith("CHAT_HISTORY:"))
                {
                    string data = message.Substring("CHAT_HISTORY:".Length);

                    string[] parts = data.Split('|', 4);

                    if (parts.Length == 4)
                    {
                        dgvHistory.Rows.Add(
                            parts[0],
                            parts[1], 
                            parts[2], 
                            parts[3]  
                        );
                    }
                }
            });
        }
    }
}
