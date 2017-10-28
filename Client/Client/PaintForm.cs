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
using System.IO;
using System.Drawing.Imaging;

namespace Client
{
    public partial class PaintForm : Form
    {
        private Panel mp;
        private Pen p = new Pen(Color.Black, 1);
        ToolType t = ToolType.Pencil;
        Form parent;
        int type;
        Answer ans;
        Choose ch;
        ClientSocket client;
        string name;
        Label lbl_Ans = new Label();
        RadioButton rbn_A;
        RadioButton rbn_B;
        RadioButton rbn_C;
        RadioButton rbn_D;
        Button btn_Choose, btn_Save1;
        OpenFileDialog ofd;
        public PaintForm(Form parent,int type,ClientSocket client,String name,String name1)
        {
            ans.an="E";
            rbn_A = new RadioButton();
            rbn_B = new RadioButton();
            rbn_C = new RadioButton();
            rbn_D = new RadioButton();
            btn_Choose = new Button();
            btn_Save1 = new Button();
            InitializeComponent();
            this.parent = parent;
            //parent.Hide();
            this.type = type;
            this.client = client;
            this.name=name;

            mp = new Panel(this,type);
            this.Controls.Add(mp);
            mp.Location = new Point(120, 80);
            mp.Size = new Size(740, 400);
            mp.BackColor = Color.White;

            this.gpb_Line.Paint += new PaintEventHandler(this.gpbLine_Paint);
            this.gpb_Line.Refresh();
            this.rbn_L1.Select();
            lbl_Ans.Size = new Size(200, 30);
            if (type == 2)
            {
                ch = new Choose(this);
                ch.ShowDialog();
            }
            if (type == 2 || type == 3)
            {
                Label lbl_OP = new Label();
                lbl_OP.Size = new Size(200, 30);
                lbl_OP.Text = "  你好，" + name + "\n 你的对手是" + name1;
                lbl_OP.Location = new Point(30, 20);
                this.Controls.Add(lbl_OP);
                this.txt_Mes.Show();
                this.btn_Mes.Show();
                this.btn_Good.Show();
                this.btn_Bad.Show();
            }
            else
            {
                this.txt_Mes.Hide();
                this.btn_Mes.Hide();
                this.btn_Good.Hide();
                this.btn_Bad.Hide();
            }
            if (type == 3)
            {
                this.gpb_Color.Hide();
                this.gpb_Tool.Hide();
                this.gpb_Line.Hide();
                this.btn_Camera.Hide();
                this.btn_Clean.Hide();
                this.btn_Import.Hide();
                this.btn_Clean.Hide();
                this.btn_Sceen.Hide();
                this.btn_Back.Hide();
                this.btn_Save.Hide();
                this.btn_OK.Hide();
                lbl_Ans.Location = new Point(430, 30);
                this.btn_Mes.Enabled = false;
                this.btn_Mes.Enabled = false;
                this.btn_Good.Enabled = false;
                this.btn_Bad.Enabled = false;
                lbl_Ans.Text = "画图者正在设计答案";
            }
            this.Controls.Add(lbl_Ans);


            rbn_A.Location = new Point(150, 510);
            rbn_A.Size = new Size(100, 30);
            rbn_B.Location = new Point(350, 510);
            rbn_B.Size = new Size(100, 30);
            rbn_C.Location = new Point(550, 510);
            rbn_C.Size = new Size(100, 30);
            rbn_D.Location = new Point(750, 510);
            rbn_D.Size = new Size(100, 30);
            btn_Choose.Location = new Point(550, 570);
            btn_Choose.Text = "提交答案";
            btn_Choose.Size = new Size(110, 50);
            btn_Save1.Location = new Point(250, 570);
            btn_Save1.Text = "保存图片";
            btn_Save1.Size = new Size(110, 50);
            this.Controls.Add(rbn_A);
            this.Controls.Add(rbn_B);
            this.Controls.Add(rbn_C);
            this.Controls.Add(rbn_D);
            this.Controls.Add(btn_Choose);
            this.Controls.Add(btn_Save1);
            this.btn_Choose.Click += new System.EventHandler(this.btnChoose);
            this.btn_Save1.Click += new System.EventHandler(this.btnSave);
            if (type != 3)
            {
                rbn_A.Hide();
                rbn_B.Hide();
                rbn_C.Hide();
                rbn_D.Hide();
                btn_Choose.Hide();
                btn_Save1.Hide();
            }
        }
        public void ShowMessage(String mes,String cap) 
        {
            MessageBox.Show(mes, cap, MessageBoxButtons.OK);
        }
        public void Answer(String anO)
        {
            String str1="";
            if (anO=="A")
                str1=ans.A;
            if (anO=="B")
                str1=ans.B;
            if (anO=="C")
                str1=ans.C;
            if (anO=="D")
                str1=ans.D;
            if (anO==ans.an)
                ShowMessage("对方回答 " + anO + " " + str1+"\n回答正确", "正确");
            else ShowMessage("对方回答 " + anO + " " + str1+"\n回答错误", "错误");
        }
        public void AnswerSet(Answer ans)
        {
            this.ans = ans;
            String Str = ans.an + ans.A + "&" + ans.B + "&" + ans.C + "&" + ans.D;
            //Console.WriteLine(Str);
            lbl_Ans.Location = new Point(430, 10);
            lbl_Ans.Text = "你设计的答案是 ("+ans.an+") :\n"+"A "+ans.A+"   B "+ans.B+"   C "+ans.C+"   D "+ans.D+"   ";
            this.Controls.Add(lbl_Ans);
            client.BSend("CH", Encoding.Default.GetBytes(Str));
        }
        public void AnswerShow(Answer ans)
        {
            this.btn_Mes.Enabled = true;
            this.btn_Mes.Enabled = true;
            this.btn_Good.Enabled = true;
            this.btn_Bad.Enabled = true;
            this.ans = ans;
            rbn_A.Text = "A "+ans.A;
            rbn_B.Text = "B "+ans.B;
            rbn_C.Text = "C "+ans.C;
            rbn_D.Text = "D "+ans.D;
            lbl_Ans.Hide();

            rbn_A.Checked = true;
            rbn_A.Show();
            rbn_B.Show();
            rbn_C.Show();
            rbn_D.Show();
            btn_Choose.Show();
            
            this.Refresh();
            //Console.WriteLine(ans.A);
            //Console.WriteLine(ans.B);
            //Console.WriteLine(ans.C);
            //Console.WriteLine(ans.D);

        }
        private void gpbLine_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.gpb_Line.CreateGraphics();
            
            Pen p=new Pen(Color.Black,1);
            g.DrawLine(p, 24, 27, 105, 27);
            p.Width = 3;
            g.DrawLine(p, 24, 57, 105, 57);
            p.Width = 5;
            g.DrawLine(p, 24, 87, 105, 87);
            p.Width = 7;
            g.DrawLine(p, 24, 119, 105, 119);
        }
        private void btnMouseEnter(object sender, EventArgs e)
        {
            string name = sender.ToString().Substring(35, 4);
            switch (name)
            {
                case "画  笔": 
                    this.pic_Pen.Show();
                    break;
                case "橡  皮": 
                    this.pic_Eraser.Show();
                    break;
                case "直  线": 
                    this.pic_Line.Show();
                    break;
                case "  圆 ": 
                    this.pic_Ellipse.Show();
                    break;
                case "填  充":
                    this.pic_Full.Show();
                    break;
                case "文  字":
                    this.pic_Text.Show();
                    break;
            }
        }
        private void btnMouseLeave(object sender, EventArgs e)
        {
            this.pic_Pen.Hide();
            this.pic_Eraser.Hide();
            this.pic_Line.Hide();
            this.pic_Ellipse.Hide();
            this.pic_Full.Hide();
            this.pic_Text.Hide();
        }
        private void btnTool(object sender, EventArgs e)
        {
            string name = sender.ToString().Substring(35, 4);
            Image pic = new Bitmap(pic_Pen.BackgroundImage, new Size(29, 29));
            switch (name)
            {
                case "画  笔":
                    pic = new Bitmap(pic_Pen.BackgroundImage, new Size(29, 29));
                    t = ToolType.Pencil;
                    mp.setPT(p, t);
                    break;
                case "橡  皮":
                    pic = new Bitmap(pic_Eraser.BackgroundImage, new Size(29, 29));
                    t = ToolType.Eraser;
                    p.Color = Color.White;
                    mp.setPT(p, t);
                    this.pic_SColor.BackColor = Color.White;
                    break;
                case "直  线":
                    pic = new Bitmap(pic_Line.BackgroundImage, new Size(29, 29));
                    t = ToolType.Line;
                    mp.setPT(p, t);
                    break;
                case "  圆 ":
                    pic = new Bitmap(pic_Ellipse.BackgroundImage, new Size(29, 29));
                    t = ToolType.Ellipse;
                    mp.setPT(p, t);
                    break;
                case "填  充":
                    pic = new Bitmap(pic_Full.BackgroundImage, new Size(29, 29));
                    t = ToolType.Full;
                    mp.setPT(p, t);
                    break;
                case "文  字":
                    pic = new Bitmap(pic_Text.BackgroundImage, new Size(29, 29));
                    t = ToolType.Text;
                    mp.setPT(p, t);
                    break;
            }
            this.pic_STool.BackgroundImage = pic;
        }
        private void btnColor(object sender, EventArgs e)
        {
            Button[] colorButton = new Button[24];
            colorButton[0] = btn_LightAqua;
            colorButton[1] = btn_Aqua;
            colorButton[2] = btn_Teal;
            colorButton[3] = btn_LightGreen;
            colorButton[4] = btn_Lime;
            colorButton[5] = btn_Green;
            colorButton[6] = btn_LightYellow;
            colorButton[7] = btn_Yellow;
            colorButton[8] = btn_Olive;
            colorButton[9] = btn_LightBrown;
            colorButton[10] = btn_MidBrown;
            colorButton[11] = btn_Brown;
            colorButton[12] = btn_LightRed;
            colorButton[13] = btn_Red;
            colorButton[14] = btn_DeepRed;
            colorButton[15] = btn_Siver;
            colorButton[16] = btn_White;
            colorButton[17] = btn_Black;
            colorButton[18] = btn_LightPurple;
            colorButton[19] = btn_Fuchsia;
            colorButton[20] = btn_Purple;
            colorButton[21] = btn_LightBlue;
            colorButton[22] = btn_Blue;
            colorButton[23] = btn_Navy;
            for (int i = 0; i < 24; i++)
            {
                if (sender.GetHashCode() == colorButton[i].GetHashCode())
                {
                    this.pic_SColor.BackColor = colorButton[i].BackColor;
                    p.Color = colorButton[i].BackColor;
                    this.mp.setPT(p, t);
                }
            }
        }

        int lhash = 0;
        private void rbnLine(object sender, EventArgs e)
        {
            lhash=sender.GetHashCode();
            this.pic_SLine.Refresh();
        }
        private void pic_SLinePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int []hash = new int[4];
            int width=0;
            hash[0] = rbn_L1.GetHashCode();
            hash[1] = rbn_L2.GetHashCode();
            hash[2] = rbn_L3.GetHashCode();
            hash[3] = rbn_L4.GetHashCode();
            for (int i = 0; i < 4; i++)
            {
                if (hash[i] == lhash)
                {
                    width = i * 2 + 1;
                }
            }
            g.DrawLine(new Pen(Color.Black,width), 4, 26, 26, 4);
            p.Width = width;
            if (type==1 || type==2)
                mp.setPT(p, t);
        }
        void btnEnter(object sender, System.EventArgs e)
        {
            this.pic_SS.Show();
            if (sender.GetHashCode() == btn_Import.GetHashCode())
            {
                this.pic_SS.BackgroundImage = Properties.Resources._71;
            }
            else if (sender.GetHashCode() == btn_Camera.GetHashCode())
            {
                this.pic_SS.BackgroundImage = Properties.Resources._81;
            }
            else this.pic_SS.BackgroundImage = Properties.Resources._91;

        }
        void btnLeave(object sender, System.EventArgs e)
        {
            this.pic_SS.Hide();
        }
        void btn_Back_Click(object sender, System.EventArgs e)
        {
            mp.Back();
        }
        void btn_Clean_Click(object sender, System.EventArgs e)
        {
            DialogResult dr=MessageBox.Show("确定清空？","清空",MessageBoxButtons.YesNo);
            if (dr==DialogResult.Yes)
                mp.Clean();
        }
        void btn_Save_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存图片";
            sfd.Filter = "图片(*.jpg)|*.jpg|全部文档(*.*)|*.*";
            sfd.ShowDialog();
            sfd.RestoreDirectory = true;
            if (sfd.FileName != "")
                mp.Save(sfd.FileName);
        }
        void btn_OK_Click(object sender, System.EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定离开？", "离开", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (parent is Login)
                    ((Login)parent).MyLeave();
                else parent.Show();
                this.Close();
            }
        }
        void btn_Camera_Click(object sender, System.EventArgs e)
        {
            mp.OpenCamera();
        }
        void btn_Import_Click(object sender, System.EventArgs e)
        {
            ofd = new OpenFileDialog();
            ofd.Title = "导入图片";
            ofd.Filter = "图片(*.jpg)|*.jpg|全部文档(*.*)|*.*";
            ofd.ShowDialog();
            ofd.RestoreDirectory = true;
            if (ofd.FileName != "")
                mp.Open(ofd.FileName);
        }
        void btn_Sceen_Click(object sender, System.EventArgs e)
        {
            mp.GrapScreen();
        }
        void btnChoose(object sender, System.EventArgs e)
        {
            if (ans.an=="E")
            {
                MessageBox.Show("答案还在设计中，请稍后", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Console.Write("WW");
            String an="A",str="",str1="";
            if (rbn_A.Checked)
            {
                an="A";
                str=ans.A;
            }
            if (rbn_B.Checked)
            {
                an="B";
                str=ans.B;
            }
            if (rbn_C.Checked)
            {
                an="C";
                str=ans.C;
            }
            if (rbn_D.Checked)
            {
                an="D";
                str=ans.D;
            }
            if (ans.an=="A")
                str1=ans.A;
            if (ans.an=="B")
                str1=ans.B;
            if (ans.an=="C")
                str1=ans.C;
            if (ans.an=="D")
                str1=ans.D;
            client.BSend("AN", Encoding.Default.GetBytes(an));
            if (an == ans.an)
                MessageBox.Show("恭喜你，回答正确\n"+an+" "+str,"回答正确",MessageBoxButtons.OK);
            else MessageBox.Show("回答错误，答案是\n" + ans.an + " "+str1 , "回答错误", MessageBoxButtons.OK);
        }
        void btnSave(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存图片";
            sfd.Filter = "图片(*.jpg)|*.jpg|全部文档(*.*)|*.*";
            sfd.ShowDialog();
            sfd.RestoreDirectory = true;
            if (sfd.FileName != "")
                mp.Save(sfd.FileName);
        }
        private void PaintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Console.WriteLine(rbn_B.Text);
            //Console.Write(1);
            if (parent is Login)
                ((Login)parent).MyDis();
            else parent.Show();
            //Console.Write(1);
        }
        public void GetBitmap(Bitmap bm)
        {
            if (type==2)
                client.BSend("PI",Bitmap2Bytes(bm));
            return;
        }
        public void SetBitmap(Byte[]buffer)
        {
            Bitmap bm=Bytes2Bitmap(buffer);
            return;
        }
        public Byte[] Bitmap2Bytes(Bitmap Bitmap)
        {
            MemoryStream ms = null;
            ms = new MemoryStream();
            Bitmap.Save(ms,ImageFormat.Bmp);
            Byte[] byteImage = new Byte[ms.Length];
            byteImage = ms.ToArray();
            //Console.WriteLine("a   "+byteImage.Count());
            return byteImage;
        }
        public Bitmap Bytes2Bitmap(Byte[]buffer)
        {
            Stream st=new MemoryStream(buffer);
            Bitmap bitmap = (Bitmap)Bitmap.FromStream(st);
            mp.SetBitmap(bitmap);
            return bitmap;
        }
        private void btn_Mes_Click(object sender, System.EventArgs e)
        {
            client.BSend("ME", Encoding.Default.GetBytes(txt_Mes.Text));
        }
        private void btn_Good_Click(object sender, System.EventArgs e)
        {
            client.BSend("ME", Encoding.Default.GetBytes("你很厉害！"));
        }
        private void btn_Bad_Click(object sender, System.EventArgs e)
        {
            client.BSend("ME", Encoding.Default.GetBytes("你不行~"));
        }
    }
}
