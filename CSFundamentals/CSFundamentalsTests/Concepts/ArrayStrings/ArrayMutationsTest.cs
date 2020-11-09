using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace CSFundamentalsTests.Concepts.ArrayStrings
{
    public class ArrayMutationsTest
    {
        private readonly ITestOutputHelper _output;

        public ArrayMutationsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void AddToStartTest1()
        {
            var a = Array.ConvertAll("1 2 3 4 5".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("6 1 2 3 4 5".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.ArrayMutations<int>()).AddToStart(a, 6);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddToEndTest1()
        {
            var a = Array.ConvertAll("1 2 3 4 5".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("1 2 3 4 5 6".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.ArrayMutations<int>()).AddToEnd(a, 6);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertAtTest1()
        {
            var a = Array.ConvertAll("1 2 3 4 5 6".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("1 2 3 7 4 5 6".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.ArrayMutations<int>()).InsertAt(a, 3, 7);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertAtTest2()
        {
            var a = Array.ConvertAll("1 2 3 4 5 6".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("1 2 3 4 5 6 7".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.ArrayMutations<int>()).InsertAt(a, 6, 7);

            Assert.Equal(expected, actual);
        }
    }
}
