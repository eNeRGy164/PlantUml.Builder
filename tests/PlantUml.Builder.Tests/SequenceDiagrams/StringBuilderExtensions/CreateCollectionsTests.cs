using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests
{
    [TestClass]
    public class CreateCollectionsTests
    {
        [TestMethod]
        public void StringBuilderExtensions_CreateCollections_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.CreateCollections("collectionsA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateCollections_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateCollections(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateCollections_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateCollections(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateCollections_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateCollections(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateCollections_Should_ContainCreateCollectionsLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateCollections("collectionsA");

            // Assert
            stringBuilder.ToString().Should().Be("create collections collectionsA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateCollections_WithDisplayName_Should_ContainCreateCollectionsLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateCollections("collectionsA", displayName: "Collections A");

            // Assert
            stringBuilder.ToString().Should().Be("create collections \"Collections A\" as collectionsA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateCollections_WithColor_Should_ContainCreateCollectionsLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateCollections("collectionsA", color: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("create collections collectionsA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateCollections_WithOrder_Should_ContainCreateCollectionsLineWithOrder()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateCollections("collectionsA", order: 10);

            // Assert
            stringBuilder.ToString().Should().Be("create collections collectionsA order 10\n");
        }
    }
}
