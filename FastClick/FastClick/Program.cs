using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FastClick
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(1, 5000));
            Console.WriteLine("PRESS KEY.PRESS KEY.PRESS KEY.PRESS KEY.PRESS KEY.PRESS KEY.");
            stopwatch.Start();
            Console.ReadKey();
            stopwatch.Stop();
            Console.WriteLine("Time : {0}", stopwatch.Elapsed);
        }
    }
}
