using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Main
{
    class Program
    {

        static void Refresh(Stack<Manager> history)
        {
            history.Pop();

            int refresh = history.Peek().Selected_Element;
            FileSystemInfo fsi_refresh = history.Peek().All[refresh];
            DirectoryInfo di_refresh = fsi_refresh as DirectoryInfo;
            history.Push(new Manager { All = di_refresh.GetFileSystemInfos(), Selected_Element = 0, current_path = di_refresh.FullName });

        }
        static void Refresh_rev(Stack<Manager> history)
        {


            int refresh = history.Peek().Selected_Element;
            FileSystemInfo fsi_refresh = history.Peek().All[refresh];
            DirectoryInfo di_refresh = fsi_refresh as DirectoryInfo;
            history.Push(new Manager { All = di_refresh.GetFileSystemInfos(), Selected_Element = 0, current_path = di_refresh.FullName });

            history.Pop();

        }
        static void Main(string[] args)
        {

            //FileSystemInfo[] for_move = new FileSystemInfo[1];
            //string old_path = "";

            DirectoryInfo start = new DirectoryInfo(@"C:\Users\DzSee\Desktop\64");
            Stack<Manager> history = new Stack<Manager>();
            ManagerMode manager_mode = ManagerMode.Directory;

            history.Push(new Manager { All = start.GetFileSystemInfos(), Selected_Element = 0, current_path = start.FullName });


            bool esc = true;
            while (esc)
            {
                if (manager_mode == ManagerMode.Directory)
                {
                    
                    history.Peek().Output();
                    Console.WriteLine("\n");
                    
                }
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        
                        history.Peek().Selected_Element++;
                        break;
                    case ConsoleKey.UpArrow:
                        history.Peek().Selected_Element--;
                        break;
                    case ConsoleKey.Enter: // open file or directory
                        int last_element_enter = history.Peek().Selected_Element;
                        FileSystemInfo fsi_enter = history.Peek().All[last_element_enter];
                        if (fsi_enter.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directory_enter = fsi_enter as DirectoryInfo;
                            history.Push(new Manager
                            {
                                All = directory_enter.GetFileSystemInfos(),
                                Selected_Element = 0,
                                current_path = directory_enter.FullName
                            });
                        }
                        else
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
                        Console.ResetColor();
                        break;
                    case ConsoleKey.RightArrow: // same as enter
                        int last_element_enter_2 = history.Peek().Selected_Element;
                        FileSystemInfo fsi_enter_2 = history.Peek().All[last_element_enter_2];
                        if (fsi_enter_2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directory_enter_2 = fsi_enter_2 as DirectoryInfo;
                            history.Push(new Manager
                            {
                                All = directory_enter_2.GetFileSystemInfos(),
                                Selected_Element = 0,
                                current_path = directory_enter_2.FullName
                            });
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
                        Console.ResetColor();
                        break;
                    case ConsoleKey.Backspace: // back to the last directory or out from the file
                        int last_element_backspace = history.Peek().Selected_Element;
                        if (manager_mode == ManagerMode.Directory)
                        {
                            
                            history.Pop();
                        }
                        else
                        {
                            manager_mode = ManagerMode.Directory;
                        }
                        break;

                    case ConsoleKey.LeftArrow: // same as backspace
                        int last_element_backspace_2 = history.Peek().Selected_Element;
                        if (manager_mode == ManagerMode.Directory)
                        {
                           
                            history.Pop();
                        }
                        else
                        {
                            manager_mode = ManagerMode.Directory;
                        }
                        break;

                    case ConsoleKey.R: // rename file or directory
                        int last_element_R = history.Peek().Selected_Element;
                        FileSystemInfo fsi_R = history.Peek().All[last_element_R];

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

                            // refresh visualy
                            Refresh(history);


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

                            // refresh visualy 
                            Refresh(history);

                        }

                        break;

                    case ConsoleKey.Delete:  // delete file or directory
                        DialogResult ans = MessageBox.Show("Are you sure?", "Yes Or NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                        {
                            int last_element_delete = history.Peek().Selected_Element;
                            FileSystemInfo fsi_delete = history.Peek().All[last_element_delete];
                            if (fsi_delete.GetType() == typeof(DirectoryInfo))
                            {
                                DirectoryInfo di_delete = fsi_delete as DirectoryInfo;
                                di_delete.Delete();

                                Refresh(history);
                            }
                            else
                            {
                                fsi_delete.Delete();

                                Refresh(history);
                            }
                        }
                        if (ans == DialogResult.No)
                        {
                            Refresh(history);
                        }
                            break;

                    
                    /* case ConsoleKey.M:                      
                       int last_element_m = history.Peek().Selected_Element;
                        FileSystemInfo fsi_m = history.Peek().All[last_element_m];
                        FileInfo fi_m = fsi_m as FileInfo;
                        for_move[0] = fi_m;
                        if (fsi_m.GetType() == typeof(FileInfo))
                        {
                            old_path = fsi_m.FullName;
                        }
                        else
                        {
                            DirectoryInfo d_m = fsi_m as DirectoryInfo;
                            old_path = d_m.FullName;
                        }
                        MessageBox.Show("Go to the new directory then press G", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case ConsoleKey.G:


                        string new_path = history.Peek().current_path;
                        FileSystemInfo fi_g = for_move[0];

                        
                         //if (!Directory.Exists(new_path))
                            //Directory.CreateDirectory(new_path);

                        File.Copy(fi_g.FullName, new_path, true);
                        Refresh(history);
                        
                        break;

                    case ConsoleKey.Escape:
                        esc = false;
                        break;
                        */
                        
                        // Создание файлов
                        // инфа о файле
                        
                        

                        

                }
            }
        }
    }
}
