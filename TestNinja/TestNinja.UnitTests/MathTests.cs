using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    public class MathTests: IClassFixture<Math>
    {
        private Math _math;
        public MathTests(Math math)
        {
            _math = math;
        }

        [Fact]
        public void Add_WhenCalled_ReturnTheSumOfParametre()
        {
            var result = _math.Add(1, 2);
             Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(2, 1, 2)]
        [InlineData(1, 2, 2)]
        [InlineData(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheCorrectValue(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.Equal(expectedResult, result);
        }
    }
}
