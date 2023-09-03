namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Base for rendering a note.
    /// </summary>
    /// <param name="position">The position of the note.</param>
    /// <param name="participant">Optional participant. The position is relative to this participant.</param>
    /// <param name="style">Optional style of note. Default <see cref="NoteStyle.Normal"/>.</param>
    /// <param name="color">Optional backgrond color.</param>
    /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <see langword="false"/>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    internal static void NoteBase(this StringBuilder stringBuilder, NotePosition position, string participant = null, NoteStyle style = NoteStyle.Normal, Color color = null, bool alignWithPrevious = false)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (alignWithPrevious)
        {
            stringBuilder.Append(Constant.AlignNote);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        switch (style)
        {
            case NoteStyle.Hexagonal:
                stringBuilder.Append(Constant.NoteHexagon);
                break;

            case NoteStyle.Box:
                stringBuilder.Append(Constant.NoteBox);
                break;
        }

        stringBuilder.Append(Constant.Words.Note);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(position.ToString().ToLowerInvariant());

        if (!string.IsNullOrWhiteSpace(participant))
        {
            if (position != NotePosition.Over)
            {
                stringBuilder.Append(Constant.Symbols.Space);
                stringBuilder.Append(Constant.Words.Of);
            }

            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(participant);
        }

        if (color is not null && color.ToString() != string.Empty)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(color);
        }
    }

    /// <summary>
    /// Base for rendering the end of a class.
    /// </summary>
    internal static void NoteBaseEnd(this StringBuilder stringBuilder, NoteStyle style = NoteStyle.Normal)
    {
        stringBuilder.Append(Constant.Words.End);
        stringBuilder.Append(Constant.Symbols.Space);

        switch (style)
        {
            case NoteStyle.Hexagonal:
                stringBuilder.Append(Constant.NoteHexagon);
                break;
            case NoteStyle.Box:
                stringBuilder.Append(Constant.NoteBox);
                break;
        }
        
        stringBuilder.Append(Constant.Words.Note);
        stringBuilder.AppendNewLine();
    }
}
