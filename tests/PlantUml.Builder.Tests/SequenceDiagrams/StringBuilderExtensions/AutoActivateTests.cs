namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class AutoActivateTests
{
    [TestMethod]
    public void StringBuilderExtensions_AutoActivate_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.AutoActivate();

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_AutoActivate_Should_ContainAutoActivateLineWithOn()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.AutoActivate();

        // Assert
        stringBuilder.ToString().Should().Be("autoactivate on\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_AutoActivate_WithOn_Should_ContainAutoActivationLineWithOn()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.AutoActivate(OnOff.On);

        // Assert
        stringBuilder.ToString().Should().Be("autoactivate on\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_AutoActivate_WithOff_Should_ContainAutoActivationLineWithOff()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.AutoActivate(OnOff.Off);

        // Assert
        stringBuilder.ToString().Should().Be("autoactivate off\n");
    }
}
