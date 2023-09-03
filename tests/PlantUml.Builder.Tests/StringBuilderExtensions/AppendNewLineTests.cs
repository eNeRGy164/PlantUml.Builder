namespace PlantUml.Builder.Tests;

[TestClass]
public class AppendNewLineTests
{
    [TestMethod]
    public void AppendNewLineReturnsANewLine()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.AppendNewLine();

        // Assert
        stringBuilder.ToString().Should().Be("\n");
    }
}
