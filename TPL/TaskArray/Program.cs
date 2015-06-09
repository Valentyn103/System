using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int[]> a = new List<int[]>();
            Stopwatch stopwatch = new Stopwatch();
            a.Add(new int[20000]);
            a.Add(new int[20000]);
            foreach (var b in a)
            {
                for (int i = 0; i < 20000; i++)
                    b[i] = rand.Next(0, 20000);
            }
            stopwatch = Stopwatch.StartNew();
            foreach (var b in a)
            {
                Task<int[]> task = new Task<int[]>(() =>
                {
                    SortBublefunc(b);
                    Thread.Sleep(100);
                    return b;
                });
                task.Start();
                var res = task.Result;
                Console.WriteLine(res);
            }
           
            Console.WriteLine("Time : " + stopwatch.ElapsedMilliseconds);
        }
        public static int[] SortBublefunc(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length - 1; i++)
                for (int j = mas.Length - 1; j > i; j--)
                    if (mas[j] < mas[j - 1])
                    {
                        temp = mas[j - 1];
                        mas[j - 1] = mas[j];
                        mas[j] = temp;
                    }
            return mas;
        }
    }
}
