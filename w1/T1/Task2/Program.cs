using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    // created class
    class Student
    {
        // created public strings and int
        public string name;
        public string id;
        public int year;

        public Student(string s, string ss, int x)
        {
            name = s;
            id = ss;
            year = x;
        }

        // created class which will print info
        public void Print()
        {
            Console.WriteLine(name + " " + id + " " + year);
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            int y = 1;

            for (int i = 0; i < 4; i++)
            {
                // call class Student, give parametrs to class
                Student a = new Student("Tolik", "12345", y);
                Student b = new Student("Zheka", "12345", y);

                a.Print();
                b.Print();

                // inc year
                ++y;
            }

            
        }
    }
}
