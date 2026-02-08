namespace PlantUml.Builder.Tests;

[TestClass]
public class AllowMixingTests
{
    [TestMethod]
    public void AllowMixingIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.AllowMixing();

        // Assert
        stringBuilder.ToString().ShouldBe("allow_mixing\n");
    }
}
