using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using common;

namespace Admin
{
    public partial class admin : Form
    {
        Form f1;
        string aid;
        public admin(Form f1,string id)
        {
            InitializeComponent();
            this.f1 = f1;
            this.aid = id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liedit l1 = new liedit(this.FindForm());
            this.Hide();
            l1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            punish p1 = new punish(this.FindForm());
            this.Hide();
            p1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchAuto s1 = new searchAuto(this.FindForm());
            s1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnenter pn1 = new pnenter(this.FindForm());
            pn1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            repwd r0 = new repwd(this.FindForm(),aid);
            this.Hide();
            r0.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            randomnumber rb0 = new randomnumber(this.FindForm());
            this.Hide();
            rb0.Show();
        }
    }
}
