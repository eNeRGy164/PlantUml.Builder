using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class ClassTests
{
    [TestMethod("Class - Name argument cannot be `null`")]
    public void ClassNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Class(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Class - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Class - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void ClassNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Class(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void ClassIsRenderedCorreclty(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Class", "class classA", "classA") };
        yield return new object[] { new MethodExpectationTestData("Class", "class \"Class A\" as classA", "classA", "Class A") };
        yield return new object[] { new MethodExpectationTestData("Class", "abstract class classA", "classA", null, true) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA<Object>", "classA", null, null, "Object") };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA <<stereotype>>", "classA", null, null, null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA <<(R,#Blue)stereotype>>", "classA", null, null, null, "stereotype", new CustomSpot('R', NamedColor.Blue)) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA $tag", "classA", null, null, null, null, null, "tag") };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA [[https://blog.hompus.nl/]]", "classA", null, null, null, null, null, null, new Uri("https://blog.hompus.nl")) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA #AliceBlue", "classA", null, null, null, null, null, null, null, (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA ##AliceBlue", "classA", null, null, null, null, null, null, null, null, (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA ##[dashed]", "classA", null, null, null, null, null, null, null, null, null, LineStyle.Dashed) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA", "classA", null, null, null, null, null, null, null, null, null, null, Array.Empty<string>()) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA extends BaseClass", "classA", null, null, null, null, null, null, null, null, null, null, new[] { "BaseClass" }) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA extends BaseClass,BaseClass2", "classA", null, null, null, null, null, null, null, null, null, null, new[] { "BaseClass", "BaseClass2" }) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA", "classA", null, null, null, null, null, null, null, null, null, null, null, Array.Empty<string>()) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA implements IInterface", "classA", null, null, null, null, null, null, null, null, null, null, null, new[] { "IInterface" }) };
        yield return new object[] { new MethodExpectationTestData("Class", "class classA implements IInterface,IInterface2", "classA", null, null, null, null, null, null, null, null, null, null, null, new[] { "IInterface", "IInterface2" }) };
        yield return new object[] { new MethodExpectationTestData("Class", "abstract class \"Class A\" as classA<T> <<(A,#Blue)stereotype>> $tag [[https://blog.hompus.nl/]] #Blue ##[dashed]Blue extends extend1,extend2 implements IInterface,IInterface2", "classA", "Class A", true, "T", "stereotype", new CustomSpot('A', NamedColor.Blue), "tag", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue, (Color)NamedColor.Blue, LineStyle.Dashed, new[] { "extend1", "extend2" }, new[] { "IInterface", "IInterface2" }) };

        yield return new object[] { new MethodExpectationTestData("ClassStart", "class classA {", "classA") };
        yield return new object[] { new MethodExpectationTestData("ClassStart", "+class classA {", "classA", null, VisibilityModifier.Public) };

        yield return new object[] { new MethodExpectationTestData("ClassEnd", "}") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
