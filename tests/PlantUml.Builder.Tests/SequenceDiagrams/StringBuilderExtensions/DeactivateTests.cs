using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class DeactivateTests
{
    [TestMethod]
    public void DeactivateNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Deactivate(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Deactivate - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Deactivate - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void DeactivateNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Deactivate(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DataRow(null, "deactivate\n", DisplayName = "Deactivate - No Parameters Should Contain Deactivate Line")]
    [DataRow("actorA", "deactivate actorA\n", DisplayName = "Deactivate - With Name Should Contain Deactivate Line With Name")]
    [TestMethod]
    public void DeactivateIsRenderedCorrectly(string actorName, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        if (actorName is not null)
        {
            stringBuilder.Deactivate(actorName);
        }
        else
        {
            stringBuilder.Deactivate();
        }

        // Assert
        stringBuilder.ToString().Should().Be(expected);
    }
}
