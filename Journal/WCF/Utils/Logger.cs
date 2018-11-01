using System.IO;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Utils
{
    public static class Logger
    {
        public static void Log(string msg)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\User\Source\Repos\Progect_Step\Journal\WCF\bin\Debug\log.txt", true, Encoding.Unicode))
            {
                sw.WriteLine($"{DateTime.Now}: {msg}");
            }
        }
    }
}
