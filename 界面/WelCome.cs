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
using temporary;

namespace 界面
{
    public partial class WelCome : Form
    {
        public WelCome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            law l = new law();
            l.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            depart d0 = new depart();
            d0.ShowDialog();
        }

        private void 信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("会有的","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            log l1 = new log(this.FindForm());
            this.Hide();
            l1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能努力开发中，敬请期待！", "感谢使用", MessageBoxButtons.OK);
        }
    }
}
