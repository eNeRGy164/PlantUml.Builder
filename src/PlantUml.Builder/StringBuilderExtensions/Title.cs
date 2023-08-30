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
        stringBuilder.Append(title);
        stringBuilder.AppendNewLine();
    }
}
