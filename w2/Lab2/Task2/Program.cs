using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static bool Check(int a)
        {
            if (a == 1)
                return false;
            for (int i = 2; i < Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }
        static string Ans(string s)
        {
            string res = "";
            string[] p = s.Split();

            foreach(var q in p)
            {
                int temp = int.Parse(q);
                if (Check(temp))
                {
                    res = res + " " + temp;
                }

            }
            return res.Trim();
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\DzSee\Documents\pp2\w2\Lab2\for T2.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();

            fs.Close();
            sr.Close();

            string res = Ans(line);

            FileStream fs_2 = new FileStream(@"C:\Users\DzSee\Documents\pp2\w2\Lab2\for T2_end.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs_2);

            sw.WriteLine(res);

            sw.Close();
            fs_2.Close();

        }
    }
}
