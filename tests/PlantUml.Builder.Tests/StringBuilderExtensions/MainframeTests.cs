using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class MainframeTests
{
    [TestMethod]
    public void MainframeIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Mainframe("This is a **mainframe**");

        // Assert
        stringBuilder.ToString().Should().Be("mainframe This is a **mainframe**\n");
    }

    [TestMethod]
    public void MainframeTitleCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Mainframe(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("title");
    }

    [DataRow(EmptyString, DisplayName = "Mainframe - Title cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Mainframe - Title cannot be any whitespace character")]
    [TestMethod]
    public void MainframeTitleMustContainAValue(string title)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Mainframe(title);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("title");
    }
}
