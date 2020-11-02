using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace CSFundamentalsTests.Leetcode
{
    public class Problem31NextPermutationTest
    {
        //[Fact]
        //public void Test1()
        //{

        //}
    }

    public class Problem43MultiplyStringsTest
    {
        [Fact]
        public void WHEN_PassedSingleDigitStringNumbers_EXPECT_SingleDigitStringNumber()
        {
            var input = new string[] { "2", "3" };
            var expected = "6";
            var actual = CSFundamentals.Leetcode.Problem43MultiplyStrings.Multiply(input[0], input[1]);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WHEN_PassedSingleDigitStringNumbers_EXPECT_DoubleDigitStringNumber()
        {
            var input = new string[] { "4", "3" };
            var expected = "12";
            var actual = CSFundamentals.Leetcode.Problem43MultiplyStrings.Multiply(input[0], input[1]);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WHEN_PassedSingleDigitStringNumbers_EXPECT_DoubleDigitStringNumber2()
        {
            var input = new string[] { "123", "456" };
            var expected = "56088";
            var actual = CSFundamentals.Leetcode.Problem43MultiplyStrings.Multiply(input[0], input[1]);
            Assert.Equal(expected, actual);
        }
    }

    public class Problem125ValidPalindromeTest
    {
        [Fact]
        public void WHEN_IsPalindrome_EXPECT_trueResult()
        {
            var input = "A man, a plan, a canal: Panama";
            var expected = true;
            var actual = CSFundamentals.Leetcode.Problem125ValidPalindrome.IsPalindrome(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WHEN_IsPalindrome2_EXPECT_trueResult()
        {
            var input = "A man, a plan, a canal: Panama";
            var expected = true;
            var actual = CSFundamentals.Leetcode.Problem125ValidPalindrome.IsPalindrome2(input);
            Assert.Equal(expected, actual);
        }
    }
}
