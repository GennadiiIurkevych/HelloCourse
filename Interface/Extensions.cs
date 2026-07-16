using System;
using System.Collections.Generic;
using System.Text;
using static Interface.DefaultInterfaceImplementation;

namespace Interface
{
    internal static class Extensions
    {
        public static void Foo(this ILogger logger)
        {
            Console.WriteLine("Foo");
        }
    }
}
