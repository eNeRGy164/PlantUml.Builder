using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class RefTests
{
    [DataRow("participant", null, AnyString, DisplayName = "Ref - participant argument cannot be `null`")]
    [DataRow("note", AnyString, null, DisplayName = "Ref - note argument cannot be `null`")]
    [TestMethod]
    public void RefWithParticipantArgumentsCannotBeNull(string parameterName, string participant, string note)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Ref(participant, note);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName(parameterName);
    }

    [TestMethod]
    public void StartRefWithParticipantCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.StartRef(null);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("participant");
    }

    [DataRow("participantA", null, AnyString, AnyString, DisplayName = "Ref - participantA argument cannot be `null`")]
    [DataRow("participantB", AnyString, null, AnyString, DisplayName = "Ref - participantB argument cannot be `null`")]
    [DataRow("note", AnyString, AnyString, null, DisplayName = "Ref - note argument cannot be `null`")]
    [TestMethod]
    public void RefWithParticipantsArgumentsCannotBeNull(string parameterName, string participantA, string participantB, string note)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Ref(participantA, participantB, note);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName(parameterName);
    }

    [DataRow("participantA", null, AnyString, DisplayName = "StartRef - participantA argument cannot be `null`")]
    [DataRow("participantB", AnyString, null, DisplayName = "StartRef - participantB argument cannot be `null`")]
    [TestMethod]
    public void StartRefWithParticipantsCannotBeNull(string parameterName, string participantA, string participantB)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.StartRef(participantA, participantB);

        // Assert
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName(parameterName);
    }

    [DataRow("participant", EmptyString, AnyString, DisplayName = "Ref - Participant argument cannot be empty")]
    [DataRow("participant", AllWhitespace, AnyString, DisplayName = "Ref - Participant argument cannot be any whitespace character")]
    [DataRow("note", AnyString, EmptyString, DisplayName = "Ref - Note argument cannot be empty")]
    [DataRow("note", AnyString, AllWhitespace, DisplayName = "Ref - Note argument cannot be any whitespace character")]
    [TestMethod]
    public void RefWithParticipantArgumentsMustContainAValue(string parameterName, string participant, string note)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Ref(participant, note);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName(parameterName);
    }

    [DataRow(EmptyString, DisplayName = "StartRef - Participant argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "StartRef - Participant argument cannot be any whitespace character")]
    [TestMethod]
    public void StartRefParticipantMustContainAValue(string participant)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.StartRef(participant);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName("participant");
    }

    [DataRow("participantA", EmptyString, AnyString, AnyString, DisplayName = "Ref - ParticipantA argument cannot be empty")]
    [DataRow("participantA", AllWhitespace, AnyString, AnyString, DisplayName = "Ref - ParticipantA argument cannot be any whitespace character")]
    [DataRow("participantB", AnyString, EmptyString, AnyString, DisplayName = "Ref - ParticipantB argument cannot be empty")]
    [DataRow("participantB", AnyString, AllWhitespace, AnyString, DisplayName = "Ref - ParticipantB argument cannot be any whitespace character")]
    [DataRow("note", AnyString, AnyString, EmptyString, DisplayName = "Ref - Note argument cannot be empty")]
    [DataRow("note", AnyString, AnyString, AllWhitespace, DisplayName = "Ref - Note argument cannot be any whitespace character")]
    [TestMethod]
    public void RefWithParticipantsArgumentsMustContainAValue(string parameterName, string participantA, string participantB, string note)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Ref(participantA, participantB, note);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName(parameterName);
    }

    [DataRow("participantA", EmptyString, AnyString, DisplayName = "StartRef - ParticipantA argument cannot be empty")]
    [DataRow("participantA", AllWhitespace, AnyString, DisplayName = "StartRef - ParticipantA argument cannot be any whitespace character")]
    [DataRow("participantB", AnyString, EmptyString, DisplayName = "StartRef - ParticipantB argument cannot be empty")]
    [DataRow("participantB", AnyString, AllWhitespace, DisplayName = "StartRef - ParticipantB argument cannot be any whitespace character")]
    [TestMethod]
    public void StartRefWithParticipantsMustContainAValue(string parameterName, string participantA, string participantB)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.StartRef(participantA, participantB);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithParameterName(parameterName);
    }

    [DataRow("actorA", "note", "ref over actorA : note", DisplayName = "Ref - Single line note should generate correct ref line")]
    [DataRow("actorA", "Line1\nLine2", "ref over actorA : Line1\\nLine2", DisplayName = "Ref - Multi-line note should escape newlines")]
    [TestMethod]
    public void RefWithParticipantIsRenderedCorrectly(string actor, string note, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Ref(actor, note);

        // Assert
        stringBuilder.ToString().ShouldBe($"{expected}\n");
    }

    [TestMethod]
    public void StartRefWithParticipantIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.StartRef("actorA");

        // Assert
        stringBuilder.ToString().ShouldBe("ref over actorA\n");
    }

    [TestMethod]
    public void RefWithParticipantsIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Ref("actorA", "actorB", "note");

        // Assert
        stringBuilder.ToString().ShouldBe("ref over actorA,actorB : note\n");
    }

    [TestMethod]
    public void StartRefWithParticipantsIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.StartRef("actorA", "actorB");

        // Assert
        stringBuilder.ToString().ShouldBe("ref over actorA,actorB\n");
    }

    [TestMethod]
    public void EndRefIsRenderedCorrectly()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.EndRef();

        // Assert
        stringBuilder.ToString().ShouldBe("end ref\n");
    }
}
