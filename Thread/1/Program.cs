using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart Lis = new ThreadStart(LisenderClient);
            Thread LisenerThread = new Thread(Lis);
            LisenerThread.IsBackground = false;
            LisenerThread.Start();
        }
        static void LisenderClient()
        {
                ParameterizedThreadStart UserDel = new ParameterizedThreadStart(UserThreadFund);
                Thread UserWorkThread = new Thread(UserDel);
                UserWorkThread.Start(new List<String> { "a", "b","c" });
        }
        static void UserThreadFund(List<String> lst)
        {
            for (int i = 0; i < lst.Count; i++)
                Console.WriteLine(lst[i].ToString());
        }
    }
}
