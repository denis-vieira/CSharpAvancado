using System;

namespace Indexadores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Temperaturas t = new Temperaturas();
            //int t1 = t[12];
            //Console.WriteLine(t1);
            //t[12] = 30;
            //Console.WriteLine(t[12]);
            Console.WriteLine(t["Mar"]);
        }
    }

    class Temperaturas
    {
        int[] temperaturas = new int[] { 30, 31, 29, 27, 22, 15, 16, 18, 23, 26, 27, 28 };

        public int this[int mes]
        {
            get
            {
                return temperaturas[mes - 1];
            }
            set
            {
                temperaturas[mes - 1] = value;
            }
        }

        public int this[string mes]
        {
            get
            {
                switch (mes)
                {
                    case "Jan":
                        return temperaturas[0];
                    case "Fev":
                        return temperaturas[1];
                    case "Mar":
                        return temperaturas[2];
                        default: return -1;
                }
            }
        }
    }
}
