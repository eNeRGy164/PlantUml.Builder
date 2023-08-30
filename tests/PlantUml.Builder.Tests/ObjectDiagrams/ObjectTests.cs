using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ObjectDiagrams.Tests;

[TestClass]
public class ObjectTests
{
    [DataRow(null, "b", DisplayName = "Name can not be `null`")]
    [DataRow("", "b", DisplayName = "Name can not be empty")]
    [DataRow(" ", "b", DisplayName = "Name can not be whitespace")]
    [TestMethod]
    public void NameMustContainAValue(string name, string value)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Object(name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationsDisplayName))]
    [TestMethod]
    public void AValidObjectNotationIsRendered(string methodName, object[] methodParameters, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var method = typeof(StringBuilderExtensions).FindOverloadedMethod(methodName, methodParameters.Select(p => p?.GetType()));
        var remainingParameters = method.GetParameters().Skip(methodParameters.Length + 1).Select(p => Type.Missing);
        var parameters = new object[] { stringBuilder }.Concat(methodParameters.Select(p => p ?? Type.Missing)).Concat(remainingParameters).ToArray();

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        // Define the valid notations and expected results for different overloads
        yield return new object[] { nameof(StringBuilderExtensions.Object), new object[] { "name", "Display Name" }, "object \"Display Name\" as name" };
        yield return new object[] { nameof(StringBuilderExtensions.Object), new object[] { "name", null, "stereotype" }, "object name <<stereotype>>" };
        yield return new object[] { nameof(StringBuilderExtensions.Object), new object[] { "name", null, null, new Uri("https://blog.hompus.nl") }, "object name [[https://blog.hompus.nl/]]" };
        yield return new object[] { nameof(StringBuilderExtensions.Object), new object[] { "name", null, null, null, (Color)NamedColor.Blue }, "object name #Blue" };
        yield return new object[] { nameof(StringBuilderExtensions.Object), new object[] { "name", "Display Name", "stereotype", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue }, "object \"Display Name\" as name <<stereotype>> [[https://blog.hompus.nl/]] #Blue" };
        yield return new object[] { nameof(StringBuilderExtensions.ObjectStart), new object[] { "objectA" }, "object objectA {" };
        yield return new object[] { nameof(StringBuilderExtensions.ObjectEnd), new object[0], "}" };
    }

    public static string GetValidNotationsDisplayName(MethodInfo _, object[] data)
    {
        var parameters = ((object[])data[1]).Select(p => (Type: p?.GetType().Name ?? "Missing", Value: p == null ? "null" : $"\"{p}\"")).ToList();
        var types = string.Join(", ", parameters.Select(p => p.Type));
        var values = string.Join(", ", parameters.Select(p => p.Value));

        return $"Method \"{data[0]}({types})\" with parameter{(parameters.Count == 1 ? "" : "s")} ({values}) should render as \"{data[2]}\\n\"";
    }
}
