using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class CreateActorTests
{
    [TestMethod]
    public void StringBuilderExtensions_CreateActor_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.CreateActor("actorA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_CreateActor_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.CreateActor(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_CreateActor_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.CreateActor(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_CreateActor_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.CreateActor(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_CreateActor_Should_ContainCreateActorLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.CreateActor("actorA");

        // Assert
        stringBuilder.ToString().Should().Be("create actor actorA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_CreateActor_WithDisplayName_Should_ContainCreateActorLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.CreateActor("actorA", displayName: "Actor A");

        // Assert
        stringBuilder.ToString().Should().Be("create actor \"Actor A\" as actorA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_CreateActor_WithColor_Should_ContainCreateActorLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.CreateActor("actorA", color: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("create actor actorA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_CreateActor_WithOrder_Should_ContainCreateActorLineWithOrder()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.CreateActor("actorA", order: 10);

        // Assert
        stringBuilder.ToString().Should().Be("create actor actorA order 10\n");
    }
}
