using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests
{
    [TestClass]
    public class StopAutoNumberTests
    {
        [TestMethod]
        public void StringBuilderExtensions_StopStopAutoNumber_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.StopAutoNumber();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_StopAutoNumber_Should_ContainStopAutoNumberLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StopAutoNumber();

            // Assert
            stringBuilder.ToString().Should().Be("autonumber stop\n");
        }
    }
}
