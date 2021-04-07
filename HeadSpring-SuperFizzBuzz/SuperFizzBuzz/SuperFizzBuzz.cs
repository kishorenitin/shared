using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperFizzBuzz
{
    public class FizzBuzz
    {
        private static readonly StringBuilder valueToPrint = new();
        /// <summary>
        /// SuperFizzBuzz for User Defined set of numbers 
        /// </summary>
        /// <param name="numbersCollection">user defined collection of non sequencial numbers. Use overloaded function for collection of sequencial numbers</param>
        /// <param name="tokens"></param>
        /// <returns>list of string values, it can be a number, a token value or a combination of token values</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<string> SuperFizzBuzz(IEnumerable<int> numbersCollection, Dictionary<int, string> tokens)
        {
            return numbersCollection.Select(p => GetValueToPrint(p, tokens).ToString());
        }
        /// <summary>
        /// SuperFizzBuzz for a range with start number and end number for sequencial collection
        /// </summary>
        /// <param name="startNumber">first number of the range</param>
        /// <param name="endNumber">last number of the range</param>
        /// <param name="tokens">number as key and value to print as value</param>
        /// <returns>list of string values, it can be a number, a token value or a combination of token values</returns>
        /// <exception cref="ArgumentOutOfRangeException">when startNumber is greater than endNumber</exception>
        public static IEnumerable<string> SuperFizzBuzz(int startNumber, int endNumber, Dictionary<int, string> tokens) => SuperFizzBuzz(Enumerable.Range(startNumber, endNumber + 1 - startNumber), tokens);
        /// <summary>
        /// This function is public for two reasons:
        /// for fast processing of large sequencial collection by directly calling this function in loop from demo, example in superfizzbuzzdemo.
        /// and to write tests for the function
        /// </summary>
        /// <param name="number"></param>
        /// <param name="tokens"></param>
        /// <returns>string value to print: the number itself, the token value or the combination of token values </returns>
        /// <exception cref="ArgumentNullException">if tokens null</exception>
        /// <exception cref="DivideByZeroException">if tokens contains any key as 0</exception>
        public static string GetValueToPrint(int number, Dictionary<int, string> tokens)
        {
            valueToPrint.Clear().Append(string.Join(string.Empty, tokens.Where(p => number != 0 && number % p.Key == 0).Select(p => p.Value)));
            return (valueToPrint.Length == 0) ? number.ToString() : valueToPrint.ToString();
        }

    }
}
