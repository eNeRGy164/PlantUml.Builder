using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ParticipantTests
{
    [TestMethod]
    public void ParticipantNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Participant(null);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Participant - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Participant - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void ParticipantNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Participant(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void ParticipantIsRenderedCorreclty(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Participant", "participant actorA", "actorA").WithDisplayName("Participant - Only name is specified") };
        yield return new object[] { new MethodExpectationTestData("Participant", "participant \"Actor A\" as actorA", "actorA", "Actor A").WithDisplayName("Participant - With display name") };
        yield return new object[] { new MethodExpectationTestData("Participant", "participant actorA #AliceBlue", "actorA", null, (Color)"AliceBlue").WithDisplayName("Participant - With color") };
        yield return new object[] { new MethodExpectationTestData("Participant", "participant actorA #AliceBlue", "actorA", null, (Color)"#AliceBlue").WithDisplayName("Participant - With color (with hashtag)") };
        yield return new object[] { new MethodExpectationTestData("Participant", "participant actorA order 10", "actorA", null, null, 10).WithDisplayName("Participant - With order") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
