namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a page footer.
    /// </summary>
    /// <param name="footer">The footer text.</param>
    /// <param name="alignment">Optional footer alignment. See <see cref="Alignment"/> for possible values.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="footer"/> is <see langword="null"/>, empty or only white space.</exception>
    public static void Footer(this StringBuilder stringBuilder, string footer, Alignment alignment = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(footer);

        if (alignment is not null && alignment.ToString() != string.Empty)
        {
            stringBuilder.Append(alignment);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(Constant.Words.Footer);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(footer.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the start of a footer block.
    /// </summary>
    /// <param name="alignment">Optional footer alignment. See <see cref="Alignment"/> for possible values.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void FooterStart(this StringBuilder stringBuilder, Alignment alignment = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (alignment is not null && alignment.ToString() != string.Empty)
        {
            stringBuilder.Append(alignment);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(Constant.Words.Footer);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the end of a footer block.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void EndFooter(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.End);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Footer);
        stringBuilder.AppendNewLine();
    }
}
