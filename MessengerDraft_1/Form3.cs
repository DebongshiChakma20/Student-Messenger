using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MessengerDraft_1
{
    public partial class signUpForm : Form
    {
        private Client client;
        public signUpForm()
        {
            InitializeComponent();
            lblNameSU.BackColor = Color.Transparent;
            lblPassSU.BackColor = Color.Transparent;
            lblUserIdSU.BackColor = Color.Transparent;

            client = new Client();
            client.Connect();
            client.MessageReceived += clientMessageReceived;
            client.StartListening();
        }

        private void signUpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            string userId = tbxUserIdSU.Text;
            string name = tbxNameSU.Text;
            string password = tbxPasswordSU.Text;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("None of the fields can be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string request = $"REGISTER:{userId}|{name}|{password}";
            client.Send(request);
        }

        private void btnbackSignUp_Click(object sender, EventArgs e)
        {
            logForm lgForm = new logForm();

            lgForm.Show();

            this.Hide();
        }

        private void clientMessageReceived(string text)
        {
            this.Invoke(() =>
            {
                if (text == "REGISTER_SUCCESS")
                {
                    MessageBox.Show("Sign Up successful!");

                    string userId = tbxUserIdSU.Text.Trim();

                    MainForm mainForm = new MainForm(userId,client);
                    mainForm.Show();

                    this.Hide();
                }
                else if (text == "REGISTER_EXISTS")
                {
                    MessageBox.Show("User ID already exists.");
                }
                else if (text == "REGISTER_FAILED")
                {
                    MessageBox.Show("Registration failed.");
                }
            });
        }
    }
  
}