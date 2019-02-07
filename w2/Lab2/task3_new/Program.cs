using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3_new
{
    class Program
    {
        static void Main(string[] args)
        {
            var Directories = new DirectoryInfo(@"C:\Users\DzSee\Desktop\64").GetDirectories("*.*", SearchOption.AllDirectories);
            // Directories.ToList();
            foreach(string f in Directories)
            {
                Console.WriteLine(Path.GetFileName(f));
            }
              //  Console.WriteLine(Path.GetFile(Dir));
        }
    }
}
