using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class FooterTests
{
    [TestMethod]
    public void FooterCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Footer(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("footer");
    }

    [DataRow(EmptyString, DisplayName = "Footer - Footer argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Footer - Footer argument cannot be any whitespace character")]
    [TestMethod]
    public void FooterMustContainAValue(string footer)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Footer(footer);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("footer");
    }

    [TestMethod]
    public void FooterIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Footer("Footer");

        // Assert
        stringBuilder.ToString().ShouldBe("footer Footer\n");
    }

    [TestMethod("Footer - Newlines are escaped")]
    public void FooterEscapesNewLines()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Footer("Footer\nLine");

        // Assert
        stringBuilder.ToString().ShouldBe("footer Footer\\nLine\n");
    }

    [DataRow("left", "left footer Footer\n", DisplayName = "Footer - Left alignment")]
    [DataRow("center", "center footer Footer\n", DisplayName = "Footer - Center alignment")]
    [DataRow("right", "right footer Footer\n", DisplayName = "Footer - Right alignment")]
    [TestMethod]
    public void FooterAlignmentIsRenderedCorrectly(string alignment, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Footer("Footer", new Alignment(alignment));

        // Assert
        stringBuilder.ToString().ShouldBe(expected);
    }

    [TestMethod("Footer - Invalid alignment is ignored")]
    public void FooterAlignmentIgnoresInvalidValues()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Footer("Footer", new Alignment("invalid"));

        // Assert
        stringBuilder.ToString().ShouldBe("footer Footer\n");
    }

    [TestMethod("FooterStart - renders footer block start")]
    public void FooterStartIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.FooterStart();

        // Assert
        stringBuilder.ToString().ShouldBe("footer\n");
    }

    [DataRow("left", "left footer\n", DisplayName = "FooterStart - Left alignment")]
    [DataRow("center", "center footer\n", DisplayName = "FooterStart - Center alignment")]
    [DataRow("right", "right footer\n", DisplayName = "FooterStart - Right alignment")]
    [TestMethod]
    public void FooterStartAlignmentIsRenderedCorrectly(string alignment, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.FooterStart(new Alignment(alignment));

        // Assert
        stringBuilder.ToString().ShouldBe(expected);
    }

    [TestMethod("FooterStart - Invalid alignment is ignored")]
    public void FooterStartAlignmentIgnoresInvalidValues()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.FooterStart(new Alignment("invalid"));

        // Assert
        stringBuilder.ToString().ShouldBe("footer\n");
    }

    [TestMethod("EndFooter - renders footer block end")]
    public void EndFooterIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.EndFooter();

        // Assert
        stringBuilder.ToString().ShouldBe("end footer\n");
    }
}
