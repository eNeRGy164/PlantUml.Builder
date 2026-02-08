namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class FootBoxTests
{
    [TestMethod]
    public void HideFootboxIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HideFootBox();

        // Assert
        stringBuilder.ToString().ShouldBe("hide footbox\n");
    }

    [TestMethod]
    public void ShowFootboxIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.ShowFootBox();

        // Assert
        stringBuilder.ToString().ShouldBe("show footbox\n");
    }
}
