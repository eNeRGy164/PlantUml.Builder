
namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class BoundaryTests
{
    [TestMethod]
    public void StringBuilderExtensions_Boundary_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Boundary("boundaryA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Boundary_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Boundary(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Boundary_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Boundary(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Boundary_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Boundary(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Boundary_Should_ContainBoundaryLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Boundary("boundaryA");

        // Assert
        stringBuilder.ToString().Should().Be("boundary boundaryA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Boundary_WithDisplayName_Should_ContainBoundaryLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Boundary("boundaryA", displayName: "Boundary A");

        // Assert
        stringBuilder.ToString().Should().Be("boundary \"Boundary A\" as boundaryA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Boundary_WithColor_Should_ContainBoundaryLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Boundary("boundaryA", color: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("boundary boundaryA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Boundary_WithColorWithHashtag_Should_ContainBoundaryLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Boundary("boundaryA", color: "#AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("boundary boundaryA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Boundary_WithOrder_Should_ContainBoundaryLineWithOrder()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Boundary("boundaryA", order: 10);

        // Assert
        stringBuilder.ToString().Should().Be("boundary boundaryA order 10\n");
    }
}
