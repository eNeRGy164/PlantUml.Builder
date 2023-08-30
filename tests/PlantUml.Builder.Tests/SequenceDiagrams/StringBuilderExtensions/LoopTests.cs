namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class LoopTests
{
    [DataRow(null, "loop", DisplayName = "StartLoop - Should generate loop line")]
    [DataRow("1000 times", "loop 1000 times", DisplayName = "StartLoop - Should generate loop line with label")]
    [TestMethod]
    public void StartLoopIsRenderedCorrectly(string label, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.StartLoop(label);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }

    [TestMethod]
    public void EndLoopIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.EndLoop();

        // Assert
        stringBuilder.ToString().Should().Be("end\n");
    }
}
