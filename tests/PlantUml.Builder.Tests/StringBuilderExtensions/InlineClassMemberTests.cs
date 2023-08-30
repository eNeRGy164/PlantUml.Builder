namespace PlantUml.Builder.Tests;

[TestClass]
public class InlineClassMemberTests
{
    [TestMethod]
    public void StringBuilderExtensions_ClassMember_Null_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.InlineClassMember(new ClassMember("member"));

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_ClassMember_ClassMemberNull_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.InlineClassMember(null);

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("classMember");
    }

    [TestMethod]
    public void StringBuilderExtensions_ClassMember_Should_ContainClassMemberLine()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InlineClassMember(new ClassMember("member"));

        // Assert
        stringBuilder.ToString().Should().Be("member\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_ClassMember_WithPublicVisibility_Should_ContainClassMemberLineWithPublicAnnotation()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InlineClassMember(new ClassMember("member", visibility: VisibilityModifier.Public));

        // Assert
        stringBuilder.ToString().Should().Be("+member\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_ClassMember_WithPackagePrivateVisibility_Should_ContainClassMemberLineWithPackagePrivateAnnotation()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InlineClassMember(new ClassMember("member", visibility: VisibilityModifier.PackagePrivate));

        // Assert
        stringBuilder.ToString().Should().Be("~member\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_ClassMember_WithProtectedVisibility_Should_ContainClassMemberLineWithProtectedAnnotation()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InlineClassMember(new ClassMember("member", visibility: VisibilityModifier.Protected));

        // Assert
        stringBuilder.ToString().Should().Be("#member\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_ClassMember_WithPrivateVisibility_Should_ContainClassMemberLineWithPrivateAnnotation()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InlineClassMember(new ClassMember("member", visibility: VisibilityModifier.Private));

        // Assert
        stringBuilder.ToString().Should().Be("-member\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_ClassMember_IsAbstract_Should_ContainClassMemberLineWithAbstractAnnotation()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InlineClassMember(new ClassMember("member", isAbstract: true));

        // Assert
        stringBuilder.ToString().Should().Be("{abstract}member\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_ClassMember_IsStatic_Should_ContainClassMemberLineWithStaticAnnotation()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InlineClassMember(new ClassMember("member", isStatic: true));

        // Assert
        stringBuilder.ToString().Should().Be("{static}member\n");
    }
}
