using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDAL
{
    public class car
    {
        private string licenseno;
        private bool iflicense;
        private string carno;
        private string motorc;
        private DateTime ydate;
        private DateTime ldate;
        private string color;
        private string brand;

        public string Licenseno { get { return this.licenseno; } set { this.licenseno = value; } }
        public bool Iflicense { get { return this.iflicense; } set { this.iflicense = value; } }
        public string Carno { get { return this.carno; } set { this.carno = value; } }
        public string Motor { get { return this.motorc; } set { this.motorc = value; } }
        public DateTime Ydate { get { return this.ydate; } set { this.ydate = value; } }
        public DateTime Ldate { get { return this.ldate; } set { this.ldate = value; } }

        public string Color { get { return this.color; } set { this.color = value; } }
        public string Brand { get { return this.brand; } set { this.brand = value; } }

    }
}
