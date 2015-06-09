using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static double s1 = 0;
        static double s2 = 0;
        static double s3 = 0;
        static void Main(string[] args)
        {
            Thread thread = new Thread(Func2);
            thread.Start();
            thread.Join();
            Thread thread1 = new Thread(Func3);
            thread1.IsBackground = true;
            thread1.Start();
            Func1();
 
            Console.WriteLine(s1 + " || " + s2 + " || "+ s3);
        }
        static void Func1()
        {
            for (double i = 0; i < 100; i++)
                s1 += i;
            Console.WriteLine("1");

        }

        static void Func2()
        {
            for (double i = 0; i < 100000; i++)
               s2 += Math.Sqrt(i);
            Console.WriteLine("2");
           
        }
        static void Func3()
        {
            for (double i = 0; i < 100000; i++)
                s3 += i*i;
            Console.WriteLine("3");

        }
    }
}
