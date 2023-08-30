namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class SpaceTests
{
    [DataRow(null, "|||", DisplayName = "Space - Default sized space")]
    [DataRow(45, "||45||", DisplayName = "Space - Custom sized space")]
    [TestMethod]
    public void SpaceIsRenderedCorrectly(int? size, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Space(size);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
