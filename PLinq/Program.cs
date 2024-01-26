using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        IEnumerable<int> numbers = Enumerable.Range(0, 100);

        var q = from n in numbers.AsParallel()
                where n >= 50 && n <= 70
                select n;

        foreach (var n in q)
        {
            Console.WriteLine(n);
        }
    }
}

