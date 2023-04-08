using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace PlantUml.Builder.Tests;

[TestClass]
public class AllowMixingTests
{
    [TestMethod]
    public void StringBuilderExtensions_AllowMixing_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.AllowMixing();

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_AllowMixing_Should_ContainAllowMixingLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.AllowMixing();

        // Assert
        stringBuilder.ToString().Should().Be("allow_mixing\n");
    }
}
