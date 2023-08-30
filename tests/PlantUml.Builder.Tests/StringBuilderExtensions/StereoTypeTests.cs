namespace PlantUml.Builder.Tests;

[TestClass]
public class StereoTypeTests
{
    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void StereoTypeIsRenderedCorrectly(MethodExpectationTestData testData)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var (method, parameters) = typeof(StringBuilderExtensions).GetExtensionMethodAndParameters(stringBuilder, testData.Method, testData.Parameters);

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"{testData.Expected}");
    }

    public static IEnumerable<object[]> GetValidNotations()
    {
        yield return new object[] { new MethodExpectationTestData("StereoType", "<<>>") };
        yield return new object[] { new MethodExpectationTestData("StereoType", "<<name>>", "name") };
        yield return new object[] { new MethodExpectationTestData("StereoType", "<<(T,#Aqua)>>", null, new CustomSpot('T', NamedColor.Aqua)) };
        yield return new object[] { new MethodExpectationTestData("StereoType", "<<(T,#Aqua)name>>", "name", new CustomSpot('T', NamedColor.Aqua))};
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
