using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    public class HtmlFormatterTests
    {
        [Fact]
        public void FormatAsBold_WhenCalled_ShouldReturnBoldString()
        {
            //Arrange
            var formatter = new HtmlFormatter();
            //Act
            var result = formatter.FormatAsBold("abc");
            //Assert
            // MORE SPECIFIC
            //Assert.Equal("<strong>abc</strong>", result);
            // MORE GENERAL
            Assert.StartsWith("<strong>", result);
            Assert.EndsWith("</strong>", result);
            Assert.Contains("abc", result);
        }
    }
}
