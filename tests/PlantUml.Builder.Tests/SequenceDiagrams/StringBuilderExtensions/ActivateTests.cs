using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ActivateTests
{
    [TestMethod]
    public void ActivateNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Activate(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Activate - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Activate - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void ActivateNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Activate(name);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void ActivateIsRenderedCorreclty(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Activate", "activate actor", "actor") };
        yield return new object[] { new MethodExpectationTestData("Activate", "activate actor #Blue", "actor", (Color)"Blue") };
        yield return new object[] { new MethodExpectationTestData("Activate", "activate actor #Blue", "actor", (Color)"#Blue") };
        yield return new object[] { new MethodExpectationTestData("Activate", "activate actor", "actor", null, (Color)"Blue") };
        yield return new object[] { new MethodExpectationTestData("Activate", "activate actor #Blue #APPLICATION", "actor", (Color)"Blue", (Color)"APPLICATION") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
