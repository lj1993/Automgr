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

namespace temporary
{
    public partial class law : Form
    {
        public law()
        {
            InitializeComponent();
            file f0=new file();
            string str2 = Environment.CurrentDirectory;
            textBox1.Text = f0.fload(str2+@"..\..\..\res\jf.txt");
            textBox1.Select(0,0);
        }        
    }
}
