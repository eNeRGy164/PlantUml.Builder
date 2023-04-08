using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams;

[TestClass]
public class InterfaceStartTests
{
    [TestMethod]
    public void StringBuilderExtensions_InterfaceStart_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.InterfaceStart(string.Empty);

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_InterfaceStart_Should_ContainInterfaceStartLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InterfaceStart("interfaceA");

        // Assert
        stringBuilder.ToString().Should().Be("interface interfaceA {\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_InterfaceStart_WithVisibility_Should_ContaiInterfaceStartLineWithVisibility()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.InterfaceStart("interfaceA", visibility: VisibilityModifier.Public);

        // Assert
        stringBuilder.ToString().Should().Be("+interface interfaceA {\n");
    }
}
