﻿using System;
using System.Threading;

namespace Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator g = new NumberGenerator();
            g.OnGenerated += NumberGenerated;
            g.Start();
        }

        static void NumberGenerated(object sender, NumberEventArgs args)
        {
            Console.WriteLine("Numero gerado: " + args.Number);
        }
    }

    //public delegate void NumberHandler(int n);
    public delegate void NumberHandler(object sender, NumberEventArgs args);

    class NumberGenerator
    {
        public event NumberHandler OnGenerated;

        Random r = new Random();

        public void Start()
        {
            while (true)
            {
                int n = r.Next(100);
                if (OnGenerated != null)
                {
                    NumberEventArgs args = new NumberEventArgs() { Number = n };
                    OnGenerated(this, args);
                }
                Thread.Sleep(1000);
            }
        }
    }

    public class NumberEventArgs : EventArgs
    {
        public int Number { get; set; }
    }
}
