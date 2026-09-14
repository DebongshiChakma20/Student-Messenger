namespace Messenger
{
    partial class logForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userPanel = new Panel();
            linkLabelSI = new LinkLabel();
            btnSignIn = new Button();
            tbxPass = new TextBox();
            tbxUserId = new TextBox();
            lblPass = new Label();
            lblName = new Label();
            btnbackSignIn = new Button();
            userPanel.SuspendLayout();
            SuspendLayout();
            // 
            // userPanel
            // 
            userPanel.Controls.Add(linkLabelSI);
            userPanel.Controls.Add(btnSignIn);
            userPanel.Controls.Add(tbxPass);
            userPanel.Controls.Add(tbxUserId);
            userPanel.Controls.Add(lblPass);
            userPanel.Controls.Add(lblName);
            userPanel.Location = new Point(288, 174);
            userPanel.Name = "userPanel";
            userPanel.Size = new Size(484, 303);
            userPanel.TabIndex = 0;
            // 
            // linkLabelSI
            // 
            linkLabelSI.AutoSize = true;
            linkLabelSI.Location = new Point(181, 256);
            linkLabelSI.Margin = new Padding(4, 0, 4, 0);
            linkLabelSI.Name = "linkLabelSI";
            linkLabelSI.Size = new Size(151, 21);
            linkLabelSI.TabIndex = 9;
            linkLabelSI.TabStop = true;
            linkLabelSI.Text = "Click here to sign up";
            linkLabelSI.LinkClicked += linkLabelSI_LinkClicked;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(192, 193);
            btnSignIn.Margin = new Padding(4);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(129, 49);
            btnSignIn.TabIndex = 8;
            btnSignIn.Text = "Sign in";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // tbxPass
            // 
            tbxPass.Location = new Point(122, 139);
            tbxPass.Margin = new Padding(4);
            tbxPass.Name = "tbxPass";
            tbxPass.PasswordChar = '*';
            tbxPass.Size = new Size(298, 29);
            tbxPass.TabIndex = 6;
            // 
            // tbxUserId
            // 
            tbxUserId.Location = new Point(122, 76);
            tbxUserId.Margin = new Padding(4);
            tbxUserId.Name = "tbxUserId";
            tbxUserId.Size = new Size(298, 29);
            tbxUserId.TabIndex = 7;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 12F);
            lblPass.ForeColor = Color.White;
            lblPass.Location = new Point(25, 142);
            lblPass.Margin = new Padding(4, 0, 4, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(79, 21);
            lblPass.TabIndex = 4;
            lblPass.Text = "Password:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(42, 79);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(62, 21);
            lblName.TabIndex = 5;
            lblName.Text = "User Id:";
            // 
            // btnbackSignIn
            // 
            btnbackSignIn.BackgroundImage = Properties.Resources.backArrow;
            btnbackSignIn.Location = new Point(12, 12);
            btnbackSignIn.Name = "btnbackSignIn";
            btnbackSignIn.Size = new Size(48, 27);
            btnbackSignIn.TabIndex = 13;
            btnbackSignIn.UseVisualStyleBackColor = true;
            btnbackSignIn.Click += btnbackSignIn_Click;
            // 
            // logForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.signinpanel;
            ClientSize = new Size(1029, 630);
            Controls.Add(btnbackSignIn);
            Controls.Add(userPanel);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "logForm";
            Text = "Sign in or up";
            FormClosing += logForm_FormClosing;
            userPanel.ResumeLayout(false);
            userPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel userPanel;
        private LinkLabel linkLabelSI;
        private Button btnSignIn;
        private TextBox tbxPass;
        private TextBox tbxUserId;
        private Label lblPass;
        private Label lblName;
        private Button btnbackSignIn;
    }
}