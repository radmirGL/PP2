using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\DzSee\Documents\pp2\w2\Lab2\for_T4_create.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(fs);

            string line = "blajfakjsfklajdasd";

            wr.WriteLine(line);
            wr.Close();
            fs.Close();

            //FileInfo fi = new FileInfo(@"C:\Users\DzSee\Documents\pp2\w2\Lab2\for_T4_create.txt");
            File.Copy(@"C:\Users\DzSee\Documents\pp2\w2\Lab2\for_T4_create.txt", @"C:\Users\DzSee\Documents\pp2\w2\Lab2\for t4_copy_there\copy.txt");

            File.Delete(@"C:\Users\DzSee\Documents\pp2\w2\Lab2\for_T4_create.txt");

            

        }
    }
}
