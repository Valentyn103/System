using System;
using System.Threading;

namespace DeadLock
{
    class DeadLockClass
    {
        static void Main(string[] args)
        {
            DeadLockClass dlc = new DeadLockClass();
            Console.WriteLine("123");
            Monitor.Enter(dlc);
            dlc = null;
            Console.WriteLine("456");
            GC.Collect(0);
            GC.WaitForPendingFinalizers();
            Console.WriteLine("789");

            Console.WriteLine("Эта строка не будет напечатана");
        }

        ~DeadLockClass()
        {
            lock (this)
            {
                Console.WriteLine("Запись лог-файла");
            }
        }
    }
}
