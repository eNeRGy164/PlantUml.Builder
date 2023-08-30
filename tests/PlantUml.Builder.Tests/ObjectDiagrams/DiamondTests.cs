
namespace PlantUml.Builder.ObjectDiagrams.Tests;

[TestClass]
public class DiamondTests
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
        Action action = () => stringBuilder.Diamond(name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationsDisplayName))]
    [TestMethod]
    public void AValidDiamondNotationIsRendered(object[] methodParameters, string expected)
    {
        // Assign
        var stringBuilder = new StringBuilder();

        var method = typeof(StringBuilderExtensions).FindOverloadedMethod(nameof(StringBuilderExtensions.Diamond), methodParameters.Select(p => p?.GetType()));
        var remainingParameters = method.GetParameters().Skip(methodParameters.Length + 1).Select(p => Type.Missing);
        var parameters = new object[] { stringBuilder }.Concat(methodParameters.Select(p => p ?? Type.Missing)).Concat(remainingParameters).ToArray();

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        yield return new object[] { new object[] { "name" }, "diamond name" };
        yield return new object[] { new object[] { "name", "Display Name" }, "diamond \"Display Name\" as name" };
        yield return new object[] { new object[] { "name", null, "generic" }, "diamond name<generic>" };
        yield return new object[] { new object[] { "name", null, null, "stereotype" }, "diamond name <<stereotype>>" };
        yield return new object[] { new object[] { "name", null, null, "stereotype", new CustomSpot('A', NamedColor.Blue) }, "diamond name <<(A,#Blue)stereotype>>" };
        yield return new object[] { new object[] { "name", null, null, null, null, "tag" }, "diamond name $tag" };
        yield return new object[] { new object[] { "name", null, null, null, null, null, new Uri("https://blog.hompus.nl") }, "diamond name [[https://blog.hompus.nl/]]" };
        yield return new object[] { new object[] { "name", null, null, null, null, null, null, (Color)NamedColor.Blue }, "diamond name #Blue" };
        yield return new object[] { new object[] { "name", null, null, null, null, null, null, null, (Color)NamedColor.Blue }, "diamond name ##Blue" };
        yield return new object[] { new object[] { "name", null, null, null, null, null, null, null, null, LineStyle.Dashed }, "diamond name ##[dashed]" };
        yield return new object[] { new object[] { "name", null, null, null, null, null, null, null, null, null, new[] { "extend1", "extend2" } }, "diamond name extends extend1,extend2" };
        yield return new object[] { new object[] { "name", null, null, null, null, null, null, null, null, null, null, new[] { "implement1", "implement2" } }, "diamond name implements implement1,implement2" };
        yield return new object[] { new object[] { "name", "Display Name", "generic", "stereotype", new CustomSpot('A', NamedColor.Blue), "tag", new Uri("https://blog.hompus.nl"), (Color)NamedColor.Blue, (Color)NamedColor.Blue, LineStyle.Dashed, new[] { "extend1", "extend2" }, new[] { "implement1", "implement2" } }, "diamond \"Display Name\" as name<generic> <<(A,#Blue)stereotype>> $tag [[https://blog.hompus.nl/]] #Blue ##[dashed]Blue extends extend1,extend2 implements implement1,implement2" };
    }

    public static string GetValidNotationsDisplayName(MethodInfo _, object[] data)
    {
        var parameters = ((object[])data[0]).Select(p => (Type: p?.GetType().Name ?? "Missing", Value: p == null ? "null" : $"\"{p}\"")).ToList();
        var types = string.Join(", ", parameters.Select(p => p.Type));
        var values = string.Join(", ", parameters.Select(p => p.Value));

        return $"Method \"{nameof(StringBuilderExtensions.Diamond)}({types})\" with parameter{(parameters.Count == 1 ? "" : "s")} ({values}) should render as \"{data[1]}\\n\"";
    }
}
