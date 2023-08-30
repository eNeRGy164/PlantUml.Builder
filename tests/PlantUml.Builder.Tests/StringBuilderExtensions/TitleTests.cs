using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class TitleTests
{
    [TestMethod]
    public void TitleCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Title(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("title");
    }

    [DataRow(EmptyString, DisplayName = "Title - Title argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Title - Title argument cannot be any whitespace character")]
    [TestMethod]
    public void TextMustContainAValue(string text)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Title(text);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("title");
    }

    [TestMethod]
    public void TitleIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Title("Title");

        // Assert
        stringBuilder.ToString().Should().Be("title Title\n");
    }
}
