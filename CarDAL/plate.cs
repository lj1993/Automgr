using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDAL
{
    public class plate
    {
        private string carno;
        private string type;
        private bool ifmaster;
        private int state;
        private string owner;

        public string Carno { get { return this.carno; } set { this.carno = value; } }
        public string Type { get { return this.type; } set { this.type = value; } }
        public bool Ifmaster { get { return this.ifmaster; } set { this.ifmaster = value; } }
        public int State { get { return this.state; } set { this.state = value; } }
        public string Owner { get { return this.owner; } set { this.owner = value; } }
    }
}
