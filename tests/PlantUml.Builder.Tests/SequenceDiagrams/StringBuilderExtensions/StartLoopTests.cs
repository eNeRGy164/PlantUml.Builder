using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class StartLoopTests
{
    [TestMethod]
    public void StringBuilderExtensions_StartLoop_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.StartLoop();

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_StartLoop_Should_ContainStartLoopLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.StartLoop();

        // Assert
        stringBuilder.ToString().Should().Be("loop\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_StartLoop_WithLabel_Should_ContainStartLoopLineWithLabel()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.StartLoop("1000 times");

        // Assert
        stringBuilder.ToString().Should().Be("loop 1000 times\n");
    }
}
