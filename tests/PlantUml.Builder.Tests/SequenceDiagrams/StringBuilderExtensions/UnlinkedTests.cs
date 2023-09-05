namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class UnlinkedTests
{
    [TestMethod]
    public void HideUnlinkedIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HideUnlinked();

        // Assert
        stringBuilder.ToString().Should().Be("hide unlinked\n");
    }

    [TestMethod]
    public void ShowUnlinkedIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.ShowUnlinked();

        // Assert
        stringBuilder.ToString().Should().Be("show unlinked\n");
    }
}
