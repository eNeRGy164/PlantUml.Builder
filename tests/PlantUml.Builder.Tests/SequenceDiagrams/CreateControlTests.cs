using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public class CreateControlTests
    {
        [TestMethod]
        public void StringBuilderExtensions_CreateControl_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.CreateControl("controlA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateControl_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateControl(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateControl_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateControl(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateControl_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateControl(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateControl_Should_ContainCreateControlLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateControl("controlA");

            // Assert
            stringBuilder.ToString().Should().Be("create control controlA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateControl_WithDisplayName_Should_ContainCreateControlLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateControl("controlA", displayName: "Control A");

            // Assert
            stringBuilder.ToString().Should().Be("create control \"Control A\" as controlA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateControl_WithColor_Should_ContainCreateControlLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateControl("controlA", color: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("create control controlA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateControl_WithOrder_Should_ContainCreateControlLineWithOrder()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateControl("controlA", order: 10);

            // Assert
            stringBuilder.ToString().Should().Be("create control controlA order 10\n");
        }
    }
}
