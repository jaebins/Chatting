namespace Chatting
{
    partial class UsersList
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
            this.Panel_UserList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Panel_UserList
            // 
            this.Panel_UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_UserList.Location = new System.Drawing.Point(0, 0);
            this.Panel_UserList.Multiline = true;
            this.Panel_UserList.Name = "Panel_UserList";
            this.Panel_UserList.ReadOnly = true;
            this.Panel_UserList.Size = new System.Drawing.Size(298, 147);
            this.Panel_UserList.TabIndex = 0;
            this.Panel_UserList.Text = "유저목록\r\n\r\n";
            // 
            // UsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 147);
            this.Controls.Add(this.Panel_UserList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsersList";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Panel_UserList;
    }
}