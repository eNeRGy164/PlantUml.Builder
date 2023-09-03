using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ReturnTests
{
    [TestMethod("Return - Message argument cannot be `null`")]
    public void ReturnMessageCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Return(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("message");
    }

    [DataRow(EmptyString, DisplayName = "Return - Message argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Return - Message argument cannot be any whitespace character")]
    [TestMethod]
    public void ReturnMessageMustContainAValue(string participant)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Return(participant);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("message");
    }

    [TestMethod("Return - Without message is rendered correctly")]
    public void ReturnIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Return();

        // Assert
        stringBuilder.ToString().Should().Be("return\n");
    }

    [TestMethod("Return - With message is rendered correctly")]
    public void ReturnWithMessageIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Return("Result");

        // Assert
        stringBuilder.ToString().Should().Be("return Result\n");
    }
}
