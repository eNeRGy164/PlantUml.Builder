using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class PragmaTests
{
    [TestMethod]
    public void PragmaIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Pragma("teoz", "true");

        // Assert
        stringBuilder.ToString().Should().Be("!pragma teoz true\n");
    }

    [TestMethod]
    public void PragmaBoolIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Pragma("teoz", true);

        // Assert
        stringBuilder.ToString().Should().Be("!pragma teoz true\n");
    }

    [DataRow("name", null, "true", DisplayName = "Pragma - Name argument cannot be `null`")]
    [DataRow("value", "teoz", null, DisplayName = "Pragma - Value argument cannot be `null`")]
    [TestMethod]
    public void PragmaArgumentsCannotBeNull(string parameterName, string name, string value)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Pragma(name, value);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName(parameterName);
    }

    [DataRow("name", EmptyString, "true", DisplayName = "Pragma - Name argument cannot be empty")]
    [DataRow("name", AllWhitespace, "true", DisplayName = "Pragma - Name argument cannot be any whitespace character")]
    [DataRow("value", "teoz", EmptyString, DisplayName = "Pragma - Value argument cannot be empty")]
    [DataRow("value", "teoz", AllWhitespace, DisplayName = "Pragma - Value argument cannot be any whitespace character")]
    [TestMethod]
    public void PragmaArgumentsMustContainAValue(string parameterName, string name, string value)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Pragma(name, value);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName(parameterName);
    }
}
