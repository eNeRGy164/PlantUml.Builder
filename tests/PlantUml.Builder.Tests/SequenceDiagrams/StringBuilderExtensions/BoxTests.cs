
namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class BoxTests
{
    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void BoxIsRenderedCorreclty(MethodExpectationTestData testData)
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
        // Define the valid notations and expected results for different overloads
        yield return new object[] { new MethodExpectationTestData("BoxStart", "box") };
        yield return new object[] { new MethodExpectationTestData("BoxStart", "box \"Box title\"", "Box title") };
        yield return new object[] { new MethodExpectationTestData("BoxStart", "box #AliceBlue", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("BoxEnd", "end box") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
