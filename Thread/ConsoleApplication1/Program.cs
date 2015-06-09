using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadstart = new ThreadStart(Print);
            Thread thread = new Thread(threadstart);

            ThreadStart threadstart1 = new ThreadStart(Print1);
            Thread thread1 = new Thread(threadstart1);
            thread.Priority = ThreadPriority.Lowest;
            thread1.Priority = ThreadPriority.Highest;
            thread.Start();
            thread1.Start();
            //    for (int i = 0; i < 1000; i++)
            //       Console.Write("- ");
        }
        static void Print()
        {
            for (int i = 0; i < 300; i++)
            {
                //    Thread.Sleep(10);
                Console.SetCursorPosition(0, i);
                Console.Write(i);
            }

        }

        static void Print1()
        {
            for (int i = 0; i < 300; i++)
            {
                //  Thread.Sleep(10);
                Console.SetCursorPosition(40, i);
                Console.Write(i);
            }
        }
    }
}
