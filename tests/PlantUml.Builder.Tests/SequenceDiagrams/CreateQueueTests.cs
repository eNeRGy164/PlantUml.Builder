using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public class CreateQueueTests
    {
        [TestMethod]
        public void StringBuilderExtensions_CreateQueue_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.CreateQueue("queueA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateQueue_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateQueue(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateQueue_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateQueue(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateQueue_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateQueue(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateQueue_Should_ContainCreateQueueLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateQueue("queueA");

            // Assert
            stringBuilder.ToString().Should().Be("create queue queueA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateQueue_WithDisplayName_Should_ContainCreateQueueLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateQueue("queueA", displayName: "Queue A");

            // Assert
            stringBuilder.ToString().Should().Be("create queue \"Queue A\" as queueA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateQueue_WithColor_Should_ContainCreateQueueLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateQueue("queueA", color: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("create queue queueA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateQueue_WithOrder_Should_ContainCreateQueueLineWithOrder()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateQueue("queueA", order: 10);

            // Assert
            stringBuilder.ToString().Should().Be("create queue queueA order 10\n");
        }
    }
}
