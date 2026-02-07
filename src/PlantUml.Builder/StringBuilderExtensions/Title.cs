namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a page title.
    /// </summary>
    /// <param name="title">The page title.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="title"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Title(this StringBuilder stringBuilder, string title)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(title);

        stringBuilder.Append(Constant.Words.Title);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(title.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the start of a title block.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void TitleStart(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Title);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the end of a title block.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void EndTitle(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.End);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Title);
        stringBuilder.AppendNewLine();
    }
}
