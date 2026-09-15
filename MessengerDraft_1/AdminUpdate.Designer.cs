namespace Messenger
{
    partial class AdminUpdate
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
            label1 = new Label();
            tbxUpdateSearch = new TextBox();
            btnAdminUpdateSearch = new Button();
            flpAdminSearch = new FlowLayoutPanel();
            updatePanel = new Panel();
            btnFinalAdminUpdate = new Button();
            tbxPassUpdate = new TextBox();
            tbxIdUpdate = new TextBox();
            tbxNameUpdate = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            updatePanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(181, 48);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "User ID: ";
            // 
            // tbxUpdateSearch
            // 
            tbxUpdateSearch.Location = new Point(237, 45);
            tbxUpdateSearch.Name = "tbxUpdateSearch";
            tbxUpdateSearch.Size = new Size(269, 23);
            tbxUpdateSearch.TabIndex = 1;
            // 
            // btnAdminUpdateSearch
            // 
            btnAdminUpdateSearch.Location = new Point(528, 45);
            btnAdminUpdateSearch.Name = "btnAdminUpdateSearch";
            btnAdminUpdateSearch.Size = new Size(75, 23);
            btnAdminUpdateSearch.TabIndex = 2;
            btnAdminUpdateSearch.Text = "Search";
            btnAdminUpdateSearch.UseVisualStyleBackColor = true;
            btnAdminUpdateSearch.Click += btnAdminUpdateSearch_Click;
            // 
            // flpAdminSearch
            // 
            flpAdminSearch.BackColor = Color.Gainsboro;
            flpAdminSearch.Location = new Point(181, 91);
            flpAdminSearch.Name = "flpAdminSearch";
            flpAdminSearch.Size = new Size(422, 100);
            flpAdminSearch.TabIndex = 3;
            // 
            // updatePanel
            // 
            updatePanel.BackColor = Color.Transparent;
            updatePanel.Controls.Add(btnFinalAdminUpdate);
            updatePanel.Controls.Add(tbxPassUpdate);
            updatePanel.Controls.Add(tbxIdUpdate);
            updatePanel.Controls.Add(tbxNameUpdate);
            updatePanel.Controls.Add(label4);
            updatePanel.Controls.Add(label2);
            updatePanel.Controls.Add(label3);
            updatePanel.Location = new Point(151, 216);
            updatePanel.Name = "updatePanel";
            updatePanel.Size = new Size(490, 184);
            updatePanel.TabIndex = 5;
            updatePanel.Visible = false;
            // 
            // btnFinalAdminUpdate
            // 
            btnFinalAdminUpdate.Location = new Point(224, 140);
            btnFinalAdminUpdate.Name = "btnFinalAdminUpdate";
            btnFinalAdminUpdate.Size = new Size(84, 32);
            btnFinalAdminUpdate.TabIndex = 12;
            btnFinalAdminUpdate.Text = "Update";
            btnFinalAdminUpdate.UseVisualStyleBackColor = true;
            btnFinalAdminUpdate.Click += btnFinalAdminUpdate_Click;
            // 
            // tbxPassUpdate
            // 
            tbxPassUpdate.Location = new Point(167, 85);
            tbxPassUpdate.Name = "tbxPassUpdate";
            tbxPassUpdate.Size = new Size(241, 23);
            tbxPassUpdate.TabIndex = 9;
            // 
            // tbxIdUpdate
            // 
            tbxIdUpdate.Location = new Point(167, 50);
            tbxIdUpdate.Name = "tbxIdUpdate";
            tbxIdUpdate.Size = new Size(241, 23);
            tbxIdUpdate.TabIndex = 10;
            // 
            // tbxNameUpdate
            // 
            tbxNameUpdate.Location = new Point(167, 13);
            tbxNameUpdate.Name = "tbxNameUpdate";
            tbxNameUpdate.Size = new Size(241, 23);
            tbxNameUpdate.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 88);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 6;
            label4.Text = "Password: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 53);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 7;
            label2.Text = "ID: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 13);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 8;
            label3.Text = "Name: ";
            // 
            // AdminUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.twoo;
            ClientSize = new Size(800, 450);
            Controls.Add(updatePanel);
            Controls.Add(flpAdminSearch);
            Controls.Add(btnAdminUpdateSearch);
            Controls.Add(tbxUpdateSearch);
            Controls.Add(label1);
            Name = "AdminUpdate";
            Text = "AdminUpdate";
            updatePanel.ResumeLayout(false);
            updatePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbxUpdateSearch;
        private Button btnAdminUpdateSearch;
        private FlowLayoutPanel flpAdminSearch;
        private Panel updatePanel;
        private Button btnFinalAdminUpdate;
        private TextBox tbxPassUpdate;
        private TextBox tbxIdUpdate;
        private TextBox tbxNameUpdate;
        private Label label4;
        private Label label2;
        private Label label3;
    }
}