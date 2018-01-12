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
using common;

namespace Admin
{
    public partial class searchAuto : Form
    {
        Form f1;
        static int k = 0;
        public searchAuto(Form f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lno = check(textBox1.Text, "vlicenseno");
            string cl = check(textBox2.Text, "color");
            string br = check(textBox3.Text, "brand"); 
            string on = check(textBox4.Text, "name");
            string ty = check(comboBox1.SelectedItem.ToString(), "motorcycle");            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select v.* from [Vinfo] v inner join [Pinfo] p ");
            sb.AppendLine("on (v.vdrivingno=p.pdrivingno)");
            sb.Append("where ");
            if (lno.Length != 0){
                sb.Append(lno);
                k--;
                if (k > 0)
                    sb.Append(" and ");
            }            
            if (cl.Length != 0)
            {
                sb.Append(cl);
                k--;
                if (k > 0)
                    sb.Append(" and ");
            }
            if (br.Length != 0)
            {
                sb.Append(br);
                k--;
                if (k > 0)
                    sb.Append(" and ");
            }
            if (on.Length != 0)
            {
                sb.Append(on);
                k--;
                if (k > 0)
                    sb.Append(" and ");
            }
            if (ty.Length != 0)
            {
                sb.Append(ty);
                k--;
            }
            dbsc d0=new dbsc();
            d0.OpenConnection();
            SqlCommand cmd = new SqlCommand(sb.ToString(),d0.Connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "p");
            d0.CloseConnection();
            dataGridView1.DataSource = ds.Tables["p"];
        }

        private static string check(string a,string b)
        {
            string re;
            if (a == null || a.Equals(""))
                re = "";
            else
            {
                re = "[" + b + "]='" + a + "'";
                k++;
            }
            return re;
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                string outs="";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < 8; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value!=null)
                            outs += dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t";
                    outs += "\r\n";
                }
                file f1 = new file();
                f1.dcreate();
                f1.fwrite(@"d:\车辆管理系统文档\车辆查询.txt",outs);
                f1.dopen();
            }
            else
                MessageBox.Show("请先查询相关信息再输出","提示",MessageBoxButtons.OK);
        }
    }
}
