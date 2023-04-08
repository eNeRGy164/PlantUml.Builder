using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams;

[TestClass]
public class EntityStartTests
{
    [TestMethod]
    public void StringBuilderExtensions_EntityStart_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.EntityStart(string.Empty);

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_EntityStart_Should_ContainEntityStartLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.EntityStart("entityA");

        // Assert
        stringBuilder.ToString().Should().Be("entity entityA {\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_EntityStart_WithVisibility_Should_ContaiEntityStartLineWithVisibility()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.EntityStart("entityA", visibility: VisibilityModifier.Public);

        // Assert
        stringBuilder.ToString().Should().Be("+entity entityA {\n");
    }
}
