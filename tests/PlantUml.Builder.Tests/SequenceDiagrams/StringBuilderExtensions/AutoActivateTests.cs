namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class AutoActivateTests
{
    [TestMethod]
    public void AutoActivateEnumerationValueShouldExist()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.AutoActivate((OnOff)byte.MaxValue);

        // Assert
        action.ShouldThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("A defined enum value should be provided*")
            .WithParameterName("mode");
    }

    [DataRow(null, "autoactivate on", DisplayName = "AutoActivate - Default is On")]
    [DataRow(OnOff.On, "autoactivate on", DisplayName = "AutoActivate - With On parameter")]
    [DataRow(OnOff.Off, "autoactivate off", DisplayName = "AutoActivate - With Off parameter")]
    [TestMethod]
    public void AutoActivateIsRenderedCorrectly(OnOff? onOff, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        if (onOff.HasValue)
        {
            stringBuilder.AutoActivate(onOff.Value);
        }
        else
        {
            stringBuilder.AutoActivate();
        }

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }
}
