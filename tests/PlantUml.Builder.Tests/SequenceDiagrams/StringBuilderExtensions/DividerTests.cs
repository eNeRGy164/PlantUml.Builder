namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class DividerTests
{
    [DataRow(null, "====", DisplayName = "Divider - Without label should only contain the divider line")]
    [DataRow("Initialization", "==Initialization==", DisplayName = "Divider - With label should contain the divider line with the title")]
    [TestMethod]
    public void DividerIsRenderedCorrectly(string title, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Divider(title);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
