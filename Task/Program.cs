using System;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        //Task t = new Task(MostrarMensagem);
        //t.Start();

        //Task t = Task.Factory.StartNew(MostrarMensagem);
        //t.Wait();

        Task<long> t = Task.Factory.StartNew(() => CalcularFatorial(30));

        try
        {

        long fatorial = t.Result;
        Console.WriteLine(fatorial);
        }catch (AggregateException ex)
        {
            var e1 = ex.InnerException;
            Console.WriteLine(e1.Message);
            Console.WriteLine(e1.GetType());
        }

    }

    static void MostrarMensagem()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Using tasks");
    }

    static long CalcularFatorial(int n)
    {
        checked
        {
            if (n == 0) return 1;

            return n * CalcularFatorial(n - 1);
        }
    }
}
