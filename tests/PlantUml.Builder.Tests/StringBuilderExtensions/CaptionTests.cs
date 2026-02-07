using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class CaptionTests
{
    [TestMethod]
    public void CaptionCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Caption(null);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("caption");
    }

    [DataRow(EmptyString, DisplayName = "Caption - Caption argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Caption - Caption argument cannot be any whitespace character")]
    [TestMethod]
    public void CaptionMustContainAValue(string caption)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Caption(caption);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithParameterName("caption");
    }

    [TestMethod]
    public void CaptionIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Caption("this is a caption");

        // Assert
        stringBuilder.ToString().Should().Be("caption this is a caption\n");
    }

    [TestMethod]
    public void CaptionEscapesNewLines()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Caption("caption\nline");

        // Assert
        stringBuilder.ToString().Should().Be("caption caption\\nline\n");
    }
}
