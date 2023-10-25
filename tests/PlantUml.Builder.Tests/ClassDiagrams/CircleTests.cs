using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class CircleTests
{
    [TestMethod("Circle - Name argument cannot be `null`")]
    public void CircleNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Circle(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Circle - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Circle - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void CircleNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Circle(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void CircleIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name", "name") };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle \"Display Name\" as name", "name", "Display Name") };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name<generic>", "name", null, "generic") };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name <<stereotype>>", "name", null, null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name <<(A,#AABBCC)stereotype>>", "name", null, null, "stereotype", new CustomSpot('A', "AABBCC")) };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name $tag", "name", null, null, null, null, "tag") };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name [[https://blog.hompus.nl/]]", "name", null, null, null, null, null, new Uri("https://blog.hompus.nl")) };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name #Blue", "name", null, null, null, null, null, null, (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name ##Blue", "name", null, null, null, null, null, null, null, (Color)NamedColor.Blue) };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name ##[dashed]", "name", null, null, null, null, null, null, null, null, LineStyle.Dashed) };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name extends extend1,extend2", "name", null, null, null, null, null, null, null, null, null, new[] { "extend1", "extend2" }) };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle name implements implement1,implement2", "name", null, null, null, null, null, null, null, null, null, null, new[] { "implement1", "implement2" }) };
        yield return new object[] { new MethodExpectationTestData("Circle", "circle \"Display Name\" as name<generic> <<(A,#AABBCC)stereotype>> $tag [[https://blog.hompus.nl/]] #Blue ##[dashed]Blue extends extend1,extend2 implements implement1,implement2", "name", "Display Name", "generic", "stereotype", new CustomSpot('A', "AABBCC"), "tag", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue, (Color)NamedColor.Blue, LineStyle.Dashed, new[] { "extend1", "extend2" }, new[] { "implement1", "implement2" }) };
        yield return new object[] { new MethodExpectationTestData("Circle", "() name", "name", null, null, null, null, null, null, null, null, null, null, null, true) };
        yield return new object[] { new MethodExpectationTestData("Circle", "() \"Display Name\" as name<generic> <<(A,#AABBCC)stereotype>> $tag [[https://blog.hompus.nl/]] #Blue ##[dashed]Blue extends extend1,extend2 implements implement1,implement2", "name", "Display Name", "generic", "stereotype", new CustomSpot('A', "AABBCC"), "tag", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue, (Color)NamedColor.Blue, LineStyle.Dashed, new[] { "extend1", "extend2" }, new[] { "implement1", "implement2" }, true) };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
