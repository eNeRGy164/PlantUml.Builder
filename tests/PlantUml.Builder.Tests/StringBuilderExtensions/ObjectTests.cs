using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class ObjectTests
    {
        [TestMethod]
        public void StringBuilderExtensions_Object_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.Object("name");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Object(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Object(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Object(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_WithName_Should_ContainObjectLineWithName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Object("name");

            // Assert
            stringBuilder.ToString().Should().Be("object name\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_WithDisplayName_Should_ContainObjectLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Object("name", displayName: "Display Name");

            // Assert
            stringBuilder.ToString().Should().Be("object \"Display Name\" as name\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_WithStereoType_Should_ContainObjectLineWithStereoType()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Object("name", stereotype: "stereotype");

            // Assert
            stringBuilder.ToString().Should().Be("object name <<stereotype>>\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_WithUrl_Should_ContainObjectLineWithStereoType()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Object("name", url: new Uri("https://blog.hompus.nl"));

            // Assert
            stringBuilder.ToString().Should().Be("object name [[https://blog.hompus.nl/]]\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_WithColor_Should_ContainObjectLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Object("name", backgroundColor: NamedColor.Blue);

            // Assert
            stringBuilder.ToString().Should().Be("object name #Blue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Object_WithAllProperties_Should_ContainObjectLineWithPropertiesInCorrectOrder()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Object("name", "Display Name", "stereotype", new Uri("https://blog.hompus.nl"), NamedColor.Blue);

            // Assert
            stringBuilder.ToString().Should().Be("object \"Display Name\" as name <<stereotype>> [[https://blog.hompus.nl/]] #Blue\n");
        }
    }
}
