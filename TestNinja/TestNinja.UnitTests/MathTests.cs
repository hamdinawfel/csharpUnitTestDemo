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

        [Fact]
        public void GetOddNumbers_LimitGreaterThanZero_ReturnOddNumberUpToLimit()
        {
            var result = _math.GetOddNumbers(3);
            var expectedResult = new int[] { 1, 3 };
            Assert.NotEmpty(result);
            Assert.Contains(result, x => x == 1);
            Assert.Contains(result, x => x == 3);
            Assert.Equal(expectedResult.Length, result.Count());
           
        }

        [Fact]
        public void GetOddNumbers_LimitEqualToZero_ReturnEmptyArray()
        {
            var result = _math.GetOddNumbers(0);
            var expectedResult = new int[] { };
            Assert.Equal(expectedResult, result);
        }
    }
}
