using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests
{
    [TestClass]
    public class CreateDatabaseTests
    {
        [TestMethod]
        public void StringBuilderExtensions_CreateDatabase_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.CreateDatabase("databaseA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateDatabase_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateDatabase(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateDatabase_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateDatabase(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateDatabase_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.CreateDatabase(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateDatabase_Should_ContainCreateDatabaseLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateDatabase("databaseA");

            // Assert
            stringBuilder.ToString().Should().Be("create database databaseA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateDatabase_WithDisplayName_Should_ContainCreateDatabaseLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateDatabase("databaseA", displayName: "Database A");

            // Assert
            stringBuilder.ToString().Should().Be("create database \"Database A\" as databaseA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateDatabase_WithColor_Should_ContainCreateDatabaseLineWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateDatabase("databaseA", color: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("create database databaseA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CreateDatabase_WithOrder_Should_ContainCreateDatabaseLineWithOrder()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CreateDatabase("databaseA", order: 10);

            // Assert
            stringBuilder.ToString().Should().Be("create database databaseA order 10\n");
        }
    }
}
