namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a page header.
    /// </summary>
    /// <param name="header">The header text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="header"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Header(this StringBuilder stringBuilder, string header)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(header);

        stringBuilder.Append(Constant.Words.Header);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(header);
        stringBuilder.AppendNewLine();
    }
}
