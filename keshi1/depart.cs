using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using common;

namespace temporary
{
    public partial class depart : Form
    {
        public depart()
        {
            InitializeComponent();
        }       
        //查询数据
        public DataSet dc;//定义数据集
        public SqlDataAdapter adapter;//定义适配器
        public void insert()
        {
            //语句多表查询
            string sql = "select unitno,unitname,unitphone from Uinfo";
            this.dc = new DataSet();//创建数据集对象
            adapter = new SqlDataAdapter();//创建sqldataadapter对象
            dbsc db0 = new dbsc();
            SqlCommand com = new SqlCommand(sql.ToString(), db0.Connection);
            adapter.SelectCommand = com;//装载数据
            adapter.Fill(dc, "temp");//填充
            this.dataGridView1.DataSource = dc.Tables["temp"];//绑定数据源
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            insert();
        }       
    }
}
