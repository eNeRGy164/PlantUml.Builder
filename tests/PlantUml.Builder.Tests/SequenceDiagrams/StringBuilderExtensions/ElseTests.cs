namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ElseTests
{
    [DataRow(null, "else", DisplayName = "ElseStart - Should only contain 'else'")]
    [DataRow("Title", "else Title", DisplayName = "ElseStart - With title argument should include the title")]
    [TestMethod]
    public void ElseStartIsRenderedCorrectly(string text, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.ElseStart(text);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }
}
