using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class TextTests
{
    [TestMethod]
    public void StringBuilderExtensions_Text_Null_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Text("text line");

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Text_NullText_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Text(null);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("text");
    }

    [TestMethod]
    public void StringBuilderExtensions_Text_EmptyText_Should_ThrowArgumentException()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Text(string.Empty);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("text");
    }

    [TestMethod]
    public void StringBuilderExtensions_Text_WhitespaceText_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Text(" ");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("text");
    }

    [TestMethod]
    public void StringBuilderExtensions_Text_WithText_Should_ContainTextLineWithText()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Text("text line");

        // Assert
        stringBuilder.ToString().Should().Be("text line\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Text_WithNewLine_Should_EscapeNewLine()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Text("text line\nanother text line");

        // Assert
        stringBuilder.ToString().Should().Be("text line\\nanother text line\n");
    }
}
