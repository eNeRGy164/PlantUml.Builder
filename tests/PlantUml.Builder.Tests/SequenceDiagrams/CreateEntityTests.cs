using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public class CreateEntityTests
    {
        [TestMethod]
        public void StringBuilderExtensions_CreateEntity_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.CreateEntity("entityA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateEntity_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateEntity(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateEntity_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateEntity(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateEntity_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateEntity(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateEntity_Should_ContainCreateEntityLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateEntity("entityA");

            // Assert
            stringBuilder.ToString().Should().Be("create entity entityA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateEntity_WithDisplayName_Should_ContainCreateEntityLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateEntity("entityA", displayName: "Entity A");

            // Assert
            stringBuilder.ToString().Should().Be("create entity \"Entity A\" as entityA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateEntity_WithColor_Should_ContainCreateEntityLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateEntity("entityA", color: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("create entity entityA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateEntity_WithOrder_Should_ContainCreateEntityLineWithOrder()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateEntity("entityA", order: 10);

            // Assert
            stringBuilder.ToString().Should().Be("create entity entityA order 10\n");
        }
    }
}
