using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class HeaderTests
{
    [TestMethod("Header - Header argument cannot be `null`")]
    public void HeaderCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Header(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("header");
    }

    [DataRow(EmptyString, DisplayName = "Header - Header argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Header - Header argument cannot be any whitespace character")]
    [TestMethod]
    public void HeaderMustContainAValue(string header)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Header(header);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("header");
    }

    [TestMethod("Header is rendered correctly")]
    public void HeaderIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Header("Header");

        // Assert
        stringBuilder.ToString().Should().Be("header Header\n");
    }

    [TestMethod("Header - Newlines are escaped")]
    public void HeaderEscapesNewLines()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Header("Header\nLine");

        // Assert
        stringBuilder.ToString().Should().Be("header Header\\nLine\n");
    }

    [DataRow("left", "left header Header\n", DisplayName = "Header - Left alignment")]
    [DataRow("center", "center header Header\n", DisplayName = "Header - Center alignment")]
    [DataRow("right", "right header Header\n", DisplayName = "Header - Right alignment")]
    [TestMethod]
    public void HeaderAlignmentIsRenderedCorrectly(string alignment, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Header("Header", new Alignment(alignment));

        // Assert
        stringBuilder.ToString().Should().Be(expected);
    }

    [TestMethod("Header - Invalid alignment is ignored")]
    public void HeaderAlignmentIgnoresInvalidValues()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Header("Header", new Alignment("invalid"));

        // Assert
        stringBuilder.ToString().Should().Be("header Header\n");
    }

    [TestMethod("HeaderStart - renders header block start")]
    public void HeaderStartIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HeaderStart();

        // Assert
        stringBuilder.ToString().Should().Be("header\n");
    }

    [DataRow("left", "left header\n", DisplayName = "HeaderStart - Left alignment")]
    [DataRow("center", "center header\n", DisplayName = "HeaderStart - Center alignment")]
    [DataRow("right", "right header\n", DisplayName = "HeaderStart - Right alignment")]
    [TestMethod]
    public void HeaderStartAlignmentIsRenderedCorrectly(string alignment, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HeaderStart(new Alignment(alignment));

        // Assert
        stringBuilder.ToString().Should().Be(expected);
    }

    [TestMethod("HeaderStart - Invalid alignment is ignored")]
    public void HeaderStartAlignmentIgnoresInvalidValues()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HeaderStart(new Alignment("invalid"));

        // Assert
        stringBuilder.ToString().Should().Be("header\n");
    }

    [TestMethod("EndHeader - renders header block end")]
    public void EndHeaderIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.EndHeader();

        // Assert
        stringBuilder.ToString().Should().Be("end header\n");
    }
}
