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
            string temp = Console.ReadLine();
            int numOr = int.Parse(temp);

            for ( int i = 0; i < numOr; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("[*]");
                }
                Console.WriteLine();
            }



        }
    }
}
