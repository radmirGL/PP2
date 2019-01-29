using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    class Program
    {
        public static bool Prime(int abc)
        {
            if (abc == 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(abc); i++)
            {
                if (abc % i == 0)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int n, cnt = 0;
            n = Convert.ToInt32(Console.ReadLine());
            int[] ar = new int[n];
            int[] ans = new int[5050];
            string[] ss = new string[100];

            ss = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                ar[i] = int.Parse(ss[i]);

                if (Prime(ar[i]))
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt + "\n");

            for (int i = 0; i < ar.Count(); i++)
            {
                if (Prime(ar[i]))
                {
                    Console.Write(ar[i] + " ");
                }
            }

        }
    }
}
