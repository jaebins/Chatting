namespace Chatting
{
    partial class Lobby
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.input_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.but_join = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.input_serverAddress = new System.Windows.Forms.TextBox();
            this.but_createRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input_name
            // 
            this.input_name.Location = new System.Drawing.Point(165, 26);
            this.input_name.Name = "input_name";
            this.input_name.Size = new System.Drawing.Size(120, 21);
            this.input_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(100, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "닉네임 :";
            // 
            // but_join
            // 
            this.but_join.Location = new System.Drawing.Point(210, 99);
            this.but_join.Name = "but_join";
            this.but_join.Size = new System.Drawing.Size(75, 23);
            this.but_join.TabIndex = 2;
            this.but_join.Text = "입장";
            this.but_join.UseVisualStyleBackColor = true;
            this.but_join.Click += new System.EventHandler(this.but_join_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(85, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "서버주소 :";
            // 
            // input_serverAddress
            // 
            this.input_serverAddress.Location = new System.Drawing.Point(165, 63);
            this.input_serverAddress.Name = "input_serverAddress";
            this.input_serverAddress.Size = new System.Drawing.Size(120, 21);
            this.input_serverAddress.TabIndex = 3;
            // 
            // but_createRoom
            // 
            this.but_createRoom.Location = new System.Drawing.Point(88, 99);
            this.but_createRoom.Name = "but_createRoom";
            this.but_createRoom.Size = new System.Drawing.Size(75, 23);
            this.but_createRoom.TabIndex = 5;
            this.but_createRoom.Text = "생성";
            this.but_createRoom.UseVisualStyleBackColor = true;
            this.but_createRoom.Click += new System.EventHandler(this.but_createRoom_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.but_createRoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.input_serverAddress);
            this.Controls.Add(this.but_join);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_name);
            this.Name = "Lobby";
            this.Text = "로비";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_join;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input_serverAddress;
        private System.Windows.Forms.Button but_createRoom;
    }
}

