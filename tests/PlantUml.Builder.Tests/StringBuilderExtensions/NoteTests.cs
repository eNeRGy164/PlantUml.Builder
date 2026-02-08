namespace PlantUml.Builder.Tests;

[TestClass]
public class NoteTests
{
    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void NoteIsRenderedCorrectly(MethodExpectationTestData testData)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var (method, parameters) = typeof(StringBuilderExtensions).GetExtensionMethodAndParameters(stringBuilder, testData.Method, testData.Parameters);

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().ShouldBe($"{testData.Expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        // Define the valid notations and expected results for different overloads

        // Note
        yield return new object[] { new MethodExpectationTestData("Note", "note left : Simple note.", NotePosition.Left, "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("Note", "note left : Line1\\nLine2", NotePosition.Left, "Line1\nLine2") };
        yield return new object[] { new MethodExpectationTestData("Note", "hnote left : Simple note.", NotePosition.Left, "Simple note.", NoteStyle.Hexagonal) };
        yield return new object[] { new MethodExpectationTestData("Note", "rnote left : Simple note.", NotePosition.Left, "Simple note.", NoteStyle.Box) };
        yield return new object[] { new MethodExpectationTestData("Note", "note left of actorA : Simple note.", NotePosition.Left, "actorA", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("Note", "note left of actorA : Line1\\nLine2", NotePosition.Left, "actorA", "Line1\nLine2") };
        yield return new object[] { new MethodExpectationTestData("Note", "note left of actorA #AliceBlue : Simple note.", NotePosition.Left, "actorA", "Simple note.", default(NoteStyle), (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("Note", "note over actorA : Simple note.", "actorA", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("Note", "note over actorA,actorB : Simple note.", "actorA", "actorB", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("Note", "/ note over actorA : Simple note.", "actorA", "Simple note.", default(NoteStyle), (Color)string.Empty, true) };

        // HNote
        yield return new object[] { new MethodExpectationTestData("HNote", "hnote left : Simple note.", NotePosition.Left, "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("HNote", "hnote left : Line1\\nLine2", NotePosition.Left, "Line1\nLine2") };
        yield return new object[] { new MethodExpectationTestData("HNote", "hnote left of actorA : Simple note.", NotePosition.Left, "actorA", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("HNote", "hnote left of actorA : Line1\\nLine2", NotePosition.Left, "actorA", "Line1\nLine2") };
        yield return new object[] { new MethodExpectationTestData("HNote", "hnote left of actorA #AliceBlue : Simple note.", NotePosition.Left, "actorA", "Simple note.", (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("HNote", "hnote over actorA : Simple note.", "actorA", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("HNote", "hnote over actorA,actorB : Simple note.", "actorA", "actorB", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("HNote", "/ hnote over actorA : Simple note.", "actorA", "Simple note.", (Color)string.Empty, true) };

        // RNote
        yield return new object[] { new MethodExpectationTestData("RNote", "rnote left : Simple note.", NotePosition.Left, "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("RNote", "rnote left : Line1\\nLine2", NotePosition.Left, "Line1\nLine2") };
        yield return new object[] { new MethodExpectationTestData("RNote", "rnote left of actorA : Simple note.", NotePosition.Left, "actorA", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("RNote", "rnote left of actorA : Line1\\nLine2", NotePosition.Left, "actorA", "Line1\nLine2") };
        yield return new object[] { new MethodExpectationTestData("RNote", "rnote left of actorA #AliceBlue : Simple note.", NotePosition.Left, "actorA", "Simple note.", (Color)NamedColor.AliceBlue) };
        yield return new object[] { new MethodExpectationTestData("RNote", "rnote over actorA : Simple note.", "actorA", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("RNote", "rnote over actorA,actorB : Simple note.", "actorA", "actorB", "Simple note.") };
        yield return new object[] { new MethodExpectationTestData("RNote", "/ rnote over actorA : Simple note.", "actorA", "Simple note.", (Color)string.Empty, true) };

        // StartNote
        yield return new object[] { new MethodExpectationTestData("StartNote", "note left", NotePosition.Left) };
        yield return new object[] { new MethodExpectationTestData("StartNote", "hnote left", NotePosition.Left, string.Empty, NoteStyle.Hexagonal) };
        yield return new object[] { new MethodExpectationTestData("StartNote", "rnote left", NotePosition.Left, string.Empty, NoteStyle.Box) };
        yield return new object[] { new MethodExpectationTestData("StartNote", "note left of actorA", NotePosition.Left, "actorA") };
        yield return new object[] { new MethodExpectationTestData("StartNote", "note over actorA", "actorA") };
        yield return new object[] { new MethodExpectationTestData("StartNote", "note over actorA,actorB", "actorA", "actorB") };

        // StartHNote
        yield return new object[] { new MethodExpectationTestData("StartHNote", "hnote left", NotePosition.Left) };
        yield return new object[] { new MethodExpectationTestData("StartHNote", "hnote left of actorA", NotePosition.Left, "actorA") };
        yield return new object[] { new MethodExpectationTestData("StartHNote", "hnote over actorA", "actorA") };
        yield return new object[] { new MethodExpectationTestData("StartHNote", "hnote over actorA,actorB", "actorA", "actorB") };

        // StartRNote
        yield return new object[] { new MethodExpectationTestData("StartRNote", "rnote left", NotePosition.Left) };
        yield return new object[] { new MethodExpectationTestData("StartRNote", "rnote left of actorA", NotePosition.Left, "actorA") };
        yield return new object[] { new MethodExpectationTestData("StartRNote", "rnote over actorA", "actorA") };
        yield return new object[] { new MethodExpectationTestData("StartRNote", "rnote over actorA,actorB", "actorA", "actorB") };

        // EndNotes
        yield return new object[] { new MethodExpectationTestData("EndNote", "end note") };
        yield return new object[] { new MethodExpectationTestData("EndHNote", "end hnote") };
        yield return new object[] { new MethodExpectationTestData("EndRNote", "end rnote") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
