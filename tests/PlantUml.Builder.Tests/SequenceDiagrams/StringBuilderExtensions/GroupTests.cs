namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class GroupTests
{
    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void GroupIsRenderedCorrectly(MethodExpectationTestData testData)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var (method, parameters) = typeof(StringBuilderExtensions).GetExtensionMethodAndParameters(stringBuilder, testData.Method, testData.Parameters);

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"{testData.Expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        // Define the valid notations and expected results for different overloads
        yield return new object[] { new MethodExpectationTestData("GroupStart", "group").WithDisplayName("GroupStart - Default group label is 'group'") };
        yield return new object[] { new MethodExpectationTestData("GroupStart", "alt", "alt").WithDisplayName("GroupStart - Different group type") };
        yield return new object[] { new MethodExpectationTestData("GroupStart", "group [Title]", default, "Title").WithDisplayName("GroupStart - Group with title") };
        yield return new object[] { new MethodExpectationTestData("GroupStart", "group Label", default, default, "Label").WithDisplayName("GroupStart - Group with label") };

        yield return new object[] { new MethodExpectationTestData("GroupEnd", "end").WithDisplayName("GroupEnd - End group") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
