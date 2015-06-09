using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDeadLock
{

    class Program
    {
        static object a = 1;

        static void Main(string[] args)
        {

            Thread a1 = new Thread(func1);
            a1.Start();
            Console.WriteLine("qwe");
        }

        public static void func1()
        {
            Thread.Sleep(100);
            lock (a)
            {
                Thread.Sleep(100);
                func2();
            }
            Console.WriteLine("1");
        }

        public static void func2()
        {
            Thread.Sleep(100);
            lock (a)
            {
                Thread.Sleep(100);
                func1();
            }
            Console.WriteLine("2");
        }
    }
}
