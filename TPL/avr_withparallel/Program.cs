using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avr_withparallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new int[10000];
            Random rand = new Random();
            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < number.Length; i++)
                number[i] = rand.Next(0, 100);

            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                var res = number.ToList().Average();
            }
            Console.WriteLine("Time : " + stopwatch.ElapsedMilliseconds);

            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                var res = number.ToList().AsParallel().Average();
            } 
            Console.WriteLine("Time : " + stopwatch.ElapsedMilliseconds);
        }
    }
}
