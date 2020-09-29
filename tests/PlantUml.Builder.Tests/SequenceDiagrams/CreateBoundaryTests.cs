using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public class CreateBoundaryTests
    {
        [TestMethod]
        public void StringBuilderExtensions_CreateBoundary_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.CreateBoundary("boundaryA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateBoundary_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateBoundary(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateBoundary_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateBoundary(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateBoundary_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateBoundary(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateBoundary_Should_ContainCreateBoundaryLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateBoundary("boundaryA");

            // Assert
            stringBuilder.ToString().Should().Be("create boundary boundaryA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateBoundary_WithDisplayName_Should_ContainCreateBoundaryLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateBoundary("boundaryA", displayName: "Boundary A");

            // Assert
            stringBuilder.ToString().Should().Be("create boundary \"Boundary A\" as boundaryA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateBoundary_WithColor_Should_ContainCreateBoundaryLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateBoundary("boundaryA", color: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("create boundary boundaryA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateBoundary_WithOrder_Should_ContainCreateBoundaryLineWithOrder()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateBoundary("boundaryA", order: 10);

            // Assert
            stringBuilder.ToString().Should().Be("create boundary boundaryA order 10\n");
        }
    }
}
