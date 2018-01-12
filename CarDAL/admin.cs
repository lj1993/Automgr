using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDAL
{
    public class admin
    {
        private int id;
        private string pwd;

        public int Id { get { return this.id; } set { this.id = value; } }
        public string Pwd { get { return this.pwd; } set { this.pwd = value; } }
    }
}
