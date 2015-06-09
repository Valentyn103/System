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
        static object b = 1;

        static void Main(string[] args)
        {
        
            Thread a1 = new Thread(func1);
            Thread b1 = new Thread(func2);
            a1.Start();
            b1.Start();
            Console.WriteLine("qwe");
        }

        public static void func1()
        {
            lock (a)
            {
                Thread.Sleep(100);
                Console.WriteLine("func1");
                lock (b)
                {
                    Console.WriteLine("ERROR1");
                }
            }
        }

        public static void func2()
        {
            lock (b)
            {
                Thread.Sleep(100);
                Console.WriteLine("func2");
                lock (a)
                {
                    Console.WriteLine("ERROR2");
                }
            }
        }
    }
}
