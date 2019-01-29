using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        // created publis strings
        public string name;
        public string id;
        public int year;
       
        public Student(string s, string ss, int x)
        {
            
            name = s;
            id = ss;
            year = x;


           // year = sss;
        }

        // class which will print (name + " " + id + " " + year);
        public void Print()
        {
            Console.WriteLine(name + " " + id + " " + year);
        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            int year = 1;

            for (int i = 0; i < 5; i++)
            {
                // call class and give to string some info
                Student a = new Student("Jeka", "12345", year);
                Student b = new Student("Vitalya", "5641232", year);

                // call class Print
                a.Print();
                b.Print();
                // ++ the year
                year++;
            }
        }
    }
}
