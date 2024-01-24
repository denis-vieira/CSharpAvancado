using System;

namespace Interlocked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Op
    {
        int value;

        public int Value
        {
            get
            {
                return value;
            }
        }

        public void Increment()
        {
            //value++;
            System.Threading.Interlocked.Increment(ref value);
        }

        public void Set(int newValue)
        {
            // this.value = value;
            System.Threading.Interlocked.Exchange(ref value, newValue);
        }

        public void CompareAndChange(int compare, int newValue)
        {
            //if (value == compare)
            //{
            //    value = newValue;
            //}

            System.Threading.Interlocked.CompareExchange(ref value, newValue, compare);
        }
    }
}
