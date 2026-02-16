using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {

            //1. Technique (write a query looks like sql query)
            //var query = from f in new DirectoryInfo(path).GetFiles()
            //            orderby f.Length descending
            //            select f;

            //foreach (var f in query.Take(5))
            //{
            //    Console.WriteLine($"{f.Name,-20}:{f.Length,10:N0}");
            //}

            //2. Technique (series of method calls)
            var query = new DirectoryInfo(path).GetFiles()
                         .OrderByDescending(f => f.Length)
                         .Take(5);
            foreach (FileInfo f in query)
            {
                Console.WriteLine($"{f.Name,-20}:{f.Length,10:N0}");
            }


        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files,new FileInfoComparer());

            for (int i=0; i<5;i++)
            {
                FileInfo f = files[i];

                Console.WriteLine($"{f.Name,-20}:{f.Length,10:N0}");
            }

        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
