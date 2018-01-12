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
    public partial class liedit : Form
    {
        Form f1;
        public liedit(Form f1)
        {
            InitializeComponent();
            this.f1 = f1;
            this.load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void load()
        {
            dbsc d0 = new dbsc();
            d0.OpenConnection();
            string sql = "select * from [Pinfo]";
            SqlCommand cmd=new SqlCommand(sql,d0.Connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            d0.CloseConnection();
            DataSet ds = new DataSet();
            sda.Fill(ds, "p");
            this.dataGridView1.DataSource = ds.Tables["p"];
        }

        private bool iss()
        {
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中一行!","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iss())
            {
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("该操作不可逆！确认删除"+name+"的相关信息吗？","警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if(dr.Equals(DialogResult.OK)){
                    StringBuilder sb=new StringBuilder();
                    sb.AppendFormat("delete from [Dinfo] where [ddrivingno]='{0}'", name);
                    sb.AppendLine();
                    sb.AppendFormat("delete from [Vinfo] where [vdrivingno]='{0}'", name);
                    sb.AppendLine();
                    sb.AppendFormat("delete from [Pinfo] where [pdrivingno]='{0}'", name);
                    dbsc d0 = new dbsc();
                    d0.OpenConnection();
                    SqlCommand cmd = new SqlCommand(sb.ToString(), d0.Connection);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("删除成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.load();
                    }
                    d0.CloseConnection();
                }
            }
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit e1 = new edit(this.FindForm());
            this.Hide();
            e1.ShowDialog();
            this.load();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iss())
            {
                string[] a = new string[7];
                for (int i = 0; i < 7; i++)
                    a[i] = dataGridView1.SelectedRows[0].Cells[i].Value.ToString();
                edit e1 = new edit(this.FindForm(), a);
                this.Hide();
                e1.ShowDialog();
                this.load();
            }
        }
    }
}
