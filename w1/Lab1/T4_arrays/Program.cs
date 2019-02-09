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
            // created 2d arrays
            string[,] a = new string[100, 100];

            // Convert.ToInt32(Console.ReadLine()) - fast convert string from console to integer
            int n = Convert.ToInt32(Console.ReadLine());

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
                    // output
                    Console.Write(a[i, j]);
                }
                // "red line"
                Console.WriteLine();
            }
        }
    }
}
