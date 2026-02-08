using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class RemoveTests
{
    [TestMethod("Remove - What argument cannot be `null`")]
    public void RemoveWhatCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Remove(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("what");
    }

    [DataRow(EmptyString, DisplayName = "Remove - What argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Remove - What argument cannot be any whitespace character")]
    [TestMethod]
    public void RemoveWhatMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Remove(name);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("what");
    }

    [TestMethod]
    public void RemoveIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Remove("name");

        // Assert
        stringBuilder.ToString().ShouldBe("remove name\n");
    }
}
