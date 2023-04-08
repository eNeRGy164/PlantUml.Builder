using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams;

[TestClass]
public class EnumTests
{
    [TestMethod]
    public void StringBuilderExtensions_Enum_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Enum("EnumA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Enum(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Enum(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Enum(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_Should_ContainEnumLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA");

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithDisplayName_Should_ContainEnumLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", displayName: "Enum A");

        // Assert
        stringBuilder.ToString().Should().Be("enum \"Enum A\" as EnumA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithStereotype_Should_ContainEnumLineWithStereotype()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", stereotype: "entity");

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA <<entity>>\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithStereotypeAndCustomSpot_Should_ContainEnumLineWithStereotypeAndCustomSpot()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", stereotype: "entity", customSpot: new CustomSpot('R', "Blue"));

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA <<(R,#Blue)entity>>\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithGenerics_Should_ContainEnumLineWithGenerics()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", generics: "Object");

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA<Object>\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithBackgroundColor_Should_ContainEnumLineWithBackgroundColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", backgroundColor: "#AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithBackgroundColorWithHashtag_Should_ContainEnumLineWithBackgroundColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", backgroundColor: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithTag_Should_ContainEnumLineWithTag()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", tag: "tag");

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA $tag\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithUrl_Should_ContainEnumLineWithUrl()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", url: new Uri("https://blog.hompus.nl"));

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA [[https://blog.hompus.nl/]]\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithLineStyle_Should_ContainEnumLineWithLineStyle()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", lineStyle: LineStyle.Bold);

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA ##[bold]\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithLineColor_Should_ContainEnumLineWithLineColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", lineColor: "Blue");

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA ##Blue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithExtends_Should_ContainEnumLineWithExtends()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", extends: new[] { "BaseClass" });

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA extends BaseClass\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithMultipleExtends_Should_ContainEnumLineWithSeperatedExtends()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", extends: new[] { "BaseClass", "BaseClass2" });

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA extends BaseClass,BaseClass2\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithNoImplements_Should_ContainEnumLineWithoutImplements()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", implements: new string[0]);

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithImplements_Should_ContainEnumLineWithImplements()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", implements: new[] { "IInterface" });

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA implements IInterface\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Enum_WithMultipleImplements_Should_ContainEnumLineWithSeperatedImplements()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Enum("EnumA", implements: new[] { "IInterface", "IInterface2" });

        // Assert
        stringBuilder.ToString().Should().Be("enum EnumA implements IInterface,IInterface2\n");
    }
}
