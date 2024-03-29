﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace FrogRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Corrida c = new Corrida(10, 500);
            c.Iniciar();
        }
    }

    class Corrida
    {
        int maxDistancia;
        Sapo[] sapos;
        CountdownEvent countDown;
        List<Sapo> ranking = new List<Sapo>();
        Stopwatch cronometro;

        public Corrida(int numSapos, int maxDistancia)
        {
            this.maxDistancia = maxDistancia;
            sapos = new Sapo[numSapos];
            countDown = new CountdownEvent(numSapos);
            cronometro = new Stopwatch();

            for (int i = 0; i < sapos.Length; i++)
            {
                sapos[i] = new Sapo();
                sapos[i].Id = i + 1;
                sapos[i].Chegou += SapoChegou;
            }
        }

        private void SapoChegou(Sapo sapo)
        {
            lock (this)
            {
                sapo.Tempo = cronometro.Elapsed;
                ranking.Add(sapo);
            }
        }

        public void Iniciar()
        {
            cronometro.Start();
            for (int i = 0; i < sapos.Length; i++)
            {
                int j = i;
                new Thread(() => sapos[j].Pular(maxDistancia, countDown)).Start();
            }

            countDown.Wait();
            cronometro.Stop();
            Console.WriteLine("A corrida acabou!\n");

            int lugar = 1; 
            foreach(Sapo sapo in ranking)
            {
                Console.WriteLine("{0}o. lugar\tSapo {1:00}\t{2:00}:{3:000}", lugar++, sapo.Id, sapo.Tempo.Seconds, sapo.Tempo.Milliseconds);
            }

        }
    }

    class Sapo
    {
        public int Id { get; set; }

        public int Distancia { get; private set; }

        public TimeSpan Tempo { get; set; }

        static Random random = new Random();

        public event Action<Sapo> Chegou;

        public void Pular(int maxDistancia, CountdownEvent countdown)
        {
            while (true)
            {
                Distancia += random.Next(60);
                Console.WriteLine($"Sapo {Id} alcançou {Distancia}");

                if (Distancia >= maxDistancia)
                {
                    if (Chegou != null)
                    {
                        Chegou(this);
                    }
                    break;
                }

                Thread.Sleep(300);
            }

            countdown.Signal();
        }
    }
}
