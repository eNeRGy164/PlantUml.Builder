using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class SkinParameterTests
{
    [DataRow("name", null, "b", DisplayName = "SkinParameter - Name argument cannot be `null`")]
    [DataRow("value", "a", null, DisplayName = "SkinParameter - Value argument cannot be `null`")]
    [TestMethod]
    public void SkinParameterArgumentsCannotBeNull(string parameterName, string name, string value)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.SkinParameter(name, value);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName(parameterName);
    }

    [DataRow("name", EmptyString, "b", DisplayName = "SkinParameter - Name argument cannot be empty")]
    [DataRow("name", AllWhitespace, "b", DisplayName = "SkinParameter - Name argument cannot be any whitespace character")]
    [DataRow("value", "a", EmptyString, DisplayName = "SkinParameter - Value argument cannot be empty")]
    [DataRow("value", "a", AllWhitespace, DisplayName = "SkinParameter - Value argument cannot be any whitespace character")]
    [TestMethod]
    public void SkinParameterArgumentsMustContainAValue(string parameterName, string name, string value)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.SkinParameter(name, value);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName(parameterName);
    }

    [TestMethod]
    public void SkinParameterEnumerationValueShouldExist()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.SkinParameter((SkinParameter)ushort.MaxValue, AnyString);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("A defined enum value should be provided*")
            .WithParameterName("skinParameter");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetMethodTestDisplayName))]
    [TestMethod]
    public void SkinParamIsRenderedCorrectly(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("SkinParameter", "skinparam monochrome true", "monochrome", "true") };
        yield return new object[] { new MethodExpectationTestData("SkinParameter", "skinparam monochrome true", " monochrome ", "true") };
        yield return new object[] { new MethodExpectationTestData("SkinParameter", "skinparam monochrome true", "monochrome", " true ") };
        yield return new object[] { new MethodExpectationTestData("SkinParameter", "skinparam Monochrome true", SkinParameter.Monochrome, "true") };
        yield return new object[] { new MethodExpectationTestData("SkinParameter", "skinparam monochrome true", "monochrome", true) };
        yield return new object[] { new MethodExpectationTestData("SkinParameter", "skinparam Monochrome false", SkinParameter.Monochrome, false) };
        yield return new object[] { new MethodExpectationTestData("SkinParameter", "skinparam minclasswidth 200", "minclasswidth", 200) };
        yield return new object[] { new MethodExpectationTestData("SkinParameter", "skinparam MinClassWidth 400", SkinParameter.MinClassWidth, 400) };
    }

    public static string GetMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
