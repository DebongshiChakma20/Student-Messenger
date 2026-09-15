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
    public partial class AdminDelete : Form
    {
        Client client;
        public AdminDelete(Client client)
        {
            this.client = client;
            InitializeComponent();
            client.MessageReceived += adminDeleteMessageReceived;
        }

        private void btnFinalAdminDelete_Click(object sender, EventArgs e)
        {
            string userID = tbxDeleteAdmin.Text.Trim();

            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Please enter a user ID to delete.");
                return;
            }

            DialogResult dr = MessageBox.Show($"Are you sure you want to delete user {userID}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                client.Send($"ADMIN_DELETE_USER:{userID}");
            }
        }

        private void adminDeleteMessageReceived(string message)
        {
            if (IsDisposed || Disposing)
                return;

            if (InvokeRequired)
            {
                Invoke(() => adminDeleteMessageReceived(message));
                return;
            }

            if (message == "ADMIN_DELETE_SUCCESS")
            {
                MessageBox.Show("User deleted successfully.");
                lblAUser.Text = "";
                tbxDeleteAdmin.Clear();
            }
            else if (message == "ADMIN_DELETE_FAILED")
            {
                MessageBox.Show("Failed to delete user.");
            }
            else if (message.StartsWith("ADMIN_USER_INFO:"))
            {
                string data = message.Substring("ADMIN_USER_INFO:".Length);

                string[] parts = data.Split('|', 2);

                if (parts.Length == 2)
                {
                    string userId = parts[0];
                    string username = parts[1];

                    lblAUser.Text =
                        $"User ID: {userId}\r\n" +
                        $"Username: {username}";
                }
            }
            else if (message == "ADMIN_USER_NOT_FOUND")
            {
                lblAUser.Text = "User not found.";
            }
        }


        private void tbxDeleteAdmin_TextChanged_1(object sender, EventArgs e)
        {
            string userID = tbxDeleteAdmin.Text.Trim();

            if (string.IsNullOrEmpty(userID))
            {
                lblAUser.Text = "";
                return;
            }

            client.Send($"ADMIN_GET_USER:{userID}");
        }
    }
}
