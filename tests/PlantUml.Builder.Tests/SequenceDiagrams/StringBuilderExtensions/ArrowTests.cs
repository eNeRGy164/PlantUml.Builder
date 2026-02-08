namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ArrowTests
{
    [DataRow(default, "->", default, DisplayName = "Both side are not defined")]
    [DataRow(default, "->]", "B", DisplayName = "Left side is not defined and arrow indicates an outgoing meesage to the right")]
    [DataRow("B", "[->", default, DisplayName = "Right side is not defined and arrow indicates an incomming message from the left")]
    [DataRow(default, "->?", "B", DisplayName = "Left side is not defined and arrow indicates a short outgoing meesage to the right")]
    [DataRow("B", "?->", default, DisplayName = "Right side is not defined and arrow indicates a short incomming message from the left")]
    [TestMethod]
    public void ArrowCannotHaveBothParticipantsOutsideTheDiagram(string left, string arrow, string right)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Arrow(left, arrow, right);

        // Assert
        action.ShouldThrowExactly<NotSupportedException>()
            .WithMessage("It is not possible for both partipants to be outside the diagram.");
    }

    [DataRow(default, "r", "[-> r", DisplayName = "Arrow_NullLeft_Should_MakeArrowComeFromTheOutside")]
    [DataRow("l", default, "l ->]", DisplayName = "Arrow_NullRight_Should_MakeArrowGoToTheOutside")]
    [TestMethod]
    public void ArrowSupportsOutsideSourcesIfParticipantIsNotSupplied(string left, string right, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Arrow(left, "->", right);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void ArrowIsRenderedCorrectly(MethodExpectationTestData testData)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var (method, parameters) = typeof(StringBuilderExtensions).GetExtensionMethodAndParameters(stringBuilder, testData.Method, testData.Parameters);

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().ShouldBe($"{testData.Expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        var left = new ParticipantName("l");
        var arrow = new Arrow("->");
        var right = new ParticipantName("r");

        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r", left, arrow, right) };
        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r : label1", left, arrow, right, "label1") };
        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r : label1\\nlabel2", left, arrow, right, "label1\nlabel2") };
        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r #Blue", left, arrow, right, default, default, (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r ++", left, arrow, right, default, LifeLineEvents.Activate) };
        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r ++ #Blue", left, arrow, right, default, LifeLineEvents.Activate, (Color)"Blue") };
        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r --", left, arrow, right, default, LifeLineEvents.Deactivate) };
        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r **", left, arrow, right, default, LifeLineEvents.Create) };
        yield return new object[] { new MethodExpectationTestData("Arrow", "l -> r !!", left, arrow, right, default, LifeLineEvents.Destroy) };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
