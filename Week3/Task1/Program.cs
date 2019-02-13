using System;
using System.IO;

namespace Task1
{
    class FarManager
    {
        public int cursor;
        public string path;
        public int size;
        public bool ok;
        DirectoryInfo directory = null;
        FileSystemInfo currentFs = null;

        public FarManager()
        {
            cursor = 0;
        }

        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
            directory = new DirectoryInfo(path);
            size = directory.GetFileSystemInfos().Length;
            ok = true;
        }

        public void Up()
        {
            cursor--;
            if (cursor < 0) cursor = size - 1;
        }
        public void Down()
        {
            cursor++;
            if (cursor == size) cursor = 0;
        }
        public void Left()
        {
            ok = false;
            cursor = 0;
        }
        public void Right()
        {
            ok = true;
            cursor = 0;
        }


        public void Color(FileSystemInfo fs, int index)
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                currentFs = fs;
            } else

            if (fs.GetType() == typeof(DirectoryInfo))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                } else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
        }

        public void CalcSz()
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            size = fs.Length;
            if (ok == false)
                for (int i = 0; i < fs.Length; i++)
                    if (fs[i].Name[0] == '.')
                        size--;
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            for (int i = 0, k = 0; i < fs.Length; i++)
            {
                if (ok == false && fs[i].Name[0] == '.')
                {
                    continue;
                }
                Color(fs[i], k);
                Console.Write(k+1); Console.Write('.');
                Console.WriteLine(fs[i].Name);
                k++;
            }
        }

        public void Start()
        {
            ConsoleKeyInfo CK = Console.ReadKey();
            while (CK.Key != ConsoleKey.Escape)
            {
                CalcSz();
                Show();
                CK = Console.ReadKey();
                if (CK.Key == ConsoleKey.UpArrow) Up();
                if (CK.Key == ConsoleKey.DownArrow) Down();
                if (CK.Key == ConsoleKey.LeftArrow) Left();
                if (CK.Key == ConsoleKey.RightArrow) Right();
                if (CK.Key == ConsoleKey.Enter)
                {
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        path = currentFs.FullName;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string path1 = currentFs.FullName;
                        StreamReader sr = new StreamReader(path1);
                        string s1 = sr.ReadToEnd();
                        sr.Close();
                        Console.Write(s1);
                        Console.ReadKey();
                    }
                }
                if (CK.Key == ConsoleKey.Backspace)
                {
                     cursor = 0;
                     path = directory.Parent.FullName;
                }
                if (CK.Key == ConsoleKey.Delete)
                {
                    string path1 = currentFs.FullName;
                    if (currentFs.GetType() == typeof(FileInfo))
                    {
                        File.Delete(path1);
                    }
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        Directory.Delete(path1);
                    }

                }
            }
        }

    } 

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Асер/Desktop/PP2";
            FarManager FarManager = new FarManager(path);
            FarManager.Start();
        }
    }
}