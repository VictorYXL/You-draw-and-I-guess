using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;
using System.Drawing;
using System.Drawing.Imaging;
namespace Server
{

    class Server
    {
        private ClientList cl;
        private Socket server;
        Byte[] buffer;
        IPAddress ip;
        IPEndPoint ipe;
        Thread thread;
        int port;
        public Server()
        {
            cl = new ClientList();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ip = IPAddress.Any;
            port = 0425;
            ipe = new IPEndPoint(ip, port);
            server.Bind(ipe);
            server.Listen(10);
            buffer = new Byte[1184060];
            thread = new Thread(Listen);
            Console.WriteLine("服务器已经开启...");
            thread.Start();
        }
        private void Listen()
        {
            while (true)
            {
                Socket newClient = server.Accept();
                newClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), newClient);
                if (cl.FirstClient(newClient)==-1)
                    Console.WriteLine(newClient.RemoteEndPoint.ToString() + "尝试连接失败");
                else Console.WriteLine(newClient.RemoteEndPoint.ToString() + "连接成功");
            }
        }
        public void ReceiveCallBack(IAsyncResult AR)
        {
            Socket client = (Socket)AR.AsyncState;
            int l = buffer[0], index;
            //Console.Write(l);
            String type="";
            try
            {
                if (l >= 2)
                    type = Encoding.Default.GetString(buffer, 1, 2);
                    
                else
                {
                    Console.WriteLine("收到不能解析的消息 IP:" + client.RemoteEndPoint.ToString());
                    return;
                }

                String rest = Encoding.Default.GetString(buffer, 3, l - 2);
                index = cl.FindClient(client);
                if (index < 0 || index > cl.count())
                {
                    return;
                }
                switch (type)
                {
                    case "CD":
                    case "CG":
                        String name = Encoding.Default.GetString(buffer, 3, l - 2);
                        if (cl.Login(index, name, type))
                            Console.WriteLine("玩家 " + name + " (IP:" + cl.GetClient(index).RemoteEndPoint.ToString() + " 身份:" + (type=="CD"? " 画图者":"猜图者") + ") 登陆成功");
                        else
                        {
                            Console.WriteLine("玩家 " + name + "尝试登陆失败");
                            return;
                        }
                        int r = cl.Connect(index);
                        if (r >= 0)
                        {
                            Console.WriteLine("玩家 " + cl.GetName(index) + " 与玩家 " + cl.GetName(r) + "开始游戏");
                            BSend("OK", Encoding.Default.GetBytes(cl.GetOppositeName(index)), cl.GetClient(index));
                            BSend("OK", Encoding.Default.GetBytes(cl.GetName(index)), cl.GetOppositeClient(index));
                            if (cl.GetType(index)=="CG")
                                Directory.CreateDirectory(cl.GetName(index) + "VS" + cl.GetOppositeName(index));
                            else Directory.CreateDirectory(cl.GetOppositeName(index) + "VS" + cl.GetName(index));
                       }
                        break;
                    case "DI":
                        if (cl.GetName(index) == null)
                        {
                            Console.WriteLine("收到不明来源的消息 IP："+ client.RemoteEndPoint.ToString());
                        }
                        else
                        {
                            //Console.Write("1");
                            if (client.Connected)
                            {
                                if (cl.GetOppositeClient(index)!=null)
                                    if (cl.GetType(index) == "CD")
                                        Console.Write(cl.GetName(index) + " VS " + cl.GetOppositeName(index) + " :   ");
                                    else Console.Write(cl.GetOppositeName(index) + " VS " + cl.GetName(index) + " : ");
                                Console.WriteLine(cl.GetName(index) + "退出游戏");
                                if (cl.GetOppositeClient(index) != null)
                                    BSend("OD", new Byte[0], cl.GetOppositeClient(index));
                                client.Shutdown(SocketShutdown.Both);
                                client.Disconnect(true);
                                client.Close();
                                cl.remove(index);
                                //Console.WriteLine(index+"   "+(cl.client[index]==null));
                            }
                        }
                        break;
                    case "CH":
                        int k = 0;
                        for (int i = 0; i < rest.Length; i++)
                            if (rest[i] == '&')
                                k++;
                        if (cl.GetType(index) != "CD" || cl.GetName(index) == null || cl.GetOppositeClient(index) == null || !(rest[0] >= 'A' && rest[0] <= 'D') || k != 3)
                        {
                            Console.WriteLine("收到不明来源的消息 IP：" + client.RemoteEndPoint.ToString());
                            break;
                        }
                        cl.GetOppositeClient(index).Send(buffer);
                        Console.Write(cl.GetName(index) + " VS " + cl.GetOppositeName(index) + " :   ");
                        Console.WriteLine(cl.GetName(index) + "发送选项");
                        break;
                    case "AN":
                        if (cl.GetType(index) != "CG" || cl.GetName(index) == null || cl.GetOppositeClient(index) == null || !(rest[0] >= 'A' && rest[0] <= 'D'))
                        {
                            Console.WriteLine("收到不能解析的消息 IP:" + client.RemoteEndPoint.ToString());
                            break;
                        }
                        cl.GetOppositeClient(index).Send(buffer);
                        Console.Write(cl.GetName(index) + " VS " + cl.GetOppositeName(index) + " :   ");
                        Console.WriteLine(cl.GetName(index) + "回答");
                        break;
                    case "PI":
                        if (cl.GetType(index) != "CD" || cl.GetName(index) == null || cl.GetOppositeClient(index) == null)
                        {
                            Console.WriteLine("收到不能解析的消息 IP:" + client.RemoteEndPoint.ToString());
                            break;
                        }
                        cl.GetOppositeClient(index).Send(buffer);
                        Console.Write(cl.GetName(index) + " VS " + cl.GetOppositeName(index) + " :   ");
                        Console.WriteLine(cl.GetName(index) + "发送图片 ("+(buffer.Length-3)/1024+"KB)");
                        Byte[] tBuffer = new Byte[1184054];
                        Array.Copy(buffer, 3, tBuffer, 0, 1184054);
                        Stream st=new MemoryStream(tBuffer);
                        Bitmap bitmap = (Bitmap)Bitmap.FromStream(st);
                        String d=DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        if (cl.GetType(index)=="CG")
                            bitmap.Save(cl.GetName(index) + "VS" + cl.GetOppositeName(index) +"/"+ d+".jpg");
                        else bitmap.Save(cl.GetOppositeName(index) + "VS" + cl.GetName(index) +"/"+ d+".jpg");

                        break;
                    case "WN":
                        Console.Write(cl.GetName(index) + " VS " + cl.GetOppositeName(index) + " :   ");
                        Console.WriteLine(cl.GetName(index) + "获得胜利");
                        break;
                    case "ME":
                        Console.Write(cl.GetName(index) + " VS " + cl.GetOppositeName(index) + " :   ");
                        Console.WriteLine(cl.GetName(index) + " 发送消息:  " + Encoding.Default.GetString(buffer, 3, l - 2));
                        cl.GetOppositeClient(index).Send(buffer);
                        break;
                    default:
                        Console.WriteLine("收到不能解析的消息 IP:" + client.RemoteEndPoint.ToString());
                        break;
                }
                if (client.Connected)
                    client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
            }
            catch
            {
                //Console.WriteLine("");
            }
            //Console.Write(l + " " + type);
        }
        private void BSend(String type, Byte[] buffer2,Socket client)
        {
            Byte[] buffer = new Byte[buffer2.Length + 3];
            Byte[] buffer1 = Encoding.Default.GetBytes(type);
            Array.Copy(buffer1, 0, buffer, 1, buffer1.Length);
            Array.Copy(buffer2, 0, buffer, 3, buffer2.Length);
            buffer[0] = (byte)buffer.Length;
            client.Send(buffer);
        }
    }
}