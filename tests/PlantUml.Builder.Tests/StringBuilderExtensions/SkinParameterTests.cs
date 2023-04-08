using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PlantUml.Builder.Tests;

[TestClass]
public class SkinParameterTests
{
    [TestMethod]
    public void StringBuilderExtensions_SkinParameter_Null_Should_ThrowExactlyArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.SkinParameter("a", "b");

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [DataRow("name", null, "b", DisplayName = "Name can not be `null`")]
    [DataRow("name", "", "b", DisplayName = "Name can not be empty")]
    [DataRow("name", " ", "b", DisplayName = "Name can not be whitespace")]
    [DataRow("value", "a", null, DisplayName = "Value can not be `null`")]
    [DataRow("value", "a", "", DisplayName = "Value can not be empty")]
    [DataRow("value", "a", " ", DisplayName = "Value can not be whitespace")]
    [TestMethod]
    public void ParametersHaveToContainAValue(string parameterName, string name, string value)
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.SkinParameter(name, value);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be(parameterName);
    }

    [TestMethod]
    public void EnumerationValueShouldExist()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.SkinParameter((SkinParameter)ushort.MaxValue, "b");

        // Assert
        action.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("A defined enum value should be provided*")
            .And.ParamName.Should().Be("skinParameter");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationsDisplayName))]
    [TestMethod]
    public void AValidSkinParamNotationIsRendered(object name, object value, string expected)
    {
        // Assign
        var stringBuilder = new StringBuilder();

        var method = typeof(StringBuilderExtensions).GetMethod("SkinParameter", new[] { typeof(StringBuilder), name.GetType(), value.GetType() });
        var parameters = new[] { stringBuilder, name, value };
        
        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"skinparam {expected}\n");
    }
    private static IEnumerable<object[]> GetValidNotations()
    {
        yield return new object[] { "monochrome", "true", "monochrome true" };
        yield return new object[] { " monochrome ", "true", "monochrome true" };
        yield return new object[] { "monochrome", " true ", "monochrome true" };
        yield return new object[] { SkinParameter.Monochrome, "true", "Monochrome true" };
        yield return new object[] { "monochrome", true, "monochrome true" };
        yield return new object[] { SkinParameter.Monochrome, false, "Monochrome false" };
        yield return new object[] { "minclasswidth", 200, "minclasswidth 200" };
        yield return new object[] { SkinParameter.MinClassWidth, 400, "MinClassWidth 400" };
    }

    public static string GetValidNotationsDisplayName(MethodInfo _, object[] data)
    {
        return $"SkinParameter \"{data[0]}\" ({data[0].GetType().Name}) with value \"{data[1]}\" ({data[1].GetType().Name}) should render as \"skinparam {data[2]}\\n\"";
    }
}
