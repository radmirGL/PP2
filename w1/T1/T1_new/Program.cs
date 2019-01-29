using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_new
{
    class Program
    {
        public static bool Prime(int x)
        {
            if (x == 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            int cnt = 0;
            string size_of_array = Console.ReadLine();
            string numbers_in_array = Console.ReadLine();

            string[] num = numbers_in_array.Split();

            int forforik = int.Parse(size_of_array);
            Queue<int> q = new Queue<int>();
            //int[] a = new int[forforik];

            for (int i = 0; i < forforik; i++)
            {
                int temp = int.Parse(num[i]);

                if (Prime(temp))
                {
                    cnt++;
                    q.Enqueue(temp);
                    //a[i] = temp;

                }
            }

            Console.WriteLine(cnt + "\n");

            for (int i = 0; i < q.Count(); i++)
            {
                int temp2 = q.Dequeue();
                Console.WriteLine(temp2);
            }
           
        }
    }
}
