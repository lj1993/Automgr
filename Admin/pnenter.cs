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
    public partial class pnenter : Form
    {
        Form f1;
        public pnenter(Form f1)
        {
            InitializeComponent();
            this.f1 = f1;
            this.comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string li = textBox1.Text;
            dbsc d0 = new dbsc();
            d0.OpenConnection();
            string sql = "select * from [Linfo] where [llicenseno]='" + li + "'";
            SqlCommand cmd = new SqlCommand(sql, d0.Connection);
            if (!cmd.ExecuteScalar().ToString().Equals(string.Empty))
            {
                MessageBox.Show("该牌号已存在","提示",MessageBoxButtons.OK);
            }
            else
            {
                string type = textBox2.Text;
                string st = textBox3.Text;
                string own = comboBox1.SelectedItem.ToString();
                string ifm="0";
                if (own.Length != 0)
                    ifm = "1";
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("insert [Linfo] values ('{0}',{1},'{2}',{3},'{4}')",li,ifm,type,st,own);
                cmd.CommandText = sb.ToString();
                cmd.ExecuteNonQuery();
                MessageBox.Show("添加成功","提示",MessageBoxButtons.OK);
                d0.CloseConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
