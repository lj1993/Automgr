using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarDAL
{
    public class dbhelper
    {
        public static readonly string con = ConfigurationManager.ConnectionStrings["vao"].ToString();
        public SqlConnection sqlc = new SqlConnection(con);

        public void open()
        {
            if (this.sqlc.State == ConnectionState.Broken)
            {
                sqlc = new SqlConnection(con);
            }
            if (this.sqlc.State == ConnectionState.Closed)
            {
                sqlc.Open();
            }
        }

        public void close()
        {
            if (this.sqlc.State == ConnectionState.Broken)
            {
                sqlc = new SqlConnection(con);
            }
            if (this.sqlc.State != ConnectionState.Closed)
            {
                sqlc.Close();
            }
        }
    }
}
