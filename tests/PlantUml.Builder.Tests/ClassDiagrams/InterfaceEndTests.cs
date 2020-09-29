using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams
{
    [TestClass]
    public class InterfaceEndTests
    {
        [TestMethod]
        public void StringBuilderExtensions_InterfaceEnd_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.InterfaceEnd();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_InterfaceEnd_Should_ContainInterfaceEnd()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.InterfaceEnd();

            // Assert
            stringBuilder.ToString().Should().Be("}\n");
        }
    }
}
