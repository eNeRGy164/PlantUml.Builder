namespace PlantUml.Builder.Tests;

[TestClass]
public class ColorTests
{
    [DataRow(null, "", DisplayName = "Color - Constructor with `null` should return empty string")]
    [DataRow("AliceBlue", "#AliceBlue", DisplayName = "Color - Constructor without hash tag should return value with hash tag")]
    [DataRow("#AliceBlue", "#AliceBlue", DisplayName = "Color - Constructor with hash tag should return value with hash tag")]
    [TestMethod]
    public void ColorConstructedWithStringIsRenderedCorrectly(string input, string expected)
    {
        // Arrange & act
        var color = new Color(input);

        // Assert
        color.ToString().Should().Be(expected);
    }

    [TestMethod]
    public void ColorConstructedWithEnumValueIsRenderedCorrectly()
    {
        // Arrange
        var color = new Color(NamedColor.AliceBlue);

        // Assert
        color.ToString().Should().Be("#AliceBlue");
    }

    [TestMethod]
    public void ColorCastedStringIsRenderedCorrectly()
    {
        // Arrange
        var value = "AliceBlue";

        // Act
        var color = (Color)value;

        // Assert
        color.ToString().Should().Be("#AliceBlue");
    }

    [TestMethod]
    public void ColorCastedEnumValueIsRenderedCorrectly()
    {
        // Arrange
        var value = NamedColor.AliceBlue;

        // Act
        var color = (Color)value;

        // Assert
        color.ToString().Should().Be("#AliceBlue");
    }

    [TestMethod]
    [DataRow("", "#AliceBlue", DisplayName = "Color - ToString with empty format should return color without brackets")]
    [DataRow("B", "[#AliceBlue]", DisplayName = "Color - ToString with 'B' format should return color with brackets")]
    public void ColorToStringFormatIsRenderedCorrectly(string format, string expected)
    {
        // Arrange
        var color = new Color(NamedColor.AliceBlue);

        // Act
        var value = color.ToString(format);

        // Assert
        value.Should().Be(expected);
    }
}
