namespace Messenger
{
    partial class Admin
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
            lblATitle = new Label();
            tbxAdminUserSearch = new TextBox();
            btnAdminSearch = new Button();
            lblAdmibYUId = new Label();
            dgvHistory = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            Sender = new DataGridViewTextBoxColumn();
            Receiver = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            lblchat = new Label();
            btnAdminDelete = new Button();
            btnAdminUpdate = new Button();
            btnbackAddUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // lblATitle
            // 
            lblATitle.AutoSize = true;
            lblATitle.Font = new Font("Segoe UI", 25F);
            lblATitle.Location = new Point(333, 27);
            lblATitle.Name = "lblATitle";
            lblATitle.Size = new Size(118, 46);
            lblATitle.TabIndex = 0;
            lblATitle.Text = "Admin";
            // 
            // tbxAdminUserSearch
            // 
            tbxAdminUserSearch.Location = new Point(257, 107);
            tbxAdminUserSearch.Name = "tbxAdminUserSearch";
            tbxAdminUserSearch.Size = new Size(244, 23);
            tbxAdminUserSearch.TabIndex = 1;
            // 
            // btnAdminSearch
            // 
            btnAdminSearch.Location = new Point(525, 107);
            btnAdminSearch.Name = "btnAdminSearch";
            btnAdminSearch.Size = new Size(75, 23);
            btnAdminSearch.TabIndex = 2;
            btnAdminSearch.Text = "Search";
            btnAdminSearch.UseVisualStyleBackColor = true;
            btnAdminSearch.Click += btnAdminSearch_Click;
            // 
            // lblAdmibYUId
            // 
            lblAdmibYUId.AutoSize = true;
            lblAdmibYUId.Location = new Point(201, 111);
            lblAdmibYUId.Name = "lblAdmibYUId";
            lblAdmibYUId.Size = new Size(50, 15);
            lblAdmibYUId.TabIndex = 3;
            lblAdmibYUId.Text = "User ID: ";
            // 
            // dgvHistory
            // 
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { Date, Sender, Receiver, Message });
            dgvHistory.Location = new Point(155, 185);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.Size = new Size(542, 240);
            dgvHistory.TabIndex = 4;
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "Date";
            Date.Name = "Date";
            // 
            // Sender
            // 
            Sender.HeaderText = "Sender";
            Sender.Name = "Sender";
            // 
            // Receiver
            // 
            Receiver.HeaderText = "Receiver";
            Receiver.Name = "Receiver";
            // 
            // Message
            // 
            Message.HeaderText = "Message";
            Message.Name = "Message";
            Message.Width = 200;
            // 
            // lblchat
            // 
            lblchat.AutoSize = true;
            lblchat.Location = new Point(155, 156);
            lblchat.Name = "lblchat";
            lblchat.Size = new Size(73, 15);
            lblchat.TabIndex = 5;
            lblchat.Text = "Chat History";
            // 
            // btnAdminDelete
            // 
            btnAdminDelete.Location = new Point(692, 24);
            btnAdminDelete.Name = "btnAdminDelete";
            btnAdminDelete.Size = new Size(75, 23);
            btnAdminDelete.TabIndex = 6;
            btnAdminDelete.Text = "Delete";
            btnAdminDelete.UseVisualStyleBackColor = true;
            btnAdminDelete.Click += btnAdminDelete_Click;
            // 
            // btnAdminUpdate
            // 
            btnAdminUpdate.Location = new Point(692, 53);
            btnAdminUpdate.Name = "btnAdminUpdate";
            btnAdminUpdate.Size = new Size(75, 23);
            btnAdminUpdate.TabIndex = 6;
            btnAdminUpdate.Text = "Update";
            btnAdminUpdate.UseVisualStyleBackColor = true;
            btnAdminUpdate.Click += btnAdminUpdate_Click;
            // 
            // btnbackAddUser
            // 
            btnbackAddUser.BackgroundImage = Properties.Resources.backArrow;
            btnbackAddUser.Location = new Point(12, 12);
            btnbackAddUser.Name = "btnbackAddUser";
            btnbackAddUser.Size = new Size(48, 24);
            btnbackAddUser.TabIndex = 14;
            btnbackAddUser.UseVisualStyleBackColor = true;
            btnbackAddUser.Click += btnbackAddUser_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.admin;
            ClientSize = new Size(800, 450);
            Controls.Add(btnbackAddUser);
            Controls.Add(btnAdminUpdate);
            Controls.Add(btnAdminDelete);
            Controls.Add(lblchat);
            Controls.Add(dgvHistory);
            Controls.Add(lblAdmibYUId);
            Controls.Add(btnAdminSearch);
            Controls.Add(tbxAdminUserSearch);
            Controls.Add(lblATitle);
            Name = "Admin";
            Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblATitle;
        private TextBox tbxAdminUserSearch;
        private Button btnAdminSearch;
        private Label lblAdmibYUId;
        private DataGridView dgvHistory;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Sender;
        private DataGridViewTextBoxColumn Receiver;
        private DataGridViewTextBoxColumn Message;
        private Label lblchat;
        private Button btnAdminDelete;
        private Button btnAdminUpdate;
        private Button btnbackAddUser;
    }
}