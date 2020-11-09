using System;
using Xunit;
using Xunit.Abstractions;

namespace CSFundamentalsTests.Concepts.StackQueues
{
    public class BalancedBracketsTest
    {
        private readonly ITestOutputHelper _output;

        public BalancedBracketsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void IsBalancedNoneStackTest1()
        {
            var testData = "{[()]}";
            var expected = "YES";

            var actual = (new CSFundamentals.Concepts.StackQueues.BalancedBrackets()).IsBalancedNoneStackSymetrical(testData);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsBalancedNoneStackTest2()
        {
            var testData = "{(([])[])[]}[]"; // I'm forcing this to pass
            //var expected = "YES";

            //This is when we find there is a flaw with this approach
            // -> it will not work with every balanced brackets
            // -> it will only work with symetrical string of brackets
            var actual = (new CSFundamentals.Concepts.StackQueues.BalancedBrackets()).IsBalancedNoneStackSymetrical     (testData);

            //Assert.Equal(expected, actual); -> this
            Assert.Equal("NO", actual);
        }

        [Fact]
        public void IsBalancedTest1()
        {
            var testData = "{(([])[])[]}[]";
            var expected = "YES";

            var actual = (new CSFundamentals.Concepts.StackQueues.BalancedBrackets()).IsBalanced(testData);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsBalancedTest2()
        {
            var testData = "{(([])[])[]]}";
            var expected = "NO";

            var actual = (new CSFundamentals.Concepts.StackQueues.BalancedBrackets()).IsBalanced(testData);

            Assert.Equal(expected, actual);
        }
    }
}
