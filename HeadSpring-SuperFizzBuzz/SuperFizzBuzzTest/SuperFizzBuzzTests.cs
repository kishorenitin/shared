using NUnit.Framework;
using SuperFizzBuzz;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperFizzBuzzTest
{
    public class SuperFizzBuzzTests
    {
        private Dictionary<int, string> Tokens;
        private List<int> NumbersCollection;
        [SetUp]
        public void Setup()
        {
            Tokens = new Dictionary<int, string>();
            NumbersCollection = new List<int>();
        }
        [Test]
        public void SuperFizzBuzz_when_numbers_collection_empty()
        {
            Tokens = new Dictionary<int, string>() { { 3, "Fizz" }, { 5, "Buzz" } };
            Assert.AreEqual(FizzBuzz.SuperFizzBuzz(NumbersCollection, Tokens).ToList().Count, 0);
        }
        [Test]
        public void SuperFizzBuzz_when_Tokens_empty()
        {
            NumbersCollection = new List<int>() { 1, 2, 3 };
            IEnumerable<string> expectedResult = new[] { "1", "2", "3" };
            Assert.IsTrue(expectedResult.SequenceEqual(FizzBuzz.SuperFizzBuzz(NumbersCollection, Tokens)));
        }
        [Test]
        public void SuperFizzBuzz_when_tokens_and_numbers_collection_empty()
        {
            Assert.AreEqual(FizzBuzz.SuperFizzBuzz(NumbersCollection, Tokens).ToList().Count, 0);
        }
        [Test]
        public void SuperFizzBuzz_when_tokens_and_numbers_collection_null()
        {
            Tokens = null;
            NumbersCollection = null;
            Assert.Throws<ArgumentNullException>(() => FizzBuzz.SuperFizzBuzz(NumbersCollection, Tokens));
        }
        [Test]
        public void SuperFizzBuzz_when_tokens_not_null_and_numbers_collection_null()
        {
            Tokens = new Dictionary<int, string>() { { 3, "Fizz" }, { 5, "Buzz" } };
            NumbersCollection = null;
            Assert.Throws<ArgumentNullException>(() => FizzBuzz.SuperFizzBuzz(NumbersCollection, Tokens));
        }
        [Test]
        [TestCase(1, 5)]
        public void SuperFizzBuzz_when_startnumber_smaller_than_endnumber_SequencialCollection(int startNum, int endNum)
        {
            Tokens = new Dictionary<int, string>() { { 3, "Fizz" }, { 5, "Buzz" } };
            var actual = FizzBuzz.SuperFizzBuzz(startNum, endNum, Tokens).ToList();
            Assert.AreEqual(actual.Count, 5);
            Assert.AreEqual(actual.Contains("3"), false);
            Assert.AreEqual(actual.Contains("5"), false);
            Assert.AreEqual(actual.Contains("Fizz"), true);
            Assert.AreEqual(actual.Contains("Buzz"), true);
        }
        [Test]
        public void SuperFizzBuzz_non_sequencial_collection()
        {
            Tokens = new Dictionary<int, string>() { { 2, "Fizz" }, { 3, "Buzz" } };
            NumbersCollection = new List<int>() { 1, 2, 3, 6, 18 };
            var actual = FizzBuzz.SuperFizzBuzz(NumbersCollection, Tokens).ToList();
            var expected = new List<string>() { "1", "Fizz", "Buzz", "FizzBuzz", "FizzBuzz" };
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
        [Test]
        [TestCase(5, 1)]
        public void SuperFizzBuzz_when_startnumber_greater_than_endnumber_SequencialCollection(int startNum, int endNum)
        {
            Tokens = new Dictionary<int, string>() { { 3, "Fizz" }, { 5, "Buzz" } };
            Assert.Throws<ArgumentOutOfRangeException>(() => FizzBuzz.SuperFizzBuzz(startNum, endNum, Tokens));
        }
        [TestCase(1)]
        public void SuperFizzBuzz_Test_GetValuesToPrint_when_tokens_null(int num)
        {
            Tokens = null;
            Assert.Throws<ArgumentNullException>(() => FizzBuzz.GetValueToPrint(num, Tokens));
        }
        [TestCase(1, 1, "Fizz", 2, "Buzz","Fizz")]
        [TestCase(2, 1, "Fizz", 2, "Buzz", "FizzBuzz")]
        [TestCase(3, 2, "Fizz", 5, "Buzz", "3")]
        public void SuperFizzBuzz_Test_GetValuesToPrint_when_tokens_not_null(int num, int tokenKey1, string tokenvalue1, int tokenKey2, string tokenvalue2, string expected)
        {
            Tokens = new Dictionary<int, string>() { { tokenKey1, tokenvalue1 }, { tokenKey2, tokenvalue2 } }; ;
            Assert.AreEqual(expected, FizzBuzz.GetValueToPrint(num, Tokens));
        }
        [Test]
        public void SuperFizzBuzz_Test_GetValuesToPrint_DivideByZero()
        {
            Tokens = new Dictionary<int, string>() { { 0, "Fizz" }, { 5, "Buzz" } };
            Assert.Throws<DivideByZeroException>(() => FizzBuzz.GetValueToPrint(5, Tokens));
        }

    }
}