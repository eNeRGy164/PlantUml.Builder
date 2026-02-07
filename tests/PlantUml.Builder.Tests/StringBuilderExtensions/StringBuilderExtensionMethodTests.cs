using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

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
        action.Should().ThrowExactly<TargetInvocationException>()
            .WithInnerExceptionExactly<ArgumentNullException>()
            .WithParameterName("stringBuilder");
    }

    private static IEnumerable<object[]> GetStringBuilderExtensionMethods()
    {
        // PlantUML methods
        yield return new object[] { new MethodWithArgumentData("Note", default(NotePosition), AnyString) };
        yield return new object[] { new MethodWithArgumentData("HNote", default(NotePosition), AnyString) };
        yield return new object[] { new MethodWithArgumentData("RNote", default(NotePosition), AnyString) };
        yield return new object[] { new MethodWithArgumentData("StartNote", default(NotePosition)) };
        yield return new object[] { new MethodWithArgumentData("StartHNote", default(NotePosition)) };
        yield return new object[] { new MethodWithArgumentData("StartRNote", default(NotePosition)) };
        yield return new object[] { new MethodWithArgumentData("EndNote") };
        yield return new object[] { new MethodWithArgumentData("EndHNote") };
        yield return new object[] { new MethodWithArgumentData("EndRNote") };
        yield return new object[] { new MethodWithArgumentData("AllowMixing") };
        yield return new object[] { new MethodWithArgumentData("Comment") };
        yield return new object[] { new MethodWithArgumentData("CommentBlock") };
        yield return new object[] { new MethodWithArgumentData("Footer", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Header", AnyString) };
        yield return new object[] { new MethodWithArgumentData("HideEntityPortion", AnyString, EntityPortion.Members) };
        yield return new object[] { new MethodWithArgumentData("InlineClassMember", (ClassMember)AnyString) };
        yield return new object[] { new MethodWithArgumentData("Mainframe", AnyString) };
        yield return new object[] { new MethodWithArgumentData("MemberDeclaration", AnyString, (ClassMember)AnyString) };
        yield return new object[] { new MethodWithArgumentData("Relationship", AnyString, AnyString, AnyString) };
        yield return new object[] { new MethodWithArgumentData("SetNamespaceSeparator") };
        yield return new object[] { new MethodWithArgumentData("SkinParameter", AnyString, AnyString) };
        yield return new object[] { new MethodWithArgumentData("StereoType") };
        yield return new object[] { new MethodWithArgumentData("Text", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Title", AnyString) };
        yield return new object[] { new MethodWithArgumentData("UmlDiagramEnd") };
        yield return new object[] { new MethodWithArgumentData("UmlDiagramStart") };

        // Non PlantUML methods
        yield return new object[] { new MethodWithArgumentData("AppendNewLine") };
        yield return new object[] { new MethodWithArgumentData("TrimEnd") };
    }

    public static string GetStringBuilderExtensionMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetStringBuilderExtensionMethodTestDisplayName(data);
}
