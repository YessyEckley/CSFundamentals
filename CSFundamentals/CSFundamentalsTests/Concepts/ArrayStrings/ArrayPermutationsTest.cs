﻿using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CSFundamentalsTests.Concepts.ArrayStrings
{
    public class ArrayPermutationsTest
    {
        private readonly ITestOutputHelper _output;

        public ArrayPermutationsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void PermutationTest1()
        {
            var input = new int[] { 1, 2, 3 };

            var expected = new List<string>
            {
                "1, 2, 3",
                "1, 3, 2",
                "2, 1, 3",
                "2, 3, 1",
                "3, 2, 1",
                "3, 1, 2"
            };

            var actual = CSFundamentals.Concepts.ArraysStrings.ArrayPermutations<int>.Permutation(input, 0, input.Length - 1, new List<int[]>());

            var dataCompare = actual.Select(s => expected.Contains(string.Join(", ", s))).ToList();

            Assert.True(!dataCompare.Contains(false));
        }
    }
}
