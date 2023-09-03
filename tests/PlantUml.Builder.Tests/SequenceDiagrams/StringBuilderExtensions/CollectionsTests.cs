using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class CollectionsTests
{
    [TestMethod]
    public void CollectionsNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Collections(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Collections - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Collections - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void CollectionsNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Collections(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
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
        stringBuilder.ToString().Should().Be($"{testData.Expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        // Define the valid notations and expected results for different overloads
        yield return new object[] { new MethodExpectationTestData("Collections", "collections collectionsA", "collectionsA") };
        yield return new object[] { new MethodExpectationTestData("Collections", "collections \"Collections A\" as collectionsA", "collectionsA", "Collections A") };
        yield return new object[] { new MethodExpectationTestData("Collections", "collections collectionsA #AliceBlue", "collectionsA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("Collections", "collections collectionsA order 10", "collectionsA", null, null, 10) };

        yield return new object[] { new MethodExpectationTestData("CreateCollections", "create collections collectionsA", "collectionsA") };
        yield return new object[] { new MethodExpectationTestData("CreateCollections", "create collections \"Collections A\" as collectionsA", "collectionsA", "Collections A") };
        yield return new object[] { new MethodExpectationTestData("CreateCollections", "create collections collectionsA #AliceBlue", "collectionsA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("CreateCollections", "create collections collectionsA order 10", "collectionsA", null, null, 10) };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
