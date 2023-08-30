using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class NewPageTests
{
    [TestMethod]
    public void StringBuilderExtensions_NewPage_Null_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.NewPage();

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_NewPage_NullWithTitle_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;
        // Act
        Action action = () => stringBuilder.NewPage("Page header");
        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }
    [TestMethod]
    public void StringBuilderExtensions_NewPage_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.NewPage(null);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("title");
    }

    [TestMethod]
    public void StringBuilderExtensions_NewPage_EmptyName_Should_ThrowArgumentException()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.NewPage(string.Empty);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("title");
    }

    [TestMethod]
    public void StringBuilderExtensions_NewPage_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.NewPage(" ");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("title");
    }

    [TestMethod]
    public void StringBuilderExtensions_NewPage_Should_ContainNewPageLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.NewPage();

        // Assert
        stringBuilder.ToString().Should().Be("newpage\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_NewPage_WithTitle_Should_ContainNewPageLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.NewPage("Page header");

        // Assert
        stringBuilder.ToString().Should().Be("newpage Page header\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_NewPage_WithNewLine_Should_EscapeNewLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.NewPage("Page\nheader");

        // Assert
        stringBuilder.ToString().Should().Be("newpage Page\\nheader\n");
    }
}
