using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class EntityTests
{
    [TestMethod]
    public void EntityNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Entity(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
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
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void EntityIsRenderedCorreclty(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA", "entityA") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity \"Entity A\" as entityA", "entityA", "Entity A") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA #AliceBlue", "entityA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA order 10", "entityA", null, null, 10) };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA <<Stereo>>", "entityA", null, null, null, "Stereo").WithDisplayName("Participant - With sterotype") };
        yield return new object[] { new MethodExpectationTestData("Entity", "entity entityA <<(C,#336699)Stereo>>", "entityA", null, null, null, "Stereo", new CustomSpot('C', "336699")).WithDisplayName("Participant - With custom spot") };

        yield return new object[] { new MethodExpectationTestData("CreateEntity", "create entity entityA", "entityA") };
        yield return new object[] { new MethodExpectationTestData("CreateEntity", "create entity \"Entity A\" as entityA", "entityA", "Entity A") };
        yield return new object[] { new MethodExpectationTestData("CreateEntity", "create entity entityA #AliceBlue", "entityA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("CreateEntity", "create entity entityA order 10", "entityA", null, null, 10) };
        yield return new object[] { new MethodExpectationTestData("CreateEntity", "create entity entityA <<Stereo>>", "entityA", null, null, null, "Stereo").WithDisplayName("Participant - With sterotype") };
        yield return new object[] { new MethodExpectationTestData("CreateEntity", "create entity entityA <<(C,#336699)Stereo>>", "entityA", null, null, null, "Stereo", new CustomSpot('C', "336699")).WithDisplayName("Participant - With custom spot") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
