using System.Windows.Forms;
using System.Drawing;
namespace Client
{
    partial class PaintForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        /// 
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //#region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaintForm_FormClosing);
            this.rbn_L1 = new System.Windows.Forms.RadioButton();
            this.rbn_L2 = new System.Windows.Forms.RadioButton();
            this.gpb_Line = new System.Windows.Forms.GroupBox();
            this.rbn_L3 = new System.Windows.Forms.RadioButton();
            this.rbn_L4 = new System.Windows.Forms.RadioButton();
            this.btn_Ellipse = new Button();
            this.btn_Pen = new Button();
            this.btn_Eraser = new Button();
            this.btn_Full = new Button();
            this.btn_Line = new Button();
            this.btn_Text = new Button();
            this.gpb_Line.SuspendLayout();
            this.gpb_Color = new System.Windows.Forms.GroupBox();
            this.btn_LightPurple = new System.Windows.Forms.Button();
            this.btn_Fuchsia = new System.Windows.Forms.Button();
            this.btn_Purple = new System.Windows.Forms.Button();
            this.btn_LightBlue = new System.Windows.Forms.Button();
            this.btn_Blue = new System.Windows.Forms.Button();
            this.btn_Navy = new System.Windows.Forms.Button();
            this.btn_LightAqua = new System.Windows.Forms.Button();
            this.btn_White = new System.Windows.Forms.Button();
            this.btn_Aqua = new System.Windows.Forms.Button();
            this.btn_Teal = new System.Windows.Forms.Button();
            this.btn_LightGreen = new System.Windows.Forms.Button();
            this.btn_Lime = new System.Windows.Forms.Button();
            this.btn_Green = new System.Windows.Forms.Button();
            this.btn_LightYellow = new System.Windows.Forms.Button();
            this.btn_Yellow = new System.Windows.Forms.Button();
            this.btn_Olive = new System.Windows.Forms.Button();
            this.btn_LightBrown = new System.Windows.Forms.Button();
            this.btn_MidBrown = new System.Windows.Forms.Button();
            this.btn_Brown = new System.Windows.Forms.Button();
            this.btn_LightRed = new System.Windows.Forms.Button();
            this.btn_Red = new System.Windows.Forms.Button();
            this.btn_DeepRed = new System.Windows.Forms.Button();
            this.btn_Siver = new System.Windows.Forms.Button();
            this.btn_Black = new System.Windows.Forms.Button();
            this.btn_Back = new Button();
            this.btn_Save = new Button();
            this.btn_Clean = new Button();
            this.btn_OK = new Button();
            this.btn_Import = new Button();
            this.btn_Camera = new Button();
            this.btn_Sceen = new Button();
            this.pic_Ellipse = new PictureBox();
            this.pic_Pen = new PictureBox();
            this.pic_Line = new PictureBox();
            this.pic_Text = new PictureBox();
            this.pic_Eraser = new PictureBox();
            this.pic_Full = new PictureBox();
            this.pic_STool = new PictureBox();
            this.pic_SColor = new PictureBox();
            this.pic_SLine = new PictureBox();
            this.pic_SS = new PictureBox();
            this.txt_Mes = new TextBox();
            this.btn_Mes = new Button();
            this.btn_Good = new Button();
            this.btn_Bad=new Button();
            this.SuspendLayout();


            this.pic_Pen.BackgroundImage = Properties.Resources._1;
            this.pic_Pen.Location = new Point(110, 70);
            this.pic_Pen.Size = new Size(100, 100);

            this.pic_Eraser.BackgroundImage = Properties.Resources._2;
            this.pic_Eraser.Location = new Point(110, 135);
            this.pic_Eraser.Size = new Size(100, 100);

            this.pic_Line.BackgroundImage = Properties.Resources._3;
            this.pic_Line.Location = new Point(110, 200);
            this.pic_Line.Size = new Size(100, 100);

            this.pic_Ellipse.BackgroundImage = Properties.Resources._4;
            this.pic_Ellipse.Location = new Point(110, 265);
            this.pic_Ellipse.Size = new Size(100, 100);

            this.pic_Full.BackgroundImage = Properties.Resources._5;
            this.pic_Full.Location = new Point(110, 330);
            this.pic_Full.Size = new Size(100, 100);

            this.pic_Text.BackgroundImage = Properties.Resources._6;
            this.pic_Text.Location = new Point(110, 395);
            this.pic_Text.Size = new Size(100, 100);

            this.pic_STool.Location = new Point(430, 45);
            this.pic_STool.Size = new Size(30, 30);
            Image pic = new Bitmap(pic_Pen.BackgroundImage, new Size(29, 29));
            this.pic_STool.BackgroundImage = pic;
            this.pic_SColor.Location = new Point(480, 45);
            this.pic_SColor.Size = new Size(29, 29);
            this.pic_SColor.BackColor = Color.Black;
            this.pic_SLine.Location = new Point(530, 45);
            this.pic_SLine.Size = new Size(30, 30);
            this.pic_SLine.Paint += new PaintEventHandler(this.pic_SLinePaint);
            //this.pic_SLine.BackColor = Color.Green;

            this.pic_Pen.Hide();
            this.pic_Eraser.Hide();
            this.pic_Line.Hide();
            this.pic_Ellipse.Hide();
            this.pic_Full.Hide();
            this.pic_Text.Hide();

            // 
            // rbn_L1
            // 
            this.rbn_L1.AutoSize = true;
            this.rbn_L1.Location = new System.Drawing.Point(6, 20);
            this.rbn_L1.Name = "rbn_L1";
            this.rbn_L1.Size = new System.Drawing.Size(14, 13);
            this.rbn_L1.TabIndex = 0;
            this.rbn_L1.TabStop = true;
            this.rbn_L1.UseVisualStyleBackColor = true;
            this.rbn_L1.Click += new System.EventHandler(this.rbnLine);
            // 
            // rbn_L2
            // 
            this.rbn_L2.AutoSize = true;
            this.rbn_L2.Location = new System.Drawing.Point(6, 51);
            this.rbn_L2.Name = "rbn_L2";
            this.rbn_L2.Size = new System.Drawing.Size(14, 13);
            this.rbn_L2.TabIndex = 1;
            this.rbn_L2.TabStop = true;
            this.rbn_L2.UseVisualStyleBackColor = true;
            this.rbn_L2.Click += new System.EventHandler(this.rbnLine);
            // 
            // gpb_Line
            // 
            this.gpb_Line.Controls.Add(this.rbn_L4);
            this.gpb_Line.Controls.Add(this.rbn_L3);
            this.gpb_Line.Controls.Add(this.rbn_L1);
            this.gpb_Line.Controls.Add(this.rbn_L2);
            this.gpb_Line.Location = new System.Drawing.Point(880, 70);
            this.gpb_Line.Name = "gpb_Line";
            this.gpb_Line.Size = new System.Drawing.Size(115, 140);
            this.gpb_Line.TabIndex = 2;
            this.gpb_Line.TabStop = false;
            this.gpb_Line.Text = "线条";

            this.txt_Mes.Size = new System.Drawing.Size(140, 20);
            this.txt_Mes.Location=new System.Drawing.Point(650, 50);

            this.btn_Mes.Size = new System.Drawing.Size(50, 30);
            this.btn_Mes.Location = new System.Drawing.Point(800, 45);
            this.btn_Mes.Text = "发送";
            this.btn_Mes.Click += new System.EventHandler(this.btn_Mes_Click);

            this.btn_Good.Size = new System.Drawing.Size(50, 30);
            this.btn_Good.Location = new System.Drawing.Point(660, 15);
            this.btn_Good.Text = "赞美";
            this.btn_Good.Click += new System.EventHandler(this.btn_Good_Click);

            this.btn_Bad.Size = new System.Drawing.Size(50, 30);
            this.btn_Bad.Location = new System.Drawing.Point(730, 15);
            this.btn_Bad.Text = "鄙视";
            this.btn_Bad.Click += new System.EventHandler(this.btn_Bad_Click);
            // 
            // rbn_L3
            // 
            this.rbn_L3.AutoSize = true;
            this.rbn_L3.Location = new System.Drawing.Point(6, 82);
            this.rbn_L3.Name = "rbn_L3";
            this.rbn_L3.Size = new System.Drawing.Size(14, 13);
            this.rbn_L3.TabIndex = 2;
            this.rbn_L3.TabStop = true;
            this.rbn_L3.UseVisualStyleBackColor = true;
            this.rbn_L3.Click += new System.EventHandler(this.rbnLine);
            // 
            // rbn_L4
            // 
            this.rbn_L4.AutoSize = true;
            this.rbn_L4.Location = new System.Drawing.Point(6, 113);
            this.rbn_L4.Name = "rbn_L4";
            this.rbn_L4.Size = new System.Drawing.Size(14, 13);
            this.rbn_L4.TabIndex = 3;
            this.rbn_L4.TabStop = true;
            this.rbn_L4.UseVisualStyleBackColor = true;
            this.rbn_L4.Click += new System.EventHandler(this.rbnLine);


            gpb_Tool = new GroupBox();
            this.gpb_Tool.Controls.Add(this.btn_Pen);
            this.gpb_Tool.Controls.Add(this.btn_Eraser);
            this.gpb_Tool.Controls.Add(this.btn_Line);
            this.gpb_Tool.Controls.Add(this.btn_Ellipse);
            this.gpb_Tool.Controls.Add(this.btn_Full);
            this.gpb_Tool.Controls.Add(this.btn_Text);
            this.gpb_Tool.Location = new System.Drawing.Point(10, 70);
            this.gpb_Tool.Name = "gpb_Tool";
            this.gpb_Tool.Size = new System.Drawing.Size(90, 420);
            this.gpb_Tool.TabIndex = 2;
            this.gpb_Tool.TabStop = false;
            this.gpb_Tool.Text = "工具";
            this.gpb_Tool.BackColor = Color.Transparent;


            btn_Pen.Location = new Point(5, 30);
            btn_Pen.Size = new Size(80, 40);
            btn_Pen.Text = "画  笔";
            btn_Pen.BackColor = Color.Lime;
            btn_Pen.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            btn_Pen.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            btn_Pen.Click += new System.EventHandler(this.btnTool);

            btn_Eraser.Location = new Point(5, 95);
            btn_Eraser.Size = new Size(80, 40);
            btn_Eraser.Text = "橡  皮";
            btn_Eraser.BackColor = Color.Lime;
            btn_Eraser.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            btn_Eraser.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            btn_Eraser.Click += new System.EventHandler(this.btnTool);

            btn_Line.Location = new Point(5, 160);
            btn_Line.Size = new Size(80, 40);
            btn_Line.Text = "直  线";
            btn_Line.BackColor = Color.Lime;
            btn_Line.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            btn_Line.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            btn_Line.Click += new System.EventHandler(this.btnTool);

            btn_Ellipse.Location = new Point(5, 225);
            btn_Ellipse.Size = new Size(80, 40);
            btn_Ellipse.Text = "  圆  ";
            btn_Ellipse.BackColor = Color.Lime;
            btn_Ellipse.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            btn_Ellipse.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            btn_Ellipse.Click += new System.EventHandler(this.btnTool);

            btn_Full.Location = new Point(5, 290);
            btn_Full.Size = new Size(80, 40);
            btn_Full.Text = "填  充";
            btn_Full.BackColor = Color.Lime;
            btn_Full.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            btn_Full.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            btn_Full.Click += new System.EventHandler(this.btnTool);

            btn_Text.Location = new Point(5, 355);
            btn_Text.Size = new Size(80, 40);
            btn_Text.Text = "文  字";
            btn_Text.BackColor = Color.Lime;
            btn_Text.MouseEnter += new System.EventHandler(this.btnMouseEnter);
            btn_Text.MouseLeave += new System.EventHandler(this.btnMouseLeave);
            btn_Text.Click += new System.EventHandler(this.btnColor);
            btn_Text.Click += new System.EventHandler(this.btnTool);

            // 
            // gpb_Color
            // 
            this.gpb_Color.Controls.Add(this.btn_LightPurple);
            this.gpb_Color.Controls.Add(this.btn_Fuchsia);
            this.gpb_Color.Controls.Add(this.btn_Purple);
            this.gpb_Color.Controls.Add(this.btn_LightBlue);
            this.gpb_Color.Controls.Add(this.btn_Blue);
            this.gpb_Color.Controls.Add(this.btn_Navy);
            this.gpb_Color.Controls.Add(this.btn_LightAqua);
            this.gpb_Color.Controls.Add(this.btn_White);
            this.gpb_Color.Controls.Add(this.btn_Aqua);
            this.gpb_Color.Controls.Add(this.btn_Teal);
            this.gpb_Color.Controls.Add(this.btn_LightGreen);
            this.gpb_Color.Controls.Add(this.btn_Lime);
            this.gpb_Color.Controls.Add(this.btn_Green);
            this.gpb_Color.Controls.Add(this.btn_LightYellow);
            this.gpb_Color.Controls.Add(this.btn_Yellow);
            this.gpb_Color.Controls.Add(this.btn_Olive);
            this.gpb_Color.Controls.Add(this.btn_LightBrown);
            this.gpb_Color.Controls.Add(this.btn_MidBrown);
            this.gpb_Color.Controls.Add(this.btn_Brown);
            this.gpb_Color.Controls.Add(this.btn_LightRed);
            this.gpb_Color.Controls.Add(this.btn_Red);
            this.gpb_Color.Controls.Add(this.btn_DeepRed);
            this.gpb_Color.Controls.Add(this.btn_Siver);
            this.gpb_Color.Controls.Add(this.btn_Black);
            this.gpb_Color.Location = new System.Drawing.Point(880, 240);
            this.gpb_Color.Name = "gpb_Color";
            this.gpb_Color.Size = new System.Drawing.Size(115, 250);
            this.gpb_Color.TabIndex = 0;
            this.gpb_Color.TabStop = false;
            this.gpb_Color.Text = "颜色";
            // 
            // btn_LightPurple
            // 
            this.btn_LightPurple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_LightPurple.Location = new System.Drawing.Point(80, 223);
            this.btn_LightPurple.Name = "btn_LightPurple";
            this.btn_LightPurple.Size = new System.Drawing.Size(31, 23);
            this.btn_LightPurple.TabIndex = 23;
            this.btn_LightPurple.UseVisualStyleBackColor = false;
            this.btn_LightPurple.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Fuchsia
            // 
            this.btn_Fuchsia.BackColor = System.Drawing.Color.Fuchsia;
            this.btn_Fuchsia.Location = new System.Drawing.Point(43, 223);
            this.btn_Fuchsia.Name = "btn_Fuchsia";
            this.btn_Fuchsia.Size = new System.Drawing.Size(31, 23);
            this.btn_Fuchsia.TabIndex = 22;
            this.btn_Fuchsia.Text = "";
            this.btn_Fuchsia.UseVisualStyleBackColor = false;
            this.btn_Fuchsia.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Purple
            // 
            this.btn_Purple.BackColor = System.Drawing.Color.Purple;
            this.btn_Purple.Location = new System.Drawing.Point(6, 223);
            this.btn_Purple.Name = "btn_Purple";
            this.btn_Purple.Size = new System.Drawing.Size(31, 23);
            this.btn_Purple.TabIndex = 21;
            this.btn_Purple.Text = "";
            this.btn_Purple.UseVisualStyleBackColor = false;
            this.btn_Purple.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_LightBlue
            // 
            this.btn_LightBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_LightBlue.Location = new System.Drawing.Point(80, 194);
            this.btn_LightBlue.Name = "btn_LightBlue";
            this.btn_LightBlue.Size = new System.Drawing.Size(31, 23);
            this.btn_LightBlue.TabIndex = 20;
            this.btn_LightBlue.Text = "";
            this.btn_LightBlue.UseVisualStyleBackColor = false;
            this.btn_LightBlue.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Blue
            // 
            this.btn_Blue.BackColor = System.Drawing.Color.Blue;
            this.btn_Blue.Location = new System.Drawing.Point(43, 194);
            this.btn_Blue.Name = "btn_Blue";
            this.btn_Blue.Size = new System.Drawing.Size(31, 23);
            this.btn_Blue.TabIndex = 19;
            this.btn_Blue.Text = "";
            this.btn_Blue.UseVisualStyleBackColor = false;
            this.btn_Blue.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Navy
            // 
            this.btn_Navy.BackColor = System.Drawing.Color.Navy;
            this.btn_Navy.Location = new System.Drawing.Point(6, 194);
            this.btn_Navy.Name = "btn_Navy";
            this.btn_Navy.Size = new System.Drawing.Size(31, 23);
            this.btn_Navy.TabIndex = 18;
            this.btn_Navy.Text = "";
            this.btn_Navy.UseVisualStyleBackColor = false;
            this.btn_Navy.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_LightAqua
            // 
            this.btn_LightAqua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_LightAqua.Location = new System.Drawing.Point(80, 165);
            this.btn_LightAqua.Name = "btn_LightAqua";
            this.btn_LightAqua.Size = new System.Drawing.Size(31, 23);
            this.btn_LightAqua.TabIndex = 17;
            this.btn_LightAqua.Text = "";
            this.btn_LightAqua.UseVisualStyleBackColor = false;
            this.btn_LightAqua.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_White
            // 
            this.btn_White.BackColor = System.Drawing.Color.White;
            this.btn_White.Location = new System.Drawing.Point(80, 20);
            this.btn_White.Name = "btn_White";
            this.btn_White.Size = new System.Drawing.Size(31, 23);
            this.btn_White.TabIndex = 1;
            this.btn_White.UseVisualStyleBackColor = false;
            this.btn_White.Click += new System.EventHandler(this.btnColor);

            // 
            // btn_Aqua
            // 
            this.btn_Aqua.BackColor = System.Drawing.Color.Aqua;
            this.btn_Aqua.Location = new System.Drawing.Point(43, 165);
            this.btn_Aqua.Name = "btn_Aqua";
            this.btn_Aqua.Size = new System.Drawing.Size(31, 23);
            this.btn_Aqua.TabIndex = 16;
            this.btn_Aqua.Text = "";
            this.btn_Aqua.UseVisualStyleBackColor = false;
            this.btn_Aqua.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Teal
            // 
            this.btn_Teal.BackColor = System.Drawing.Color.Teal;
            this.btn_Teal.Location = new System.Drawing.Point(6, 165);
            this.btn_Teal.Name = "btn_Teal";
            this.btn_Teal.Size = new System.Drawing.Size(31, 23);
            this.btn_Teal.TabIndex = 15;
            this.btn_Teal.Text = "";
            this.btn_Teal.UseVisualStyleBackColor = false;
            this.btn_Teal.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_LightGreen
            // 
            this.btn_LightGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_LightGreen.Location = new System.Drawing.Point(80, 136);
            this.btn_LightGreen.Name = "btn_LightGreen";
            this.btn_LightGreen.Size = new System.Drawing.Size(31, 23);
            this.btn_LightGreen.TabIndex = 14;
            this.btn_LightGreen.Text = "";
            this.btn_LightGreen.UseVisualStyleBackColor = false;
            this.btn_LightGreen.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Lime
            // 
            this.btn_Lime.BackColor = System.Drawing.Color.Lime;
            this.btn_Lime.Location = new System.Drawing.Point(43, 136);
            this.btn_Lime.Name = "btn_Lime";
            this.btn_Lime.Size = new System.Drawing.Size(31, 23);
            this.btn_Lime.TabIndex = 13;
            this.btn_Lime.Text = "";
            this.btn_Lime.UseVisualStyleBackColor = false;
            this.btn_Lime.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Green
            // 
            this.btn_Green.BackColor = System.Drawing.Color.Green;
            this.btn_Green.Location = new System.Drawing.Point(6, 136);
            this.btn_Green.Name = "btn_Green";
            this.btn_Green.Size = new System.Drawing.Size(31, 23);
            this.btn_Green.TabIndex = 12;
            this.btn_Green.Text = "";
            this.btn_Green.UseVisualStyleBackColor = false;
            this.btn_Green.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_LightYellow
            // 
            this.btn_LightYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_LightYellow.Location = new System.Drawing.Point(80, 107);
            this.btn_LightYellow.Name = "btn_LightYellow";
            this.btn_LightYellow.Size = new System.Drawing.Size(31, 23);
            this.btn_LightYellow.TabIndex = 11;
            this.btn_LightYellow.Text = "";
            this.btn_LightYellow.UseVisualStyleBackColor = false;
            this.btn_LightYellow.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Yellow
            // 
            this.btn_Yellow.BackColor = System.Drawing.Color.Yellow;
            this.btn_Yellow.Location = new System.Drawing.Point(43, 107);
            this.btn_Yellow.Name = "btn_Yellow";
            this.btn_Yellow.Size = new System.Drawing.Size(31, 23);
            this.btn_Yellow.TabIndex = 10;
            this.btn_Yellow.Text = "";
            this.btn_Yellow.UseVisualStyleBackColor = false;
            this.btn_Yellow.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Olive
            // 
            this.btn_Olive.BackColor = System.Drawing.Color.Olive;
            this.btn_Olive.Location = new System.Drawing.Point(6, 107);
            this.btn_Olive.Name = "btn_Olive";
            this.btn_Olive.Size = new System.Drawing.Size(31, 23);
            this.btn_Olive.TabIndex = 9;
            this.btn_Olive.Text = "";
            this.btn_Olive.UseVisualStyleBackColor = false;
            this.btn_Olive.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_LightBrown
            // 
            this.btn_LightBrown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_LightBrown.Location = new System.Drawing.Point(80, 78);
            this.btn_LightBrown.Name = "btn_LightBrown";
            this.btn_LightBrown.Size = new System.Drawing.Size(31, 23);
            this.btn_LightBrown.TabIndex = 8;
            this.btn_LightBrown.Text = "";
            this.btn_LightBrown.UseVisualStyleBackColor = false;
            this.btn_LightBrown.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_MidBrown
            // 
            this.btn_MidBrown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_MidBrown.Location = new System.Drawing.Point(43, 78);
            this.btn_MidBrown.Name = "btn_MidBrown";
            this.btn_MidBrown.Size = new System.Drawing.Size(31, 23);
            this.btn_MidBrown.TabIndex = 7;
            this.btn_MidBrown.Text = "";
            this.btn_MidBrown.UseVisualStyleBackColor = false;
            this.btn_MidBrown.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Brown
            // 
            this.btn_Brown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(164)))), ((int)(((byte)(64)))));
            this.btn_Brown.Location = new System.Drawing.Point(6, 78);
            this.btn_Brown.Name = "btn_Brown";
            this.btn_Brown.Size = new System.Drawing.Size(31, 23);
            this.btn_Brown.TabIndex = 6;
            this.btn_Brown.Text = "";
            this.btn_Brown.UseVisualStyleBackColor = false;
            this.btn_Brown.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_LightRed
            // 
            this.btn_LightRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_LightRed.Location = new System.Drawing.Point(80, 49);
            this.btn_LightRed.Name = "btn_LightRed";
            this.btn_LightRed.Size = new System.Drawing.Size(31, 23);
            this.btn_LightRed.TabIndex = 5;
            this.btn_LightRed.Text = "";
            this.btn_LightRed.UseVisualStyleBackColor = false;
            this.btn_LightRed.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Red
            // 
            this.btn_Red.BackColor = System.Drawing.Color.Red;
            this.btn_Red.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Red.Location = new System.Drawing.Point(43, 49);
            this.btn_Red.Name = "btn_Red";
            this.btn_Red.Size = new System.Drawing.Size(31, 23);
            this.btn_Red.TabIndex = 4;
            this.btn_Red.Text = "";
            this.btn_Red.UseVisualStyleBackColor = false;
            this.btn_Red.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_DeepRed
            // 
            this.btn_DeepRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_DeepRed.Location = new System.Drawing.Point(6, 49);
            this.btn_DeepRed.Name = "btn_DeepRed";
            this.btn_DeepRed.Size = new System.Drawing.Size(31, 23);
            this.btn_DeepRed.TabIndex = 3;
            this.btn_DeepRed.Text = "";
            this.btn_DeepRed.UseVisualStyleBackColor = false;
            this.btn_DeepRed.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Siver
            // 
            this.btn_Siver.BackColor = System.Drawing.Color.Silver;
            this.btn_Siver.Location = new System.Drawing.Point(43, 20);
            this.btn_Siver.Name = "btn_Siver";
            this.btn_Siver.Size = new System.Drawing.Size(31, 23);
            this.btn_Siver.TabIndex = 2;
            this.btn_Siver.Text = "";
            this.btn_Siver.UseVisualStyleBackColor = false;
            this.btn_Siver.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Black
            // 
            this.btn_Black.BackColor = System.Drawing.Color.Black;
            this.btn_Black.Location = new System.Drawing.Point(6, 20);
            this.btn_Black.Name = "btn_Black";
            this.btn_Black.Size = new System.Drawing.Size(31, 23);
            this.btn_Black.TabIndex = 0;
            this.btn_Black.Text = "";
            this.btn_Black.UseVisualStyleBackColor = false;
            this.btn_Black.Click += new System.EventHandler(this.btnColor);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(180, 560);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(98, 53);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.Text = " 撤  销 ";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.BackColor = Color.SkyBlue;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(540, 560);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(91, 56);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = " 保  存 ";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.BackColor = Color.SkyBlue;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(720, 560);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(94, 53);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = " 离  开 ";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.BackColor = Color.SkyBlue;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.Location = new System.Drawing.Point(360, 560);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(98, 53);
            this.btn_Clean.TabIndex = 6;
            this.btn_Clean.Text = " 清  空 ";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.BackColor = Color.SkyBlue;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);

            this.btn_Import.Location = new System.Drawing.Point(270, 498);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(100, 50);
            this.btn_Import.TabIndex = 6;
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.BackColor = Color.SkyBlue;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            this.btn_Import.BackgroundImage = Properties.Resources._7;
            this.btn_Import.MouseEnter += this.btnEnter;
            this.btn_Import.MouseLeave += this.btnLeave;

            this.btn_Camera.Location = new System.Drawing.Point(450, 498);
            this.btn_Camera.Name = "btn_Camera";
            this.btn_Camera.Size = new System.Drawing.Size(100, 50);
            this.btn_Camera.TabIndex = 6;
            this.btn_Camera.UseVisualStyleBackColor = true;
            this.btn_Camera.BackColor = Color.SkyBlue;
            this.btn_Camera.BackgroundImage = Properties.Resources._8;
            this.btn_Camera.Click += new System.EventHandler(this.btn_Camera_Click);
            this.btn_Camera.MouseEnter += this.btnEnter;
            this.btn_Camera.MouseLeave += this.btnLeave;

            this.pic_SS.Size = new Size(188, 53);
            this.pic_SS.Location = new System.Drawing.Point(401, 425);
            this.pic_SS.Hide();

            this.btn_Sceen.Location = new System.Drawing.Point(630, 498);
            this.btn_Sceen.Name = "btn_Sceen";
            this.btn_Sceen.Size = new System.Drawing.Size(100, 50);
            this.btn_Sceen.TabIndex = 6;
            this.btn_Sceen.UseVisualStyleBackColor = true;
            this.btn_Sceen.BackColor = Color.SkyBlue;
            this.btn_Sceen.Click += new System.EventHandler(this.btn_Sceen_Click);
            this.btn_Sceen.BackgroundImage = Properties.Resources._9;
            this.btn_Sceen.MouseEnter += this.btnEnter;
            this.btn_Sceen.MouseLeave += this.btnLeave;


            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 630);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Back";
            this.Text = "Drawing";
            this.ResumeLayout(false);
            this.Controls.Add(this.gpb_Line);
            this.Controls.Add(this.gpb_Tool);
            this.Controls.Add(this.gpb_Color);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.btn_Camera);
            this.Controls.Add(this.btn_Sceen);
            this.Controls.Add(this.pic_Pen);
            this.Controls.Add(this.pic_Eraser);
            this.Controls.Add(this.pic_Line);
            this.Controls.Add(this.pic_Ellipse);
            this.Controls.Add(this.pic_Full);
            this.Controls.Add(this.pic_Text);
            this.Controls.Add(this.pic_STool);
            this.Controls.Add(this.pic_SColor);
            this.Controls.Add(this.pic_SLine);
            this.Controls.Add(this.pic_SS);
            this.Controls.Add(this.txt_Mes);
            this.Controls.Add(this.btn_Mes);
            this.Controls.Add(this.btn_Good);
            this.Controls.Add(this.btn_Bad);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.SuspendLayout();
        }

        
        private System.Windows.Forms.RadioButton rbn_L1;
        private System.Windows.Forms.RadioButton rbn_L2;
        private System.Windows.Forms.GroupBox gpb_Line;
        private System.Windows.Forms.RadioButton rbn_L4;
        private System.Windows.Forms.RadioButton rbn_L3;
        private System.Windows.Forms.GroupBox gpb_Tool;
        private System.Windows.Forms.Button btn_Pen;
        private System.Windows.Forms.Button btn_Eraser;
        private System.Windows.Forms.Button btn_Line;
        private System.Windows.Forms.Button btn_Ellipse;
        private System.Windows.Forms.Button btn_Full;
        private System.Windows.Forms.Button btn_Text;
        private System.Windows.Forms.GroupBox gpb_Color;
        private System.Windows.Forms.Button btn_LightAqua;
        private System.Windows.Forms.Button btn_Aqua;
        private System.Windows.Forms.Button btn_Teal;
        private System.Windows.Forms.Button btn_LightGreen;
        private System.Windows.Forms.Button btn_Lime;
        private System.Windows.Forms.Button btn_Green;
        private System.Windows.Forms.Button btn_LightYellow;
        private System.Windows.Forms.Button btn_Yellow;
        private System.Windows.Forms.Button btn_Olive;
        private System.Windows.Forms.Button btn_LightBrown;
        private System.Windows.Forms.Button btn_MidBrown;
        private System.Windows.Forms.Button btn_Brown;
        private System.Windows.Forms.Button btn_LightRed;
        private System.Windows.Forms.Button btn_Red;
        private System.Windows.Forms.Button btn_DeepRed;
        private System.Windows.Forms.Button btn_Siver;
        private System.Windows.Forms.Button btn_White;
        private System.Windows.Forms.Button btn_Black;
        private System.Windows.Forms.Button btn_LightPurple;
        private System.Windows.Forms.Button btn_Fuchsia;
        private System.Windows.Forms.Button btn_Purple;
        private System.Windows.Forms.Button btn_LightBlue;
        private System.Windows.Forms.Button btn_Blue;
        private System.Windows.Forms.Button btn_Navy;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.Button btn_Camera;
        private System.Windows.Forms.Button btn_Sceen;
        private System.Windows.Forms.TextBox txt_Mes;
        private System.Windows.Forms.Button btn_Mes;
        private System.Windows.Forms.Button btn_Good;
        private System.Windows.Forms.Button btn_Bad;

        private PictureBox pic_Pen;
        private PictureBox pic_Eraser;
        private PictureBox pic_Line;
        private PictureBox pic_Ellipse;
        private PictureBox pic_Full;
        private PictureBox pic_Text;
        private PictureBox pic_STool;
        private PictureBox pic_SColor;
        private PictureBox pic_SLine;
        private PictureBox pic_SS;
    }
}
