using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class DeactivateTests
{
    [TestMethod]
    public void StringBuilderExtensions_Deactivate_Null_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Deactivate();

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Deactivate_NullWithName_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Deactivate("actorA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Deactivate_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Deactivate(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Deactivate_EmptyName_Should_ThrowArgumentException()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Deactivate(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Deactivate_WhitespaceName_Should_ThrowArgumentException()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Deactivate(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Deactivate_WithName_Should_ContainDeactivateLineWithName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Deactivate("actorA");

        // Assert
        stringBuilder.ToString().Should().Be("deactivate actorA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Deactivate_NoParameters_Should_ContainDeactivateLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Deactivate();

        // Assert
        stringBuilder.ToString().Should().Be("deactivate\n");
    }
}
