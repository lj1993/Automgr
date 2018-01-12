using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDAL
{
    public class driver
    {
        private string licenseno;
        private string dname;
        private int age;
        private string contact;
        private DateTime getdate;//考取日期
        private string address;
        private string idcard;
        private string pwd;

        public string Licenseno { get { return this.licenseno; } set { this.licenseno = value; } }
        public string Dname { get { return this.dname; } set { this.dname = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
        public string Contact { get { return this.contact; } set { this.contact = value; } }
        public DateTime Getdate { get { return this.getdate; } set { this.getdate = value; } }
        public string Address { get { return this.address; } set { this.address = value; } }
        public string Idcard { get { return this.idcard; } set { this.idcard = value; } }
        public string Pwd { get {
            if (pwd == "" && idcard != "")
            {
                string t = idcard.Substring(12, 6);
                return t;
            }
            return this.pwd; } set { this.pwd = value; } }
    }
}
