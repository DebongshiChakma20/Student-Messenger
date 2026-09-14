namespace Messenger
{
    partial class AdminDelete
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
            tbxDeleteAdmin = new TextBox();
            label1 = new Label();
            btnFinalAdminDelete = new Button();
            lblAUser = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // tbxDeleteAdmin
            // 
            tbxDeleteAdmin.Location = new Point(264, 106);
            tbxDeleteAdmin.Name = "tbxDeleteAdmin";
            tbxDeleteAdmin.Size = new Size(233, 23);
            tbxDeleteAdmin.TabIndex = 0;
            tbxDeleteAdmin.TextChanged += tbxDeleteAdmin_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(208, 109);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "User ID: ";
            // 
            // btnFinalAdminDelete
            // 
            btnFinalAdminDelete.Location = new Point(515, 106);
            btnFinalAdminDelete.Name = "btnFinalAdminDelete";
            btnFinalAdminDelete.Size = new Size(75, 23);
            btnFinalAdminDelete.TabIndex = 2;
            btnFinalAdminDelete.Text = "Delete";
            btnFinalAdminDelete.UseVisualStyleBackColor = true;
            btnFinalAdminDelete.Click += btnFinalAdminDelete_Click;
            // 
            // lblAUser
            // 
            lblAUser.BorderStyle = BorderStyle.Fixed3D;
            lblAUser.FlatStyle = FlatStyle.Flat;
            lblAUser.Font = new Font("Segoe UI", 12F);
            lblAUser.Location = new Point(219, 213);
            lblAUser.Name = "lblAUser";
            lblAUser.Size = new Size(385, 184);
            lblAUser.TabIndex = 3;
            lblAUser.Text = "Info";
            lblAUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 180);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 4;
            label2.Text = "User Information";
            // 
            // AdminDelete
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(lblAUser);
            Controls.Add(btnFinalAdminDelete);
            Controls.Add(label1);
            Controls.Add(tbxDeleteAdmin);
            Name = "AdminDelete";
            Text = "Admin Delete";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxDeleteAdmin;
        private Label label1;
        private Button btnFinalAdminDelete;
        private Label lblAUser;
        private Label label2;
    }
}