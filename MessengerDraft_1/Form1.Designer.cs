namespace MessengerDraft_1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            fopContact = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            moreToolStripMenuItem = new ToolStripMenuItem();
            aboutUsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            signUpInToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            addUserToolStripMenuItem = new ToolStripMenuItem();
            tbxSearch = new TextBox();
            lblSearch = new Label();
            btnSearch = new Button();
            panelMessage = new Panel();
            floMsg = new FlowLayoutPanel();
            panel2 = new Panel();
            rtbMessage = new RichTextBox();
            btnSend = new Button();
            lblText = new Label();
            panel1 = new Panel();
            lblUsersId = new Label();
            pbProfile = new PictureBox();
            btnbackMain = new Button();
            replyTimer = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            panelMessage.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProfile).BeginInit();
            SuspendLayout();
            // 
            // fopContact
            // 
            fopContact.AutoScroll = true;
            fopContact.BackgroundImage = Properties.Resources.chatList;
            fopContact.FlowDirection = FlowDirection.TopDown;
            fopContact.Location = new Point(14, 77);
            fopContact.Margin = new Padding(3, 4, 3, 4);
            fopContact.Name = "fopContact";
            fopContact.Size = new Size(363, 552);
            fopContact.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { moreToolStripMenuItem, addUserToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1017, 30);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // moreToolStripMenuItem
            // 
            moreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutUsToolStripMenuItem, exitToolStripMenuItem, signUpInToolStripMenuItem, logOutToolStripMenuItem });
            moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            moreToolStripMenuItem.Size = new Size(58, 24);
            moreToolStripMenuItem.Text = "More";
            // 
            // aboutUsToolStripMenuItem
            // 
            aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            aboutUsToolStripMenuItem.Size = new Size(224, 26);
            aboutUsToolStripMenuItem.Text = "About us";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // signUpInToolStripMenuItem
            // 
            signUpInToolStripMenuItem.Name = "signUpInToolStripMenuItem";
            signUpInToolStripMenuItem.Size = new Size(224, 26);
            signUpInToolStripMenuItem.Text = "SignUp/In";
            signUpInToolStripMenuItem.Click += signUpInToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(224, 26);
            logOutToolStripMenuItem.Text = "Log out";
            
            // 
            // addUserToolStripMenuItem
            // 
            addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            addUserToolStripMenuItem.Size = new Size(84, 24);
            addUserToolStripMenuItem.Text = "Add User";
            addUserToolStripMenuItem.Click += addUserToolStripMenuItem_Click;
            // 
            // tbxSearch
            // 
            tbxSearch.Location = new Point(142, 40);
            tbxSearch.Margin = new Padding(3, 4, 3, 4);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(175, 27);
            tbxSearch.TabIndex = 7;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(75, 45);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search:";
            // 
            // btnSearch
            // 
            btnSearch.Image = Properties.Resources.search4;
            btnSearch.Location = new Point(325, 37);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(66, 35);
            btnSearch.TabIndex = 9;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // panelMessage
            // 
            panelMessage.Controls.Add(floMsg);
            panelMessage.Controls.Add(panel2);
            panelMessage.Location = new Point(397, 44);
            panelMessage.Margin = new Padding(3, 4, 3, 4);
            panelMessage.Name = "panelMessage";
            panelMessage.Size = new Size(512, 585);
            panelMessage.TabIndex = 10;
            // 
            // floMsg
            // 
            floMsg.AutoScroll = true;
            floMsg.BackgroundImage = Properties.Resources.chatBack;
            floMsg.FlowDirection = FlowDirection.TopDown;
            floMsg.Location = new Point(0, 0);
            floMsg.Margin = new Padding(3, 4, 3, 4);
            floMsg.Name = "floMsg";
            floMsg.Size = new Size(512, 532);
            floMsg.TabIndex = 0;
            floMsg.WrapContents = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(rtbMessage);
            panel2.Controls.Add(btnSend);
            panel2.Controls.Add(lblText);
            panel2.Location = new Point(0, 531);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(510, 60);
            panel2.TabIndex = 12;
            // 
            // rtbMessage
            // 
            rtbMessage.Location = new Point(55, 9);
            rtbMessage.Margin = new Padding(3, 4, 3, 4);
            rtbMessage.Name = "rtbMessage";
            rtbMessage.Size = new Size(350, 33);
            rtbMessage.TabIndex = 8;
            rtbMessage.Text = "";
            // 
            // btnSend
            // 
            btnSend.Image = Properties.Resources.sendIcon;
            btnSend.Location = new Point(424, 9);
            btnSend.Margin = new Padding(3, 4, 3, 4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(86, 43);
            btnSend.TabIndex = 7;
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.BackColor = Color.FromArgb(128, 255, 255);
            lblText.Location = new Point(16, 13);
            lblText.Name = "lblText";
            lblText.Size = new Size(36, 20);
            lblText.TabIndex = 5;
            lblText.Text = "Text";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblUsersId);
            panel1.Controls.Add(pbProfile);
            panel1.Location = new Point(915, 36);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(102, 104);
            panel1.TabIndex = 11;
            // 
            // lblUsersId
            // 
            lblUsersId.Location = new Point(3, 64);
            lblUsersId.Name = "lblUsersId";
            lblUsersId.Size = new Size(96, 37);
            lblUsersId.TabIndex = 1;
            lblUsersId.Text = "Id";
            lblUsersId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbProfile
            // 
            pbProfile.BackgroundImage = Properties.Resources.profile2;
            pbProfile.Location = new Point(27, 11);
            pbProfile.Margin = new Padding(3, 4, 3, 4);
            pbProfile.Name = "pbProfile";
            pbProfile.Size = new Size(42, 37);
            pbProfile.TabIndex = 0;
            pbProfile.TabStop = false;
            pbProfile.Click += pbProfile_Click;
            // 
            // btnbackMain
            // 
            btnbackMain.BackgroundImage = Properties.Resources.backArrow;
            btnbackMain.Location = new Point(0, 36);
            btnbackMain.Margin = new Padding(3, 4, 3, 4);
            btnbackMain.Name = "btnbackMain";
            btnbackMain.Size = new Size(55, 31);
            btnbackMain.TabIndex = 12;
            btnbackMain.UseVisualStyleBackColor = true;
            // 
            // replyTimer
            // 
            replyTimer.Interval = 1000;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            BackgroundImage = Properties.Resources.back;
            ClientSize = new Size(1017, 659);
            Controls.Add(btnbackMain);
            Controls.Add(panel1);
            Controls.Add(panelMessage);
            Controls.Add(btnSearch);
            Controls.Add(lblSearch);
            Controls.Add(tbxSearch);
            Controls.Add(fopContact);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Main";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelMessage.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel fopContact;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem moreToolStripMenuItem;
        private ToolStripMenuItem aboutUsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TextBox tbxSearch;
        private Label lblSearch;
        private Button btnSearch;
        private Panel panelMessage;
        private FlowLayoutPanel floMsg;
        private ToolStripMenuItem signUpInToolStripMenuItem;
        private ToolStripMenuItem addUserToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private Button btnSend;
        private Label lblText;
        private PictureBox pbProfile;
        private Label lblUsersId;
        private RichTextBox rtbMessage;
        private Button btnbackMain;
        private System.Windows.Forms.Timer replyTimer;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}
