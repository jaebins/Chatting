using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chatting
{
    public struct ReceiveFileInfor
    {
        public string fileName;
        public MemoryStream ms;
    }

    public partial class Main : Form
    {
        UsersList usersListForm = new UsersList();

        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<ReceiveFileInfor> filesMs = new List<ReceiveFileInfor>();

        List<string> userList = new List<string>();
        int myNumber;
        string myName;
        string sendFilePath;
        bool isFileMode;

        public Main(string myName, string serverAddress, bool isServerHost)
        {
            usersListForm.StartPosition = FormStartPosition.Manual;
            usersListForm.Location = new Point(this.Location.X + this.Size.Width - 15, this.Location.Y);
            usersListForm.Show();

            this.myName = myName;

            if (isServerHost)
            {
                Server server = new Server();
                Thread serverThread = new Thread(server.CreateServer);
                serverThread.IsBackground = true;
                serverThread.Start();

                serverAddress = getLocalIPAddress();
            }

            try
            {
                byte[] buffer = new byte[1024];
                IPEndPoint ipt = new IPEndPoint(IPAddress.Parse(serverAddress), Rule.port);
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(ipt);

                clientSocket.Receive(buffer);
                myNumber = Int32.Parse(Encoding.UTF8.GetString(buffer));
                buffer = Encoding.UTF8.GetBytes(myName);
                clientSocket.Send(buffer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
            }

            Thread receiveHandler = new Thread(ReceiveMsg);
            receiveHandler.IsBackground = true;
            receiveHandler.Start();

            //MessageBox.Show($"연결 완료 : {serverAddress}:{Rule.port}");

            InitializeComponent();
        }

        void SendMsg(string msg)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);

            input_desc.Text = "";
        }

        void ReceiveMsg()
        {
            try
            {
                string msg = string.Empty;
                byte[] buffer = new byte[1024];
                while (true)
                {
                    if (!isFileMode)
                    {
                        clientSocket.Receive(buffer);
                        msg = Encoding.UTF8.GetString(buffer);

                        if (msg.Contains("$usersSend$"))
                        {
                            msg = msg.Substring(14, msg.Length - 14);
                            invokeControl_inputText(panel_chat, msg + Environment.NewLine);
                        }
                        else if (msg.Contains("$flag(userJoin)$"))
                        {
                            myNumber = 0;
                            msg = msg.Substring(19, msg.Length - 19);
                            string[] users = msg.Split('※');
                            foreach (string userName in users)
                            {
                                userList.Add(msg);
                                invokeControl_inputText(usersListForm.Panel_UserList, msg + " ");
                            }
                        }
                        else if (msg.Contains("$flag(fileMode)$"))
                        {
                            isFileMode = true;
                            msg = msg.Substring(19, msg.Length - 19);
                            string fileSender = msg.Split(':')[0];
                            string fileName = msg.Split(':')[1];
                            string fileNameLen = msg.Split(':')[2];
                            if (Int32.Parse(fileSender) == myNumber)
                            {
                                Thread sendFileThread = new Thread(SendFile);
                                sendFileThread.IsBackground = true;
                                sendFileThread.Start();
                            }

                            Thread receiveFileThread = new Thread(() => ReceiveFile(fileName, Int32.Parse(fileNameLen)));
                            receiveFileThread.IsBackground = true;
                            receiveFileThread.Start();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
            }
        }

        void SendFile()
        {
            byte[] buffer = new byte[1024];
            using (FileStream fs = new FileStream(sendFilePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (buffer.Length > 0)
                    {
                        Thread.Sleep(500);
                        buffer = br.ReadBytes(1024);
                        clientSocket.Send(buffer, 0, buffer.Length, 0);
                    }
                }
            }
            Console.WriteLine("보내는거끝");
            string msg = "fileSendEnd";
            buffer = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(buffer, 0, buffer.Length, 0);
        }

        void ReceiveFile(string receiveFileName, int fileNameLen)
        {
            byte[] buffer = new byte[1024];
            string saveFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{receiveFileName}";
            try
            {
                MemoryStream receiveMs = new MemoryStream();
                int mount = 0;
                while (true)
                {
                    int len = clientSocket.Receive(buffer);
                    if (Encoding.UTF8.GetString(buffer).Contains("fileSendEnd"))
                    {
                        break;
                    }
                    mount += len;
                    Console.WriteLine("클라이언트에서 받음 : " + len);
                    Console.WriteLine("총합 : " + mount);
                    receiveMs.Write(buffer, 0, len);
                }
                
                receiveFileName = receiveFileName.Substring(0, fileNameLen);
                ReceiveFileInfor receiveFileInfor = new ReceiveFileInfor
                {
                    fileName = receiveFileName,
                    ms = receiveMs
                };
                filesMs.Add(receiveFileInfor);

                Console.WriteLine("클라이언트 끝");
                isFileMode = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public static string getLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        void invokeControl_inputText(TextBox input, string msg)
        {
            if (input.InvokeRequired)
            {
                input.Invoke(new MethodInvoker(delegate
                {
                    input.AppendText(msg);
                }));
            }
            else
                input.AppendText(msg);
        }

        private void but_send_Click(object sender, EventArgs e)
        {
            SendMsg($"$usersSend$ - {myName} : {input_desc.Text}");
        }

        private void panel_chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMsg($"$usersSend$ - {myName} : {input_desc.Text}");
            }
        }

        private void but_FileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sendFilePath = ofd.FileName;
                SendMsg($"$flag(fileMode)$ - {myNumber}:{ofd.SafeFileName}:{ofd.SafeFileName.Length}");
            }
        }

        private void Main_LocationChanged(object sender, EventArgs e)
        {
            usersListForm.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msg = $"$flag(exit)$ - {myNumber}";
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            clientSocket.Send(buffer);

            Application.Exit();
        }

        private void fileListtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileList fileList = new FileList();

            Point imgSize = new Point(50, 50);
            Point nowImgPos = new Point(0, 0);

            foreach (ReceiveFileInfor receiveFileInfor in filesMs)
            {
                Bitmap _ = new Bitmap(receiveFileInfor.ms);
                Bitmap bitmap = new Bitmap(_, new Size(imgSize));

                Button image = new Button
                {
                    Text = "",
                    Image = bitmap,
                    Size = new Size(imgSize),
                    Location = nowImgPos
                };
                image.Click += (sender2, e2) => image_Click(receiveFileInfor);
                fileList.Controls.Add(image);

                nowImgPos.X += 60;
                if (nowImgPos.X >= 480)
                {
                    nowImgPos.X = 0;
                    nowImgPos.Y += 60;
                }
            }
            fileList.Show();
        }

        private void image_Click(ReceiveFileInfor receiveFileInfor)
        {
            Console.WriteLine("클릭");
            string saveFilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{receiveFileInfor.fileName}";
            FileStream fs = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write);
            fs.Close();
            File.WriteAllBytes(saveFilePath, receiveFileInfor.ms.ToArray());
            MessageBox.Show("파일 다운로드 완료");
        }
    }
}
