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
            string amount = Console.ReadLine();
            string numbers = Console.ReadLine();

            int forforik = int.Parse(amount);
            string[] num2 = numbers.Split();

            for (int i = 0; i < forforik; i++)
            {
                int temp = int.Parse(num2[i]);
                for ( int j = 1; j <= 2; j++)
                {
                    Console.Write(temp + " ");
                }
            }
        }
    }
}
