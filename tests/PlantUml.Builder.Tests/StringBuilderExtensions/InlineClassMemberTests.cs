namespace PlantUml.Builder.Tests;

[TestClass]
public class InlineClassMemberTests
{
    [TestMethod("InlineClassMember - Class member argument cannot be `null`")]
    public void InlineClassMemberCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.InlineClassMember(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("classMember");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void InlineClassMemberIsRenderedCorrectly(ClassMemberData testData)
    {
        // Arrange
        var stringBuilder = new StringBuilder();
        var classMember = new ClassMember(testData.Name, testData.IsStatic, testData.IsAbstract, testData.Visibility);

        // Act
        stringBuilder.InlineClassMember(classMember);

        // Assert
        stringBuilder.ToString().Should().Be($"{testData.Expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        yield return new object[] { new ClassMemberData("member", "member") };
        yield return new object[] { new ClassMemberData("{abstract} member", "member", IsAbstract: true) };
        yield return new object[] { new ClassMemberData("{static} member", "member", IsStatic: true) };
        yield return new object[] { new ClassMemberData("+member", "member", Visibility: VisibilityModifier.Public) };
        yield return new object[] { new ClassMemberData("~member", "member", Visibility: VisibilityModifier.PackagePrivate) };
        yield return new object[] { new ClassMemberData("#member", "member", Visibility: VisibilityModifier.Protected) };
        yield return new object[] { new ClassMemberData("-member", "member", Visibility: VisibilityModifier.Private) };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data)
    {
        if (data[0] is not ClassMemberData testData)
        {
            throw new ArgumentException($"Data array must contain a {nameof(ClassMemberData)} instance.", nameof(data));
        }

        var types = new StringBuilder();
        var values = new StringBuilder();

        return $"ClassMember with Name={testData.Name}, IsStatic={testData.IsStatic}, IsAbstract={testData.IsAbstract}, Visibility={testData.Visibility} should render as \"{testData.Expected}\\n\"";
    }

    public record ClassMemberData(string Expected, string Name, bool IsStatic = false, bool IsAbstract = false, VisibilityModifier Visibility = VisibilityModifier.None);
}
