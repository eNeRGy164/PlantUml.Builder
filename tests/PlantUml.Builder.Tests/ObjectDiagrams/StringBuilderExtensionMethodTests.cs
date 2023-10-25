using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ObjectDiagrams.Tests;

[TestClass]
public class StringBuilderExtensionMethodTests
{
    [TestMethod]
    [DynamicData(nameof(GetStringBuilderExtensionMethods), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetStringBuilderExtensionMethodTestDisplayName))]
    public void ExtensionMethodsShouldNotWorkOnANullStringBuilder(MethodWithArgumentData testData)
    {
        // Arrange
        var (method, parameters) = typeof(StringBuilderExtensions).GetExtensionMethodAndParameters(null, testData.Method, testData.Parameters);

        // Act
        Action action = () => method.Invoke(null, parameters);

        // Assert
        action.Should()
            .ThrowExactly<TargetInvocationException>()
            .WithInnerExceptionExactly<ArgumentNullException>()
            .WithParameterName("stringBuilder");
    }

    private static IEnumerable<object[]> GetStringBuilderExtensionMethods()
    {
        // Define the valid notations and expected results for different overloads
        yield return new object[] { new MethodWithArgumentData("MapStart", AnyString) };
        yield return new object[] { new MethodWithArgumentData("MapEnd") };
        yield return new object[] { new MethodWithArgumentData("Object", AnyString) };
        yield return new object[] { new MethodWithArgumentData("ObjectStart", AnyString) };
        yield return new object[] { new MethodWithArgumentData("ObjectEnd") };
    }

    public static string GetStringBuilderExtensionMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetStringBuilderExtensionMethodTestDisplayName(data);
}
