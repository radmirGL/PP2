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
            // created int
            // Convert.ToInt32(Console.ReadLine()) - will convert string from console to int

            int forforik = Convert.ToInt32(Console.ReadLine());

            
            // created array of string
            
            string[] num2 = new string[256];

            // in array of string push the string from console and sptit it by namespace
            // ex : string - "1 2 3 4 5" will splited like "1" , "2", etc
            num2 = Console.ReadLine().Split();

            for (int i = 0; i < forforik; i++)
            {
                // created integer
                // int.Parse(num2[i]) will convert string of array to int
                int temp = int.Parse(num2[i]);

                // second for for (:D) clone the numbers
                for ( int j = 1; j <= 2; j++)
                {
                    // output
                    Console.Write(temp + " ");
                }
            }
        }
    }
}
