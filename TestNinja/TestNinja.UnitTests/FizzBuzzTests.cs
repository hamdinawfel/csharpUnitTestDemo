using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{

    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(15,"FizzBuzz")]
        [InlineData(3,"Fizz")]
        [InlineData(5,"Buzz")]
        [InlineData(1,"1")]
        public void GetOutput_WhenCalles_ReturnTheCorrectString(int number, string expected)
        {
            var result = FizzBuzz.GetOutput(number);
            Assert.Equal(expected, result);
        }
    }
}
