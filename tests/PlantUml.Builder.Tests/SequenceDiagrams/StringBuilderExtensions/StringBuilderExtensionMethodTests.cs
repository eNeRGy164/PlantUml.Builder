using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

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
        action.ShouldThrowExactly<TargetInvocationException>()
            .ShouldHaveInnerExceptionExactly<ArgumentNullException>()
            .WithParameterName("stringBuilder");
    }

    private static IEnumerable<object[]> GetStringBuilderExtensionMethods()
    {
        yield return new object[] { new MethodWithArgumentData("Activate", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Actor", AnyString) };
        yield return new object[] { new MethodWithArgumentData("AltStart") };
        yield return new object[] { new MethodWithArgumentData("Arrow", (ParticipantName)AnyString, Arrow.Right, (ParticipantName)AnyString) };
        yield return new object[] { new MethodWithArgumentData("AutoNumber") };
        yield return new object[] { new MethodWithArgumentData("AutoActivate") };
        yield return new object[] { new MethodWithArgumentData("Boundary", AnyString) };
        yield return new object[] { new MethodWithArgumentData("BoxEnd") };
        yield return new object[] { new MethodWithArgumentData("BoxStart") };
        yield return new object[] { new MethodWithArgumentData("Collections", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Control", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Create", AnyString) };
        yield return new object[] { new MethodWithArgumentData("CreateActor", AnyString) };
        yield return new object[] { new MethodWithArgumentData("CreateBoundary", AnyString) };
        yield return new object[] { new MethodWithArgumentData("CreateCollections", AnyString) };
        yield return new object[] { new MethodWithArgumentData("CreateControl", AnyString) };
        yield return new object[] { new MethodWithArgumentData("CreateDatabase", AnyString) };
        yield return new object[] { new MethodWithArgumentData("CreateEntity", AnyString) };
        yield return new object[] { new MethodWithArgumentData("CreateQueue", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Database", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Deactivate") };
        yield return new object[] { new MethodWithArgumentData("Deactivate", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Delay") };
        yield return new object[] { new MethodWithArgumentData("Destroy", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Divider") };
        yield return new object[] { new MethodWithArgumentData("ElseStart") };
        yield return new object[] { new MethodWithArgumentData("EndLoop") };
        yield return new object[] { new MethodWithArgumentData("EndRef") };
        yield return new object[] { new MethodWithArgumentData("Entity", AnyString) };
        yield return new object[] { new MethodWithArgumentData("HideFootBox") };
        yield return new object[] { new MethodWithArgumentData("HideUnlinked") };
        yield return new object[] { new MethodWithArgumentData("GroupEnd") };
        yield return new object[] { new MethodWithArgumentData("GroupStart") };
        yield return new object[] { new MethodWithArgumentData("IncreaseAutoNumber") };
        yield return new object[] { new MethodWithArgumentData("NewPage") };
        yield return new object[] { new MethodWithArgumentData("NewPage", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Participant", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Queue", AnyString) };
        yield return new object[] { new MethodWithArgumentData("Ref", AnyString, AnyString) };
        yield return new object[] { new MethodWithArgumentData("Ref", AnyString, AnyString, AnyString) };
        yield return new object[] { new MethodWithArgumentData("ResumeAutoNumber") };
        yield return new object[] { new MethodWithArgumentData("Return") };
        yield return new object[] { new MethodWithArgumentData("Return", AnyString) };
        yield return new object[] { new MethodWithArgumentData("ShowFootBox") };
        yield return new object[] { new MethodWithArgumentData("ShowUnlinked") };
        yield return new object[] { new MethodWithArgumentData("Space") };
        yield return new object[] { new MethodWithArgumentData("StartLoop") };
        yield return new object[] { new MethodWithArgumentData("StartRef", AnyString) };
        yield return new object[] { new MethodWithArgumentData("StartRef", AnyString, AnyString) };
        yield return new object[] { new MethodWithArgumentData("StopAutoNumber") };

    }

    public static string GetStringBuilderExtensionMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetStringBuilderExtensionMethodTestDisplayName(data);
}
