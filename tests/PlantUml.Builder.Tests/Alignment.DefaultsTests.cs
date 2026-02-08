namespace PlantUml.Builder.Tests;

[TestClass]
public class AlignmentDefaultsTests
{
    [DynamicData(nameof(GetDefaultAlignments), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetDefaultAlignmentsDisplayName))]
    [TestMethod]
    public void DefaultAlignmentsAreRenderedCorrectly(string name, string expected)
    {
        // Arrange & act
        var alignment = typeof(Alignment).GetProperty(name).GetValue(null);

        // Assert
        alignment.ToString().ShouldBe(expected);
    }

    private static IEnumerable<object[]> GetDefaultAlignments()
    {
        yield return new[] { "Left", "left" };
        yield return new[] { "Center", "center" };
        yield return new[] { "Right", "right" };
    }

    public static string GetDefaultAlignmentsDisplayName(MethodInfo _, object[] data) => $"The default \"{data[0]}\" should be \"{data[1]}\"";
}
