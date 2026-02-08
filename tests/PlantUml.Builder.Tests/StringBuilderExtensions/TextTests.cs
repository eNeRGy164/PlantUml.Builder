using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class TextTests
{
    [TestMethod]
    public void TextCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Text(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("text");
    }

    [DataRow(EmptyString, DisplayName = "Text - InputText argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Text - InputText argument cannot be any whitespace character")]
    [TestMethod]
    public void TextMustContainAValue(string text)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Text(text);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("text");
    }

    [DataRow("text line", "text line", DisplayName = "Text - Text line is provided")]
    [DataRow("text line\nanother text line", "text line\\nanother text line", DisplayName = "Text - New line is escaped")]
    [TestMethod]
    public void TextIsRenderedCorrectly(string inputText, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Text(inputText);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }
}
