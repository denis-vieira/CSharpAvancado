using System;
using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nome classe: ");
            string className = Console.ReadLine();

            Type t = Type.GetType(className);

            PropertyInfo[] props = t.GetProperties();

            foreach (PropertyInfo prop in props)
            {
                Console.WriteLine(prop.Name + " => " + prop.PropertyType);
            }

            var method = t.GetMethod("Init");

            if(method == null)
            {
                Console.WriteLine("Método Init() não existe");
            }
            else
            {
                object obj = Activator.CreateInstance(t);
                method.Invoke(obj, null);
            }
        }
    }

    class MyClass
    {
        public int X { get; set; }

        public void Init()
        {
            Console.WriteLine("Método Init() chamado!");
        }
    }
}
