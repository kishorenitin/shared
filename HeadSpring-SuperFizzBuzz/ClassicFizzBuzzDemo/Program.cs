using System;
using System.Collections.Generic;
using SuperFizzBuzz;

namespace ClassicFizzBuzzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine, FizzBuzz.SuperFizzBuzz(1, 100, new Dictionary<int, string>() { { 3, "Fizz" }, { 5, "Buzz" } })));
        }
    }
}
