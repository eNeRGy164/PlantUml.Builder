namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a page header.
    /// </summary>
    /// <param name="header">The header text.</param>
    /// <param name="alignment">Optional header alignment. See <see cref="Alignment"/> for possible values.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="header"/> is <see langword="null"/>, empty or only white space.</exception>
    public static void Header(this StringBuilder stringBuilder, string header, Alignment alignment = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(header);

        if (alignment is not null && alignment.ToString() != string.Empty)
        {
            stringBuilder.Append(alignment);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(Constant.Words.Header);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(header.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the start of a header block.
    /// </summary>
    /// <param name="alignment">Optional header alignment. See <see cref="Alignment"/> for possible values.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void HeaderStart(this StringBuilder stringBuilder, Alignment alignment = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (alignment is not null && alignment.ToString() != string.Empty)
        {
            stringBuilder.Append(alignment);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(Constant.Words.Header);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the end of a header block.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void EndHeader(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.End);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Header);
        stringBuilder.AppendNewLine();
    }
}
