
namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class AutoNumberTests
{
    [DataRow("start", "", "<b>[000]", DisplayName = "Start can not be empty")]
    [DataRow("start", " ", "<b>[000]", DisplayName = "Start can not be whitespace")]
    [DataRow("format", "1", "", DisplayName = "Format can not be empty")]
    [DataRow("format", "1", " ", DisplayName = "Format can not be whitespace")]
    [TestMethod]
    public void AutoNumberParametersMustToContainAValidValue(string parameterName, string start, string format)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.AutoNumber(start, default, format);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be(parameterName);
    }

    [DataRow(default, default, default, "autonumber", DisplayName = "Autonumber")]
    [DataRow(10, default, default, "autonumber 10", DisplayName = "Autonumber with start")]
    [DataRow("1.1.1", default, default, "autonumber 1.1.1", DisplayName = "Autonumber with start")]
    [DataRow(default, 10, default, "autonumber", DisplayName = "Autonumber should ignore step if there is no start")]
    [DataRow(10, 20, default, "autonumber 10 20", DisplayName = "Autonumber with start and step")]
    [DataRow(default, default, "<b>[000]", "autonumber \"<b>[000]\"", DisplayName = "Autonumber with format")]
    [DataRow(10, 20, "<b>[000]", "autonumber 10 20 \"<b>[000]\"", DisplayName = "Autonumber with all parameters")]
    [TestMethod]
    public void ACorrectAutoNumberIsRendered(object start, int? step, string format, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var startType = start?.GetType() ?? typeof(string);

        var method = typeof(StringBuilderExtensions).GetMethod("AutoNumber", new[] { typeof(StringBuilder), startType, typeof(int?), typeof(string) });
        var parameters = new object[] { stringBuilder, start, step, format };

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }

    [TestMethod]
    public void ACorrectStopAutoNumberIsRendered()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.StopAutoNumber();

        // Assert
        stringBuilder.ToString().Should().Be("autonumber stop\n");
    }

    [DataRow("", DisplayName = "Value can not be empty")]
    [DataRow(" ", DisplayName = "Value can not be whitespace")]
    [TestMethod]
    public void ResumeFormatParameterMustToContainAValidValue(string format)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.ResumeAutoNumber(default, format);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("format");
    }

    [DataRow(default, default, "autonumber resume", DisplayName = "Resume autonumber")]
    [DataRow(20, default, "autonumber resume 20", DisplayName = "Resume autonumber with step size")]
    [DataRow(default, "<b>[000]", "autonumber resume \"<b>[000]\"", DisplayName = "Resume autonumber with format")]
    [DataRow(20, "<b>[000]", "autonumber resume 20 \"<b>[000]\"", DisplayName = "Resume autonumber with step size and format")]
    [TestMethod]
    public void ACorrectAutoNumberResumeIsRendered(int? step, string format, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var method = typeof(StringBuilderExtensions).GetMethod("ResumeAutoNumber");
        var parameters = new object[] { stringBuilder, step, format };

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }

    [DataRow('0', DisplayName = "Position cannot be a number")]
    [DataRow('Ç', DisplayName = "Position cannot be a outside A-Z")]
    [DataRow('þ', DisplayName = "Position cannot be a outside A-Z")]
    [DataRow('ë', DisplayName = "Position cannot contain diacritics")]
    [DataRow('¿', DisplayName = "Position cannot contain unicode symbols")]
    [DataRow('!', DisplayName = "Position cannot contain ascii symbols")]
    [DataRow((char)0, DisplayName = "Position cannot contain nul char")]
    [TestMethod]
    public void PositionParameterMustBeInTheValidRange(char position)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.IncreaseAutoNumber(position);

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("Only the characters A - Z are allowed*")
            .And.ParamName.Should().Be("position");
    }

    [DataRow(default, "autonumber inc", DisplayName = "Position is optional")]
    [DataRow('A', "autonumber inc A", DisplayName = "A is the lowest possible position")]
    [DataRow('a', "autonumber inc a", DisplayName = "Position is case insensitive")]
    [DataRow('Z', "autonumber inc Z", DisplayName = "A is the highest possible position")]
    [TestMethod]
    public void ACorrectAutoNumberIncreaseIsRendered(char? position, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.IncreaseAutoNumber(position);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
