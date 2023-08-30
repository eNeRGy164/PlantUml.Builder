
namespace PlantUml.Builder.ObjectDiagrams.Tests;

[TestClass]
public class StringBuilderExtensionMethodTests
{
    [TestMethod]
    [DynamicData(nameof(GetStringBuilderExtensionMethods), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetStringBuilderExtensionMethodsDisplayName))]
    public void ExtensionMethodsShouldNotWorkOnANullStringBuilder(string methodName, object[] methodParameters)
    {
        // Arrange
        StringBuilder stringBuilder = null;

        var method = typeof(StringBuilderExtensions).FindOverloadedMethod(methodName, methodParameters.Select(p => p.GetType()));
        var remainingParameters = method.GetParameters().Skip(methodParameters.Length + 1).Select(p => Type.Missing);
        var parameters = new object[] { stringBuilder }.Concat(methodParameters).Concat(remainingParameters).ToArray();

        // Act
        Action action = () => method.Invoke(null, parameters);

        // Assert
        action.Should().ThrowExactly<TargetInvocationException>()
            .WithInnerExceptionExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    private static IEnumerable<object[]> GetStringBuilderExtensionMethods()
    {
        // Define the valid notations and expected results for different overloads
        yield return new object[] { "Object", new object[] { "name" } };
        yield return new object[] { "MapStart", new object[] { "name" } };
        yield return new object[] { "ObjectStart", new object[] { "name" } };
        yield return new object[] { "MapEnd", new object[0] };
        yield return new object[] { "ObjectEnd", new object[0] };
    }

    public static string GetStringBuilderExtensionMethodsDisplayName(MethodInfo _, object[] data)
    {
        return $"Method \"{data[0]}\" should throw an argument exception when StringBuilder is `null`";
    }
}
