using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

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
        yield return new object[] { new MethodWithArgumentData("Circle", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Class", AnyString) };
        yield return new object[] { new MethodWithArgumentData("ClassStart", AnyString) };
        yield return new object[] { new MethodWithArgumentData("ClassEnd") };
        yield return new object[] { new MethodWithArgumentData("Diamond", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Entity", AnyString) };
        yield return new object[] { new MethodWithArgumentData("EntityStart", AnyString) };
        yield return new object[] { new MethodWithArgumentData("EntityEnd") };
        yield return new object[] { new MethodWithArgumentData("Enum", AnyString) };
        yield return new object[] { new MethodWithArgumentData("EnumStart", AnyString) };
        yield return new object[] { new MethodWithArgumentData("EnumEnd") };
        yield return new object[] { new MethodWithArgumentData("Interface", AnyString) };
        yield return new object[] { new MethodWithArgumentData("InterfaceStart", AnyString) };
        yield return new object[] { new MethodWithArgumentData("InterfaceEnd") };
        yield return new object[] { new MethodWithArgumentData("NamespaceStart", AnyString) };
        yield return new object[] { new MethodWithArgumentData("NamespaceEnd") };
        yield return new object[] { new MethodWithArgumentData("Remove", AnyString) };
    }

    public static string GetStringBuilderExtensionMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetStringBuilderExtensionMethodTestDisplayName(data);
}
