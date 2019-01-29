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
            // i'll exclude 1 bcs every number must divides into 1
            if (abc == 1)
                return false;
            // simple cycle 
            // Math.Sqrt(abc) command which takes the root of my int abc
            for (int i = 2; i <= Math.Sqrt(abc); i++)
            {
                // if our number was divided by i
                // that means number isnt prime
                // return false to bool

                if (abc % i == 0)
                    return false;
            }
            // if number not divided by i
            // thath means number is prime
            // return true to bool
            return true;
        }

        static void Main(string[] args)
        {
            // created integers
            int n, cnt = 0;
            // Convert.ToInt32 - convert string out of console to integer from console string
            n = Convert.ToInt32(Console.ReadLine());
            // created array of integers size (n)
            int[] ar = new int[n];
            // created array of integers size (5050) 
            int[] ans = new int[5050];
            // created array of strings size (100)
            string[] ss = new string[100];

            // in array of string push the string from console and sptit it by namespace
            // ex : string - "1 2 3 4 5" will splited like "1" , "2", etc
            ss = Console.ReadLine().Split();

            // cycle
            for (int i = 0; i < n; i++)
            {
                // in array of integers push the string from array pf strings
                // and convert strings to int 
                // int.Parse(ss[i]) - convert string from ss[] to integer
                // господи, на кой хрен я это все пишу ?
                ar[i] = int.Parse(ss[i]);

                // call our class Prime
                if (Prime(ar[i]))
                {
                    cnt++;
                }
            }
            // output the cnt, which counted prime numbers 
            Console.WriteLine(cnt + "\n");

            for (int i = 0; i < ar.Count(); i++)
            {
                // call our class Prime
                if (Prime(ar[i]))
                {
                    // outout ar[i] + namespace
                    Console.Write(ar[i] + " ");
                }
            }

        }
    }
}
