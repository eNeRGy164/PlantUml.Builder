namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a reference over a participant.
    /// </summary>
    /// <param name="participant">Optional participant. The position is relative to this participant.</param>
    /// <param name="note">The text of the note.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="participant"/> is <see langword="null"/>, empty of only white space.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="note"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Ref(this StringBuilder stringBuilder, string participant, string note)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(participant);
        ArgumentException.ThrowIfNullOrWhitespace(note);

        stringBuilder.Append(Constant.Words.Ref);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Over);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(participant);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Symbols.Colon);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(note.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders a reference over multiple participants.
    /// </summary>
    /// <param name="participantA">The first participant.</param>
    /// <param name="participantB">The second participant.</param>
    /// <param name="note">The text of the note.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="participantA"/> is <see langword="null"/>, empty of only white space.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="participantB"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Ref(this StringBuilder stringBuilder, string participantA, string participantB, string note)
    {
        ArgumentException.ThrowIfNullOrWhitespace(participantA);
        ArgumentException.ThrowIfNullOrWhitespace(participantB);

        stringBuilder.Ref(participantA + Constant.Symbols.Comma + participantB, note);
    }

    /// <summary>
    /// Renders the start of a multiline note.
    /// </summary>
    /// <param name="participant">Optional participant. The position is relative to this participant.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="participant"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void StartRef(this StringBuilder stringBuilder, string participant)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(participant);

        stringBuilder.Append(Constant.Words.Ref);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Over);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(participant);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the start of multiline over multiple participants.
    /// </summary>
    /// <param name="participantA">The first participant.</param>
    /// <param name="participantB">The second participant.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="participantA"/> is <see langword="null"/>, empty of only white space.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="participantB"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void StartRef(this StringBuilder stringBuilder, string participantA, string participantB)
    {
        ArgumentException.ThrowIfNullOrWhitespace(participantA);
        ArgumentException.ThrowIfNullOrWhitespace(participantB);

        stringBuilder.StartRef(participantA + Constant.Symbols.Comma + participantB);
    }

    /// <summary>
    /// Renders the end of a multiline note.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void EndRef(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.End);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Ref);
        stringBuilder.AppendNewLine();
    }
}
