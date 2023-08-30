namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Creates a new page.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void NewPage(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        
        stringBuilder.Append(Constant.Words.New);
        stringBuilder.Append(Constant.Words.Page);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Creates a new page.
    /// </summary>
    /// <param name="title">Title of the new page.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="title"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void NewPage(this StringBuilder stringBuilder, string title)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(title);

        stringBuilder.Append(Constant.Words.New);
        stringBuilder.Append(Constant.Words.Page);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(title.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }
}
