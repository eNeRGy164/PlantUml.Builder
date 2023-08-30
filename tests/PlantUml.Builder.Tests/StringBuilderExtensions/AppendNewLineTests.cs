namespace PlantUml.Builder.Tests;

[TestClass]
public class AppendNewLineTests
{
    [TestMethod]
    public void StringBuilderExtensions_AppendNewLine_Null_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.AppendNewLine();

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_AppendNewLine_Should_ContainNewLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.AppendNewLine();

        // Assert
        stringBuilder.ToString().Should().Be("\n");
    }
}
