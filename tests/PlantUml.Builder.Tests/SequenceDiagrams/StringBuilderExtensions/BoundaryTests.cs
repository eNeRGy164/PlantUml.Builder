using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class BoundaryTests
{
    [TestMethod]
    public void BoundaryNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Boundary(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Boundary - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Boundary - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void BoundaryNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Boundary(name);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void BoundaryIsRenderedCorreclty(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Boundary", "boundary boundaryA", "boundaryA") };
        yield return new object[] { new MethodExpectationTestData("Boundary", "boundary \"Boundary A\" as boundaryA", "boundaryA", "Boundary A") };
        yield return new object[] { new MethodExpectationTestData("Boundary", "boundary boundaryA #AliceBlue", "boundaryA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("Boundary", "boundary boundaryA order 10", "boundaryA", null, null, 10) };
        yield return new object[] { new MethodExpectationTestData("Boundary", "boundary boundaryA <<Stereo>>", "boundaryA", null, null, null, "Stereo").WithDisplayName("Participant - With sterotype") };
        yield return new object[] { new MethodExpectationTestData("Boundary", "boundary boundaryA <<(C,#336699)Stereo>>", "boundaryA", null, null, null, "Stereo", new CustomSpot('C', "336699")).WithDisplayName("Participant - With custom spot") };

        yield return new object[] { new MethodExpectationTestData("CreateBoundary", "create boundary boundaryA", "boundaryA") };
        yield return new object[] { new MethodExpectationTestData("CreateBoundary", "create boundary \"Boundary A\" as boundaryA", "boundaryA", "Boundary A") };
        yield return new object[] { new MethodExpectationTestData("CreateBoundary", "create boundary boundaryA #AliceBlue", "boundaryA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("CreateBoundary", "create boundary boundaryA order 10", "boundaryA", null, null, 10) };
        yield return new object[] { new MethodExpectationTestData("CreateBoundary", "create boundary boundaryA <<Stereo>>", "boundaryA", null, null, null, "Stereo").WithDisplayName("Participant - With sterotype") };
        yield return new object[] { new MethodExpectationTestData("CreateBoundary", "create boundary boundaryA <<(C,#336699)Stereo>>", "boundaryA", null, null, null, "Stereo", new CustomSpot('C', "336699")).WithDisplayName("Participant - With custom spot") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
