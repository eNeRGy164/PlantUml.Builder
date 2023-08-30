namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a page footer.
    /// </summary>
    /// <param name="footer">The footer text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="footer"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Footer(this StringBuilder stringBuilder, string footer)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(footer);

        stringBuilder.Append(Constant.Footer);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(footer);
        stringBuilder.AppendNewLine();
    }
}
