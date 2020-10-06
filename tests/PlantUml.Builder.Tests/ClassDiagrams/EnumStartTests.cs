using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams
{
    [TestClass]
    public class EnumStartTests
    {
        [TestMethod]
        public void StringBuilderExtensions_EnumStart_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.EnumStart(string.Empty);

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_EnumStart_Should_ContainEnumStartLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.EnumStart("enumA");

            // Assert
            stringBuilder.ToString().Should().Be("enum enumA {\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_EnumStart_WithVisibility_Should_ContaiEnumStartLineWithVisibility()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.EnumStart("enumA", visibility: VisibilityModifier.Public);

            // Assert
            stringBuilder.ToString().Should().Be("+enum enumA {\n");
        }
    }
}
