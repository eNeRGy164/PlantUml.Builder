using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class EndRNoteTests
    {
        [TestMethod]
        public void StringBuilderExtensions_EndRNote_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.EndRNote();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_EndRNote_With_Should_ContainEndNoteLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.EndRNote();

            // Assert
            stringBuilder.ToString().Should().Be("end rnote\n");
        }
    }
}
