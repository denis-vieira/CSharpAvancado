using System;

namespace Closures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int x = 10;
            //Action a = () => Console.WriteLine(x);
            //x = 5;
            //a();

            Action[] actions = new Action[5];

            for (int i = 0; i<5; i++)
            {
                int j = i;
                //actions[i] = () => Console.WriteLine(i); //store only the address on memory, not the value
                actions[i] = () => Console.WriteLine(j);
            }

            foreach (Action action in actions)
            {
                action();
            }
        }
    }
}
