namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ArrowDefaultsTests
{
    [DynamicData(nameof(GetDefaultArrows), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetDefaultArrowsDisplayName))]
    [TestMethod]
    public void ReturnCorrectDefaultArrowNotation(string name, string expected)
    {
        // Arrange & Act
        var arrow = typeof(Arrow).GetProperty(name).GetValue(null);

        // Assert
        arrow.ToString().ShouldBe(expected);
    }

    private static IEnumerable<object[]> GetDefaultArrows()
    {
        yield return new[] { "Right", "->" };
        yield return new[] { "DottedRight", "-->" };
        yield return new[] { "ThinRight", "->>" };
        yield return new[] { "DottedThinRight", "-->>" };
        yield return new[] { "AsyncRight", "->" };
        yield return new[] { "SyncRight", "->>" };
        yield return new[] { "AsyncReplyRight", "-->" };
        yield return new[] { "SyncReplyRight", "-->>" };
        yield return new[] { "BottomRight", "-/" };
        yield return new[] { "DottedBottomRight", "--/" };
        yield return new[] { "ThinBottomRight", "-//" };
        yield return new[] { "DottedThinBottomRight", "--//" };
        yield return new[] { "TopRight", "-\\" };
        yield return new[] { "DottedTopRight", "--\\" };
        yield return new[] { "ThinTopRight", "-\\\\" };
        yield return new[] { "DottedThinTopRight", "--\\\\" };
        yield return new[] { "Left", "<-" };
        yield return new[] { "DottedLeft", "<--" };
        yield return new[] { "ThinLeft", "<<-" };
        yield return new[] { "DottedThinLeft", "<<--" };
        yield return new[] { "AsyncLeft", "<-" };
        yield return new[] { "SyncLeft", "<<-" };
        yield return new[] { "AsyncReplyLeft", "<--" };
        yield return new[] { "SyncReplyLeft", "<<--" };
        yield return new[] { "BottomLeft", "/-" };
        yield return new[] { "DottedBottomLeft", "/--" };
        yield return new[] { "ThinBottomLeft", "//-" };
        yield return new[] { "DottedThinBottomLeft", "//--" };
        yield return new[] { "TopLeft", "\\-" };
        yield return new[] { "DottedTopLeft", "\\--" };
        yield return new[] { "ThinTopLeft", "\\\\-" };
        yield return new[] { "DottedThinTopLeft", "\\\\--" };
        yield return new[] { "LeftRight", "<->" };
        yield return new[] { "DottedLeftRight", "<-->" };
        yield return new[] { "ThinLeftRight", "<<->>" };
        yield return new[] { "DottedThinLeftRight", "<<-->>" };
    }

    public static string GetDefaultArrowsDisplayName(MethodInfo _, object[] data) => $"The default \"{data[0]}\" should have the \"{data[1]}\" notation";
}
