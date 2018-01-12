using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CarDAL
{
    public class server
    {
        static dbhelper db0 = new dbhelper();
        static SqlCommand cmd;        
        public static DataSet GetPhone()//查询科室电话
        {
            db0.open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            using (db0.sqlc)
            {
                string sql = "select unitno,unitname,unitphone from Uinfo";                
                SqlCommand com = new SqlCommand(sql.ToString(), db0.sqlc);
                sda.SelectCommand = com;//装载数据
                sda.Fill(ds, "temp");//填充
            }
            return ds;
        }

        public static string GetLogin(string s1)
        {
            string sql;
            if(s1.Length==12){
                sql = "select [pwd] from [admin] where [ID]='@id'";
            }else{
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("declare @pwd0 varchar");
                sb.AppendLine("select @pwd0=[pwd] from [Pinfo] where [pdrivingno]='@id'");
                sb.AppendLine("if @pwd0 is null");
                sb.AppendLine("select [idcard] from [Pinfo] where [pdrivingno]='@id'");
                sb.AppendLine("else");
                sb.AppendFormat("select [pwd] from [Pinfo] where [pdrivingno]='@id'");
                sql=sb.ToString();
            }
            db0.open();
            string pwd;
            using (db0.sqlc)
            {
                cmd = new SqlCommand(sql,db0.sqlc);
                SqlParameter sp = new SqlParameter("id", s1);
                cmd.Parameters.Add(sp);
                pwd = cmd.ExecuteScalar().ToString();
            }
            return pwd;
        }//查询登陆密码

        public static DataSet GetInfo()
        {
            db0.open();
            DataSet ds = new DataSet();
            using (db0.sqlc)
            {
                string sql = "select * from [Pinfo] where [pdrivingno] not like 'jkbm#%'";
                SqlCommand cmd = new SqlCommand(sql, db0.sqlc);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "p");
            }
            return ds;
        }//查询驾照信息

        public static bool AddInfo(driver d)//添加驾照信息
        {
            string sql = "insert [Pinfo] values ('@id','@name',@age,'@contact',@date,'@address','@idcard',null)";
            db0.open();
            SqlParameter[] sp=new SqlParameter[]{
                new SqlParameter("id",d.Licenseno),
                new SqlParameter("name",d.Dname),
                new SqlParameter("age",d.Age),
                new SqlParameter("contact",d.Contact),
                new SqlParameter("date",d.Getdate),
                new SqlParameter("address",d.Address),
                new SqlParameter("idcard",d.Idcard)
            };
            using (db0.sqlc)
            {
                SqlCommand cmd = new SqlCommand(sql, db0.sqlc);
                cmd.Parameters.AddRange(sp);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public static bool UpdateInfo(driver d)
        {
            string sql = "update [Pinfo] set [name]='@name',[age]=@age,[contact]='@contact',[address]='@address' where [pdrivingno]='@id'";
            db0.open();
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("id",d.Licenseno),
                new SqlParameter("name",d.Dname),
                new SqlParameter("age",d.Age),
                new SqlParameter("contact",d.Contact),
                new SqlParameter("address",d.Address),
            };
            using (db0.sqlc)
            {
                SqlCommand cmd = new SqlCommand(sql, db0.sqlc);
                cmd.Parameters.AddRange(sp);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                return true;
            }
        }//修改驾照信息

        public static bool DeleteInfo(string name)
        {
            db0.open();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from [Dinfo] where [ddrivingno]='@id'");
            sb.AppendLine("delete from [Vinfo] where [vdrivingno]='@id'");
            sb.AppendLine("delete from [Pinfo] where [pdrivingno]='@id'");
            using (db0.sqlc)
            {
                SqlCommand cmd = new SqlCommand(sb.ToString(), db0.sqlc);
                SqlParameter sp = new SqlParameter("@id",name);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                return false;
            }
        }//删除驾照信息

        public static bool AddPlate(plate p)
        {
            db0.open();
            string sql = "select * from [Linfo] where [llicenseno]='@no'";
            using (db0.sqlc)
            {
                SqlCommand cmd = new SqlCommand(sql, db0.sqlc);
                SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("no",p.Carno),
                    new SqlParameter("ifm",p.Ifmaster),
                    new SqlParameter("type",p.Type),
                    new SqlParameter("st",p.State.ToString()),
                    new SqlParameter("own",p.Owner)
                };
                if (!cmd.ExecuteScalar().ToString().Equals(string.Empty))
                {
                    return false;
                }
                else
                {
                    sql="insert [Linfo] values ('@no',@ifm,'@type',@st,'@own')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }//号牌登记

        public static string UpdateLicense(lisence l,int num)
        {
            db0.open();
            string t;
            using(db0.sqlc){
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("declare @s int");
                    sb.AppendLine("select @s=[recorf]+@score from [Dinfo] where [ddrivingno]='@id'");
                    sb.AppendLine("if @s>=12");
                    sb.AppendLine("begin");
                    sb.AppendLine("update [Dinfo] set [recorf]=12,[stat]='暂扣' where [ddrivingno]='@id'");
                    sb.AppendLine();
                    sb.AppendLine("end");
                    sb.AppendLine("else");
                    sb.AppendLine("update [Dinfo] set [recorf]=@s where [ddrivingno]='@id'");
                    sb.AppendLine();
                    sb.AppendFormat("select [recorf] from [Dinfo] where [ddrivingno]='@id'");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), db0.sqlc);
                SqlParameter[] sp=new SqlParameter[]{
                    new SqlParameter("id",l.Licenseno),
                    new SqlParameter("score",num)
                };
                cmd.Parameters.Add(sp);
                    int t0 = Convert.ToInt32(cmd.ExecuteScalar());
                    if (t0 == 12)
                        t = "编号为" + l.Licenseno + "的驾照记分已满12分，执行暂扣";
                    else if (t0 != 0)
                        t = "登记成功，编号为" + l.Licenseno + "的驾照记分为" + t0;
                    else
                        t = "查无此照\n";
                return t;
            }
        }//驾照扣分

        public static bool UpdateLicense(lisence l){
            db0.open();
            using (db0.sqlc)
            {
                string sql = "update [Dinfo] set [recorf]=12,[stat]='@state' where [ddrivingno]='@id'";
                SqlCommand cmd0 = new SqlCommand(sql, db0.sqlc);
                SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("id",l.Licenseno),
                    new SqlParameter("state",l.State)
                };
                cmd.Parameters.Add(sp);
                if (cmd0.ExecuteNonQuery() != 0)
                    return true;
                else
                    return false;
            }
        }//驾照处罚

        public static List<string> GetPlate()
        {
            db0.open();
            using (db0.sqlc)
            {
                string sql = "select [llicenseno] from [Linfo] where [ifmaster]=0";
                SqlCommand cmd = new SqlCommand(sql, db0.sqlc);
                SqlDataReader sdr = cmd.ExecuteReader();
                List<string> lid = new List<string>();
                while (sdr.Read())
                {
                    lid.Add(sdr["llicenseno"].ToString());
                }
                return lid;
            }
        }//查询现有无主号牌

        public static DataSet SearchCar(car c,string name)
        {
            int k = 0;
            string lno = check(c.Licenseno, "vlicenseno",ref k);
            string cl = check(c.Color, "color",ref k);
            string br = check(c.Brand, "brand",ref k);
            string on = check(name, "name",ref k);
            string ty = check(c.Motor, "motorcycle",ref k);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select v.* from [Vinfo] v inner join [Pinfo] p ");
            sb.AppendLine("on (v.vdrivingno=p.pdrivingno)");
            sb.Append("where ");
            if (lno.Length != 0)
            {
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
            db0.open();
            using(db0.sqlc){
            SqlCommand cmd = new SqlCommand(sb.ToString(), db0.sqlc);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "p");
                return ds;
            }
        }//车辆查询

        private static string check(string a, string b,ref int k)
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

        public static lisence GetPersonInfo(string id)
        {
            db0.open();
            string sql = "select * from [Dinfo] where [ddrivingno]='@id'";
            lisence l = new lisence();
            using (db0.sqlc)
            {
                SqlCommand cmd = new SqlCommand(sql, db0.sqlc);
                SqlParameter sp = new SqlParameter("id", id);
                cmd.Parameters.Add(sp);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    l.Licenseno = id;
                    l.Type= dr["dtype"].ToString();
                    l.Date=DateTime.Parse(dr["date"].ToString());
                    l.Record= int.Parse(dr["recorf"].ToString()) ;
                    l.State= dr["stat"].ToString();
                }
            }
            return l;
        }//用户驾照查询

        public static bool RegisterLicense(lisence l)
        {
            db0.open();
            using (db0.sqlc)
            {
                string sql = "update [Dinfo] set [stat]='@state' where [ddrivingno]='@id'";
                SqlCommand cmd0 = new SqlCommand(sql, db0.sqlc);
                SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("id",l.Licenseno),
                    new SqlParameter("state",l.State)
                };
                cmd.Parameters.Add(sp);
                if (cmd0.ExecuteNonQuery() != 0)
                    return true;
                else
                    return false;
            }
        }//驾照补换登记

        public static bool RegisterPlate(plate p)
        {
            db0.open();
            using (db0.sqlc)
            {
                string sql = "update [Linfo] set [state]='@state' where [llicenseno]='@id'";
                SqlCommand cmd0 = new SqlCommand(sql, db0.sqlc);
                SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("id",p.Carno),
                    new SqlParameter("state",p.State)
                };
                cmd.Parameters.Add(sp);
                if (cmd0.ExecuteNonQuery() != 0)
                    return true;
                else
                    return false;
            }
        }//号牌补换登记

        public static bool RegisterExam(driver d)
        {
            return AddInfo(d);
        }//驾考报名

        public static int GetExamReCount()
        {
            db0.open();
            using (db0.sqlc)
            {
                string sql = "select count(*) from [Pinfo] where [pdrivingno] like 'jkbm#%'";
                SqlCommand cmd = new SqlCommand(sql, db0.sqlc);
                int num =Convert.ToInt32(cmd.ExecuteScalar());
                return num;
            }
        }//获取考试编号
    }
}
