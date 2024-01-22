using System;

namespace CastingCustomizado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var la = new LetraAlfabeto('B');

            //explicit
            //char c = (char)la;
            //char c = la; implicit
            //Console.WriteLine(c);

            LetraAlfabeto la2 = 'X';
            //Console.WriteLine(la2);
        }
    }

    class LetraAlfabeto
    {
        readonly char caractere;

        public LetraAlfabeto(char caractere)
        {
            this.caractere = char.ToUpper(caractere);
        }

        public static explicit operator char(LetraAlfabeto la)
        {
            return la.caractere;
        }

        public static implicit operator LetraAlfabeto(char c)
        {
            return new LetraAlfabeto(c);
        }
    }
}
