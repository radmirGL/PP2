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

        public FileSystemInfo[] Vse_cho_est
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
                if (value >= Vse_cho_est.Length)
                {
                    selected_element = 0;
                }
                else if (value < 0)
                {
                    selected_element = Vse_cho_est.Length - 1;
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

        }

        public void Output()
        {
            Console.Clear();
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            //Console.Clear();
            Console.WriteLine("_____________[ FILE MANAGER ]_____________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Current path:  ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(current_path + "\n");
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < Vse_cho_est.Length; i++)
            {

                if (i == Selected_Element)
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                else
                    Console.BackgroundColor = ConsoleColor.Black;

                
                Console.WriteLine(i + 1 + ".  " + Vse_cho_est[i].Name);
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
