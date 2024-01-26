using System;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine(i);
        //}

        //Parallel.For(0, 100, i =>
        //{

        //    Console.WriteLine(i);
        //});

        //Parallel.For(0, 100, (i, status) =>
        //{
        //    if(i > 10)
        //    {
        //        //status.Break();
        //        status.Stop();
        //    }

        //    Console.WriteLine(i);
        //});

        string[] array = { "A", "B", "C", "D", "E" };

        Parallel.ForEach(array, i => { Console.WriteLine(i); });

        Parallel.Invoke(Processar1, Processar2);

        Console.WriteLine();
    }

    static void Processar1()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write("-");
        }
    }

    static void Processar2()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write("+");
        }
    }

}
