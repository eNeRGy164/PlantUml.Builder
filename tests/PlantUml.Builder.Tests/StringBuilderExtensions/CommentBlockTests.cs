namespace PlantUml.Builder.Tests;

[TestClass]
public class CommentBlockTests
{
    [DataRow(null, "/'  '/", DisplayName = "CommentBlock - Handles an empty comment block")]
    [DataRow("This is a comment", "/' This is a comment '/", DisplayName = "CommentBlock - Renders a comment block with content")]
    [DataRow("\nThis is a comment\non multiple lines\n", "/' \nThis is a comment\non multiple lines\n '/", DisplayName = "CommentBlock - Supports new lines inside a comment block")]
    [TestMethod]
    public void CommentBlockIsRenderedCorrectly(string comment, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.CommentBlock(comment);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
