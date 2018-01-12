using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Admin;
using common;
using driver;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace 界面
{
    public partial class log : Form
    {
        Form f1;
        public log(Form f1)
        {
            InitializeComponent();
            this.f1 = f1;
            this.comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    alog();
                }
                else
                {
                    dlog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private bool check()
        {
            if (textBox1.Text.Length==0)
            {
                MessageBox.Show("请输入账号","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox1.Focus();
                return false;
            }else if(textBox2.Text.Length<6){
                MessageBox.Show("密码长度不小于6位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            return true;
        }

        private void alog()
        {
            if (textBox1.Text.ToString().Length == 7)
            {
                try {
                    int id = Convert.ToInt32(textBox1.Text.ToString());
                    dbsc d0 = new dbsc();
                    d0.OpenConnection();
                    string sql = "select [pwd] from [admin] where [ID]=" + id;
                    SqlCommand cmd = new SqlCommand(sql, d0.Connection);
                    string pwd = cmd.ExecuteScalar().ToString();
                    d0.CloseConnection();
                    if (pwd.Equals(textBox2.Text.ToString()))
                    {
                        MessageBox.Show("登录成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        admin ad1 = new admin(this.FindForm(),id.ToString());
                        this.textBox1.Text="";
                        this.textBox2.Text = "";
                        this.Hide();
                        ad1.Show();
                    }
                    else {
                        MessageBox.Show("用户名或密码错误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                }
                catch (Exception)
                {
                    MessageBox.Show("应输入7位数字账号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("应输入7位账号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
        }

        private void dlog()
        {
            if (textBox1.Text.ToString().Length == 12)
            {
                string id = textBox1.Text.ToString();
                string pwd = textBox2.Text.ToString();
                dbsc d0 = new dbsc();
                d0.OpenConnection();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("declare @pwd0 varchar");
                sb.AppendFormat("select @pwd0=[pwd] from [Pinfo] where [pdrivingno]='{0}'",id);
                sb.AppendLine();
                sb.AppendLine("if @pwd0 is null");
                sb.AppendFormat("select [idcard] from [Pinfo] where [pdrivingno]='{0}'", id);
                sb.AppendLine();
                sb.AppendLine("else");
                sb.AppendFormat("select [pwd] from [Pinfo] where [pdrivingno]='{0}'", id);
                SqlCommand cmd = new SqlCommand(sb.ToString(), d0.Connection);
                string pwd0 = cmd.ExecuteScalar().ToString();
                d0.CloseConnection();
                if (pwd.Equals(pwd0) || pwd.Equals(pwd0.Substring(pwd0.Length - 6, 6)))
                {
                    MessageBox.Show("登录成功！","提示" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    owner o1 = new owner(this.FindForm(),id);
                    o1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                MessageBox.Show("账号为12位驾驶证号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
        }
    }
}
