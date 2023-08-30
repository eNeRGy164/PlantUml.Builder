
namespace PlantUml.Builder.Tests;

[TestClass]
public class StringBuilderExtensionMethodTests
{
    [TestMethod]
    [DynamicData(nameof(GetStringBuilderExtensionMethods), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetStringBuilderExtensionMethodsDisplayName))]
    public void ExtensionMethodsShouldNotWorkOnANullStringBuilder(string methodName, object[] methodParameters)
    {
        // Assign
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
        yield return new object[] { "Note", new object[] { default(NotePosition), string.Empty } };
        yield return new object[] { "HNote", new object[] { default(NotePosition), string.Empty } };
        yield return new object[] { "RNote", new object[] { default(NotePosition), string.Empty } };
        yield return new object[] { "StartNote", new object[] { default(NotePosition) } };
        yield return new object[] { "StartHNote", new object[] { default(NotePosition) } };
        yield return new object[] { "StartRNote", new object[] { default(NotePosition) } };
        yield return new object[] { "EndNote", new object[0] };
        yield return new object[] { "EndHNote", new object[0] };
        yield return new object[] { "EndRNote", new object[0] };
    }

    public static string GetStringBuilderExtensionMethodsDisplayName(MethodInfo _, object[] data)
    {
        return $"Method \"{data[0]}\" should throw an argument exception when StringBuilder is `null`";
    }
}
