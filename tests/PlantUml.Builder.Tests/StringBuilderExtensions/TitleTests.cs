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

    [DataRow("Title", "title Title", DisplayName = "Title - Simple title")]
    [DataRow("Title\nNewLine", "title Title\\nNewLine", DisplayName = "Title - Newlines are escaped")]
    [TestMethod]
    public void TitleIsRenderedCorrectly(string title, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Title(title);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
