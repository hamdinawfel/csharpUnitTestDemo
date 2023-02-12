using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    public class DemeritPointsCalculatorTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(301)]
        public void CalculateDemeritPoints_OutOfRangeSpeed_ThrowException(int speed)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(()=> demeritPointsCalculator.CalculateDemeritPoints(speed));
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(65,0)]
        [InlineData(64,0)]
        [InlineData(70,1)]
        [InlineData(75,2)]
        public void CalculateDemeritPoints_WhenCallad_ReturnDemeritPonits(int speed, int experctedResult)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();
            var result = demeritPointsCalculator.CalculateDemeritPoints(speed);
            Assert.Equal(experctedResult, result);
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedIs70_Return1()
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();
            var result = demeritPointsCalculator.CalculateDemeritPoints(70);
            Assert.Equal(1, result);
        }
    }
}
