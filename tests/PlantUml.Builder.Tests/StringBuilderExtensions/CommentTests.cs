namespace PlantUml.Builder.Tests;

[TestClass]
public class CommentTests
{
    [DataRow(null, "'", DisplayName = "Comment - Handles an empty comment")]
    [DataRow("This is a comment", "' This is a comment", DisplayName = "Comment - Renders a comment with content")]
    [DataRow("\nThis is a comment\non multiple lines\n", "' \\nThis is a comment\\non multiple lines\\n", DisplayName = "Comment - Escapes new lines inside a comment")]
    [TestMethod]
    public void CommentIsRenderedCorrectly(string comment, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Comment(comment);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
