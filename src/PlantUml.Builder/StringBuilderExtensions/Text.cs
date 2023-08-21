namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a line of text.
    /// </summary>
    /// <param name="text">Line of text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="text"/> is <c>null</c>, empty of only white space.</exception>
    public static void Text(this StringBuilder stringBuilder, string text)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("A non-empty value should be provided", nameof(text));

        stringBuilder.Append(text.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }
}
