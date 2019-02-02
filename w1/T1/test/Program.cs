using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string[] s = new string[256];
            s = Console.ReadLine().Split();

            for ( int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(s[i]);
            }

            var ar = (int[])a.Clone();
            for  ( int i = 0; i < ar.Count(); i++)
            {
                Console.Write(ar[i] + " ");
            }
        }
    }
}
