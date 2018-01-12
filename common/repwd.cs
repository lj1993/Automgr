using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace common
{
    public partial class repwd : Form
    {
        Form f1;
        string user;
        bool pwdv = false;
        public repwd(Form f1, string user)
        {
            InitializeComponent();
            this.f1 = f1;
            this.user = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.lch())
            {
                dbsc d0 = new dbsc();
                d0.OpenConnection();
                string table = "[Pinfo]";
                string col = "[ID]";
                if (user.Length == 7)
                    table = "[admin]";
                else
                    col = "[pdrivingno]";
                string sql = "select [pwd] from " + table + " where " + col + "=" + user + "'";
                SqlCommand cmd = new SqlCommand(sql, d0.Connection);
                string bpwd = cmd.ExecuteScalar().ToString();
                if (bpwd.Equals(textBox1.Text))
                {
                    sql = "update " + table + " set [pwd]=" + textBox2.Text + " where " + col + "='" + user + "'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("密码更改成功！", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("原密码输入错误！", "警告", MessageBoxButtons.OK);
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
        }

        private bool lch()
        {
            if (textBox1.Text.Length < 6)
            {
                MessageBox.Show("密码长度不能小于6位", "提示", MessageBoxButtons.OK);
                textBox1.Focus();
                return false;
            }
            if (textBox2.Text.Length < 6)
            {
                MessageBox.Show("密码长度不能小于6位", "提示", MessageBoxButtons.OK);
                textBox2.Focus();
                return false;
            }
            if (!textBox3.Text.Equals(textBox2.Text))
            {
                MessageBox.Show("两次输入的密码不一致", "提示", MessageBoxButtons.OK);
                textBox2.Focus();
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pwdv == false)
            {
                DialogResult dr = MessageBox.Show("你的密码可能泄露，确认显示密码吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr.Equals(DialogResult.OK))
                {
                    pwdv=true;
                    button3.Text = "隐藏密码";
                    textBox1.UseSystemPasswordChar = false;
                    textBox2.UseSystemPasswordChar = false;
                    textBox3.UseSystemPasswordChar = false;
                }
            }
            else
            {
                pwdv = false;
                button3.Text = "显示密码";
                textBox1.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
