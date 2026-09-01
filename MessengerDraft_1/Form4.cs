using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerDraft_1
{
    public partial class addUserForm : Form
    {
        public MainForm mForm;
        private List<Contact> contacts;
        private Client client;
        private string currentUserId;

        public addUserForm(MainForm mForm,Client client,string userId)
        {
            InitializeComponent();
            this.mForm = mForm;
            currentUserId = userId;
            this.client = client;

            client.MessageReceived += clientMessageReceived;
        }

        private void addUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnbackAddUser_Click(object sender, EventArgs e)
        {
            
            mForm.Show();

            this.Hide();
        }

        private void btnAddUserSearch_Click(object sender, EventArgs e)
        {
            string userId = tbxSearch.Text.Trim();

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Enter a User ID.");
                return;
            }

            string request = $"SEARCH_USER:{userId}";
            client.Send(request);

        }

        private void ShowSearchResult(Contact contact)
        {
            floSearch.Controls.Clear();

            Panel searchResultPanel = new Panel();
            searchResultPanel.Size = new Size(890, 60);
            searchResultPanel.BorderStyle = BorderStyle.FixedSingle;

            Label lblId = new Label();
            lblId.Text = contact.id;
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 20);

            Label lblName = new Label();
            lblName.Text = contact.name;
            lblName.Location = new Point(300, 20);
            lblName.AutoSize = true;

            Label lblStatus = new Label();
            lblStatus.Text = contact.status;
            lblStatus.Location = new Point(450, 20);
            lblStatus.AutoSize = true;

            Button btnAdd = new Button();
            btnAdd.Text = "Add";
            btnAdd.Location = new Point(600, 17);
            btnAdd.AutoSize = true;

            btnAdd.Tag = contact;
            btnAdd.Click += btnAddUser_Click;


            searchResultPanel.Controls.Add(lblId);
            searchResultPanel.Controls.Add(lblName);
            searchResultPanel.Controls.Add(lblStatus);
            searchResultPanel.Controls.Add(btnAdd);

            floSearch.Controls.Add(searchResultPanel);
        }
        private void btnAddUser_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn)
                return;

            if (btn.Tag is not Contact selected)
                return;
            string request = $"ADD_CONTACT:{currentUserId}|{selected.id}";
            client.Send(request);

        }

        private void clientMessageReceived(string text)
        {
            this.Invoke(() =>
            {
                if (text == "CONTACT_ADD_SUCCESSFUL")
                {
                    
                    string searchedId = tbxSearch.Text.Trim();

                    
                    foreach (Control control in floSearch.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control child in panel.Controls)
                            {
                                if (child is Button button &&
                                    button.Tag is Contact contact)
                                {
                                    mForm.AddContact(contact);

                                    mForm.Show();
                                    this.Hide();
                                    return;
                                }
                            }
                        }
                    }

                    return;
                }

                if (text == "CONTACT_ALREADY_EXIST")
                {
                    MessageBox.Show("Contact already exists.");
                    return;
                }

                if (text == "CONTACT_ADD_FAILED")
                {
                    MessageBox.Show("Failed to add contact.");
                    return;
                }

                string[] parts = text.Split('|');

                if (parts[0] == "USER_NOT_FOUND")
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                if (parts[1] == "USER_FOUND")
                {
                    Contact contact = new Contact();

                    contact.id = parts[1];
                    contact.name = parts[2];
                    contact.status = parts[3];

                    ShowSearchResult(contact);
                }
            });
        }
    }
}
