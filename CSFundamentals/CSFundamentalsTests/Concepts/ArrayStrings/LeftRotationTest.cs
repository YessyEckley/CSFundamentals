using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace CSFundamentalsTests.Concepts.ArrayStrings
{
    public class LeftRotationTest
    {
        private readonly ITestOutputHelper _output;

        public LeftRotationTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void RotLeftLogicTest1()
        {
            var d = 4;
            var a = Array.ConvertAll("1 2 3 4 5".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("5 1 2 3 4".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.LeftRotation()).RotLeftLogic(a, d);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotLeftLogicTest2()
        {
            var d = 10;
            var a = Array.ConvertAll("41 73 89 7 10 1 59 58 84 77 77 97 58 1 86 58 26 10 86 51".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("77 97 58 1 86 58 26 10 86 51 41 73 89 7 10 1 59 58 84 77".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.LeftRotation()).RotLeftLogic(a, d);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotLeftLogicTest3()
        {
            var d = 13;
            var a = Array.ConvertAll("33 47 70 37 8 53 13 93 71 72 51 100 60 87 97".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("87 97 33 47 70 37 8 53 13 93 71 72 51 100 60".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.LeftRotation()).RotLeftLogic(a, d);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void RotLeftFasterLogicTest1()
        {
            var d = 4;
            var a = Array.ConvertAll("1 2 3 4 5".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("5 1 2 3 4".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.LeftRotation()).RotLeftFasterLogic(a, d);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotLeftFasterLogicTest2()
        {
            var d = 10;
            var a = Array.ConvertAll("41 73 89 7 10 1 59 58 84 77 77 97 58 1 86 58 26 10 86 51".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("77 97 58 1 86 58 26 10 86 51 41 73 89 7 10 1 59 58 84 77".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.LeftRotation()).RotLeftFasterLogic(a, d);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotLeftFasterLogicTest3()
        {
            var d = 13;
            var a = Array.ConvertAll("33 47 70 37 8 53 13 93 71 72 51 100 60 87 97".Split(" "), conv => Convert.ToInt32(conv));
            var expected = Array.ConvertAll("87 97 33 47 70 37 8 53 13 93 71 72 51 100 60".Split(" "), conv => Convert.ToInt32(conv));
            var actual = (new CSFundamentals.Concepts.ArraysStrings.LeftRotation()).RotLeftFasterLogic(a, d);

            Assert.Equal(expected, actual);
        }
    }
}
