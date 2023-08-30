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
}
