using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Print_info(FileSystemInfo fi, int nmspc)
        {
            string s = new string(' ', nmspc);
            s = s + fi.Name;
            Console.WriteLine(s);

            if ( fi.GetType() ==  typeof(DirectoryInfo))
            {
                var v = (fi as DirectoryInfo).GetFileSystemInfos();
                foreach (var n in v)
                {
                    Print_info(n, nmspc + 3);
                }
            }

        }
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\DzSee\Desktop\64");
            Print_info(di, 1);
        }
    }
}
