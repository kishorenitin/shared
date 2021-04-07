using System;
using System.Collections.Generic;
using SuperFizzBuzz;

namespace SuperFizzBuzzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //demo for SuperFizzBuzz
            Dictionary<int, string> tokens = new Dictionary<int, string>() { { 3, "Fizz" }, { 7, "Buzz" }, { 38, "Bazz" } };
            Console.WriteLine(string.Join(Environment.NewLine, FizzBuzz.SuperFizzBuzz(-12, 145, tokens)));

            //Uncomment following lines: demo for large sequencial collection by directly calling GetValueToPrint function
            //for (int i = -12; i <= 145; i++)
            //{
            //    Console.WriteLine(FizzBuzz.GetValueToPrint(i, tokens));
            //}
        }
    }
}
