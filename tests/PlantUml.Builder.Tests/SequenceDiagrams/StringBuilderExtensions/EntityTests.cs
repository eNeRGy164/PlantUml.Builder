using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void StringBuilderExtensions_Entity_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.Entity("entityA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Entity(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Entity(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Entity(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_Should_ContainEntityLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("entityA");

            // Assert
            stringBuilder.ToString().Should().Be("entity entityA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithDisplayName_Should_ContainEntityLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("entityA", displayName: "Entity A");

            // Assert
            stringBuilder.ToString().Should().Be("entity \"Entity A\" as entityA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithColor_Should_ContainEntityLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("entityA", color: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("entity entityA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithColorWithHashtag_Should_ContainEntityLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("entityA", color: "#AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("entity entityA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithOrder_Should_ContainEntityLineWithOrder()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("entityA", order: 10);

            // Assert
            stringBuilder.ToString().Should().Be("entity entityA order 10\n");
        }
    }
}
