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
    public partial class punish : Form
    {
        Form f1;
        public punish(Form f1)
        {
            InitializeComponent();
            this.f1 = f1;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            if (id.Length == 12)
            {
                dbsc d0 = new dbsc();
                d0.OpenConnection();
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        int score = 6;
                        string t;
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0:
                                score = 1;
                                break;
                            case 1:
                                score = 2;
                                break;
                            case 2:
                                score = 3;
                                break;
                        }
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("declare @s int");
                        sb.AppendFormat("select @s=[recorf]+{1} from [Dinfo] where [ddrivingno]='{0}'", id, score);
                        sb.AppendLine("if @s>=12");
                        sb.AppendLine("begin");
                        sb.AppendFormat("update [Dinfo] set [recorf]=12,[stat]='暂扣' where [ddrivingno]='{0}'", id);
                        sb.AppendLine();
                        sb.AppendLine("end");
                        sb.AppendLine("else");
                        sb.AppendFormat("update [Dinfo] set [recorf]=@s where [ddrivingno]='{0}'", id);
                        sb.AppendLine();
                        sb.AppendFormat("select [recorf] from [Dinfo] where [ddrivingno]='{0}'", id);
                        SqlCommand cmd = new SqlCommand(sb.ToString(), d0.Connection);
                        int t0 = Convert.ToInt32(cmd.ExecuteScalar());
                        if (t0 == 12)
                            t = "编号为" + id + "的驾照记分已满12分，执行暂扣";
                        else if (t0 != 0)
                            t = "登记成功，编号为" + id + "的驾照记分为" + t0;
                        else
                            t = "查无此照\n";
                        textBox2.Text += t + "\n";
                        break;
                    case 1:
                        string sql = "update [Dinfo] set [recorf]=12,[stat]='暂扣' where [ddrivingno]='" + id + "'";
                        SqlCommand cmd0 = new SqlCommand(sql, d0.Connection);
                        if(cmd0.ExecuteNonQuery()!=0)
                            textBox2.Text += "登记成功，编号为" + id + "的驾照已暂扣\n";
                        else
                            textBox2.Text += "查无此照\n";
                        break;
                    case 2:
                        string sql0 = "update [Dinfo] set [recorf]=12,[stat]='吊销' where [ddrivingno]='" + id + "'";
                        SqlCommand cmd1 = new SqlCommand(sql0, d0.Connection);
                        if(cmd1.ExecuteNonQuery()!=0)
                        textBox2.Text += "登记成功，编号为" + id + "的驾照已吊销\n";
                        else
                            textBox2.Text += "查无此照\n";
                        break;
                }
                d0.CloseConnection();
            }
            else
            {
                MessageBox.Show("请输入12位驾驶证号", "提示", MessageBoxButtons.OK);
                textBox1.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
                comboBox2.Enabled = false;
            else
                comboBox2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }
    }
}
