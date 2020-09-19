using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class StartStartNoteTests
    {
        [TestMethod]
        public void StringBuilderExtensions_StartNote_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.StartNote(NotePosition.Left);

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartNote_WithPosition_Should_ContainStartNoteLineWithPosition()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StartNote(NotePosition.Left);

            // Assert
            stringBuilder.ToString().Should().Be("note left\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartNote_WithHexagonalStyle_Should_ContainStartNoteLineWithHexagonalStyle()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StartNote(NotePosition.Left, style: NoteStyle.Hexagonal);

            // Assert
            stringBuilder.ToString().Should().Be("hnote left\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartNote_WithBoxStyle_Should_ContainStartNoteLineWithBoxStyle()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StartNote(NotePosition.Left, style: NoteStyle.Box);

            // Assert
            stringBuilder.ToString().Should().Be("rnote left\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartNote_WithPositionRelatedToParticipant_Should_ContainStartNoteLineWithParticipant()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StartNote(NotePosition.Left, "actorA");

            // Assert
            stringBuilder.ToString().Should().Be("note left of actorA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartNote_PositionOverParticipant_Should_ContainStartNoteLineWithOver()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StartNote("actorA");

            // Assert
            stringBuilder.ToString().Should().Be("note over actorA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_StartNote_AcrossParticipant_Should_ContainStartNoteLineWithBothParticipants()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StartNote("actorA", "actorB");

            // Assert
            stringBuilder.ToString().Should().Be("note over actorA,actorB\n");
        }
    }
}
