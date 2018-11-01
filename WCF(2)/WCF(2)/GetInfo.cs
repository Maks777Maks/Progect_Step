using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscInfo
{
    public class GetInfo : IGetInfo
    {
        public string[] GetDiskInfo(string path)
        {
            List<string> strarr = new List<string>();
            DirectoryInfo info = new DirectoryInfo(path);
            foreach(var i in info.GetDirectories())
            {
                
                strarr.Add(i.Name + "/t/tFolder");
            }
            foreach (var i in info.GetFiles())
            {
                strarr.Add(i.Name + "/t/tFile");
            }
            return strarr.ToArray();
        }
    }
}
