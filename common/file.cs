using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class file
    {
        string path = @"d:\车辆管理系统文档";
        public string  fload(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("gb2312"));
            String line;
            string r = "";
            while ((line = sr.ReadLine()) != null)
            {
                r+=line+"\r\n";
            }
            return r;
        }

        public void fwrite(string path,string res)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(res);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public void dcreate()
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                directoryInfo.Create();
            }
        }

        public void dopen()
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
    }
}
