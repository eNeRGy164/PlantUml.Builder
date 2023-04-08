using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class EndRefTests
{
    [TestMethod]
    public void StringBuilderExtensions_EndRef_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.EndRef();

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_EndRef_Should_ContainEndRef()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.EndRef();

        // Assert
        stringBuilder.ToString().Should().Be("end ref\n");
    }
}
