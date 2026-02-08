using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class NamespaceTests
{
    [TestMethod("NamespaceStart - Name argument cannot be `null`")]
    public void NamespaceNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.NamespaceStart(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "NamespaceStart - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "NamespaceStart - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void NamespaceNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.NamespaceStart(name);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetMethodTestDisplayName))]
    [TestMethod]
    public void NamespaceIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("NamespaceStart", "namespace name {", "name") };
        yield return new object[] { new MethodExpectationTestData("NamespaceStart", "namespace \"Display Name\" as name {", "name", "Display Name") };
        yield return new object[] { new MethodExpectationTestData("NamespaceStart", "namespace name <<stereotype>> {", "name", null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("NamespaceStart", "namespace name #Blue {", "name", null, null, (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("NamespaceStart", "namespace \"Display Name\" as name <<stereotype>> #Blue {", "name", "Display Name", "stereotype", (Color)NamedColor.Blue) };

        yield return new object[] { new MethodExpectationTestData("NamespaceEnd", "}") };
    }

    public static string GetMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
