﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static void Spaces(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("    ");
            }
        }

        public static void Direc(DirectoryInfo dir, int level)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                Spaces(level);
                Console.WriteLine(f.Name);
            }

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                Spaces(level);
                Console.WriteLine(d.Name);
                Direc(d, level + 1);
            }

        }

        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\DzSee\Desktop\64");

            Direc(directory, 0);

            Console.ReadKey();
        }
    }
}