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

namespace Server
{
    class ClientNode
    {
        public ClientNode(Socket client,String name,String type)
        {
            this.client=client;
            this.name=name;
            this.type=type;
        }
        public Socket client;
        public String name;
        public String type;
    }
    class ClientList
    {
        public ClientNode[] client;
        int[] c2c;
        public static int SCount = 1024;
        public ClientList()
        {
            client = new ClientNode[SCount];
            c2c = new int[SCount];
            for (int i = 0; i < SCount; i++)
                c2c[i] = -1;
        }
        public Socket GetClient(int index)
        {
            return client[index].client;
        }
        public String GetName(int index)
        {
            return client[index].name;
        }
        public String GetType(int index)
        {
            return client[index].type;
        }
        public int FirstClient(Socket newClient)
        {
            int i;
            if (FindClient(newClient) != -1)
                return -1;
            for (i = 0; i < client.Length; i++)
                if (client[i] == null)
                {
                    client[i] = new ClientNode(newClient, null, null);
                    return i;
                }
            return -1;
        }
        public int FindClient(Socket tClient)
        {
            for (int i = 0; i < SCount; i++)
            {
                if (client[i]!=null && client[i].client == tClient)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Login(int index,String name, String type)
        {
            if (client[index].name == null)
            {
                client[index].name = name;
                client[index].type = type;
                return true;
            }
            else return false;
        }
        public int Connect(int index)
        {
            int i;
            for (i= 0; i < SCount; i++)
            {
                if (client[i]!=null)
                    if ((client[index].type == "CD" && client[i].type == "CG") || (client[index].type == "CG" && client[i].type == "CD") && c2c[i] == -1)
                    {
                        c2c[i] = index;
                        c2c[index] = i;
                        break;
                    }
            }
            if (i>=SCount)
                return -1;
            else return i;
        }
        public void remove(int index)
        {
            if (c2c[index]>0)
                c2c[c2c[index]] = -1;
            c2c[index] = -1;
            client[index] = null;
        }
        public int count()
        {
            return SCount;
        }
        public Socket GetOppositeClient(int index)
        {
            //Console.Write(index + "   " + c2c[index]);
            if (c2c[index] >= 0)
                return client[c2c[index]].client;
            return null;
        }
        public String GetOppositeName(int index)
        {
            if (c2c[index]>=0)
                return client[c2c[index]].name;
            return null;
        }
    }
    /*class ClientToClient
    {
        public ClientToClient()
        {
            drawClient = null;
            guessClient = null;
            drawName = null;
            guessName = null;
        }
        public int Login(Socket socket,String name,String type)
        {
            if (type == "CD")
            {
                if (drawClient != null)
                    return -1; //已有对应玩家
                drawClient = socket;
                drawName = name;
                if (guessClient == null)
                    return 0;//登陆成功等待对手
                else return 1;//登陆成功，匹配对手成功
            }
            else
            {
                if (guessClient != null)
                    return -1; 
                guessClient = socket;
                guessName = name;
               if (drawClient == null)
                    return 0;
                else return 1;
            }
        }
        public Socket drawClient;
        public Socket guessClient;
        public String drawName;
        public String guessName;
    }*/
}
