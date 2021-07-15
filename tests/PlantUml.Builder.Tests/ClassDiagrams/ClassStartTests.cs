using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.ClassDiagrams.Tests
{
    [TestClass]
    public class ClassStartTests
    {
        [TestMethod]
        public void StringBuilderExtensions_ClassStart_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.ClassStart(string.Empty);

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_ClassStart_Should_ContainClassStartLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.ClassStart("classA");

            // Assert
            stringBuilder.ToString().Should().Be("class classA {\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_ClassStart_WithVisibility_Should_ContainClassStartLineWithVisibility()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.ClassStart("classA", visibility: VisibilityModifier.Public);

            // Assert
            stringBuilder.ToString().Should().Be("+class classA {\n");
        }
    }
}
