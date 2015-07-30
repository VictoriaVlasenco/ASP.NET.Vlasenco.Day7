using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task1Library;
using Task3Library;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmClockMenager menager = new AlarmClockMenager();
            OnePeople p = new OnePeople();
            AnotherPeople ap = new AnotherPeople();
            p.Register(menager);
            menager.SetAlarmClock(8000);
            menager.SetAlarmClock(6000);
            menager.SetAlarmClock(1000);
            Thread.Sleep(7000);
            ap.Register(menager);

            //CustomQueue<int> q = new CustomQueue<int>();
            //for (int i = 0; i < 1; i++)
            //{
            //    q.Enqueue(i);
            //}
            //foreach (var i in q)
            //{
            //    Console.WriteLine(i);
            //}
            //q.Dequeue();
            //foreach (var i in q)
            //{
            //    Console.WriteLine(i);
            //}

            //foreach (long i in Fibonacci.GetNumbers(2))
            //{
            //    Console.WriteLine(i);
            //}

            Console.Read();
        }
    }
}
