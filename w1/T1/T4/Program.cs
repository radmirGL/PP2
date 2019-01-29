using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Convert.ToInt32(Console.ReadLine()) - fast convert string from console to integer
            int numOr = Convert.ToInt32(Console.ReadLine());

            for ( int i = 0; i < numOr; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    // output
                    Console.Write("[*]");
                }
                // "red line"
                Console.WriteLine();
            }



        }
    }
}
