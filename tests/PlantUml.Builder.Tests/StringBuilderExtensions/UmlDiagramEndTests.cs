namespace PlantUml.Builder.Tests;

[TestClass]
public class UmlDiagramEndTests
{
    [TestMethod]
    public void UmlDiagramEndIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be("@enduml\n");
    }
}
