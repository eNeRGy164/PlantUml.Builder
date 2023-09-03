namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class DelayTests
{
    [DataRow(default, "...", DisplayName = "Delay - Default delay line")]
    [DataRow("5 minutes later", "...5 minutes later...", DisplayName = "Delay - With message")]
    [TestMethod]
    public void DelayIsRenderedCorrectly(string message, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Delay(message);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
