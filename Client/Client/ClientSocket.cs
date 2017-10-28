using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public class ClientSocket
    {
        Socket client;
        Byte[] sendBuffer;
        Byte[] acceptBuffer;
        IPEndPoint ipe;
        Thread threadConnect;
        Login parent;
        String name, name1;
        int type;
        public PaintForm pf;
        public ClientSocket(Login parent,int type)
        {
            //Control.CheckForIllegalCrossThreadCalls = true;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.parent=parent;
            this.type = type;
        }
        public void Login(String ipS,String portS,String name)
        {
            IPAddress ip;
            if (!IPAddress.TryParse(ipS, out ip))
            {
                MessageBox.Show("IP地址不合法", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ip = IPAddress.Parse(ipS);
            int port = Int32.Parse(portS);
            ipe = new IPEndPoint(ip, port);
            this.name = name;
            threadConnect = new Thread(Connect);
            threadConnect.Start();
        }
        private void Connect()
        {
            try
            {
                //Control.CheckForIllegalCrossThreadCalls = true;
                parent.SetState(false, "正在登陆...", 102);
                client.Connect(ipe);
                sendBuffer = Encoding.Default.GetBytes(((type == 1) ? "CD" : "CG") + name);
                sendBuffer = Encoding.Default.GetBytes(name);
                BSend(((type == 2) ? "CD" : "CG"),sendBuffer);
                //Console.WriteLine(Encoding.Default.GetString(sendBuffer));
                parent.SetState(false, "登陆成功,正在寻找对手...", 60);
                if (client.Connected == false)
                    return;
                acceptBuffer = new Byte[1184060];
                client.BeginReceive(acceptBuffer, 0, acceptBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
            }
            catch
            {
                parent.SetState(true, "尚未登陆", 102);
                MessageBox.Show("连接失败，请检查IP地址和端口", "失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ReceiveCallBack(IAsyncResult AR)
        {
            int p = acceptBuffer[0];
            if (p < 0 || !client.Connected)
                return;
            String T = Encoding.Default.GetString(acceptBuffer, 1, 2);
            
            switch (T)
            {
                case "OK":
                    String str = "匹配成功，你的对手是：\n" + Encoding.Default.GetString(acceptBuffer, 3, p - 2);
                    name1 = Encoding.Default.GetString(acceptBuffer, 3, p - 2);
                    parent.Hide();
                    parent.SetState(false, str, 60);
                    Thread t = new Thread(gb);
                    t.ApartmentState = ApartmentState.STA;
                    t.Start();
                    break;
                case"OD":
                    pf.ShowMessage("你的对手退出游戏","消息");
                    Console.Write("qq");
                    parent.MyLeave();
                    
                    break;
                case"CH":
                    String m=Encoding.Default.GetString(acceptBuffer, 3, p-2);
                    String an, a, b, c, d;
                    an = m.Substring(0,1);
                    int i = 1,j=0;
                    while (m[i+j] != '&')
                        j++;
                    a = m.Substring(i, j);
                    i = i + j + 1;
                    j = 0;
                    while (m[i+j] != '&')
                        j++;
                    b = m.Substring(i, j);
                    i = i + j + 1;
                    j = 0;
                    while (m[i+j] != '&')
                        j++;
                    c = m.Substring(i, j);
                    i = i + j + 1;
                    j = 0;
                    d = m.Substring(i, m.Length - i);
                    Answer ans=new Answer(a, b, c, d, an);
                    pf.AnswerShow(ans);
                    break;
                case"AN":
                    String anO = Encoding.Default.GetString(acceptBuffer, 3, 1);
                    pf.Answer(anO);
                    break;
                case "PI":
                    Byte[] buffer = new Byte[1184054];
                    Array.Copy(acceptBuffer, 3, buffer, 0, 1184054);
                    pf.SetBitmap(buffer);
                    break;
                case "ME":
                    pf.ShowMessage(Encoding.Default.GetString(acceptBuffer, 3, p - 2),"对方发来消息");
                    break;
            }
            try
            {
                client.BeginReceive(acceptBuffer, 0, acceptBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);
            }
            catch 
            {
                MessageBox.Show("已经与服务器断开连接", "断开连接", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void gb()
        {
            int p = acceptBuffer[0];
            parent.Hide();
            pf = new PaintForm(parent, type, this, name, name1);
            pf.ShowDialog();
        }
        public void DisConnect()
        {
            if (client.Connected)
            {
                BSend("DI", new Byte[0]); 
                client.Shutdown(SocketShutdown.Both);
                client.Disconnect(false);
            }
            client.Close();
        }
        public void BSend(String type,Byte[] buffer2)
        {
            Byte[] buffer = new Byte[buffer2.Length + 3];
            Byte[] buffer1 = Encoding.Default.GetBytes(type);
            Array.Copy(buffer1, 0, buffer, 1, buffer1.Length);
            Array.Copy(buffer2, 0, buffer, 3, buffer2.Length);
            buffer[0] = (byte)(buffer.Length-1);
            Console.WriteLine("b   " + (buffer.Length - 1));
            Console.WriteLine("c   " +(int) (buffer[0]));
            //Console.WriteLine(buffer.Length);
            client.Send(buffer);
        }
    }
}
