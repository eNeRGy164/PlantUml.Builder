namespace PlantUml.Builder.Tests;

[TestClass]
public class AlignmentTests
{
    [DataRow(null, "", DisplayName = "Alignment - Constructor with `null` returns empty string")]
    [DataRow("left", "left", DisplayName = "Alignment - Left is normalized")]
    [DataRow(" Center ", "center", DisplayName = "Alignment - Center is normalized")]
    [DataRow("RIGHT", "right", DisplayName = "Alignment - Right is normalized")]
    [DataRow("invalid", "", DisplayName = "Alignment - Invalid value returns empty string")]
    [TestMethod]
    public void AlignmentConstructedWithStringIsRenderedCorrectly(string input, string expected)
    {
        // Arrange & act
        var alignment = new Alignment(input);

        // Assert
        alignment.ToString().ShouldBe(expected);
    }

    [TestMethod]
    public void AlignmentCastedStringIsRenderedCorrectly()
    {
        // Arrange
        var value = "left";

        // Act
        var alignment = (Alignment)value;

        // Assert
        alignment.ToString().ShouldBe("left");
    }
}
