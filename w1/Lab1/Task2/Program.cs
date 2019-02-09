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

        public Student(string s, string ss)
        {
            name = s;
            id = ss;
        }
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(name + " " + id + " " + year);
            ++year;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            string l = Console.ReadLine();
            string[] line = l.Split();
            string s = line[0];
            string ss = line[1];
            int y = int.Parse(line[2]);

            Student a = new Student(s, ss)
            {
                year = y
            };

            for (int i = 0; i < 4; i++)
            {
                a.Print();
            }           

        }
    }
}
