namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a page caption.
    /// </summary>
    /// <param name="caption">The caption text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="caption"/> is <see langword="null"/>, empty or only white space.</exception>
    public static void Caption(this StringBuilder stringBuilder, string caption)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(caption);

        stringBuilder.Append(Constant.Words.Caption);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(caption.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }
}
