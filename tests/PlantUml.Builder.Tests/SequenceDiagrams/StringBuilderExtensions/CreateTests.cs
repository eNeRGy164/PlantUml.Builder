using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class CreateTests
{
    [TestMethod]
    public void StringBuilderExtensions_Create_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Create("actorA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Create_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Create(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Create_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Create(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Create_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Create(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Create_Should_ContainCreateLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Create("actorA");

        // Assert
        stringBuilder.ToString().Should().Be("create actorA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Create_WithOrder_Should_ContainCreateLineWithOrder()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Create("actorA", order: 10);

        // Assert
        stringBuilder.ToString().Should().Be("create actorA order 10\n");
    }
}
