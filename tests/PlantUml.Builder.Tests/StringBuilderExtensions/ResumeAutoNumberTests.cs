using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class ResumeAutoNumberTests
    {
        [TestMethod]
        public void StringBuilderExtensions_ResumeAutoNumber_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.ResumeAutoNumber();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_ResumeAutoNumber_EmptyParticipant_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.ResumeAutoNumber(format: string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("format");
        }

        [TestMethod]
        public void StringBuilderExtensions_ResumeAutoNumber_WhitespaceParticipant_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.ResumeAutoNumber(format: " ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("format");
        }

        [TestMethod]
        public void StringBuilderExtensions_ResumeAutoNumber_Should_ContainResumeAutoNumberLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.ResumeAutoNumber();

            // Assert
            stringBuilder.ToString().Should().Be("autonumber resume\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_ResumeAutoNumber_WithStartAndStep_Should_ContainResumeAutoNumberLineWithStartAndStep()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.ResumeAutoNumber(step: 20);

            // Assert
            stringBuilder.ToString().Should().Be("autonumber resume 20\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_ResumeAutoNumber_WithFormat_Should_ContainResumeAutoNumberLineWithFormat()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.ResumeAutoNumber(format: "<b>[000]");

            // Assert
            stringBuilder.ToString().Should().Be("autonumber resume \"<b>[000]\"\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_ResumeAutoNumber_AllParamters_Should_ContainResumeAutoNumberLineWithCorrectOrderedParameters()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.ResumeAutoNumber(20, "<b>[000]");

            // Assert
            stringBuilder.ToString().Should().Be("autonumber resume 20 \"<b>[000]\"\n");
        }
    }
}
