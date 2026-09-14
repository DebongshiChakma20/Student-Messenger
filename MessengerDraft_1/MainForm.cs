using System.Text;
using System.Net.Sockets;
using System.Net.Sockets;

namespace Messenger
{
    public partial class MainForm : Form
    {
        private Client client;



        private Contact currentContact;

        public MainForm(string userId, Client client)
        {
            InitializeComponent();
            this.client = client;
            lblUsersId.Text = userId;
            btnbackMain.BackColor = Color.Transparent;
        }

        List<Panel> myContactListPanel = new List<Panel>();
        List<Contact> myContacts = new List<Contact>();
        List<Message> allMsg = new List<Message>();




        private void signUpInToolStripMenuItem_Click(object sender, EventArgs e)
        {

            logForm lgform = new logForm();
            lgform.Show();

            this.Hide();
            client.Disconnect();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUserForm addForm = new addUserForm(this, client, lblUsersId.Text);


            addForm.Show();

            this.Hide();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            client.Disconnect();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                client.MessageReceived += clientMessageReceived;
                client.StartListening();
                client.Send($"LOAD_CONTACTS:{lblUsersId.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void clientMessageReceived(string text)
        {
            this.Invoke(() =>
            {
                Console.WriteLine("Mainfrom received" + text);

                if (text.StartsWith("CONTACT:"))
                {
                    string data = text.Substring("CONTACT:".Length);

                    string[] parts = data.Split('|', 3);

                    if (parts.Length != 3)
                        return;

                    Contact contact = new Contact();

                    contact.id = parts[0];
                    contact.name = parts[1];
                    contact.status = parts[2];

                    AddContact(contact);

                    return;
                }
                if (text.StartsWith("MESSAGE:"))
                {
                    string data = text.Substring("MESSAGE:".Length);

                    string[] parts = data.Split('|', 2);

                    if (parts.Length != 2)
                        return;

                    Message message = new Message();

                    message.senderId = parts[0];
                    message.recreiverId = lblUsersId.Text;
                    message.messageText = parts[1];
                    message.time = DateTime.Now;

                    allMsg.Add(message);

                    if (currentContact != null && currentContact.id == message.senderId)
                    {
                        messageOThersDisplay(message);
                        scrollMessageBottom();
                    }

                    return;
                }

                if (text.StartsWith("OLD_MESSAGE:"))
                {
                    string data = text.Substring("OLD_MESSAGE:".Length);
                    string[] parts = data.Split('|', 4);

                    if (parts.Length != 4) return;

                    Message message = new Message();
                    message.messageId = parts[0];
                    message.senderId = parts[1];
                    message.recreiverId = parts[2];
                    message.messageText = parts[3];
                    message.time = DateTime.Now;

                    allMsg.Add(message);

                    return;
                }

                if (text == "MESSAGES_LOADED")
                {
                    if (currentContact != null)
                    {
                        loadConversation(currentContact);
                    }

                    return;
                }
                if (text == "DELETE_SUCCESS")
                {
                    MessageBox.Show("Message deleted successfully.");

                    return;
                }

                if (text == "DELETE_FAILED")
                {
                    MessageBox.Show("Failed to delete message.");

                    return;
                }

            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            if (currentContact == null)
            {
                MessageBox.Show("Please select a contact.");
                return;
            }

            if (string.IsNullOrEmpty(rtbMessage.Text))
            {
                return;
            }
            Message message = new Message();

            message.senderId = lblUsersId.Text;
            message.messageText = rtbMessage.Text;
            message.time = DateTime.Now;
            message.recreiverId = currentContact.id;


            messageOwnDisplay(message);
            allMsg.Add(message);
            scrollMessageBottom();
            string send = $"SEND_MESSAGE:{lblUsersId.Text}|{currentContact.id}|{rtbMessage.Text}";


            client.Send(send);
            rtbMessage.Clear();

        }



        private void pbProfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog profilePic = new OpenFileDialog();

            profilePic.Title = "Select a profile picture";
            profilePic.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (profilePic.ShowDialog() == DialogResult.OK)
            {
                pbProfile.Image = Image.FromFile(profilePic.FileName);
                pbProfile.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void addContactToFlow(Contact contacts)
        {
            Panel singleContactPanel = new Panel();
            singleContactPanel.Size = new Size(362, 50);
            singleContactPanel.BackColor = Color.White;
            singleContactPanel.BorderStyle = BorderStyle.FixedSingle;
            singleContactPanel.Margin = new Padding(3);


            Label lblIdOfContact = new Label();
            lblIdOfContact.Text = contacts.id;
            lblIdOfContact.Location = new Point(10, 15);
            lblIdOfContact.AutoSize = true;
            lblIdOfContact.Font = new Font("Segoe UI", 8, FontStyle.Regular);

            Label lblNameOfContact = new Label();
            lblNameOfContact.Text = contacts.name;
            lblNameOfContact.Location = new Point(130, 15);
            lblNameOfContact.AutoSize = true;
            lblNameOfContact.Font = new Font("Segoe UI", 8, FontStyle.Regular);

            Label lblStatus = new Label();
            lblStatus.Text = contacts.status;
            lblStatus.Location = new Point(230, 15);
            lblStatus.AutoSize = true;

            singleContactPanel.Controls.Add(lblIdOfContact);
            singleContactPanel.Controls.Add(lblNameOfContact);
            singleContactPanel.Controls.Add(lblStatus);

            singleContactPanel.Tag = contacts;

            singleContactPanel.Click += contact_Click;
            lblIdOfContact.Click += contact_Click;
            lblNameOfContact.Click += contact_Click;
            lblStatus.Click += contact_Click;

            fopContact.Controls.Add(singleContactPanel);
        }

        public void AddContact(Contact contact)
        {
            myContacts.Add(contact);

            addContactToFlow(contact);
        }

        public void contact_Click(object sender, EventArgs e)
        {

            Control clicked = (Control)sender;

            Panel clicked_Panel;

            if (clicked is Panel)
            {
                clicked_Panel = (Panel)clicked;
            }
            else
            {
                clicked_Panel = (Panel)clicked.Parent;
            }
            Contact selectedContact = (Contact)clicked_Panel.Tag;

            currentContact = (Contact)clicked_Panel.Tag;

            string request = $"LOAD_MESSAGES:{lblUsersId.Text}|{currentContact.id}";

            client.Send(request);

            // Clear current conversation
            floMsg.Controls.Clear();

        }

        private void loadConversation(Contact contact)
        {

            floMsg.Controls.Clear();

            foreach (Message msg in allMsg)
            {
                string msgId = msg.messageId;
                if ((msg.senderId == lblUsersId.Text && msg.recreiverId == contact.id) || (msg.senderId == contact.id && msg.recreiverId == lblUsersId.Text))
                {
                    if (msg.senderId == lblUsersId.Text)
                    {
                        messageOwnDisplay(msg);
                    }
                    else
                    {
                        messageOThersDisplay(msg);
                    }
                }

            }
            scrollMessageBottom();

        }

        private void messageOwnDisplay(Message message)
        {
            Panel row = new Panel();
            row.Width = floMsg.ClientSize.Width - 25;
            row.AutoSize = false;
            row.BackColor = Color.Transparent;


            Panel msg = new Panel();
            msg.AutoSize = true;
            msg.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            msg.BackColor = Color.Transparent;
            msg.Padding = new Padding(10);
            msg.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            msg.Location = new Point(row.ClientSize.Width - msg.PreferredSize.Width, 10);


            Label lbl = new Label();
            lbl.Text = message.messageText;
            lbl.AutoSize = true;
            lbl.BackColor = Color.White;
            lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lbl.MaximumSize = new Size(180, 0);
            lbl.Location = new Point(10, 10);


            msg.Controls.Add(lbl);
            msg.PerformLayout();
            msg.Size = msg.PreferredSize;

            msg.Location = new Point(row.Width - msg.Width - 15, 10);
            row.Height = msg.Height + 20;

            Label lblMenu = new Label();
            lblMenu.Text = "⋮";
            lblMenu.Size = new Size(20, 20);
            lblMenu.Cursor = Cursors.Hand;
            lblMenu.Font = new Font("Arial", 14, FontStyle.Bold);
            lblMenu.ForeColor = Color.DarkGray;
            lblMenu.TextAlign = ContentAlignment.MiddleCenter;
            lblMenu.Visible = true;
            lblMenu.Location = new Point(msg.Left - 25, msg.Top + (msg.Height - lblMenu.Height) / 2);


            ContextMenuStrip deleteMenu = new ContextMenuStrip();
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Message");

            deleteItem.Click += (sender, e) =>
            {
                DialogResult dr = MessageBox.Show("Do u want to delete this message?", "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    client.deleteMessage(message.messageId);
                }
                else
                {
                    return;
                }
            };


            deleteMenu.Items.Add(deleteItem);
            lblMenu.Click += (sender, e) =>
            {
                deleteMenu.Show(lblMenu, new Point(0, lblMenu.Height));
            };
            EventHandler showMenu = (s, e) => { lblMenu.Visible = true; };
            EventHandler hideMenu = (s, e) =>
            {
                Point clientMousePos = row.PointToClient(Cursor.Position);
                if (!row.ClientRectangle.Contains(clientMousePos))
                {
                    lblMenu.Visible = false;
                }
            };
            row.MouseEnter += showMenu;
            row.MouseLeave += hideMenu;
            msg.MouseEnter += showMenu;
            msg.MouseLeave += hideMenu;
            lbl.MouseEnter += showMenu;
            lbl.MouseLeave += hideMenu;
            lblMenu.MouseEnter += showMenu;
            lblMenu.MouseLeave += hideMenu;

            row.Height = row.Height + 20;
            row.Controls.Add(msg);
            row.Controls.Add(lblMenu);

            floMsg.Controls.Add(row);
        }

        private void messageOThersDisplay(Message message)
        {
            Panel row = new Panel();
            row.Width = floMsg.ClientSize.Width - 25;
            row.AutoSize = false;
            row.BackColor = Color.Transparent;


            Panel msg = new Panel();
            msg.AutoSize = true;
            msg.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            msg.BackColor = Color.LightGray;
            msg.Padding = new Padding(10);



            Label lbl = new Label();
            lbl.Text = message.messageText;
            lbl.AutoSize = true;
            lbl.BackColor = Color.White;
            lbl.Font = new Font("Sage UI", 15, FontStyle.Regular);
            lbl.MaximumSize = new Size(180, 0);
            lbl.Location = new Point(10, 10);


            msg.Controls.Add(lbl);
            msg.PerformLayout();
            msg.Size = msg.PreferredSize;
            msg.Location = new Point(10, 10);
            row.Height = msg.Height + 20;
            Label lblMenu = new Label();
            lblMenu.Text = "⋮";
            lblMenu.Size = new Size(15, 20);
            lblMenu.Cursor = Cursors.Hand;
            lblMenu.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblMenu.ForeColor = Color.Gray;
            lblMenu.TextAlign = ContentAlignment.MiddleCenter;
            lblMenu.Visible = true;
            lblMenu.Location = new Point(msg.Right + 5, msg.Top + (msg.Height - lblMenu.Height) / 2);
            ContextMenuStrip deleteMenu = new ContextMenuStrip();
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Message");

            deleteItem.Click += (sender, e) =>
            {
                DialogResult dr = MessageBox.Show("Do u want to delete this message?", "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    client.deleteMessage(message.messageId);
                }
                else
                {
                    return;
                }
            };

            deleteMenu.Items.Add(deleteItem);
            lblMenu.Click += (sender, e) =>
            {
                deleteMenu.Show(lblMenu, new Point(0, lblMenu.Height));
            };
            EventHandler showMenu = (s, e) => { lblMenu.Visible = true; };
            EventHandler hideMenu = (s, e) =>
            {
                Point clientMousePos = row.PointToClient(Cursor.Position);
                if (!row.ClientRectangle.Contains(clientMousePos))
                {
                    lblMenu.Visible = false;
                }
            };
            row.MouseEnter += showMenu;
            row.MouseLeave += hideMenu;
            msg.MouseEnter += showMenu;
            msg.MouseLeave += hideMenu;
            lbl.MouseEnter += showMenu;
            lbl.MouseLeave += hideMenu;
            lblMenu.MouseEnter += showMenu;
            lblMenu.MouseLeave += hideMenu;


            msg.Controls.Add(lbl);
            msg.PerformLayout();
            msg.Size = msg.PreferredSize;

            msg.Location = new Point(10, 10);

            row.Height = row.Height + 20;
            row.Controls.Add(msg);
            row.Controls.Add(lblMenu);

            floMsg.Controls.Add(row);
        }

        private void scrollMessageBottom()
        {
            if (floMsg.Controls.Count == 0)
                return;

            floMsg.PerformLayout();

            int bottom = floMsg.VerticalScroll.Maximum;

            floMsg.VerticalScroll.Value = bottom;

            floMsg.ScrollControlIntoView(
              floMsg.Controls[floMsg.Controls.Count - 1]
            );
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logForm lf = new logForm();

            this.Hide();
            lf.Show();
            client.Disconnect();
        }
    }
}

