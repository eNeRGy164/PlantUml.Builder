namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class AltTests
{
    [DataRow(null, "alt", DisplayName = "AltStart - No additional content")]
    [DataRow("Title", "alt Title", DisplayName = "AltStart - With text")]
    [TestMethod]
    public void AltStartIsRenderedCorrectly(string text, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.AltStart(text);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }
}
