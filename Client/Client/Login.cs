using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Client
{
    public partial class Login : Form
    {
        int type;
        ClientSocket client;
        Welcome parent;
        public Login(int type,Welcome parent)
        {
            //Control.CheckForIllegalCrossThreadCalls = true;
            this.parent=parent;
            this.type = type;
            client = new ClientSocket(this,type);
            InitializeComponent();
            parent.Hide();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (this.txt_IP.Text.Equals(""))
            {
                MessageBox.Show("匿名不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            client.Login(this.txt_IP.Text, this.txt_Port.Text, this.txt_Name.Text);
        }
        public void SetState(bool btn,String lbl,int X)
        {
            try
            {
                this.btn_Login.Enabled = btn;
                this.txt_IP.Enabled = btn;
                this.txt_Name.Enabled = btn;
                this.txt_Port.Enabled = btn;
                lbl_State.Text = lbl;
                lbl_State.Location = new Point(X, lbl_State.Location.Y);
            }
            catch { }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                client.DisConnect();
                parent.Show();
                this.Close();
            }
            catch { }
        }
        public void MyLeave()
        {
            try
            {
                client.DisConnect();
                client.pf.Close();
                parent.Show();
                this.Close();
                //Console.Write("1");
            }
            catch {
                //Console.Write("2");
            }
        }
        public void MyDis()
        {
            try
            {
                client.DisConnect();
                parent.Show();
            }
            catch 
            {
            }
        }

    }
}
