using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ObjectDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams;

[TestClass]
public class ObjectStartTests
{
    [TestMethod]
    public void StringBuilderExtensions_ObjectStart_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.ObjectStart("objectA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_ObjectStart_Should_ContainObjectStartLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.ObjectStart("objectA");

        // Assert
        stringBuilder.ToString().Should().Be("object objectA {\n");
    }
}
