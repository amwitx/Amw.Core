using System;
using UnitDemo;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        //[Fact]
        [Theory]
        [InlineData(1)]
        public void Test1(int a)
        {
            var sut = new Calculator();
            var result = sut.Add(a, 2);
            Assert.Equal(3, result);
        }
    }
}
