using System;

namespace DelegateGenerico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = new Temperature();

            Func<double, double> convertToCelsius = t.ToCelsius;
            Func<double, double> convertToFahrenheit = t.ToFahrenheit;

            //TemperatureConverter converterToCelsius = t.ToCelsius;
            //TemperatureConverter converterToFahreinheit = t.ToFahrenheit;

            double celsius = convertToCelsius(90);
            double fahrenheit = convertToFahrenheit(25);

            Console.WriteLine(celsius);
            Console.WriteLine(fahrenheit);

            Action<double> printCelsius = t.PrintCelsius;
            Action<double> printFahreinheit = t.PrintFahrenheit;

            printCelsius(80);
            printFahreinheit(20);
        }
    }

    //public delegate double TemperatureConverter(double temp);

    class Temperature
    {
        public double ToFahrenheit(double value)
        {
            return (value * 9 / 5) + 32;
        }

        public double ToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public void PrintFahrenheit(double celsius)
        {
            Console.WriteLine(ToFahrenheit(celsius));
        }

        public void PrintCelsius(double fahrenheit)
        {
            Console.WriteLine(ToCelsius(fahrenheit));
        }
    }
}
