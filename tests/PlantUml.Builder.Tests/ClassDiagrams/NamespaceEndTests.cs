using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams
{
    [TestClass]
    public class NamespaceEndTests
    {
        [TestMethod]
        public void StringBuilderExtensions_NamespaceEnd_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.NamespaceEnd();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_NamespaceEnd_Should_ContainNamespaceEnd()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.NamespaceEnd();

            // Assert
            stringBuilder.ToString().Should().Be("}\n");
        }
    }
}
