using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace CSFundamentalsTests.Concepts.ArrayStrings
{
    public class RightRotationTest
    {
        private readonly ITestOutputHelper _output;

        public RightRotationTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void RotLeftLogicTest1()
        {
            var d = 4;
            var a = Array.ConvertAll("1 2 3 4 5".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("2 3 4 5 1".Split(" "), conv => Convert.ToInt32(conv));
            var actual = CSFundamentals.Concepts.ArraysStrings.RightRotation.RotRightLogic(a, d);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotLeftLogicTest2()
        {
            var d = 10;
            var a = Array.ConvertAll("41 73 89 7 10 1 59 58 84 77 77 97 58 1 86 58 26 10 86 51".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("77 97 58 1 86 58 26 10 86 51 41 73 89 7 10 1 59 58 84 77".Split(" "), conv => Convert.ToInt32(conv));
            var actual = CSFundamentals.Concepts.ArraysStrings.RightRotation.RotRightLogic(a, d);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotLeftLogicTest3()
        {
            var d = 13;
            var a = Array.ConvertAll("33 47 70 37 8 53 13 93 71 72 51 100 60 87 97".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("70 37 8 53 13 93 71 72 51 100 60 87 97 33 47".Split(" "), conv => Convert.ToInt32(conv));
            var actual = CSFundamentals.Concepts.ArraysStrings.RightRotation.RotRightLogic(a, d);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void RotRightFasterLogicTest1()
        {
            var d = 4;
            var a = Array.ConvertAll("1 2 3 4 5".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("2 3 4 5 1".Split(" "), conv => Convert.ToInt32(conv));
            var actual = CSFundamentals.Concepts.ArraysStrings.RightRotation.RotRightFasterLogic(a, d);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotRightFasterLogicTest2()
        {
            var d = 10;
            var a = Array.ConvertAll("41 73 89 7 10 1 59 58 84 77 77 97 58 1 86 58 26 10 86 51".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("77 97 58 1 86 58 26 10 86 51 41 73 89 7 10 1 59 58 84 77".Split(" "), conv => Convert.ToInt32(conv));
            var actual = CSFundamentals.Concepts.ArraysStrings.RightRotation.RotRightFasterLogic(a, d);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotRightFasterLogicTest3()
        {
            var d = 13;
            var a = Array.ConvertAll("33 47 70 37 8 53 13 93 71 72 51 100 60 87 97".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("70 37 8 53 13 93 71 72 51 100 60 87 97 33 47".Split(" "), conv => Convert.ToInt32(conv));
            var actual = CSFundamentals.Concepts.ArraysStrings.RightRotation.RotRightFasterLogic(a, d);

            Assert.Equal(expected, actual);
        }
    }
}
