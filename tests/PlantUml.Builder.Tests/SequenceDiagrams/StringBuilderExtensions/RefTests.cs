using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class RefTests
{
    [TestMethod]
    public void StringBuilderExtensions_Ref_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Ref("actorA", "note");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_NullWithMultipleParticipants_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;
        // Act
        Action action = () => stringBuilder.Ref("actorA", "actorB", "note");
        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_NullParticipant_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Ref(null, "note");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participant");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_EmptyParticipant_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Ref(string.Empty, "note");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participant");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_WhitespaceParticipant_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Ref(" ", "note");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participant");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_NullNote_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref("actorA", null);
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("note");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_EmptyNote_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref("actorA", string.Empty);
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("note");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_WhitespaceNote_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref("actorA", " ");
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("note");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_NullParticipantB_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref("actorA", null, "note");
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participantB");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_EmptyParticipantA_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref(string.Empty, "actorB", "note");
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participantA");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_WhitespaceParticipantA_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref(" ", "actorB", "note");
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participantA");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_NullParticipantA_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref(null, "actorB", "note");
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participantA");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_EmptyParticipantB_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref("actorA", string.Empty, "note");
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participantB");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_WhitespaceParticipantB_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();
        // Act
        Action action = () => stringBuilder.Ref("actorA", " ", "note");
        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("participantB");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_Should_ContainRefLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Ref("actorA", "note");

        // Assert
        stringBuilder.ToString().Should().Be("ref over actorA : note\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_WithMultiLineNote_Should_ContainRefLineWithMultilineNote()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Ref("actorA", "Line1\nLine2");

        // Assert
        stringBuilder.ToString().Should().Be("ref over actorA : Line1\\nLine2\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Ref_WithDisplayName_Should_ContainRefLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Ref("actorA", "actorB", "note");

        // Assert
        stringBuilder.ToString().Should().Be("ref over actorA,actorB : note\n");
    }
}
