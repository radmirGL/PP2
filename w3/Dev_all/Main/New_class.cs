using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Manager
    {

        public FileSystemInfo[] All
        {
            get;
            set;
        }

        int selected_element;
        public string current_path;


        public int Selected_Element
        {
            get
            {
                return selected_element;
            }
            set
            {
                if (value >= All.Length)
                {
                    selected_element = 0;
                }
                else if (value < 0)
                {
                    selected_element = All.Length - 1;
                }
                else selected_element = value;
            }
        }
        public void Output_past()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("UP ARROW ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- move to the up");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("DOWN ARROW ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- move to the down");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("RIGHT ARROW or ENTER ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- open directoty or file");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("LEFT ARROW or BACKSPACE ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- left from directory or file");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("R ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- rename");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("DEL ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- delete directory or file");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- out from the programm");

        }

        public void Output()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            //Console.Clear();
            Console.WriteLine("_________________[ FILE MANAGER ]_________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Current path:  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(current_path + "\n");
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < All.Length; i++)
            {

                if (i == Selected_Element)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;

                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;

                Console.WriteLine(i + 1 + ".  " + All[i].Name);
                Console.ResetColor();
            }
            Console.WriteLine("\n");
            Output_past();
        }

    }
   

    enum ManagerMode
    {
        File, Directory
    }
}
