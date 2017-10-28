using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public enum ToolType { Pencil, Eraser, Line, Ellipse, Full, Text };
    public class Panel : PictureBox
    {
        private Bitmap bm1;
        private Bitmap[] bm = new Bitmap[10000];
        private ToolType t;
        private Pen p = null;
        private MyDraw md = null;
        TextBox tb;
        Camera cam;

        int step = 0;
        public PaintForm parent;
        public Panel(PaintForm parent, int type)
        {
            bm[0] = new Bitmap(740, 400);
            for (int i = 0; i < bm[0].Width; i++)
                for (int j = 0; j < bm[0].Height; j++)
                    bm[0].SetPixel(i, j, Color.White);
            this.Image = bm[0];
            if (type == 1 || type == 2)
            {
                tb = new TextBox();
                tb.Size = new Size(100, 50);
                tb.ImeMode = ImeMode.On;
                tb.Hide();
                this.Controls.Add(tb);

                this.MouseMove += this.Panel_Mouse;
                this.MouseClick += this.Panel_Mouse;
                p = new Pen(Color.Black, 1);
                md = new MyDraw(this);
                t = ToolType.Pencil;

                bm[1] = (Bitmap)bm[0].Clone();
                step = 1;
                this.parent = parent;
            }
            
        }
        public void SetBitmap(Bitmap bm)
        {
            Bitmap bm1 = new Bitmap(700, 400);
            for (int i = 0; i < bm1.Width; i++)
                for (int j = 0; j < bm1.Height; j++)
                    bm1.SetPixel(i, j, Color.White);
            this.Image = (Image)bm1;
            this.Image = (Image)bm;
        }
        public void setPT(Pen p, ToolType t)
        {
            this.Clear();
            this.p = p;
            this.t = t;
        }
        public void Clear()
        {
            md.cstep();
            tb.Clear();
            tb.Hide();

        }
        private void Panel_Mouse(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Clear();
                return;
            }
            bm1 = (Bitmap)bm[step].Clone();
            int  s = md.Draw(p, t, e, bm[step],bm1,tb);
            if (s == -1)
                this.Image = bm1;
            else
            {
                this.Image = bm[step];
                //this.parent.GetBitmap(bm[step]);
            }
            if (s==1)
            {
                tb.Clear();
                tb.Hide();
                md.cstep();
                if (step >= 9998)
                    return;
                bm[step + 1 ] = (Bitmap)bm[step].Clone();
                bm[step + 2] = null;
                this.Image = bm[step];
                step++;
                this.parent.GetBitmap(bm[step-1]);
            }
        }

        public void Back()
        {
            if (bm[step + 1] == null && step>0)
                this.step--;
            if (step>0)
                step--;
            this.Image=bm[step];
            bm[step + 1] = (Bitmap)bm[step].Clone();
            step++;
            bm[step+1] = null;
            parent.GetBitmap(bm[step-1]);
        }
        public void Clean()
        {
            bm[1] = (Bitmap)bm[0].Clone();
            bm[2] = null;
            step = 1;
            this.Image = bm[step];
            parent.GetBitmap(bm[1]);
        }
        public void Save(String fileName)
        {
            this.Image.Save(fileName);
        }
        public void Open(String fileName)
        {
            Image img = Image.FromFile(fileName);
            Bitmap fbm;
            fbm = md.drawImage(img);
            bm[step] = fbm;
            this.Image = bm[step];
            bm[step + 1] = (Bitmap)bm[step].Clone();
            bm[step + 2] = null;
            step++;
            parent.GetBitmap(bm[step - 1]);
        }
        public void OpenCamera()
        {
            cam = new Camera(this);
            cam.ShowDialog();
        }
        public void DrawCamera(Bitmap cbm)
        {
            bm[step] = cbm;
            bm[step + 1] = (Bitmap)bm[step].Clone();
            bm[step + 2] = null;
            this.Image = bm[step];
            step++;
            parent.GetBitmap(bm[step - 1]);
        }
        public void GrapScreen()
        {
            Bitmap smp=md.GrapScreen();
            bm[step] = smp;
            bm[step + 1] = (Bitmap)bm[step].Clone();
            bm[step + 2] = null;
            this.Image = bm[step];
            this.Size = smp.Size;
            step++;
            parent.GetBitmap(bm[step - 1]);
        }
    }
}
