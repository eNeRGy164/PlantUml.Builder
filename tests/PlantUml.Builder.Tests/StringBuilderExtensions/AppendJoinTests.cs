using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace PlantUml.Builder.Tests;

[TestClass]
public class AppendJoinTests
{
    [TestMethod]
    public void StringBuilderExtensions_AppendJoinTests_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => StringBuilderExtensions.AppendJoin(stringBuilder, ',', "a");

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_AppendJoinTests_ValuesNull_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => StringBuilderExtensions.AppendJoin(stringBuilder, ',', null);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("values");
    }

    [TestMethod]
    public void StringBuilderExtensions_AppendJoinTests_NoValues_Should_HaveEmptyString()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        StringBuilderExtensions.AppendJoin(stringBuilder, ',');

        // Assert
        stringBuilder.ToString().Should().BeEmpty();
    }

    [TestMethod]
    public void StringBuilderExtensions_AppendJoinTests_SingleValue_Should_NotHaveSeperator()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        StringBuilderExtensions.AppendJoin(stringBuilder, ',', "a");

        // Assert
        stringBuilder.ToString().Should().Be("a");
    }

    [TestMethod]
    public void StringBuilderExtensions_AppendJoinTests_MultipleValues_Should_HaveSeperatorBetweenValues()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        StringBuilderExtensions.AppendJoin(stringBuilder, ',', "a", "b", "c");

        // Assert
        stringBuilder.ToString().Should().Be("a,b,c");
    }

    [TestMethod]
    public void StringBuilderExtensions_AppendJoinTests_ValueWithNull_Should_BeHandledAsNoValue()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        StringBuilderExtensions.AppendJoin(stringBuilder, ',', "a", null, "c");

        // Assert
        stringBuilder.ToString().Should().Be("a,,c");
    }
}
