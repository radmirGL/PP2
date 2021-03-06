﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
//using Microsoft.DirectX.AudioVideoPlayback;
// eta hernya ne rabotaet 
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Main
{
    class Program
    {
        // Refresh picture
        static void Refresh(Stack<Manager> record, FileSystemInfo a)
        {
            if (a.GetType() == typeof(DirectoryInfo))
            {
                DirectoryInfo d = a as DirectoryInfo;
                record.Peek().All = d.Parent.GetFileSystemInfos();
            }
            else
            {
                FileInfo f = a as FileInfo;
                record.Peek().All = f.Directory.GetFileSystemInfos();
            }

        }
        
        static void Main(string[] args)
        {
            bool lenght_fix = true;

            DirectoryInfo start = new DirectoryInfo(@"C:\Users\DzSee\Desktop\64");
            string check_and_ask = start.FullName;

            Stack<Manager> record = new Stack<Manager>();
            ManagerMode manager_mode = ManagerMode.Directory;

            record.Push(new Manager { All = start.GetFileSystemInfos(), Selected_Element = 0, current_path = start.FullName });

            bool esc = true;
            while (esc)
            {

                if (manager_mode == ManagerMode.Directory)
                {
                    record.Peek().Output();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine();

                    if (lenght_fix == true)
                    {
                        int for_legnth = record.Peek().Selected_Element;

                        // пофиксить вывод размера, если папка пуста1
                        FileSystemInfo fsi_lenght = record.Peek().All[for_legnth];

                        if (fsi_lenght.GetType() == typeof(FileInfo))
                        {
                            FileInfo fi_lenght = fsi_lenght as FileInfo;
                            long lenght = fi_lenght.Length;
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("File lenght:  " + lenght + "  bytes");
                        }
                        else
                        {
                            DirectoryInfo dir_lenght = fsi_lenght as DirectoryInfo;
                            var files = Directory.EnumerateFiles(dir_lenght.FullName, "*", SearchOption.AllDirectories);
                            long lenght = (from file in files let FileInfo = new FileInfo(file) select FileInfo.Length).Sum();
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("File lenght:  " + lenght + "  bytes");
                        }
                    }

                }
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        record.Peek().Selected_Element++;
                        break;

                    case ConsoleKey.UpArrow:
                        record.Peek().Selected_Element--;
                        break;

                    case ConsoleKey.Enter: // open file or directory
                        int last_element_enter = record.Peek().Selected_Element;
                        FileSystemInfo fsi_enter = record.Peek().All[last_element_enter];

                        if (fsi_enter.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directory_enter = fsi_enter as DirectoryInfo;
                            if (System.IO.Directory.GetDirectories(fsi_enter.FullName).Length + System.IO.Directory.GetFiles(fsi_enter.FullName).Length > 0)
                            {
                                lenght_fix = false;
                            }
                            record.Push(new Manager { All = directory_enter.GetFileSystemInfos(), Selected_Element = 0, current_path = directory_enter.FullName });
                        }
                        else if (fsi_enter.GetType() == typeof(FileInfo))
                        {

                            FileInfo fi_enter = fsi_enter as FileInfo;
                            string check_ext = Path.GetExtension(fi_enter.FullName);
                            if (check_ext == ".exe")
                            {
                                System.Diagnostics.Process.Start(fi_enter.FullName);
                            }
                            else if (check_ext == ".jpg" || check_ext == ".bmp" || check_ext == ".gif" || check_ext == ".gif")
                            {
                                Form1 try_it = new Form1(fi_enter);
                                Application.Run(try_it);
                            }
                            else if (check_ext == ".txt" || check_ext == ".docx" || check_ext == ".rtf" )
                            {
                                manager_mode = ManagerMode.File;


                                FileStream fileStream_enter = new FileStream(fsi_enter.FullName, FileMode.Open, FileAccess.Read);
                                StreamReader streamReader_enter = new StreamReader(fileStream_enter);
                               
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Clear();

                                Console.WriteLine(streamReader_enter.ReadToEnd());

                                streamReader_enter.Close();
                                fileStream_enter.Close();
                            }
                        }
                        Console.ResetColor();
                        break;

                    case ConsoleKey.RightArrow: // same as enter
                        int last_element_enter_2 = record.Peek().Selected_Element;
                        FileSystemInfo fsi_enter_2 = record.Peek().All[last_element_enter_2];

                        if (fsi_enter_2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directory_enter_2 = fsi_enter_2 as DirectoryInfo;
                            record.Push(new Manager { All = directory_enter_2.GetFileSystemInfos(), Selected_Element = 0, current_path = directory_enter_2.FullName });
                        }
                        else if (fsi_enter_2.GetType() == typeof(FileInfo))
                        {
                            FileInfo fi_enter = fsi_enter_2 as FileInfo;
                            string ext = Path.GetExtension(fi_enter.FullName);
                            if (ext == ".exe")
                            {
                                System.Diagnostics.Process.Start(fi_enter.FullName);
                            }
                            else
                            {
                                manager_mode = ManagerMode.File;
                                FileStream fileStream_enter_2 = new FileStream(fsi_enter_2.FullName, FileMode.Open, FileAccess.Read);
                                StreamReader streamReader_enter_2 = new StreamReader(fileStream_enter_2);

                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Clear();

                                Console.WriteLine(streamReader_enter_2.ReadToEnd());

                                streamReader_enter_2.Close();
                                fileStream_enter_2.Close();
                            }
                        }
                        Console.ResetColor();
                        break;

                    case ConsoleKey.Backspace: // back to the last directory or out from the file
                        int last_element_backspace = record.Peek().Selected_Element;
                        // fix sdelat' 
                        FileSystemInfo fsi_backspace = record.Peek().All[last_element_backspace];

                        if (manager_mode == ManagerMode.Directory)
                        {
                            if (fsi_backspace.GetType() == typeof(FileInfo))
                            {
                                FileInfo di_backspace = fsi_backspace as FileInfo;
                                string check = di_backspace.Directory.FullName;

                                if (check_and_ask != check)
                                {
                                    record.Pop();
                                }
                                else
                                    MessageBox.Show("YOU CAN'T LEAVE FROM THE ROOT DIRECTORY!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else if (fsi_backspace.GetType() == typeof(DirectoryInfo))
                            {
                                DirectoryInfo di_backspace = fsi_backspace as DirectoryInfo;
                                string check = di_backspace.Parent.FullName;

                                if (check_and_ask != check)
                                {
                                    record.Pop();
                                }
                                else
                                    MessageBox.Show("YOU CAN'T LEAVE FROM THE ROOT DIRECTORY!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            manager_mode = ManagerMode.Directory;
                        }


                        break;

                    case ConsoleKey.LeftArrow: // same as backspace
                        int last_element_left = record.Peek().Selected_Element;
                        FileSystemInfo fsi_left = record.Peek().All[last_element_left];

                        if (manager_mode == ManagerMode.Directory)
                        {
                            if (fsi_left.GetType() == typeof(FileInfo))
                            {
                                FileInfo di_left = fsi_left as FileInfo;
                                string check = di_left.Directory.FullName;

                                if (check_and_ask != check)
                                {
                                    record.Pop();
                                }
                                else
                                    MessageBox.Show("YOU CAN'T LEAVE FROM THE ROOT DIRECTORY!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else if (fsi_left.GetType() == typeof(DirectoryInfo))
                            {
                                DirectoryInfo di_left = fsi_left as DirectoryInfo;
                                string check = di_left.Parent.FullName;

                                if (check_and_ask != check)
                                {
                                    record.Pop();
                                }
                                else
                                    MessageBox.Show("YOU CAN'T LEAVE FROM THE ROOT DIRECTORY!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            manager_mode = ManagerMode.Directory;
                        }


                        break;

                    case ConsoleKey.R: // rename file or directory
                        int last_element_R = record.Peek().Selected_Element;
                        FileSystemInfo fsi_R = record.Peek().All[last_element_R];

                        if (fsi_R.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directory_R = fsi_R as DirectoryInfo;

                            Console.Clear();

                            Console.WriteLine("Enter new name for directory:");
                            string new_name_directory = Console.ReadLine();

                            try
                            {
                                // vot eta hernya ne rabotaet
                                //Directory.Move(directory_R.FullName, directory_R.FullName.Replace(directory_R.Name, new_name_directory));

                                // a eta rabotaet
                                directory_R.MoveTo(Path.Combine(directory_R.Parent.FullName, new_name_directory));
                            }
                            catch
                            {
                                MessageBox.Show("SUCH NAME ALREADY EXISTS!" + "\n" + "PLEASE REPEAT PROCEDURE", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            // Refresh picture
                            Refresh(record, fsi_R);
                        }
                        else
                        {
                            Console.Clear();

                            Console.WriteLine("Enter new name for file:");
                            string new_name_file = Console.ReadLine();
                            new_name_file = new_name_file + ".txt";

                            try
                            {
                                //File.Move(Path.Combine(fsi_R.FullName, new_name_file));
                                File.Move(fsi_R.FullName, fsi_R.FullName.Replace(fsi_R.Name, new_name_file));
                            }
                            catch
                            {
                                MessageBox.Show("SUCH NAME ALREADY EXISTS!" + "\n" + "PLEASE REPEAT PROCEDURE", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            // Refresh picture 
                            Refresh(record, fsi_R);
                        }
                        break;

                    case ConsoleKey.Delete:  // delete file or directory                       
                        int last_element_delete = record.Peek().Selected_Element;
                        FileSystemInfo fsi_delete = record.Peek().All[last_element_delete];

                        DialogResult ans = MessageBox.Show("Are you sure?", "Yes Or NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (ans == DialogResult.Yes)
                        {
                            if (fsi_delete.GetType() == typeof(DirectoryInfo))
                            {
                                DirectoryInfo di_delete = fsi_delete as DirectoryInfo;
                                di_delete.Delete();

                                // Refresh picture
                                Refresh(record, fsi_delete);

                                record.Peek().Selected_Element--;
                            }
                            else
                            {
                                FileInfo fi_delete = fsi_delete as FileInfo;
                                fi_delete.Delete();

                                // Refresh picture
                                Refresh(record, fsi_delete);

                                record.Peek().Selected_Element--;
                            }
                        }
                        if (ans == DialogResult.No)
                        {
                            Refresh(record, fsi_delete);
                        }
                        break;

                    case ConsoleKey.Escape:

                        esc = false;
                        break;

                    case ConsoleKey.Y:
                        
                        break;








                }
            }
        }
    }
}
