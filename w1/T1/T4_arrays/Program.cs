using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] a = new string[100, 100];

            string temp = Console.ReadLine();
            int n = int.Parse(temp);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    a[i, j] = "[*]";
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
