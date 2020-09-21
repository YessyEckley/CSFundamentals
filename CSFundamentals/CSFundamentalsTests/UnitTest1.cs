using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace CSFundamentalsTests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }

        //[Fact]
        //public void Test1()
        //{
        //    var sw = new Stopwatch();
        //    sw.Start();
        //    sw.Stop();

        //    _output.WriteLine($"Time elepsed for RotLeftLogic: {sw.ElapsedMilliseconds} ms.");
        //}
    }
}
