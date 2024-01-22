using System;
using System.Collections.Generic;

namespace Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> l = BuildList(1, 100, delegate (int n)
            //{
            //    return n * 2;
            //});

            List<int> l = BuildList(1, 100, x => x * 2);

            foreach (int i in l)
            {
                Console.WriteLine(i);
            }
        }

        static int Process(int n)
        {
            return n + 2;
        }

        static List<int> BuildList(int start, int end, ItemHandler handler)
        {
            List<int> l = new List<int>();

            l.Add(start);
            int n = handler(start);

            while (n <= end)
            {
                l.Add(n);
                n = handler(n);
            }

            return l;
        }
    }

    delegate int ItemHandler(int n);
}
