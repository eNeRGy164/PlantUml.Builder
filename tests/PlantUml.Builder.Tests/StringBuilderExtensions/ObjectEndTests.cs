using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class ObjectEndTests
    {
        [TestMethod]
        public void StringBuilderExtensions_ObjectEnd_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.ObjectEnd();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_ObjectEnd_Should_ContainObjectEnd()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.ObjectEnd();

            // Assert
            stringBuilder.ToString().Should().Be("}\n");
        }
    }
}
