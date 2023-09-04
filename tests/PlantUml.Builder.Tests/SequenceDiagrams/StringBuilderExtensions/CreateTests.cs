using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class CreateTests
{
    [TestMethod("Create - Name argument cannot be `null`")]
    public void CreateNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Create(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Create - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Create - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void CreateNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Create(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void CreateIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Create", "create actorA", "actorA").WithDisplayName("Create - Default create line") };
        yield return new object[] { new MethodExpectationTestData("Create", "create actorA order 10", "actorA", null, null, 10).WithDisplayName("Create - Create line with order") };
        yield return new object[] { new MethodExpectationTestData("Create", "create actorA <<Stereo>>", "actorA", null, null, null, "Stereo").WithDisplayName("Participant - With sterotype") };
        yield return new object[] { new MethodExpectationTestData("Create", "create actorA <<(C,#336699)Stereo>>", "actorA", null, null, null, "Stereo", new CustomSpot('C', "336699")).WithDisplayName("Participant - With custom spot") };
    }    

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
