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

        if (string.IsNullOrWhiteSpace(header)) throw new ArgumentException("A non-empty value should be provided", nameof(header));

        stringBuilder.Append(Constant.Header);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(header);
        stringBuilder.AppendNewLine();
    }
}
