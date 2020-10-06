using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests
{
    [TestClass]
    public class ActivateTests
    {
        [TestMethod]
        public void StringBuilderExtensions_Activate_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.Activate("actor");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_Activate_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Activate(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Activate_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Activate(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Activate_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Activate(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Activate_Should_ContainActivateLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Activate("actor");

            // Assert
            stringBuilder.ToString().Should().Be("activate actor\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Activate_WithColor_Should_ContainActivationLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Activate("actor", "Blue");

            // Assert
            stringBuilder.ToString().Should().Be("activate actor #Blue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Activate_WithColorWithHashTag_Should_ContainActivationLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Activate("actor", "#Blue");

            // Assert
            stringBuilder.ToString().Should().Be("activate actor #Blue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Activate_WithOnlyBorderColor_Should_ContainActivationLineWithNoColors()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Activate("actor", borderColor: "Blue");

            // Assert
            stringBuilder.ToString().Should().Be("activate actor\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Activate_WithColorAndBorderColor_Should_ContainActivationLineWithColors()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Activate("actor", "Blue", NamedColor.APPLICATION);

            // Assert
            stringBuilder.ToString().Should().Be("activate actor #Blue #APPLICATION\n");
        }
    }
}
