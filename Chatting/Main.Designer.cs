namespace Chatting
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.panel_chat = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileListtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.input_desc = new System.Windows.Forms.TextBox();
            this.but_send = new System.Windows.Forms.Button();
            this.but_FileSelect = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_chat
            // 
            this.panel_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.panel_chat.ContextMenuStrip = this.contextMenuStrip1;
            this.panel_chat.Font = new System.Drawing.Font("돋움", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel_chat.Location = new System.Drawing.Point(0, 0);
            this.panel_chat.Multiline = true;
            this.panel_chat.Name = "panel_chat";
            this.panel_chat.ReadOnly = true;
            this.panel_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.panel_chat.Size = new System.Drawing.Size(385, 535);
            this.panel_chat.TabIndex = 0;
            this.panel_chat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.panel_chat_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileListtoolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // fileListtoolStripMenuItem1
            // 
            this.fileListtoolStripMenuItem1.Name = "fileListtoolStripMenuItem1";
            this.fileListtoolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.fileListtoolStripMenuItem1.Text = "파일 목록";
            this.fileListtoolStripMenuItem1.Click += new System.EventHandler(this.fileListtoolStripMenuItem1_Click);
            // 
            // input_desc
            // 
            this.input_desc.Font = new System.Drawing.Font("굴림", 11F);
            this.input_desc.Location = new System.Drawing.Point(25, 535);
            this.input_desc.Name = "input_desc";
            this.input_desc.Size = new System.Drawing.Size(295, 24);
            this.input_desc.TabIndex = 1;
            // 
            // but_send
            // 
            this.but_send.Location = new System.Drawing.Point(320, 535);
            this.but_send.Name = "but_send";
            this.but_send.Size = new System.Drawing.Size(65, 25);
            this.but_send.TabIndex = 2;
            this.but_send.Text = "전송";
            this.but_send.UseVisualStyleBackColor = true;
            this.but_send.Click += new System.EventHandler(this.but_send_Click);
            // 
            // but_FileSelect
            // 
            this.but_FileSelect.Location = new System.Drawing.Point(0, 535);
            this.but_FileSelect.Name = "but_FileSelect";
            this.but_FileSelect.Size = new System.Drawing.Size(25, 25);
            this.but_FileSelect.TabIndex = 4;
            this.but_FileSelect.Text = "F";
            this.but_FileSelect.UseVisualStyleBackColor = true;
            this.but_FileSelect.Click += new System.EventHandler(this.but_FileSelect_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.but_FileSelect);
            this.Controls.Add(this.but_send);
            this.Controls.Add(this.input_desc);
            this.Controls.Add(this.panel_chat);
            this.Name = "Main";
            this.Text = "채팅";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox panel_chat;
        private System.Windows.Forms.TextBox input_desc;
        private System.Windows.Forms.Button but_send;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileListtoolStripMenuItem1;
        private System.Windows.Forms.Button but_FileSelect;
    }
}