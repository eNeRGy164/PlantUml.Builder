
namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ControlTests
{
    [TestMethod]
    public void StringBuilderExtensions_Control_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Control("controlA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Control_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Control(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Control_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Control(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Control_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Control(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Control_Should_ContainControlLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Control("controlA");

        // Assert
        stringBuilder.ToString().Should().Be("control controlA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Control_WithDisplayName_Should_ContainControlLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Control("controlA", displayName: "Control A");

        // Assert
        stringBuilder.ToString().Should().Be("control \"Control A\" as controlA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Control_WithColor_Should_ContainControlLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Control("controlA", color: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("control controlA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Control_WithColorWithHashtag_Should_ContainControlLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Control("controlA", color: "#AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("control controlA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Control_WithOrder_Should_ContainControlLineWithOrder()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Control("controlA", order: 10);

        // Assert
        stringBuilder.ToString().Should().Be("control controlA order 10\n");
    }
}
