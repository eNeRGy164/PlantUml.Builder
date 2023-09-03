using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class DestroyTests
{
    [TestMethod]
    public void DestroyNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Destroy(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Destroy - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Destroy - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void DestroyNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Destroy(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [TestMethod]
    public void DestroyIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Destroy("actorA");

        // Assert
        stringBuilder.ToString().Should().Be("destroy actorA\n");
    }
}
