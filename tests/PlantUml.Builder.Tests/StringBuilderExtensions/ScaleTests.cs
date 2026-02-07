using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class ScaleTests
{
    [TestMethod]
    public void ScaleStringCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Scale(null);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("scale");
    }

    [DataRow(EmptyString, DisplayName = "Scale - Scale argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Scale - Scale argument cannot be any whitespace character")]
    [TestMethod]
    public void ScaleStringMustContainAValue(string scale)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Scale(scale);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithParameterName("scale");
    }

    [DataRow("2", "scale 2\n", DisplayName = "Scale - Ratio")]
    [DataRow("2/3", "scale 2/3\n", DisplayName = "Scale - Fraction")]
    [TestMethod]
    public void ScaleStringIsRenderedCorrectly(string scale, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Scale(scale);

        // Assert
        stringBuilder.ToString().Should().Be(expected);
    }

    [DataRow(180, 90, false, "scale 180*90\n", DisplayName = "Scale(width,height)")]
    [DataRow(300, 200, true, "scale max 300*200\n", DisplayName = "Scale(width,height,max)")]
    [TestMethod]
    public void ScaleWidthHeightIsRenderedCorrectly(int width, int height, bool max, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Scale(width, height, max);

        // Assert
        stringBuilder.ToString().Should().Be(expected);
    }

    [DataRow(0, 90, "width", DisplayName = "Scale(width,height) - Width must be positive")]
    [DataRow(180, 0, "height", DisplayName = "Scale(width,height) - Height must be positive")]
    [DataRow(-1, 90, "width", DisplayName = "Scale(width,height) - Width must not be negative")]
    [DataRow(180, -1, "height", DisplayName = "Scale(width,height) - Height must not be negative")]
    [TestMethod]
    public void ScaleWidthHeightMustBePositive(int width, int height, string paramName)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Scale(width, height);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithParameterName(paramName);
    }

    [DataRow(200, ScaleDimension.Width, false, "scale 200 width\n", DisplayName = "Scale(pixels,dimension) - Width")]
    [DataRow(200, ScaleDimension.Height, false, "scale 200 height\n", DisplayName = "Scale(pixels,dimension) - Height")]
    [DataRow(1024, ScaleDimension.Width, true, "scale max 1024 width\n", DisplayName = "Scale(pixels,max,dimension) - Max width")]
    [DataRow(768, ScaleDimension.Height, true, "scale max 768 height\n", DisplayName = "Scale(pixels,max,dimension) - Max height")]
    [TestMethod]
    public void ScalePixelsDimensionIsRenderedCorrectly(int pixels, ScaleDimension dimension, bool max, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        if (max)
        {
            stringBuilder.Scale(pixels, true, dimension);
        }
        else
        {
            stringBuilder.Scale(pixels, dimension);
        }

        // Assert
        stringBuilder.ToString().Should().Be(expected);
    }

    [DataRow(0, DisplayName = "Scale(pixels,dimension) - Pixels must be positive")]
    [DataRow(-1, DisplayName = "Scale(pixels,dimension) - Pixels must not be negative")]
    [TestMethod]
    public void ScalePixelsMustBePositive(int pixels)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Scale(pixels, ScaleDimension.Width);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithParameterName("pixels");
    }

    [TestMethod]
    public void ScalePixelsDimensionMustBeDefined()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Scale(200, (ScaleDimension)99);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithParameterName("dimension");
    }
}
