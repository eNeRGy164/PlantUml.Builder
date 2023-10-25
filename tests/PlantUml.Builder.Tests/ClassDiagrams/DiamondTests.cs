using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class DiamondTests
{
    [TestMethod("Diamond - Name argument cannot be `null`")]
    public void DiamondNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Diamond(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Diamond - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Diamond - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void DiamondNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Diamond(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void DiamondIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name", "name") };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond \"Display Name\" as name", "name", "Display Name") };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name<generic>", "name", null, "generic") };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name <<stereotype>>", "name", null, null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name <<(A,#Blue)stereotype>>", "name", null, null, "stereotype", new CustomSpot('A', NamedColor.Blue)) };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name $tag", "name", null, null, null, null, "tag") };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name [[https://blog.hompus.nl/]]", "name", null, null, null, null, null, new Uri("https://blog.hompus.nl")) };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name #Blue", "name", null, null, null, null, null, null, (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name ##Blue", "name", null, null, null, null, null, null, null, (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name ##[dashed]", "name", null, null, null, null, null, null, null, null, LineStyle.Dashed) };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name extends extend1,extend2", "name", null, null, null, null, null, null, null, null, null, new[] { "extend1", "extend2" }) };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond name implements implement1,implement2", "name", null, null, null, null, null, null, null, null, null, null, new[] { "implement1", "implement2" }) };
        yield return new object[] { new MethodExpectationTestData("Diamond", "diamond \"Display Name\" as name<generic> <<(A,#Blue)stereotype>> $tag [[https://blog.hompus.nl/]] #Blue ##[dashed]Blue extends extend1,extend2 implements implement1,implement2", "name", "Display Name", "generic", "stereotype", new CustomSpot('A', NamedColor.Blue), "tag", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue, (Color)NamedColor.Blue, LineStyle.Dashed, new[] { "extend1", "extend2" }, new[] { "implement1", "implement2" }) };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
