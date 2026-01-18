namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a pragma directive.
    /// </summary>
    /// <param name="name">The pragma name.</param>
    /// <param name="value">The pragma value.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> or <paramref name="value"/> is <see langword="null"/>, empty or only white space.</exception>
    public static void Pragma(this StringBuilder stringBuilder, string name, string value)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(name);
        ArgumentException.ThrowIfNullOrWhitespace(value);

        stringBuilder.Append(Constant.Symbols.Exclamation);
        stringBuilder.Append(Constant.Words.Pragma);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(name.Trim());
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(value.Trim());
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders a pragma directive.
    /// </summary>
    /// <param name="name">The pragma name.</param>
    /// <param name="value">The pragma value.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty or only white space.</exception>
    public static void Pragma(this StringBuilder stringBuilder, string name, bool value)
    {
        stringBuilder.Pragma(name, value.ToString().ToLowerInvariant());
    }
}
