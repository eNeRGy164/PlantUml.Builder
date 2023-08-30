using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class EnumTests
{
    [TestMethod("Enum - Name argument cannot be `null`")]
    public void EnumNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Enum(null);

        // Assert
        action.Should().
            ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Enum - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Enum - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void EnumNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Enum(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetMethodTestDisplayName))]
    [TestMethod]
    public void EnumIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA", "enumA") };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum \"Enum A\" as enumA", "enumA", "Enum A") };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA<Object>", "enumA", null, "Object") };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA <<stereotype>>", "enumA", null, null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA <<(R,#Blue)stereotype>>", "enumA", null, null, "stereotype", new CustomSpot('R', NamedColor.Blue)) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA $tag", "enumA", null, null, null, null, "tag") };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA [[https://blog.hompus.nl/]]", "enumA", null, null, null, null, null, new Uri("https://blog.hompus.nl")) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA #AliceBlue", "enumA", null, null, null, null, null, null, (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA ##AliceBlue", "enumA", null, null, null, null, null, null, null, (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA ##[dashed]", "enumA", null, null, null, null, null, null, null, null, LineStyle.Dashed) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA", "enumA", null, null, null, null, null, null, null, null, null, Array.Empty<string>()) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA extends BaseClass", "enumA", null, null, null, null, null, null, null, null, null, new[] { "BaseClass" }) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA extends BaseClass,BaseClass2", "enumA", null, null, null, null, null, null, null, null, null, new[] { "BaseClass", "BaseClass2" }) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA", "enumA", null, null, null, null, null, null, null, null, null, null, Array.Empty<string>()) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA implements IInterface", "enumA", null, null, null, null, null, null, null, null, null, null, new[] { "IInterface" }) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum enumA implements IInterface,IInterface2", "enumA", null, null, null, null, null, null, null, null, null, null, new[] { "IInterface", "IInterface2" }) };
        yield return new object[] { new MethodExpectationTestData("Enum", "enum \"Enum A\" as enumA<T> <<(A,#Blue)stereotype>> $tag [[https://blog.hompus.nl/]] #Blue ##[dashed]Blue extends BaseClass,BaseClass2 implements IInterface,IInterface2", "enumA", "Enum A", "T", "stereotype", new CustomSpot('A', NamedColor.Blue), "tag", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue, (Color)NamedColor.Blue, LineStyle.Dashed, new[] { "BaseClass", "BaseClass2" }, new[] { "IInterface", "IInterface2" }) };

        yield return new object[] { new MethodExpectationTestData("EnumStart", "enum enumA {", "enumA") };
        yield return new object[] { new MethodExpectationTestData("EnumStart", "+enum enumA {", "enumA", null, VisibilityModifier.Public) };

        yield return new object[] { new MethodExpectationTestData("EnumEnd", "}") };
    }

    public static string GetMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
