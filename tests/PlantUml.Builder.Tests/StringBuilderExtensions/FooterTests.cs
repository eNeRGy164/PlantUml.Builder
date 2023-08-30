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
        action.Should().ThrowExactly<ArgumentNullException>()
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
        action.Should().ThrowExactly<ArgumentException>()
            .WithParameterName("footer");
    }

    [TestMethod]
    public void FooterIsRenderedCorrectlyv()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Footer("Footer");

        // Assert
        stringBuilder.ToString().Should().Be("footer Footer\n");
    }
}
