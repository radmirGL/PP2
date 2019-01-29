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
            // 2d arrays of strings
            string[,] a = new string[100, 100];

            // Convert.ToInt32 - convert string out of console to integer from console string
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    // a[i,j] will take value - string "[*]"
                    a[i, j] = "[*]";
                }
            }

            // 2d array simple output
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
