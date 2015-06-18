using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(100, "Q", 20);
            bank.Name = "w";
            bank.Money = 412412;
        }
    }

    class Bank
    {
        private int money;
        private string name;
        private int percent;
        public int Money
        {
            set
            {
                money = value;
Threadsleep()
            }
            get { return money; }
        }
        public string Name
        {
            set
            {
                name = value;
Threadsleep()
            }
            get { return name; }
        }
        public int Percent
        {
            set
            {  
                percent = value;
             Threadsleep()
            }
            get { return percent; }
        }

        public Bank(int money, string name, int percent)
        {
            Money = money;
            Name = name;
            Percent = percent;
        }
        public void Threadsleep()
        {
            Thread.Sleep(10);
            Thread thread = new Thread(SaveFile);
            thread.Start();
        }
        public void SaveFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\MyBank.txt"))
            {
                file.WriteLine(Money.ToString() + " | " + Name + " | " + Percent.ToString());
            }
        }
    }
}
