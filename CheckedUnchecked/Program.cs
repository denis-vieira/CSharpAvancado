﻿using System;

namespace CheckedUnchecked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short s1 = 25000;
            short s2 = 20000;

            //checked
            //{
                short s3 = (short)(s1 + s2);
                Console.WriteLine(s3);
            //}
        }
    }
}
