namespace Messenger
{
    partial class signUpForm
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
            signUpPanel2 = new Panel();
            btSignUp = new Button();
            tbxPasswordSU = new TextBox();
            tbxNameSU = new TextBox();
            tbxUserIdSU = new TextBox();
            lblPassSU = new Label();
            lblNameSU = new Label();
            lblUserIdSU = new Label();
            btnbackSignUp = new Button();
            signUpPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // signUpPanel2
            // 
            signUpPanel2.Controls.Add(btSignUp);
            signUpPanel2.Controls.Add(tbxPasswordSU);
            signUpPanel2.Controls.Add(tbxNameSU);
            signUpPanel2.Controls.Add(tbxUserIdSU);
            signUpPanel2.Controls.Add(lblPassSU);
            signUpPanel2.Controls.Add(lblNameSU);
            signUpPanel2.Controls.Add(lblUserIdSU);
            signUpPanel2.Location = new Point(211, 82);
            signUpPanel2.Name = "signUpPanel2";
            signUpPanel2.Size = new Size(425, 266);
            signUpPanel2.TabIndex = 0;
            // 
            // btSignUp
            // 
            btSignUp.Font = new Font("Segoe UI", 12F);
            btSignUp.Location = new Point(150, 199);
            btSignUp.Name = "btSignUp";
            btSignUp.Size = new Size(133, 46);
            btSignUp.TabIndex = 11;
            btSignUp.Text = "Sign up";
            btSignUp.UseVisualStyleBackColor = true;
            btSignUp.Click += btSignUp_Click;
            // 
            // tbxPasswordSU
            // 
            tbxPasswordSU.Location = new Point(130, 144);
            tbxPasswordSU.Name = "tbxPasswordSU";
            tbxPasswordSU.PasswordChar = '*';
            tbxPasswordSU.Size = new Size(235, 23);
            tbxPasswordSU.TabIndex = 8;
            // 
            // tbxNameSU
            // 
            tbxNameSU.Location = new Point(130, 95);
            tbxNameSU.Name = "tbxNameSU";
            tbxNameSU.Size = new Size(235, 23);
            tbxNameSU.TabIndex = 9;
            // 
            // tbxUserIdSU
            // 
            tbxUserIdSU.Location = new Point(130, 46);
            tbxUserIdSU.Name = "tbxUserIdSU";
            tbxUserIdSU.Size = new Size(235, 23);
            tbxUserIdSU.TabIndex = 10;
            // 
            // lblPassSU
            // 
            lblPassSU.AutoSize = true;
            lblPassSU.Font = new Font("Segoe UI", 12F);
            lblPassSU.ForeColor = Color.White;
            lblPassSU.Location = new Point(45, 142);
            lblPassSU.Name = "lblPassSU";
            lblPassSU.Size = new Size(79, 21);
            lblPassSU.TabIndex = 7;
            lblPassSU.Text = "Password:";
            // 
            // lblNameSU
            // 
            lblNameSU.AutoSize = true;
            lblNameSU.Font = new Font("Segoe UI", 12F);
            lblNameSU.ForeColor = Color.White;
            lblNameSU.Location = new Point(62, 93);
            lblNameSU.Name = "lblNameSU";
            lblNameSU.Size = new Size(55, 21);
            lblNameSU.TabIndex = 6;
            lblNameSU.Text = "Name:";
            // 
            // lblUserIdSU
            // 
            lblUserIdSU.AutoSize = true;
            lblUserIdSU.Font = new Font("Segoe UI", 12F);
            lblUserIdSU.ForeColor = Color.Transparent;
            lblUserIdSU.Location = new Point(62, 44);
            lblUserIdSU.Name = "lblUserIdSU";
            lblUserIdSU.Size = new Size(62, 21);
            lblUserIdSU.TabIndex = 5;
            lblUserIdSU.Text = "User Id:";
            // 
            // btnbackSignUp
            // 
            btnbackSignUp.BackgroundImage = Properties.Resources.backArrow;
            btnbackSignUp.Location = new Point(12, 3);
            btnbackSignUp.Name = "btnbackSignUp";
            btnbackSignUp.Size = new Size(48, 20);
            btnbackSignUp.TabIndex = 13;
            btnbackSignUp.UseVisualStyleBackColor = true;
            btnbackSignUp.Click += btnbackSignUp_Click;
            // 
            // signUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.signUpBack;
            ClientSize = new Size(881, 418);
            Controls.Add(btnbackSignUp);
            Controls.Add(signUpPanel2);
            Name = "signUpForm";
            Text = "Sign up";
            FormClosing += signUpForm_FormClosing;
            signUpPanel2.ResumeLayout(false);
            signUpPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel signUpPanel2;
        private Button btSignUp;
        private TextBox tbxPasswordSU;
        private TextBox tbxNameSU;
        private TextBox tbxUserIdSU;
        private Label lblPassSU;
        private Label lblNameSU;
        private Label lblUserIdSU;
        private Button btnbackSignUp;
    }
}