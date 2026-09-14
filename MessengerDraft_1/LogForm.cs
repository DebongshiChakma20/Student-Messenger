using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger
{
    public partial class logForm : Form
    {
        private Client client;
        public logForm()
        {
            InitializeComponent();
            lblName.BackColor = Color.Transparent;
            lblPass.BackColor = Color.Transparent;
            linkLabelSI.BackColor = Color.Transparent;
            userPanel.BackColor = Color.Transparent;

            client = new Client();
            client.Connect();

            client.MessageReceived += clientMessageReceived;
            client.StartListening();

        }


        private void linkLabelSI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signUpForm suForm = new signUpForm();

            suForm.Show();

            this.Hide();
        }

        private void logForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnbackSignIn_Click(object sender, EventArgs e)
        {
            string userId = tbxUserId.Text.Trim();
            MainForm mainForm = new MainForm(userId,client);
            mainForm.Show();

            this.Hide();

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string userId = tbxUserId.Text;
            string password = tbxPass.Text;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both User ID and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string request = $"LOGIN:{userId}|{password}";
            client.Send(request);


            if(userId == "admin" && password == "1444")
            {
                
            }

        }

        private void clientMessageReceived(string text)
        {
            this.Invoke(() =>
            {

                if (text == "ADMIN_LOGIN_SUCCESS")
                {
                    string userId = tbxUserId.Text.Trim();

                    client.MessageReceived -= clientMessageReceived;

                    Admin adminForm = new Admin(userId, client);
                    adminForm.Show();
                    this.Hide();
                }
                else if (text == "LOGIN_SUCCESS")
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        string userId = tbxUserId.Text.Trim();
                        client.MessageReceived -= clientMessageReceived; 
                        MainForm mainForm = new MainForm(userId, client);
                        mainForm.Show();
                        this.Hide();
                    }));



                }
                else if (text == "LOGIN_FAILED")
                {
                    MessageBox.Show(
                        "Incorrect User ID or Password.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                
            });
        }


    }
    
}
