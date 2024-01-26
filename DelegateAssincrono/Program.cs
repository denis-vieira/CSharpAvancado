using System;
using System.Threading;

namespace DelegateAssincrono
{
    internal class Program
    {
        private static bool calculando;
        static void Main(string[] args)
        {
            CalcularPi calcularPi = CalcularSerieGregory;
            //decimal pi = calcularPi();

            calcularPi.BeginInvoke(CalculoFinalizado, calcularPi);
            calculando = true;
            while (calculando)
            {
                Console.WriteLine("Calculando...");
                Thread.Sleep(1000);
            }
        }

        static void CalculoFinalizado(IAsyncResult ar)
        {
            CalcularPi calcular = (CalcularPi)ar.AsyncState;
            calculando = false;

            decimal pi = calcular.EndInvoke(ar);
            Console.WriteLine("PI = " + pi);
        }

        static decimal CalcularSerieGregory()
        {
            int numIteracoes = 20000000;

            decimal soma = 0;
            for (int i = 0; i < numIteracoes; i++)
            {
                int s;
                if (i % 2 == 0)
                {
                    s = 1;
                }
                else
                {
                    s = -1;
                }

                soma += (decimal)s / (2 * i + 1);
            }

            decimal pi = soma * 4;
            return pi;
        }
    }
}
public delegate decimal CalcularPi();
