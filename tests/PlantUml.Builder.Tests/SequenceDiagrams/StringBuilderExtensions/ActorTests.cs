using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ActorTests
{
    [TestMethod]
    public void StringBuilderExtensions_Actor_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Actor("actorA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Actor_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Actor(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Actor_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Actor(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Actor_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Actor(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Actor_Should_ContainActorLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Actor("actorA");

        // Assert
        stringBuilder.ToString().Should().Be("actor actorA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Actor_WithDisplayName_Should_ContainActorLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Actor("actorA", displayName: "Actor A");

        // Assert
        stringBuilder.ToString().Should().Be("actor \"Actor A\" as actorA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Actor_WithColor_Should_ContainActorLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Actor("actorA", color: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("actor actorA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Actor_WithColorWithHashtag_Should_ContainActorLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Actor("actorA", color: "#AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("actor actorA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Actor_WithOrder_Should_ContainActorLineWithOrder()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Actor("actorA", order: 10);

        // Assert
        stringBuilder.ToString().Should().Be("actor actorA order 10\n");
    }
}
