using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class InterfaceTests
{
    [TestMethod("Interface - Name argument cannot be `null`")]
    public void InterfaceNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Interface(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Interface - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Interface - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void InterfaceNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Interface(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetMethodTestDisplayName))]
    [TestMethod]
    public void InterfaceIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA", "interfaceA") };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface \"Interface A\" as interfaceA", "interfaceA", "Interface A") };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA<Object>", "interfaceA", null, "Object") };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA <<stereotype>>", "interfaceA", null, null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA <<(R,#Blue)stereotype>>", "interfaceA", null, null, "stereotype", new CustomSpot('R', NamedColor.Blue)) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA $tag", "interfaceA", null, null, null, null, "tag") };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA [[https://blog.hompus.nl/]]", "interfaceA", null, null, null, null, null, new Uri("https://blog.hompus.nl")) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA #AliceBlue", "interfaceA", null, null, null, null, null, null, (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA ##AliceBlue", "interfaceA", null, null, null, null, null, null, null, (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA ##[dashed]", "interfaceA", null, null, null, null, null, null, null, null, LineStyle.Dashed) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA", "interfaceA", null, null, null, null, null, null, null, null, null, Array.Empty<string>()) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA extends BaseClass", "interfaceA", null, null, null, null, null, null, null, null, null, new[] { "BaseClass" }) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA extends BaseClass,BaseClass2", "interfaceA", null, null, null, null, null, null, null, null, null, new[] { "BaseClass", "BaseClass2" }) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA", "interfaceA", null, null, null, null, null, null, null, null, null, null, Array.Empty<string>()) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA implements IInterface", "interfaceA", null, null, null, null, null, null, null, null, null, null, new[] { "IInterface" }) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface interfaceA implements IInterface,IInterface2", "interfaceA", null, null, null, null, null, null, null, null, null, null, new[] { "IInterface", "IInterface2" }) };
        yield return new object[] { new MethodExpectationTestData("Interface", "interface \"Interface A\" as interfaceA<T> <<(A,#Blue)stereotype>> $tag [[https://blog.hompus.nl/]] #Blue ##[dashed]Blue extends BaseClass,BaseClass2 implements IInterface,IInterface2", "interfaceA", "Interface A", "T", "stereotype", new CustomSpot('A', NamedColor.Blue), "tag", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue, (Color)NamedColor.Blue, LineStyle.Dashed, new[] { "BaseClass", "BaseClass2" }, new[] { "IInterface", "IInterface2" }) };

        yield return new object[] { new MethodExpectationTestData("InterfaceStart", "interface interfaceA {", "interfaceA") };
        yield return new object[] { new MethodExpectationTestData("InterfaceStart", "+interface interfaceA {", "interfaceA", null, VisibilityModifier.Public) };

        yield return new object[] { new MethodExpectationTestData("InterfaceEnd", "}") };
    }

    public static string GetMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
