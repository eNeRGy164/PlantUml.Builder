using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class ClassMemberTests
{
    [TestMethod]
    public void ClassMember_NullName_Should_ThrowArgumentException()
    {
        // Arrange & Act
        Action action = () => _ = new ClassMember(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void ClassMember_EmptyName_Should_ThrowArgumentException()
    {
        // Arrange & Act
        Action action = () => _ = new ClassMember(name);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void ClassMember_WhitespaceName_Should_ThrowArgumentException()
    {
        // Act
        Action action = () => new ClassMember(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [DataRow("member", "member", DisplayName = "Value without special values should stay the same")]
    [DataRow("  member  ", "member", DisplayName = "Whitespace should be trimmed")]
    [DataRow("#member", "member", DisplayName = "Protected visibility modifiers are trimmed")]
    [DataRow("-member", "member", DisplayName = "Private visibility modifiers are trimmed")]
    [DataRow("+member", "member", DisplayName = "Public visibility modifiers are trimmed")]
    [DataRow("~member", "member", DisplayName = "Package private visibility modifiers are trimmed")]
    [DataRow("~#member", "#member", DisplayName = "Only the first visibility modifier character is trimmed")]
    [DataRow("~#", "~#", DisplayName = "Value must have more then 2 characters to detect a visibility modifier")]
    [DataRow("{static}", "", DisplayName = "If value only contains modifiers, it leaves an empty name")]
    [DataRow("  # member", "member", DisplayName = "Visibility modifiers are trimmed, even if there is whitespace in front")]
    [DataRow("##member", "##member", DisplayName = "If the first to characters are the same, do not treat it as a visibility modifier")]
    [DataRow("{static} member", "member", DisplayName = "Static modifier is trimmed")]
    [DataRow("{abstract} member", "member", DisplayName = "Abstract modifier is trimmed")]
    [DataRow("{static} {abstract} member", "member", DisplayName = "Modifiers are trimmed")]
    [DataRow("member{static} {abstract}member", "member member", DisplayName = "Modifiers in the middle of the value are trimmed")]
    [TestMethod]
    public void CastingShouldLeaveTrimmedNamePart(string value, string expected)
    {
        // Act
        ClassMember member = value;

        // Assert
        member.Name.Should().Be(expected);
    }

    [DataRow("member", false, DisplayName = "Instance member should not be static")]
    [DataRow("{static} member", true, DisplayName = "Static member should be static")]
    [DataRow("{StaTic} member", true, DisplayName = "Casing should not make a difference")]
    [DataRow("{abstract} member", false, DisplayName = "Abstract member should not be static")]
    [DataRow("{static}", true, DisplayName = "If value only contains static, it should be static")]
    [DataRow("{static} {abstract} member", true, DisplayName = "Abstract static member should be static")]
    [DataRow("member{static} member", true, DisplayName = "Should detect static in the middle of the value")]
    [TestMethod]
    public void CastingShouldDetectStaticModifier(string value, bool expected)
    {
        // Act
        ClassMember member = value;

        // Assert
        member.IsStatic.Should().Be(expected);
    }

    [DataRow("member", false, DisplayName = "Instance member should not be abstract")]
    [DataRow("{static} member", false, DisplayName = "Static member should not be abstract")]
    [DataRow("{abstract} member", true, DisplayName = "Abstract member should be abstract")]
    [DataRow("{AbsTract} member", true, DisplayName = "Casing should not make a difference")]
    [DataRow("{abstract}", true, DisplayName = "If value only contains abstract, it should be abstract")]
    [DataRow("{static} {abstract} member", true, DisplayName = "Abstract static member should be abstract")]
    [DataRow("member {abstract}member", true, DisplayName = "Should detect abstract in the middle of the value")]
    [TestMethod]
    public void CastingShouldDetectAbstractModifier(string value, bool expected)
    {
        // Act
        ClassMember member = value;

        // Assert
        member.IsAbstract.Should().Be(expected);
    }

    [DataRow("member", VisibilityModifier.None, DisplayName = "No modifiers")]
    [DataRow("#member", VisibilityModifier.Protected, DisplayName = "Protected visibility modifier")]
    [DataRow("-member", VisibilityModifier.Private, DisplayName = "Private visibility modifier")]
    [DataRow("+member", VisibilityModifier.Public, DisplayName = "Public visibility modifier")]
    [DataRow("~member", VisibilityModifier.PackagePrivate, DisplayName = "Package private visibility modifier")]
    [DataRow("~#member", VisibilityModifier.PackagePrivate, DisplayName = "Only the first visibility modifier character is detected")]
    [DataRow("  # member", VisibilityModifier.Protected, DisplayName = "Visibility modifier is detected, even if there is whitespace in front")]
    [DataRow("##member", VisibilityModifier.None, DisplayName = "If the first to characters are the same, do not treat it as a visibility modifier")]
    [TestMethod]
    public void CastingShouldVisibilityModifier(string value, VisibilityModifier expected)
    {
        // Act
        ClassMember member = value;

        // Assert
        member.Visibility.Should().Be(expected);
    }
}
