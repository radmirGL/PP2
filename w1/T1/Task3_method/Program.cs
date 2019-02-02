using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_method
{

    class Program
    {   // create static class array of int type    
        public static int[] Doub(int[] a)
        {
            // size of array doub will be siza of array a * 2
            int[] doub = new int[a.Length * 2];

            // just cycle for clone the elements
            for (int i = 0; i < a.Length; i++)
            {
                int temp = a[i];
                doub[2 * i] = doub[2 * i + 1] = a[i];
            }
            return doub;
        }
        // create static class which will not return any one
        // but will print some info
        static void Print_ans(int[] a)
        {
            foreach (var x in a)
            {
                Console.Write(x + " ");
            }
        }
        static void Main(string[] args)
        {
            // create n for size of array and cycle
            int n = int.Parse(Console.ReadLine());
            // string array
            // Console.ReadLine().Split(); will read string from console ans split by namespace
            string[] ss = Console.ReadLine().Split();
            // array of int size n
            int[] array = new int[n];
            
            // cycle for fuel the array
            for (int i = 0; i < n; i++)
            {
                // int.Parse - convert method string to int
                array[i] = int.Parse(ss[i]);
            }

            // call class Doub for array
            int[] ans = Doub(array);

            /*foreach(var x in array)
            {
                Console.Write(x + " ");
            }*/

            // call void Print_ans for print array
            Print_ans(ans);
        }
    }
}
