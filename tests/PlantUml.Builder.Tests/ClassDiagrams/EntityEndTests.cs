using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams
{
    [TestClass]
    public class EntityEndTests
    {
        [TestMethod]
        public void StringBuilderExtensions_EntityEnd_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.EntityEnd();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_EntityEnd_Should_ContainEntityEndLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.EntityEnd();

            // Assert
            stringBuilder.ToString().Should().Be("}\n");
        }
    }
}
