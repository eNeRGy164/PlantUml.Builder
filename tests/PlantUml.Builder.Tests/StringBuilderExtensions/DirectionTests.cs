namespace PlantUml.Builder.Tests;

[TestClass]
public class DirectionTests
{
    [TestMethod]
    public void AutoActivateEnumerationValueShouldExist()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Direction((DiagramDirection)byte.MaxValue);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("A defined enum value should be provided*")
            .WithParameterName("direction");
    }

    [DataRow(DiagramDirection.LeftToRight, "left to right direction", DisplayName = "Direction - With LeftToRight parameter")]
    [DataRow(DiagramDirection.TopToBottom, "top to bottom direction", DisplayName = "Direction - With TopToBottom parameter")]
    [TestMethod]
    public void AutoActivateIsRenderedCorrectly(DiagramDirection direction, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Direction(direction);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
