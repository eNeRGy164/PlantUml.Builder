using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ReturnTests
{
    [TestMethod]
    public void StringBuilderExtensions_Return_Null_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Return();

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Return_NullWithMessage_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;
        // Act
        Action action = () => stringBuilder.Return("Result");
        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Return_NullMessage_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Return(null);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("message");
    }

    [TestMethod]
    public void StringBuilderExtensions_Return_EmptyMessage_Should_ThrowArgumentException()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Return(string.Empty);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("message");
    }

    [TestMethod]
    public void StringBuilderExtensions_Return_WhitespaceMessage_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Return(" ");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("message");
    }

    [TestMethod]
    public void StringBuilderExtensions_Return_Should_ContainReturnLine()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Return();

        // Assert
        stringBuilder.ToString().Should().Be("return\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Return_WithMessage_Should_ContainReturnLineWithMessage()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Return("Result");

        // Assert
        stringBuilder.ToString().Should().Be("return Result\n");
    }
}
