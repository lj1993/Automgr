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
using System.Data.SqlClient;

namespace Admin
{
    public partial class randomnumber : Form
    {
        Form f1;
        int t2tk=0;
        public randomnumber(Form f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        private void 自主选号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Visible = true;
            button1.Visible = false;
            timer1.Enabled = true;
            timer2.Interval = 1000;
            timer2.Enabled = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd=new Random();
            label1.Text = "";
            for (int i = 0; i < 5; i++)
                label1.Text += rd.Next(9).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                textBox1.Text = "恭喜抽中号牌："+label1.Text;
                button1.Text = "开始";
                timer1.Enabled = false;
            }
            else if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button1.Text = "停止";
            }
        }

        private void 随机生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            button1.Visible = true;
        }

        private void 现有抽取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            button1.Visible = false;
            dbsc d0 = new dbsc();
            d0.OpenConnection();
            string sql = "select [llicenseno] from [Linfo] where [ifmaster]=0";
            SqlCommand cmd = new SqlCommand(sql, d0.Connection);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<string> lid = new List<string>();
            while (sdr.Read())
            {
                lid.Add(sdr["llicenseno"].ToString());
            }
            d0.CloseConnection();
            Random rd = new Random();
            int num = rd.Next(lid.Count-1);
            textBox1.Text = "恭喜抽中号牌："+lid[num];
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (t2tk < 9)
            {
                timer1.Stop();
                textBox1.Text += label1.Text + "\r\n";
                t2tk++;
                timer1.Start();
            }
            else
            {
                timer1.Enabled=false;
                textBox1.Text += label1.Text + "\r\n";
                t2tk = 0;
                timer2.Enabled = false;
            }
        } 
    }
}
