using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class FarManager
    {
        public string path;
        public int cursor;
        public bool ok;
        DirectoryInfo directory = null;
        FileSystemInfo currentfs = null;
        public int size;

        public FarManager()
        {
            cursor = 0;
        }

        public FarManager(string path)
        {
            this.path = path;
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            size = fs.Length;
            cursor = 0;
            ok = true;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                currentfs = fs;
            }
            else
                if (fs.GetType() == typeof(DirectoryInfo))
                Console.ForegroundColor = ConsoleColor.White;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            for (int i = 0, k = 0; i < fs.Length; i++)
            {
                if (ok == false && fs[i].Name[0] == '.') continue;
                else
                {
                    Color(fs[i], k);
                    Console.Write(k + 1);Console.Write('.');
                    Console.WriteLine(fs[i].Name);
                    k++;
                }
            }
        }

        public void CalcSz()
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            for (int i = 0; i < fs.Length; i++)
            {
                if (ok == false && fs[i].Name[0] == '.')
                    size--;
            }
        }

        public void Start(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            CalcSz();
            Show();

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.Start();
        }
    }
}
