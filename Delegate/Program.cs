using System;
using System.Threading;

namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Semaforo s = new Semaforo();

            for (int i = 1; i <= 3; i++)
            {
                var car = new Carro(i);
                s.AdicionarCallBack(car.SemaforoAlterado);
            }
            //s.AdicionarCallBack(new SemaforoHandler(c.SemaforoAlterado)); forma estendida
            //s.AdicionarCallBack(c.SemaforoAlterado);
            //s.AdicionarCallBack(c2.SemaforoAlterado);
            s.Iniciar();
        }
    }

    enum Cor
    {
        VERDE,
        VERMELHO,
        AMARELO       
    }

    delegate void SemaforoHandler(Cor cor);

    class Semaforo
    {
        Cor cor = Cor.VERMELHO;
        SemaforoHandler callbacks;

        public void Iniciar()
        {
            while (true)
            {
                if(cor==Cor.VERMELHO) 
                {
                    cor = Cor.VERDE;
                }
                else if(cor == Cor.VERDE)
                {
                    cor = Cor.AMARELO;
                }
                else if(cor == Cor.AMARELO)
                {
                    cor = Cor.VERMELHO;
                }

                Console.WriteLine("Semaforo mudou para " + cor);
                callbacks(cor);

                Thread.Sleep(2000);
            }
        }

        public void AdicionarCallBack(SemaforoHandler handler)
        {
            callbacks += handler;
        }
    }

    class Carro
    {
        int id;

        public Carro(int id)
        {
            this.id = id;
        }

        public void SemaforoAlterado(Cor cor)
        {
            Console.WriteLine("Carro {0:d} notificado: cor {1}", id, cor);
        }
    }
}
