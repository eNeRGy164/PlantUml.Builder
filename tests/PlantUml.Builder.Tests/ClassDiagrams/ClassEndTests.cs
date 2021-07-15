using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams
{
    [TestClass]
    public class ClassEndTests
    {
        [TestMethod]
        public void StringBuilderExtensions_ClassEnd_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.ClassEnd();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_ClassEnd_Should_ContainClassEnd()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.ClassEnd();

            // Assert
            stringBuilder.ToString().Should().Be("}\n");
        }
    }
}
