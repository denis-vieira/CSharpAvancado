using System;
using System.Timers;

namespace Timers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Timer timer = new Timer(OnTimer, null, 3000, 2000);
            //Console.ReadLine();
            //timer.Dispose();
            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += OnTimer;

            timer.Start();
            Console.ReadLine();
        }

        static void OnTimer(object param)
        {
            Console.WriteLine("Timer disparado!");
        }

        static void OnTimer(object sender, ElapsedEventArgs args)
        {
            Console.WriteLine("Timer disparado");
        }
    }
}
