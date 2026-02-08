namespace PlantUml.Builder.Tests;

[TestClass]
public class UmlDiagramStartTests
{
    [DataRow(null, "@startuml", DisplayName = "UmlDiagramStart - No additional content")]
    [DataRow("example.puml", "@startuml example.puml", DisplayName = "UmlDiagramStart - With filename")]
    [TestMethod]
    public void CommentIsRenderedCorrectly(string comment, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart(comment);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }
}
