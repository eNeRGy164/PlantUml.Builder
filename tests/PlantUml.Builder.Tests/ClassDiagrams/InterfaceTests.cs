using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams;

[TestClass]
public class InterfaceTests
{
    [TestMethod]
    public void StringBuilderExtensions_Interface_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Interface("interfaceA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Interface(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Interface(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Interface(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_Should_ContainInterfaceLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA");

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithDisplayName_Should_ContainInterfaceLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", displayName: "Interface A");

        // Assert
        stringBuilder.ToString().Should().Be("interface \"Interface A\" as interfaceA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithStereotype_Should_ContainInterfaceLineWithStereotype()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", stereotype: "entity");

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA <<entity>>\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithStereotypeAndCustomSpot_Should_ContainInterfaceLineWithStereotypeAndCustomSpot()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", stereotype: "entity", customSpot: new CustomSpot('R', "Blue"));

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA <<(R,#Blue)entity>>\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithGenerics_Should_ContainInterfaceLineWithGenerics()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", generics: "Object");

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA<Object>\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithBackgroundColor_Should_ContainInterfaceLineWithBackgroundColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", backgroundColor: "#AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithBackgroundColorWithHashtag_Should_ContainInterfaceLineWithBackgroundColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", backgroundColor: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithTag_Should_ContainInterfaceLineWithTag()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", tag: "tag");

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA $tag\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithUrl_Should_ContainInterfaceLineWithUrl()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", url: new Uri("https://blog.hompus.nl"));

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA [[https://blog.hompus.nl/]]\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithLineStyle_Should_ContainInterfaceLineWithLineStyle()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", lineStyle: LineStyle.Bold);

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA ##[bold]\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithLineColor_Should_ContainInterfaceLineWithLineColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", lineColor: "Blue");

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA ##Blue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithExtends_Should_ContainInterfaceLineWithExtends()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", extends: new[] { "BaseClass" });

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA extends BaseClass\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithMultipleExtends_Should_ContainInterfaceLineWithSeperatedExtends()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", extends: new[] { "BaseClass", "BaseClass2" });

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA extends BaseClass,BaseClass2\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithNoImplements_Should_ContainInterfaceLineWithoutImplements()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", implements: new string[0]);

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithImplements_Should_ContainInterfaceLineWithImplements()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", implements: new[] { "IInterface" });

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA implements IInterface\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Interface_WithMultipleImplements_Should_ContainInterfaceLineWithSeperatedImplements()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Interface("interfaceA", implements: new[] { "IInterface", "IInterface2" });

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA implements IInterface,IInterface2\n");
    }
}
