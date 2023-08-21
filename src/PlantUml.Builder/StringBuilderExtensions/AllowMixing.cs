namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Allows mixing of chart types.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void AllowMixing(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Allow);
        stringBuilder.Append(Constant.Underscore);
        stringBuilder.Append(Constant.Mixing);

        stringBuilder.AppendNewLine();
    }
}
