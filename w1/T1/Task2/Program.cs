using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        public string name;
        public string id;
        public int year;

        public Student(string s, string ss, int x)
        {
            name = s;
            id = ss;
            year = x;
        }
        public void Print()
        {
            Console.WriteLine(name + " " + id + " " + year);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string ss = Console.ReadLine();
            int y = int.Parse(Console.ReadLine());

            Student a = new Student(s, ss, y);

            for (int i = 0; i < 4; i++)
            {
                a.Print();
                ++y;
            }           
        }
    }
}
