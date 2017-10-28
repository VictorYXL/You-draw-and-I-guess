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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            //int a=1184054;
            //Byte []p=(Byte[])a;
            //Console.WriteLine((int)p);
            InitializeComponent();
        }
        public void Single(object sender, EventArgs e)
        {
            this.Hide();
            PaintForm pf = new PaintForm(this, 1, null, null, null);
            pf.ShowDialog();
            this.Show();
            //this.Hide();
        }
        public void Network(object sender, EventArgs e)
        {
            Login lg;
            if (sender.GetHashCode()==this.btn_Network1.GetHashCode())
                lg = new Login(2,this);
            else lg = new Login(3,this);
            lg.Show();
        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
