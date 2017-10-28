using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Client
{
    public class MyDraw
    {
        ToolType t;
        int step;
        Point lastClick, lastMove, nowClick, nowMove;
        Panel mp;
        public MyDraw(Panel mp)
        {
            lastClick = new Point(-1, -1);
            lastMove = new Point(-1, -1);
            nowClick = new Point(-1, -1);
            nowMove = new Point(-1, -1);
            t = ToolType.Pencil;
            step = 0;
            this.mp = mp;
        }
        public void cstep()
        {
            this.step = 0;
        }

        public int Draw(Pen p, ToolType t, MouseEventArgs e, Bitmap bm, Bitmap bm1, TextBox tb)
        {
            this.t = t;
            int s = 0;
            switch (t)
            {
                case ToolType.Pencil:
                    s = Pencil(p, e, bm);
                    break;
                case ToolType.Eraser:
                    s = Eraser(p, e, bm);
                    break;
                case ToolType.Line:
                    s = Line(p, e, bm, bm1);
                    break;
                case ToolType.Ellipse:
                    s = Ellipse(p, e, bm, bm1);
                    break;
                case ToolType.Full:
                    s = Full(p, e, bm);
                    break;
                case ToolType.Text:
                    s = Text(p, e, bm, tb);
                    break;
            }
            return s;
        }

        public int Pencil(Pen p, MouseEventArgs e, Bitmap bm)
        {
            int s = 0;
            Graphics g = Graphics.FromImage(bm);
            if (e.Button == MouseButtons.Left)
            {
                if (step == 0)
                {
                    this.lastMove = new Point(e.X, e.Y);
                    this.nowMove = new Point(e.X, e.Y);
                    step = 1;
                }
                else if (step == 1)
                {
                    this.lastMove = this.nowMove;
                    this.nowMove = new Point(e.X, e.Y);
                    g.DrawLine(p, lastMove, nowMove);
                }
            }
            else if (e.Button == MouseButtons.None)
            {
                if (step == 1)
                    s = 1;
                step = 0;
            }
            return s;
        }
        public int Eraser(Pen p, MouseEventArgs e, Bitmap bm)
        {
            int s = 0;
            Graphics g = Graphics.FromImage(bm);
            if (e.Button == MouseButtons.Left)
            {
                if (step == 0)
                {
                    this.lastMove = new Point(e.X, e.Y);
                    this.nowMove = new Point(e.X, e.Y);
                    step = 1;
                }
                else if (step == 1)
                {
                    this.lastMove = this.nowMove;
                    this.nowMove = new Point(e.X, e.Y);
                    Point[] pn = new Point[4];
                    pn[0] = new Point((int)(lastMove.X - p.Width * 2), (int)(lastMove.Y - p.Width * 2));
                    pn[3] = new Point((int)(lastMove.X + p.Width * 2), (int)(lastMove.Y - p.Width * 2));
                    pn[1] = new Point((int)(nowMove.X - p.Width * 2), (int)(nowMove.Y + p.Width * 2));
                    pn[2] = new Point((int)(nowMove.X + p.Width * 2), (int)(nowMove.Y + p.Width * 2));
                    g.FillPolygon(p.Brush, pn);
                }
            }
            else if (e.Button == MouseButtons.None)
            {
                if (step == 1)
                    s = 1;
                step = 0;
            }
            return s;
        }
        public int Line(Pen p, MouseEventArgs e, Bitmap bm, Bitmap bm1)
        {
            int s = 0;
            if (step == 0 && e.Button == MouseButtons.Left)
            {
                nowClick = new Point(e.X, e.Y);
                step = 1;
                s = 0;
            }
            if ((step == 1 || step == 2) && e.Button == MouseButtons.None)
            {
                Graphics g = Graphics.FromImage(bm1);
                lastClick = nowClick;
                this.nowMove = new Point(e.X, e.Y);
                g.DrawLine(p, lastClick, nowMove);
                //Console.WriteLine("***:" + s);
                s = -1;
                step = 2;
            }
            if (step == 2 && e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bm);
                this.nowClick = new Point(e.X, e.Y);
                g.DrawLine(p, lastClick, nowClick);
                step = 3;
                s = 0;
            }
            if (step == 3 && e.Button == MouseButtons.None)
            {
                s = 1;
            }
            return s;
        }
        public int Ellipse(Pen p, MouseEventArgs e, Bitmap bm, Bitmap bm1)
        {
            int s = 0;
            if (step == 0 && e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bm);
                nowClick = new Point(e.X, e.Y);
                step = 1;
                s = 0;
            }
            if ((step == 1 || step == 2) && e.Button == MouseButtons.None)
            {
                Graphics g = Graphics.FromImage(bm1);
                lastClick = nowClick;
                this.nowMove = new Point(e.X, e.Y);
                g.DrawEllipse(p, lastClick.X, lastClick.Y, nowMove.X - lastClick.X, nowMove.Y - lastClick.Y);
                s = -1;
                step = 2;
            }
            if (step == 2 && e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bm);
                this.nowClick = new Point(e.X, e.Y);
                g.DrawEllipse(p, lastClick.X, lastClick.Y, nowClick.X - lastClick.X, nowClick.Y - lastClick.Y);
                step = 3;
                s = 0;
            }
            if (step == 3 && e.Button == MouseButtons.None)
            {
                s = 1;
            }
            return s;
        }
        public int Full(Pen p, MouseEventArgs e, Bitmap bm)
        {
            int s = 0, x = e.X, y = e.Y;
            if (e.Button == MouseButtons.None && step == 1)
                s = 1;
            if (e.Button != MouseButtons.Left || step != 0)
                return s;
            Color nc = bm.GetPixel(x, y), lc = p.Color;
            if (lc.ToArgb() == nc.ToArgb())
                return s;
            fill(nc, lc, x, y, bm);
            step = 1;
            return s;
        }
        public int Text(Pen p, MouseEventArgs e, Bitmap bm, TextBox tb)
        {
            int s = 0;
            tb.Font = new Font(tb.Font.Name, 9 + p.Width * 3);
            tb.Show();
            if (e.Button == MouseButtons.None && step <= 1)
            {
                tb.Location = new Point(e.X + 1, e.Y + 1);
                step = 1;
            }
            if (e.Button == MouseButtons.Left && step == 1)
            {
                step = 2;
                tb.Focus();
            }
            if (e.Button == MouseButtons.None && step == 2)
            {
                step = 3;
            }
            if (e.Button == MouseButtons.Left && step == 3)
            {
                Graphics g = Graphics.FromImage(bm);
                g.DrawString(tb.Text, tb.Font, p.Brush, tb.Location);
                s = 1;
            }
            return s;
        }

        public void fill(Color nc, Color lc, int x, int y, Bitmap bm)
        {
            int i = 0, j = 0;
            List<Point> pl = new List<Point>();
            List<Point> pl1 = new List<Point>();

            while (y - j >= 0 && bm.GetPixel(x, y - j) == nc)
            {
                i = 0;
                while (x - i >= 0 && bm.GetPixel(x - i, y - j) == nc)
                {
                    bm.SetPixel(x - i, y - j, lc);
                    pl.Add(new Point(x - i, y - j));
                    i++;
                }
                i = 1;
                while (x + i < bm.Width && bm.GetPixel(x + i, y - j) == nc)
                {
                    bm.SetPixel(x + i, y - j, lc);
                    pl.Add(new Point(x + i, y - j));
                    i++;
                }
                j++;
            }
            j = 1;
            while (y + j < bm.Height && bm.GetPixel(x, y + j) == nc)
            {
                i = 0;
                while (x - i >= 0 && bm.GetPixel(x - i, y + j) == nc)
                {
                    bm.SetPixel(x - i, y + j, lc);
                    pl.Add(new Point(x - i, y + j));
                    i++;
                }
                i = 1;
                while (x + i < bm.Width && bm.GetPixel(x + i, y + j) == nc)
                {
                    bm.SetPixel(x + i, y + j, lc);
                    pl.Add(new Point(x + i, y + j));
                    i++;
                }
                j++;
            }
            if (pl.Count <= 0)
                return;
            pl1.Add(pl.ElementAt(0));
            for (int k = 1; k < pl.Count; k++)
            {
                int x1 = pl.ElementAt(k).X, y1 = pl.ElementAt(k).Y;
                if (y1 - 1 >= 0 && bm.GetPixel(x1, y1 - 1) == nc)
                {
                    pl1.Add(new Point(x1, y1 - 1));
                }
                if (y1 + 1 < bm.Height && bm.GetPixel(x1, y1 + 1) == nc)
                {
                    pl1.Add(new Point(x1, y1 + 1));
                }
            }
            for (int k = 0; k < pl1.Count; k++)
            {
                fill(nc, lc, pl1.ElementAt(k).X, pl1.ElementAt(k).Y, bm);
            }
        }
        public Bitmap GrapScreen()
        {
            this.mp.parent.Hide();
            System.Threading.Thread.Sleep(500);
            Screen sc=Screen.PrimaryScreen;
            Bitmap bm = new Bitmap(sc.Bounds.Width, sc.Bounds.Height), bm1,bm2 = new Bitmap(740, 400);
            Graphics g1 = Graphics.FromImage(bm), g2 = Graphics.FromImage(bm2);
            g1.CopyFromScreen(new Point(0, 0), new Point(0, 0), sc.Bounds.Size);
            if (bm.Width <= bm.Height * 740 / 400)
            {
                Console.Write(bm.Width + " " + bm.Height);
                bm1 = new Bitmap(bm, new Size(bm.Width*400 / bm.Height, 400));
                g2.DrawImage(bm1, new Point(370 - bm.Width * 200 / bm.Height, 0));
            }
            else
            {
                bm1 = new Bitmap(740, bm.Height*740 / bm.Width);
                g2.DrawImage(bm1, new Point(0, 200 - bm.Height*370 / bm.Width));
            }
            this.mp.parent.Show();
            return bm2;
        }
        public Bitmap drawImage(Image img)
        {
            Bitmap bm, bm1 = new Bitmap(740, 400);
            Graphics g = Graphics.FromImage(bm1);
            if (img.Width <= img.Height * 740 / 400)
            {
                bm = new Bitmap(img, new Size(img.Width*400 / img.Height , 400));
                g.DrawImage(bm, new Point(370 - img.Width*200 / img.Height , 0));
            }
            else
            {
                bm = new Bitmap(740, img.Height* 740 / img.Width );
                g.DrawImage(bm,new Point(0, 200 - img.Height * 370 / img.Width));
            }
            return bm1;
        }
    }
}
