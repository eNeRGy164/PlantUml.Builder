namespace PlantUml.Builder.Tests;

[TestClass]
public class LegendTests
{
    [TestMethod]
    public void LegendStartIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.LegendStart();

        // Assert
        stringBuilder.ToString().Should().Be("legend\n");
    }

    [DataRow(LegendAlignment.Left, "legend left\n", DisplayName = "LegendStart - Left alignment")]
    [DataRow(LegendAlignment.Center, "legend center\n", DisplayName = "LegendStart - Center alignment")]
    [DataRow(LegendAlignment.Right, "legend right\n", DisplayName = "LegendStart - Right alignment")]
    [DataRow(LegendAlignment.Top, "legend top\n", DisplayName = "LegendStart - Top position")]
    [DataRow(LegendAlignment.Bottom, "legend bottom\n", DisplayName = "LegendStart - Bottom position")]
    [DataRow(LegendAlignment.TopLeft, "legend top left\n", DisplayName = "LegendStart - TopLeft position")]
    [DataRow(LegendAlignment.TopCenter, "legend top center\n", DisplayName = "LegendStart - TopCenter position")]
    [DataRow(LegendAlignment.TopRight, "legend top right\n", DisplayName = "LegendStart - TopRight position")]
    [DataRow(LegendAlignment.BottomLeft, "legend bottom left\n", DisplayName = "LegendStart - BottomLeft position")]
    [DataRow(LegendAlignment.BottomCenter, "legend bottom center\n", DisplayName = "LegendStart - BottomCenter position")]
    [DataRow(LegendAlignment.BottomRight, "legend bottom right\n", DisplayName = "LegendStart - BottomRight position")]
    [TestMethod]
    public void LegendStartWithAlignmentIsRenderedCorrectly(LegendAlignment alignment, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.LegendStart(alignment);

        // Assert
        stringBuilder.ToString().Should().Be(expected);
    }

    [TestMethod]
    public void LegendStartSupportsFlagsComposition()
    {
        // Arrange
        var stringBuilder = new StringBuilder();
        var alignment = LegendAlignment.Top | LegendAlignment.Left;

        // Act
        stringBuilder.LegendStart(alignment);

        // Assert
        stringBuilder.ToString().Should().Be("legend top left\n");
    }

    [DataRow((LegendAlignment)byte.MaxValue, DisplayName = "LegendStart - Undefined enum value is rejected")]
    [DataRow(LegendAlignment.Top | LegendAlignment.Bottom, DisplayName = "LegendStart - Conflicting vertical flags are rejected")]
    [DataRow(LegendAlignment.Left | LegendAlignment.Center, DisplayName = "LegendStart - Conflicting horizontal flags are rejected")]
    [TestMethod]
    public void LegendStartAlignmentMustBeAValidDefinedValue(LegendAlignment alignment)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.LegendStart(alignment);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("A defined enum value should be provided*")
            .WithParameterName("alignment");
    }

    [TestMethod]
    public void EndLegendIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.EndLegend();

        // Assert
        stringBuilder.ToString().Should().Be("end legend\n");
    }
}
