﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace WaitPulse
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            const int NumProdutores = 5;
            const int NumConsumidores = 1;

            Buffer buffer = new Buffer();

            for (int i = 0; i < NumProdutores; i++)
            {
                new Thread(() => Produzir(buffer)).Start();
            }

            for (int i = 0; i < NumConsumidores; i++)
            {
                new Thread(() => Consumir(buffer)).Start();
            }

            static void Produzir(Buffer buffer)
            {
                while (true)
                {
                    buffer.Produzir(random.Next(10));
                    buffer.Mostrar();
                    Thread.Sleep(1000);
                }
            }

            static void Consumir(Buffer buffer)
            {
                while (true)
                {
                    int e = buffer.Consumir();
                    buffer.Mostrar();
                    Thread.Sleep(1000);
                }
            }
        }
    }
    public class Buffer
    {
        const int Max = 10;
        readonly object sync = new object();

        Queue<int> lista = new Queue<int>();

        public void Produzir(int n)
        {
            lock (sync)
            {
                while (lista.Count == Max)
                {
                    Monitor.Wait(sync);
                }
                lista.Enqueue(n);
            }
        }

        public int Consumir()
        {
            lock (sync)
            {
                while (lista.Count == 0)
                {
                    Monitor.Wait(sync);
                }

                var n = lista.Dequeue();

                Monitor.PulseAll(sync);

                return n;
            }
        }

        public void Mostrar()
        {
            lock (sync)
            {
                Console.WriteLine("=> ");
                foreach (int e in lista)
                {
                    Console.WriteLine(e + " ");
                }
                Console.WriteLine();
            }
        }
    }
}