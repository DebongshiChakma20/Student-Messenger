namespace Messenger
{
    partial class addUserForm
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
            floSearch = new FlowLayoutPanel();
            searchPanel = new Panel();
            btnAddUserSearch = new Button();
            lblSearch = new Label();
            tbxSearch = new TextBox();
            btnbackAddUser = new Button();
            searchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // floSearch
            // 
            floSearch.BackgroundImage = Properties.Resources.addPanelBAck;
            floSearch.Location = new Point(1, 105);
            floSearch.Name = "floSearch";
            floSearch.Size = new Size(786, 306);
            floSearch.TabIndex = 0;
            // 
            // searchPanel
            // 
            searchPanel.Controls.Add(btnAddUserSearch);
            searchPanel.Controls.Add(lblSearch);
            searchPanel.Controls.Add(tbxSearch);
            searchPanel.Location = new Point(126, 12);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(489, 60);
            searchPanel.TabIndex = 4;
            // 
            // btnAddUserSearch
            // 
            btnAddUserSearch.Font = new Font("Segoe UI", 10F);
            btnAddUserSearch.Location = new Point(375, 14);
            btnAddUserSearch.Name = "btnAddUserSearch";
            btnAddUserSearch.Size = new Size(75, 33);
            btnAddUserSearch.TabIndex = 6;
            btnAddUserSearch.Text = "Search";
            btnAddUserSearch.UseVisualStyleBackColor = true;
            btnAddUserSearch.Click += btnAddUserSearch_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 12F);
            lblSearch.Location = new Point(39, 19);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(60, 21);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Search:";
            // 
            // tbxSearch
            // 
            tbxSearch.Location = new Point(105, 17);
            tbxSearch.Name = "tbxSearch";
            tbxSearch.Size = new Size(264, 23);
            tbxSearch.TabIndex = 4;
            // 
            // btnbackAddUser
            // 
            btnbackAddUser.BackgroundImage = Properties.Resources.backArrow;
            btnbackAddUser.Location = new Point(12, 12);
            btnbackAddUser.Name = "btnbackAddUser";
            btnbackAddUser.Size = new Size(48, 24);
            btnbackAddUser.TabIndex = 13;
            btnbackAddUser.UseVisualStyleBackColor = true;
            btnbackAddUser.Click += btnbackAddUser_Click;
            // 
            // addUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.addPanel;
            ClientSize = new Size(788, 450);
            Controls.Add(btnbackAddUser);
            Controls.Add(searchPanel);
            Controls.Add(floSearch);
            Name = "addUserForm";
            Text = "Add User";
            FormClosing += addUserForm_FormClosing;
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel floSearch;
        private Panel panel1;
        private Button btnAddUserSearch;
        private Label lblSearch;
        private TextBox tbxSearch;
        private Button btnbackAddUser;
        private Panel searchPanel;
    }
}