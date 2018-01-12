using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDAL
{
    public class lisence
    {
        private string licenseno;
        private string type;
        private DateTime date;
        private int record;
        private string state;

        public string Licenseno { get { return this.licenseno; } set { this.licenseno = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
        public DateTime Date { get { return this.date; } set { this.date = value; } }
        public int Record { get { return this.record; } set { this.record = value; } }
        public string State { get { return this.state; } set { this.state = value; } }
    }
}
