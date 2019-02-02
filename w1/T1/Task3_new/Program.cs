using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_new
{
    class Try
    {
        public int[] ar = new int[500500];
        public int[] arr = new int[500500];
        public Try(int[] a)
        {
           ar = a;
        }

        public void Do()
        {
            for (int i = 0; i < ar.Count(); i++)
            {
                int temp = ar[i];
                for (int j = 1; j <= 2; j++)
                {
                    //Console.Write(temp + " ");
                    arr[i] = temp;
                    //Console.Write(arr[i] + " ");

                }
            }

            for (int i = 0; i < arr.Count(); i++)
            {
               Console.Write(arr[i] + " ");
            }
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            string[] s = new string[256];
            s = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(s[i]);
            }

            Try a = new Try(array);
            a.Do();
        }
    }
}
