using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class TrimEndTests
{
    [TestMethod]
    public void StringBuilderExtensions_TrimEnd_Null_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.TrimEnd();

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_TrimEnd_WithWhitespace_Should_BeEmpty()
    {
        // Assign
        var stringBuilder = new StringBuilder("   ");

        // Act
        stringBuilder.TrimEnd();

        // Assert
        stringBuilder.ToString().Should().BeEmpty();
    }

    [TestMethod]
    public void StringBuilderExtensions_TrimEnd_TextWithWhitespace_Should_BeTextOnly()
    {
        // Arrange
        var stringBuilder = new StringBuilder("Text   ");

        // Act
        stringBuilder.TrimEnd();

        // Assert
        stringBuilder.ToString().Should().Be("Text");
    }

    [TestMethod]
    public void StringBuilderExtensions_TrimEnd_OnlyText_Should_BeUnaltered()
    {
        // Assign
        var stringBuilder = new StringBuilder("Text");

        // Act
        stringBuilder.TrimEnd();

        // Assert
        stringBuilder.ToString().Should().Be("Text");
    }

    [TestMethod]
    public void StringBuilderExtensions_TrimEnd_Empty_Should_StayEmpty()
    {
        // Assign
        var stringBuilder = new StringBuilder("");

        // Act
        stringBuilder.TrimEnd();

        // Assert
        stringBuilder.ToString().Should().BeEmpty();
    }
}
