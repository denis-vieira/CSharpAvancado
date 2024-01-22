using System;
using System.Reflection;

namespace Attribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            foreach (var item in types)
            {
                MessageAttribute attr = (MessageAttribute)item.GetCustomAttribute(typeof(MessageAttribute));

                if(attr != null)
                {
                    Console.WriteLine("Classe " + item.FullName + ": " + attr.Value);
                }
            }
        }
    }

    [Message(Value = "ABC")]
    class A
    {
    }

    [Message(Value = "DEF")]
    class B
    {
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MessageAttribute : System.Attribute
    {
        public string Value { get; set; }
    }
}
