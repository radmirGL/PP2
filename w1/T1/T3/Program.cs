using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Convert.ToInt32(Console.ReadLine()) - fast convert string from console to integer
            int forforik = Convert.ToInt32(Console.ReadLine());
            // Console.ReadLine().Split() - read the string from console and split this string by "namespace"
            string[] num2 = Console.ReadLine().Split();

            for (int i = 0; i < forforik; i++)
            {
                // int.Parse - convert method from string to int 
                int temp = int.Parse(num2[i]);
                for ( int j = 1; j <= 2; j++)
                {
                    // output
                    Console.Write(temp + " ");
                }
            }
        }
    }
}
