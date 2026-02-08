using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class AutoNumberTests
{
    [DataRow("start", EmptyString, "<b>[000]", DisplayName = "AutoNumber - Start argument cannot be an empty string")]
    [DataRow("start", AllWhitespace, "<b>[000]", DisplayName = "AutoNumber - Start argument cannot contain only whitespace")]
    [DataRow("format", "1", EmptyString, DisplayName = "AutoNumber - Format argument cannot be an empty string")]
    [DataRow("format", "1", AllWhitespace, DisplayName = "AutoNumber - Format argument cannot contain only whitespace")]
    [TestMethod]
    public void AutoNumberParametersMustContainAValidValue(string parameterName, string start, string format)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.AutoNumber(start, default, format);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName(parameterName);
    }

    [DataRow(default, default, default, "autonumber", DisplayName = "AutoNumber - Basic usage with default parameters")]
    [DataRow(10, default, default, "autonumber 10", DisplayName = "AutoNumber - With numeric start value")]
    [DataRow("1.1.1", default, default, "autonumber 1.1.1", DisplayName = "AutoNumber - With string start value")]
    [DataRow(default, 10, default, "autonumber", DisplayName = "AutoNumber - Ignores step size when start value is absent")]
    [DataRow(10, 20, default, "autonumber 10 20", DisplayName = "AutoNumber - With both numeric start and step size")]
    [DataRow(default, default, "<b>[000]", "autonumber \"<b>[000]\"", DisplayName = "AutoNumber - With custom format only")]
    [DataRow(10, 20, "<b>[000]", "autonumber 10 20 \"<b>[000]\"", DisplayName = "AutoNumber - With all parameters including start, step, and format")]
    [TestMethod]
    public void AutoNumberIsRenderedCorrectly(object start, int? step, string format, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var startType = start?.GetType() ?? typeof(string);

        var method = typeof(StringBuilderExtensions).GetMethod("AutoNumber", new[] { typeof(StringBuilder), startType, typeof(int?), typeof(string) });
        var parameters = new object[] { stringBuilder, start, step, format };

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }

    [TestMethod]
    public void AutoNumberStopIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.StopAutoNumber();

        // Assert
        stringBuilder.ToString().ShouldBe("autonumber stop\n");
    }

    [DataRow(EmptyString, DisplayName = "ResumeAutoNumber - Format argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "ResumeAutoNumber - Format argument cannot be whitespace")]
    [TestMethod]
    public void AutoNumberResumeFormatMustContainAValue(string format)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.ResumeAutoNumber(default, format);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("format");
    }

    [DataRow(default, default, "autonumber resume", DisplayName = "ResumeAutoNumber - Basic resume without step size or format")]
    [DataRow(20, default, "autonumber resume 20", DisplayName = "ResumeAutoNumber - Resume with specified step size")]
    [DataRow(default, "<b>[000]", "autonumber resume \"<b>[000]\"", DisplayName = "ResumeAutoNumber - Resume with custom format")]
    [DataRow(20, "<b>[000]", "autonumber resume 20 \"<b>[000]\"", DisplayName = "ResumeAutoNumber - Resume with both step size and custom format")]
    [TestMethod]
    public void AutoNumberResumeIsRenderedCorrectly(int? step, string format, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.ResumeAutoNumber(step, format);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }

    [DataRow('1', DisplayName = "IncreaseAutoNumber - Position argument cannot be a numeric character")]
    [DataRow('Ç', DisplayName = "IncreaseAutoNumber - Position argument cannot be a outside the range A-Z")]
    [DataRow('þ', DisplayName = "IncreaseAutoNumber - Position argument cannot be a outside the range A-Z")]
    [DataRow('ë', DisplayName = "IncreaseAutoNumber - Position argument cannot contain diacritic marks")]
    [DataRow('¿', DisplayName = "IncreaseAutoNumber - Position argument cannot be a Unicode symbol")]
    [DataRow('!', DisplayName = "IncreaseAutoNumber - Position argument cannot be an ASCII symbols")]
    [DataRow((char)0, DisplayName = "IncreaseAutoNumber - Position argument cannot be a nul character")]
    [TestMethod]
    public void AutoNumberIncreasePositionParameterMustBeValid(char position)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.IncreaseAutoNumber(position);

        // Assert
        action.ShouldThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("Only the characters A - Z are allowed*")
            .WithParameterName("position");
    }

    [DataRow(default, "autonumber inc", DisplayName = "IncreaseAutoNumber - Position is optional and defaults to empty")]
    [DataRow('A', "autonumber inc A", DisplayName = "IncreaseAutoNumber - 'A' is the lowest valid position")]
    [DataRow('a', "autonumber inc a", DisplayName = "IncreaseAutoNumber - Position is case-insensitive")]
    [DataRow('Z', "autonumber inc Z", DisplayName = "IncreaseAutoNumber - 'Z' is the highest valid position")]
    [TestMethod]
    public void AutoNumberIncreaseIsRenderedCorrectly(char? position, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.IncreaseAutoNumber(position);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }
}
