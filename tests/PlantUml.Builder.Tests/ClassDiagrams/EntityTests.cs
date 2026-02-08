using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class EntityTests
{
    [TestMethod("Entity - Name argument cannot be `null`")]
    public void EntityNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Entity(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Entity - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Entity - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void EntityNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Entity(name);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetMethodTestDisplayName))]
    [TestMethod]
    public void EntityIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA", "entityA") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity \"Entity A\" as entityA", "entityA", "Entity A") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA<Object>", "entityA", null, "Object") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA <<stereotype>>", "entityA", null, null, "stereotype") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA <<(R,#Blue)stereotype>>", "entityA", null, null, "stereotype", new CustomSpot('R', NamedColor.Blue)) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA $tag", "entityA", null, null, null, null, "tag") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA [[https://blog.hompus.nl/]]", "entityA", null, null, null, null, null, new Uri("https://blog.hompus.nl")) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA #AliceBlue", "entityA", null, null, null, null, null, null, (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA ##AliceBlue", "entityA", null, null, null, null, null, null, null, (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA ##[dashed]", "entityA", null, null, null, null, null, null, null, null, LineStyle.Dashed) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA", "entityA", null, null, null, null, null, null, null, null, null, Array.Empty<string>()) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA extends BaseClass", "entityA", null, null, null, null, null, null, null, null, null, new[] { "BaseClass" }) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA extends BaseClass,BaseClass2", "entityA", null, null, null, null, null, null, null, null, null, new[] { "BaseClass", "BaseClass2" }) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA", "entityA", null, null, null, null, null, null, null, null, null, null, Array.Empty<string>()) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA implements IInterface", "entityA", null, null, null, null, null, null, null, null, null, null, new[] { "IInterface" }) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA implements IInterface,IInterface2", "entityA", null, null, null, null, null, null, null, null, null, null, new[] { "IInterface", "IInterface2" }) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity \"Entity A\" as entityA<T> <<(A,#Blue)stereotype>> $tag [[https://blog.hompus.nl/]] #Blue ##[dashed]Blue extends BaseClass,BaseClass2 implements IInterface,IInterface2", "entityA", "Entity A", "T", "stereotype", new CustomSpot('A', NamedColor.Blue), "tag", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue, (Color)NamedColor.Blue, LineStyle.Dashed, new[] { "BaseClass", "BaseClass2" }, new[] { "IInterface", "IInterface2" }) };

        yield return new object[] { new MethodExpectationTestData("EntityStart", "entity entityA {", "entityA") };
        yield return new object[] { new MethodExpectationTestData("EntityStart", "+entity entityA {", "entityA", null, VisibilityModifier.Public) };

        yield return new object[] { new MethodExpectationTestData("EntityEnd", "}") };
    }

    public static string GetMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
