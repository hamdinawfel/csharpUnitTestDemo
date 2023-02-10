using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    public class ErrorLoggerTests
    {
        [Fact]
        public void ErrorLogger_ErrorNotNull_ReturnTheLastErrorProperty()
        {
            var logger = new ErrorLogger();
            logger.Log("a");
            Assert.Equal("a", logger.LastError);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ErrorLogger_ErrorIsNull_ThrowAnException(string error)
        {
            var logger = new ErrorLogger();
            Assert.Throws<ArgumentNullException>(()=>logger.Log(error));
        }
    }
}
