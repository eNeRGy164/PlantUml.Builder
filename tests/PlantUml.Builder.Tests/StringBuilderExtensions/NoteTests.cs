namespace PlantUml.Builder.Tests;

[TestClass]
public class NoteTests
{
    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationsDisplayName))]
    [TestMethod]
    public void AValidNoteIsRendered(string methodName, object[] methodParameters, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var method = typeof(StringBuilderExtensions).FindOverloadedMethod(methodName, methodParameters.Select(p => p.GetType()));
        var remainingParameters = method.GetParameters().Skip(methodParameters.Length + 1).Select(p => Type.Missing);
        var parameters = new object[] { stringBuilder }.Concat(methodParameters).Concat(remainingParameters).ToArray();

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        yield return new object[] { "Note", new object[] { NotePosition.Left, "Simple note." }, "note left : Simple note." };
        yield return new object[] { "Note", new object[] { NotePosition.Left, "Line1\nLine2" }, "note left : Line1\\nLine2" };
        yield return new object[] { "Note", new object[] { NotePosition.Left, "Simple note.", NoteStyle.Hexagonal }, "hnote left : Simple note." };
        yield return new object[] { "Note", new object[] { NotePosition.Left, "Simple note.", NoteStyle.Box }, "rnote left : Simple note." };
        yield return new object[] { "Note", new object[] { NotePosition.Left, "actorA", "Simple note." }, "note left of actorA : Simple note." };
        yield return new object[] { "Note", new object[] { NotePosition.Left, "actorA", "Line1\nLine2" }, "note left of actorA : Line1\\nLine2" };
        yield return new object[] { "Note", new object[] { NotePosition.Left, "actorA", "Simple note.", default(NoteStyle), (Color)NamedColor.AliceBlue }, "note left of actorA #AliceBlue : Simple note." };
        yield return new object[] { "Note", new object[] { "actorA", "Simple note." }, "note over actorA : Simple note." };
        yield return new object[] { "Note", new object[] { "actorA", "actorB", "Simple note." }, "note over actorA,actorB : Simple note." };
        yield return new object[] { "Note", new object[] { "actorA", "Simple note.", default(NoteStyle), (Color)string.Empty, true }, "/ note over actorA : Simple note." };
        yield return new object[] { "HNote", new object[] { NotePosition.Left, "Simple note." }, "hnote left : Simple note." };
        yield return new object[] { "HNote", new object[] { NotePosition.Left, "Line1\nLine2" }, "hnote left : Line1\\nLine2" };
        yield return new object[] { "HNote", new object[] { NotePosition.Left, "actorA", "Simple note." }, "hnote left of actorA : Simple note." };
        yield return new object[] { "HNote", new object[] { NotePosition.Left, "actorA", "Line1\nLine2" }, "hnote left of actorA : Line1\\nLine2" };
        yield return new object[] { "HNote", new object[] { NotePosition.Left, "actorA", "Simple note.", (Color)NamedColor.AliceBlue }, "hnote left of actorA #AliceBlue : Simple note." };
        yield return new object[] { "HNote", new object[] { "actorA", "Simple note." }, "hnote over actorA : Simple note." };
        yield return new object[] { "HNote", new object[] { "actorA", "actorB", "Simple note." }, "hnote over actorA,actorB : Simple note." };
        yield return new object[] { "HNote", new object[] { "actorA", "Simple note.", (Color)string.Empty, true }, "/ hnote over actorA : Simple note." };
        yield return new object[] { "RNote", new object[] { NotePosition.Left, "Simple note." }, "rnote left : Simple note." };
        yield return new object[] { "RNote", new object[] { NotePosition.Left, "Line1\nLine2" }, "rnote left : Line1\\nLine2" };
        yield return new object[] { "RNote", new object[] { NotePosition.Left, "actorA", "Simple note." }, "rnote left of actorA : Simple note." };
        yield return new object[] { "RNote", new object[] { NotePosition.Left, "actorA", "Line1\nLine2" }, "rnote left of actorA : Line1\\nLine2" };
        yield return new object[] { "RNote", new object[] { NotePosition.Left, "actorA", "Simple note.", (Color)NamedColor.AliceBlue }, "rnote left of actorA #AliceBlue : Simple note." };
        yield return new object[] { "RNote", new object[] { "actorA", "Simple note." }, "rnote over actorA : Simple note." };
        yield return new object[] { "RNote", new object[] { "actorA", "actorB", "Simple note." }, "rnote over actorA,actorB : Simple note." };
        yield return new object[] { "RNote", new object[] { "actorA", "Simple note.", (Color)string.Empty, true }, "/ rnote over actorA : Simple note." };
        yield return new object[] { "StartNote", new object[] { NotePosition.Left }, "note left" };
        yield return new object[] { "StartNote", new object[] { NotePosition.Left, string.Empty, NoteStyle.Hexagonal }, "hnote left" };
        yield return new object[] { "StartNote", new object[] { NotePosition.Left, string.Empty, NoteStyle.Box }, "rnote left" };
        yield return new object[] { "StartNote", new object[] { NotePosition.Left, "actorA" }, "note left of actorA" };
        yield return new object[] { "StartNote", new object[] { "actorA" }, "note over actorA" };
        yield return new object[] { "StartNote", new object[] { "actorA", "actorB" }, "note over actorA,actorB" };
        yield return new object[] { "StartHNote", new object[] { NotePosition.Left }, "hnote left" };
        yield return new object[] { "StartHNote", new object[] { NotePosition.Left, "actorA" }, "hnote left of actorA" };
        yield return new object[] { "StartHNote", new object[] { "actorA" }, "hnote over actorA" };
        yield return new object[] { "StartHNote", new object[] { "actorA", "actorB" }, "hnote over actorA,actorB" };
        yield return new object[] { "StartRNote", new object[] { NotePosition.Left }, "rnote left" };
        yield return new object[] { "StartRNote", new object[] { NotePosition.Left, "actorA" }, "rnote left of actorA" };
        yield return new object[] { "StartRNote", new object[] { "actorA" }, "rnote over actorA" };
        yield return new object[] { "StartRNote", new object[] { "actorA", "actorB" }, "rnote over actorA,actorB" };
        yield return new object[] { "EndNote", new object[0], "end note" };
        yield return new object[] { "EndHNote", new object[0], "end hnote" };
        yield return new object[] { "EndRNote", new object[0], "end rnote" };
    }

    public static string GetValidNotationsDisplayName(MethodInfo _, object[] data)
    {
        var parameters = ((object[])data[1]).Select(p => (Type: p.GetType().Name, Value: $"\"{p}\""));
        var types = string.Join(", ", parameters.Select(p => p.Type));
        var values = string.Join(", ", parameters.Select(p => p.Value));

        return $"Method \"{data[0]}({types})\" with parameters {values} should render as \"{data[2]}\\n\"";
    }
}
