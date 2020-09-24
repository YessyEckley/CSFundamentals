using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace CSFundamentalsTests.Concepts.ArrayStrings
{
    public class MoveZerosInOnePassTest
    {
        private readonly ITestOutputHelper _output;

        public MoveZerosInOnePassTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void MoveAllZerosToEndTest1()
        {
            var testData = new int[] { 3, 5, 0, 4, 0 };
            var expected = "[3, 5, 4, 0, 0]";

            var actual = $"[{String.Join(", ", CSFundamentals.Concepts.ArraysStrings.MoveZerosInOnePass.MoveAllZerosToEnd(testData))}]";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MoveAllZerosToBeginingTest1()
        {
            var testData = new int[] { 3, 5, 0, 4, 0 };
            var expected = "[0, 0, 3, 5, 4]";

            var actual = $"[{String.Join(", ", CSFundamentals.Concepts.ArraysStrings.MoveZerosInOnePass.MoveAllZerosToBegining(testData))}]";

            Assert.Equal(expected, actual);
        }
    }
}
