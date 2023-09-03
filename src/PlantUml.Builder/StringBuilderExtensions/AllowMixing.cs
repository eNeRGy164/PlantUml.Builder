namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Allows mixing of chart types.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void AllowMixing(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Allow);
        stringBuilder.Append(Constant.Symbols.Underscore);
        stringBuilder.Append(Constant.Words.Mixing);

        stringBuilder.AppendNewLine();
    }
}
