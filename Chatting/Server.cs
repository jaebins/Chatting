using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatting
{
    public struct UsersInfor{
        public Socket socket { set; get; }
        public int num;
        public string name;
    } 

    internal class Server
    {
        Socket server;

        bool isFileMode;
        int userCount = 0;
        List<UsersInfor> usersInfors = new List<UsersInfor>();

        public void CreateServer()
        {
            IPEndPoint ipt = new IPEndPoint(IPAddress.Any, Rule.port);
            using (server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                server.Bind(ipt);
                server.Listen(20);
                Console.WriteLine($"Server Start! Listen port {ipt.Port}...");
                using (Socket client = server.Accept())
                {
                    string msg = userCount.ToString();
                    byte[] buffer = Encoding.UTF8.GetBytes(msg);
                    client.Send(buffer);
                    buffer = new byte[1024];
                    client.Receive(buffer);

                    UsersInfor usersInfor = new UsersInfor();
                    usersInfor.socket = client;
                    usersInfor.name = Encoding.UTF8.GetString(buffer);
                    usersInfor.num = userCount;
                    usersInfors.Add(usersInfor);
                    
                    SendUserList(msg, buffer);
                    userCount++;

                    try
                    {
                        while (true)
                        {
                            if (!isFileMode)
                            {
                                msg = string.Empty;
                                buffer = new byte[1024];
                                client.Receive(buffer);
                                msg = Encoding.UTF8.GetString(buffer);
                                if (msg.Contains("$usersSend$"))
                                {
                                    SendMessage(buffer);
                                }
                                else if (msg.Contains("$flag(exit)$"))
                                {
                                    msg = msg.Substring(12, msg.Length - 12);
                                    usersInfor = new UsersInfor();
                                    foreach(UsersInfor findUser in usersInfors)
                                    {
                                        if(findUser.num == Int32.Parse(msg))
                                        {
                                            usersInfor = findUser;
                                            break;
                                        } 
                                    }
                                    usersInfors.Remove(usersInfor);
                                    SendUserList(msg, buffer);
                                }
                                else if (msg.Contains("$flag(fileMode)$"))
                                {
                                    SendMessage(buffer);
                               
                                    msg = msg.Substring(19, msg.Length - 19);
                                    string fileSender = msg.Split(':')[0];
                                    string fileName = msg.Split(':')[1];
                                    isFileMode = true;

                                    Thread sendFileThread = new Thread(() => SendFile(fileSender));
                                    sendFileThread.IsBackground = true;
                                    sendFileThread.Start();
                                }
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                        Application.Exit();
                    }
                }
            }
        }

        void SendMessage(byte[] buffer)
        {
            foreach (UsersInfor users in usersInfors)
            {
                users.socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
        }

        void SendUserList(string msg, byte[] buffer)
        {
            msg = $"$flag(userJoin)$ - ";
            foreach (UsersInfor users in usersInfors)
            {
                msg += users.name + "※";
            }
            buffer = Encoding.UTF8.GetBytes(msg);
            SendMessage(buffer);
        }

        void SendFile(string fileSenderNum)
        {
            byte[] buffer = new byte[1024];
            foreach (UsersInfor users in usersInfors)
            {
                if (users.num == Int32.Parse(fileSenderNum))
                {
                    Socket senderClientSocket = users.socket;

                    while (true)
                    {
                        Console.WriteLine("대기중");
                        int len = senderClientSocket.Receive(buffer);
                        Console.WriteLine("서버에서 버퍼를 받음 : " + len);
                        foreach (UsersInfor users2 in usersInfors)
                        {
                            users2.socket.Send(buffer, 0, len, 0);
                        }
                        Console.WriteLine("서버에서 버퍼를 보냄");

                        if (Encoding.UTF8.GetString(buffer).Contains("fileSendEnd"))
                        {
                            break;
                        }
                    }

                    Console.WriteLine("서버 파일 전송 끝");
                    isFileMode = false;
                    break;
                }
            }
        }
    }
}
