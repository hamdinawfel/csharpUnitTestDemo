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
        public void CalculateDemeritPoints_WithWrongParametre_ThrowException(int speed)
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(()=> demeritPointsCalculator.CalculateDemeritPoints(speed));
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedLessToSpeedLimit_Return0()
        {
            var demeritPointsCalculator = new DemeritPointsCalculator();
            var result = demeritPointsCalculator.CalculateDemeritPoints(65);
            Assert.Equal(0, result);
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
