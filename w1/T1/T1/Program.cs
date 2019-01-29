using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    class Program
    {
        // created public class bool type
        public static bool Prime(int abc)
        {
            
            // return false to bool bcs every number must divides by 1
            if (abc == 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(abc); i++)
            {
                if (abc % i == 0)
                    return false;
                // return false to bool if abc was divided by i
                // that means number isnt simple
            }
            return true;
            // return true to bool if number is prime
        }

        static void Main(string[] args)
        {
            // created integers
            int n, cnt = 0;
            // Convert.ToInt32(Console.ReadLine()) - fast convert string from console to integer
            n = Convert.ToInt32(Console.ReadLine());
            // created arrays 
            int[] ar = new int[n];
            int[] ans = new int[5050];
            string[] ss = new string[100];

            // Console.ReadLine().Split() - read the string from console and split this string by "namespace"
            ss = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                // int.Parse - convert method from string to int
                ar[i] = int.Parse(ss[i]);

                // call our class Prime
                if (Prime(ar[i]))
                {
                    cnt++;
                }
            }
            // output 
            Console.WriteLine(cnt);

            for (int i = 0; i < ar.Count(); i++)
            {
                // call our class Prime
                if (Prime(ar[i]))
                {
                    // output
                    Console.Write(ar[i] + " ");
                }
            }

        }
    }
}
