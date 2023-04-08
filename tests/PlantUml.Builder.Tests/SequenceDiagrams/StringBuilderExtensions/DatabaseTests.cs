using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class DatabaseTests
{
    [TestMethod]
    public void StringBuilderExtensions_Database_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Database("databaseA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Database_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Database(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Database_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Database(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Database_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Database(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Database_Should_ContainDatabaseLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Database("databaseA");

        // Assert
        stringBuilder.ToString().Should().Be("database databaseA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Database_WithDisplayName_Should_ContainDatabaseLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Database("databaseA", displayName: "Database A");

        // Assert
        stringBuilder.ToString().Should().Be("database \"Database A\" as databaseA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Database_WithColor_Should_ContainDatabaseLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Database("databaseA", color: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("database databaseA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Database_WithColorWithHashtag_Should_ContainDatabaseLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Database("databaseA", color: "#AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("database databaseA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Database_WithOrder_Should_ContainDatabaseLineWithOrder()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Database("databaseA", order: 10);

        // Assert
        stringBuilder.ToString().Should().Be("database databaseA order 10\n");
    }
}
