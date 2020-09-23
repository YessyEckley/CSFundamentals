using System.Collections.Generic;
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
            var input = new string[] { "a", "b" };

            var expected = new List<string>
            {
                "a, b",
                "b, a"
            };

            var actual = CSFundamentals.Concepts.ArraysStrings.ArrayPermutations<string>.Permutation(input, 0, input.Length - 1, new List<string[]>());
            var stringifiedActual = actual.Select(s => string.Join(", ", s)).ToList();

            Assert.Equal(string.Join(" -> ", expected), string.Join(" -> ", stringifiedActual));
        }

        [Fact]
        public void PermutationTest2()
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
            var stringifiedActual = actual.Select(s => string.Join(", ", s)).ToList();

            Assert.Equal(string.Join(" -> ", expected), string.Join(" -> ", stringifiedActual));
        }
    }
}
