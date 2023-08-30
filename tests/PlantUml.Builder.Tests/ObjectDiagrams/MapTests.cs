using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ObjectDiagrams.Tests;

[TestClass]
public class MapTests
{
    [TestMethod]
    public void NameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.MapStart(null);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Name can not be empty")]
    [DataRow(AllWhitespace, DisplayName = "Name can not be any whitespace character")]
    [TestMethod]
    public void NameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.MapStart(name);
        
        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void AValidMapNotationIsRendered(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("MapStart", "map name {", "name") };
        yield return new object[] { new MethodExpectationTestData("MapStart", "map \"Display Name\" as name {", "name", "Display Name") };
        yield return new object[] { new MethodExpectationTestData("MapStart", "map name <<stereotype>> {", "name", null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("MapStart", "map name [[https://blog.hompus.nl/]] {", "name", null, null, new Uri("https://blog.hompus.nl")) };
        yield return new object[] { new MethodExpectationTestData("MapStart", "map name #Blue {", "name", null, null, null, (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("MapStart", "map \"Display Name\" as name <<stereotype>> [[https://blog.hompus.nl/]] #Blue {", "name", "Display Name", "stereotype", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("MapEnd", "}") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
