using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatting
{
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();
        }

        private void but_join_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(input_name.Text) || string.IsNullOrEmpty(input_serverAddress.Text))
            {
                MessageBox.Show("닉네임이나 서버 주소를 입력해주세요.");
            }
            else
            {
                Main main = new Main(input_name.Text, input_serverAddress.Text, false);
                main.Show();
                this.Hide();
            }
        }

        private void but_createRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(input_name.Text))
            {
                MessageBox.Show("닉네임을 입력해주세요.");
            }
            else
            {
                Main main = new Main(input_name.Text, input_serverAddress.Text, true);
                main.Show();
                this.Hide();
            }
        }
    }
}
