using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public struct Answer
    {
        public Answer(String A, String B, String C, String D, String an)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.an = an;
        }
        public String A;
        public String B;
        public String C;
        public String D;
        public String an;
    }
    public partial class Choose : Form
    {
        PaintForm parent;
        public Choose(PaintForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String an = "A";
            if (this.rbn_A.Checked)
                an="A";
            else if (this.rbn_B.Checked)
                an="B";
            else if (this.rbn_C.Checked)
                an="C";
            else if (this.rbn_D.Checked)
                an="D";
            parent.AnswerSet(new Answer(this.txt_A.Text, this.txt_B.Text, this.txt_C.Text, this.txt_D.Text, an));
            this.Close();
        }
    }
}
