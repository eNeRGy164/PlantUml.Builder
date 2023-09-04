using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ActorTests
{
    [TestMethod]
    public void ActorNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Actor(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Actor - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Actor - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void ActorNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Actor(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void ActorIsRenderedCorreclty(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Actor", "actor actorA", "actorA") };
        yield return new object[] { new MethodExpectationTestData("Actor", "actor \"Actor A\" as actorA", "actorA", "Actor A") };
        yield return new object[] { new MethodExpectationTestData("Actor", "actor actorA #AliceBlue", "actorA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("Actor", "actor actorA order 10", "actorA", null, null, 10) };
        yield return new object[] { new MethodExpectationTestData("Actor", "actor actorA <<Stereo>>", "actorA", null, null, null, "Stereo").WithDisplayName("Participant - With sterotype") };
        yield return new object[] { new MethodExpectationTestData("Actor", "actor actorA <<(C,#336699)Stereo>>", "actorA", null, null, null, "Stereo", new CustomSpot('C', "336699")).WithDisplayName("Participant - With custom spot") };

        yield return new object[] { new MethodExpectationTestData("CreateActor", "create actor actorA", "actorA") };
        yield return new object[] { new MethodExpectationTestData("CreateActor", "create actor \"Actor A\" as actor", "actor", "Actor A") };
        yield return new object[] { new MethodExpectationTestData("CreateActor", "create actor actorA #AliceBlue", "actorA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("CreateActor", "create actor actorA order 10", "actorA", null, null, 10) };
        yield return new object[] { new MethodExpectationTestData("CreateActor", "create actor actorA <<Stereo>>", "actorA", null, null, null, "Stereo").WithDisplayName("Participant - With sterotype") };
        yield return new object[] { new MethodExpectationTestData("CreateActor", "create actor actorA <<(C,#336699)Stereo>>", "actorA", null, null, null, "Stereo", new CustomSpot('C', "336699")).WithDisplayName("Participant - With custom spot") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
