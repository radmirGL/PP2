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
        static void Recur(FileSystemInfo fi, int nmspc)
        {
            string s = new string(' ', nmspc);
            s = s + fi.Name;
            Console.WriteLine(s);

            if (fi.GetType() == typeof(DirectoryInfo))
            {
                var x = (fi as DirectoryInfo).GetFileSystemInfos();

                foreach( var i in x)
                {
                    Recur(i, nmspc + 4);
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\DzSee\Desktop\64");

            Recur(di, 1);
        }
    }
}
