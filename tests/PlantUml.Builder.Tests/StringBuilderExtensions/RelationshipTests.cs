using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class RelationshipTests
{
    [DataRow("left", null, "-", "r", DisplayName = "Relationship - Left argument cannot be `null`")]
    [DataRow("type", "l", null, "r", DisplayName = "Relationship - Type argument cannot be `null`")]
    [DataRow("right", "l", "-", null, DisplayName = "Relationship - Right argument cannot be `null`")]
    [TestMethod]
    public void RelationshipArgumentsCannotBeNull(string parameterName, string left, string type, string right)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Relationship(left, type, right);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName(parameterName);
    }

    [DataRow("left", EmptyString, "-", "r", DisplayName = "Relationship - Left argument cannot be empty")]
    [DataRow("left", AllWhitespace, "-", "r", DisplayName = "Relationship - Left argument cannot be any whitespace character")]
    [DataRow("type", "l", EmptyString, "r", DisplayName = "Relationship - Type argument cannot be empty")]
    [DataRow("type", "l", AllWhitespace, "r", DisplayName = "Relationship - Type argument cannot be any whitespace character")]
    [DataRow("right", "l", "-", EmptyString, DisplayName = "Relationship - Right argument cannot be empty")]
    [DataRow("right", "l", "-", AllWhitespace, DisplayName = "Relationship - Right argument cannot be any whitespace character")]
    [TestMethod]
    public void RelationshipArgumentsMustContainAValue(string parameterName, string left, string type, string right)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Relationship(left, type, right);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName(parameterName);
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void RelationshipIsRenderedCorrectly(MethodExpectationTestData testData)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var (method, parameters) = typeof(StringBuilderExtensions).GetExtensionMethodAndParameters(stringBuilder, testData.Method, testData.Parameters);

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().ShouldBe($"{testData.Expected}\n");
    }

    public static IEnumerable<object[]> GetValidNotations()
    {
        // Define the valid notations and expected results for different overloads
        yield return new object[] { new MethodExpectationTestData("Relationship", "l - r", "l", "-", "r") };
        yield return new object[] { new MethodExpectationTestData("Relationship", "l - r : label1", "l", "-", "r", "label1") };
        yield return new object[] { new MethodExpectationTestData("Relationship", "l \"*\" - r", "l", "-", "r", null, "*") };
        yield return new object[] { new MethodExpectationTestData("Relationship", "l - \"*\" r", "l", "-", "r", null, null, "*") };
        yield return new object[] { new MethodExpectationTestData("Relationship", "l - \"*\" r : label1", "l", "-", "r", "label1", null, "*") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
