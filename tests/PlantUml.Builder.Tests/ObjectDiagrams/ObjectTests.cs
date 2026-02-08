using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ObjectDiagrams.Tests;

[TestClass]
public class ObjectTests
{
    [TestMethod("Object - Name argument cannot be `null`")]
    public void ObjectNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Object(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Object - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Object - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void ObjectNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Object(name);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void ObjectIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Object", "object name", "name") };
        yield return new object[] { new MethodExpectationTestData("Object", "object \"Display Name\" as name", "name", "Display Name") };
        yield return new object[] { new MethodExpectationTestData("Object", "object name <<stereotype>>", "name", null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("Object", "object name [[https://blog.hompus.nl/]]", "name", null, null, new Uri("https://blog.hompus.nl")) };
        yield return new object[] { new MethodExpectationTestData("Object", "object name #Blue", "name", null, null, null, (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("Object", "object \"Display Name\" as name <<stereotype>> [[https://blog.hompus.nl/]] #Blue", "name", "Display Name", "stereotype", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue) };

        yield return new object[] { new MethodExpectationTestData("ObjectStart", "object objectA {", "objectA") };

        yield return new object[] { new MethodExpectationTestData("ObjectEnd", "}") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
