using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class MemberDeclarationTests
{
    [DataRow("name", null, AnyString, DisplayName = "MemberDeclaration - Class argument cannot be `null`")]
    [DataRow("member", AnyString, null, DisplayName = "MemberDeclaration - Member argument cannot be `null`")]
    [TestMethod]
    public void MemberDeclarationArgumentsCannotBeNull(string parameterName, string name, string member)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.MemberDeclaration(name, (ClassMember)member);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName(parameterName);
    }

    [DataRow(EmptyString, DisplayName = "MemberDeclaration - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "MemberDeclaration - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void MemberDeclarationNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.MemberDeclaration(name, (ClassMember)AnyString);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void MemberDeclarationIsRenderedCorrectly(MemberDeclarationData testData)
    {
        // Arrange
        var stringBuilder = new StringBuilder();
        var classMember = new ClassMember(testData.MemberName, testData.IsStatic, testData.IsAbstract, testData.Visibility);

        // Act
        stringBuilder.MemberDeclaration(testData.ClassName, classMember);

        // Assert
        stringBuilder.ToString().ShouldBe($"{testData.Expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        yield return new object[] { new MemberDeclarationData("class : data", "class", "data") };
        yield return new object[] { new MemberDeclarationData("class : member", "class", "member") };
        yield return new object[] { new MemberDeclarationData("class : {abstract} member", "class", "member", IsAbstract: true) };
        yield return new object[] { new MemberDeclarationData("class : {static} member", "class", "member", IsStatic: true) };
        yield return new object[] { new MemberDeclarationData("class : +member", "class", "member", Visibility: VisibilityModifier.Public) };
        yield return new object[] { new MemberDeclarationData("class : ~member", "class", "member", Visibility: VisibilityModifier.PackagePrivate) };
        yield return new object[] { new MemberDeclarationData("class : #member", "class", "member", Visibility: VisibilityModifier.Protected) };
        yield return new object[] { new MemberDeclarationData("class : -member", "class", "member", Visibility: VisibilityModifier.Private) };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data)
    {
        if (data[0] is not MemberDeclarationData testData)
        {
            throw new ArgumentException($"Data array must contain a {nameof(MemberDeclarationData)} instance.", nameof(data));
        }

        return $"MemberDeclaration with ClassName={testData.ClassName}, MemberName={testData.MemberName}, IsStatic={testData.IsStatic}, IsAbstract={testData.IsAbstract}, Visibility={testData.Visibility} should render as \"{testData.Expected}\\n\"";
    }

    public record MemberDeclarationData(string Expected, string ClassName, string MemberName, bool IsStatic = false, bool IsAbstract = false, VisibilityModifier Visibility = VisibilityModifier.None);
}
