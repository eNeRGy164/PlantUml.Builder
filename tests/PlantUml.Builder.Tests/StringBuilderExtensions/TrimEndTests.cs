using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class TrimEndTests
{
    [DataRow(EmptyString, DisplayName = "TrimEnd - Stays empty")]
    [DataRow(AllWhitespace, DisplayName = "TrimEnd - All input is whitespace")]
    [TestMethod]
    public void TrimEndRemovesTrailingWhitespace(string input)
    {
        // Arrange
        var stringBuilder = new StringBuilder(input);

        // Act
        stringBuilder.TrimEnd();

        // Assert
        stringBuilder.ToString().Should().BeEmpty();
    }

    [DataRow(AnyString, AnyString, DisplayName = "TrimEnd - Text without trailing whitespace remains unaltered")]
    [DataRow("Text   ", "Text", DisplayName = "TrimEnd - Trims trailing whitespace")]
    [TestMethod]
    public void TrimEndTrimsTrailingWhitespace(string input, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder(input);

        // Act
        stringBuilder.TrimEnd();

        // Assert
        stringBuilder.ToString().Should().Be(expected);
    }
}
