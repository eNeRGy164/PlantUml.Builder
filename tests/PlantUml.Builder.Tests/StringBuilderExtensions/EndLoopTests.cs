using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class EndLoopTests
    {
        [TestMethod]
        public void StringBuilderExtensions_EndLoop_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.EndLoop();

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_EndLoop_Should_ContainNewLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.EndLoop();

            // Assert
            stringBuilder.ToString().Should().Be("end\n");
        }
    }
}
