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
    public partial class edit : Form
    {
        bool b = true;
        Form f1;
        public edit(Form f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        public edit(Form f1, string[] a)
        {
            InitializeComponent();
            this.f1 = f1;
            b = false;
            this.Text = "修改";
            button1.Text = "修改";
            textBox1.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox1.Text = a[0];
            textBox2.Text = a[1];
            textBox3.Text = a[2]; 
            textBox4.Text = a[3]; 
            textBox5.Text = a[4];
            textBox6.Text = a[5];
            textBox7.Text = a[6];
        }

        private bool check()
        {
            if (textBox1.Text.ToString().Length != 12)
            {
                MessageBox.Show("驾驶证编号应当为12位","警告",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                textBox1.Focus();
                return false;
            }
            else if (textBox2.Text.ToString().Length == 0)
            {
                MessageBox.Show("请输入姓名", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox2.Focus();
                return false;
            }else if(textBox7.Text.ToString().Length!=18){
                MessageBox.Show("身份证号码应当为18位", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox7.Focus();
                return false;
            }
            try
            {
                int age = Convert.ToInt32(textBox3.Text);
                if (age < 18 || age > 70)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("请输入18到70之间的年龄", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox3.Focus();
                return false;
            }
            try
            {
                DateTime date = DateTime.Parse(textBox5.Text);
                DateTime date0 =DateTime.Parse(DateTime.Now.ToShortDateString());
                if (DateTime.Compare(date, date0) > 0)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("请按照“YYYY-MM-DD”的格式输入不超过当前日期的日期", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox5.Focus();
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string id = textBox1.Text;
                string name = textBox2.Text;
                string age = textBox3.Text;
                string contact = textBox4.Text;
                string date = textBox5.Text;
                string address = textBox6.Text;
                string idcard = textBox7.Text;
                StringBuilder sb = new StringBuilder();
                if (b == true)
                {
                    sb.AppendFormat("insert [Pinfo] values ('{0}','{1}',{2},'{3}',{4},'{5}','{6}',null)",id,name,age,contact,date,address,idcard);
                }
                else
                {
                    sb.AppendFormat("update [Pinfo] set [name]='{0}',[age]={1},[contact]='{2}',[address]='{3}' where [pdrivingno]='{4}'",name,age,contact,address,id);
                }
                dbsc d0 = new dbsc();
                d0.OpenConnection();
                SqlCommand cmd = new SqlCommand(sb.ToString(), d0.Connection);
                cmd.ExecuteNonQuery();
                d0.CloseConnection();
                MessageBox.Show("更新成功","提示",MessageBoxButtons.OK);
                f1.Show();
                this.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }
    }
}
