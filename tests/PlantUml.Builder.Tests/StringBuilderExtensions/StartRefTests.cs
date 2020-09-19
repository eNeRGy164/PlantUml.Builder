using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class StartRefTests
    {
        [TestMethod]
        public void StringBuilderExtensions_StartRef_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.StartRef("actorA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_NullWithParticipants_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;
            // Act
            Action action = () => stringBuilder.StartRef("actorA", "actorB");
            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_NullParticipant_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.StartRef(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participant");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_EmptyParticipant_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.StartRef(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participant");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_WhitespaceParticipant_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.StartRef(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participant");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_NullParticipantA_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.StartRef(null, "actorB");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participantA");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_EmptyParticipantA_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.StartRef(string.Empty, "actorB");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participantA");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_WhitespaceParticipantA_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.StartRef(" ", "actorB");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participantA");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_NullParticipantB_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();
            // Act
            Action action = () => stringBuilder.StartRef("actorA", null);
            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participantB");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_EmptyParticipantB_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();
            // Act
            Action action = () => stringBuilder.StartRef("actorA", string.Empty);
            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participantB");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_WhitespaceParticipantB_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();
            // Act
            Action action = () => stringBuilder.StartRef("actorA", " ");
            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("participantB");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_Should_ContainStartRefLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StartRef("actorA");

            // Assert
            stringBuilder.ToString().Should().Be("ref over actorA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartRef_WithVisibility_Should_ContainStartRefLineWithVisibility()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StartRef("actorA", "actorB");

            // Assert
            stringBuilder.ToString().Should().Be("ref over actorA,actorB\n");
        }
    }
}
