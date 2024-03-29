namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a line of text.
    /// </summary>
    /// <param name="text">Line of text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Text(this StringBuilder stringBuilder, string text)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(text);

        stringBuilder.Append(text.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }
}
