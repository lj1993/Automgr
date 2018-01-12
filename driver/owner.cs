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

namespace driver
{
    public partial class owner : Form
    {
        Form f1;
        string did;
        public owner(Form f1,string id)
        {
            InitializeComponent();
            this.f1 = f1;
            this.did = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            repwd re0 = new repwd(this.FindForm(), did);
            this.Hide();
            re0.ShowDialog();
        }

        private void 驾照查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbsc db0 = new dbsc();
            db0.OpenConnection();
            string sql = "select * from [Dinfo] where [ddrivingno]='"+did+"'";
            SqlCommand cmd = new SqlCommand(sql,db0.Connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = "驾驶证编号：" + did+"\r\n";
                textBox1.Text += "驾驶证类型：" + dr["dtype"].ToString() + "\r\n";
                textBox1.Text += "发证日期：" + dr["date"].ToString() + "\r\n";
                textBox1.Text += "记分：" + dr["recorf"].ToString() + "\r\n";
                textBox1.Text += "状态：" + dr["stat"].ToString();
            }
            db0.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 申请号牌ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能努力开发中，敬请期待！","感谢使用",MessageBoxButtons.OK);
        }

        private void 补办号牌ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能努力开发中，敬请期待！", "感谢使用", MessageBoxButtons.OK);
        }

        private void 驾照补换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能努力开发中，敬请期待！", "感谢使用", MessageBoxButtons.OK);
        }
    }
}
