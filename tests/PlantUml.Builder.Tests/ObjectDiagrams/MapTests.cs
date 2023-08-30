
namespace PlantUml.Builder.ObjectDiagrams.Tests;

[TestClass]
public class MapTests
{
    [DataRow(null, "b", DisplayName = "Name can not be `null`")]
    [DataRow("", "b", DisplayName = "Name can not be empty")]
    [DataRow(" ", "b", DisplayName = "Name can not be whitespace")]
    [TestMethod]
    public void NameMustContainAValue(string name, string value)
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.MapStart(name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationsDisplayName))]
    [TestMethod]
    public void AValidMapNotationIsRendered(string methodName, object[] methodParameters, string expected)
    {
        // Assign
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
        yield return new object[] { nameof(StringBuilderExtensions.MapStart), new object[] { "name" }, "map name {" };
        yield return new object[] { nameof(StringBuilderExtensions.MapStart), new object[] { "name", "Display Name" }, "map \"Display Name\" as name {" };
        yield return new object[] { nameof(StringBuilderExtensions.MapStart), new object[] { "name", null, "stereotype" }, "map name <<stereotype>> {" };
        yield return new object[] { nameof(StringBuilderExtensions.MapStart), new object[] { "name", null, null, new Uri("https://blog.hompus.nl") }, "map name [[https://blog.hompus.nl/]] {" };
        yield return new object[] { nameof(StringBuilderExtensions.MapStart), new object[] { "name", null, null, null, (Color)NamedColor.Blue }, "map name #Blue {" };
        yield return new object[] { nameof(StringBuilderExtensions.MapStart), new object[] { "name", "Display Name", "stereotype", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue }, "map \"Display Name\" as name <<stereotype>> [[https://blog.hompus.nl/]] #Blue {" };
        yield return new object[] { nameof(StringBuilderExtensions.MapEnd), new object[0], "}" };
    }

    public static string GetValidNotationsDisplayName(MethodInfo _, object[] data)
    {
        var parameters = ((object[])data[1]).Select(p => (Type: p?.GetType().Name ?? "Missing", Value: p == null ? "null" : $"\"{p}\"")).ToList();
        var types = string.Join(", ", parameters.Select(p => p.Type));
        var values = string.Join(", ", parameters.Select(p => p.Value));

        return $"Method \"{data[0]}({types})\" with parameter{(parameters.Count == 1 ? "" : "s")} ({values}) should render as \"{data[2]}\\n\"";
    }
}
