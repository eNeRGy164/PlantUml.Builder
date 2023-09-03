namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Switch autoactivate on or off.
    /// </summary>
    /// <param name="mode">Set autoactivation <c>On</c> or <c>Off</c>. Default is <c>On</c>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void AutoActivate(this StringBuilder stringBuilder, OnOff mode = OnOff.On)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        if (!Enum.IsDefined(mode)) throw new ArgumentOutOfRangeException(nameof(mode), "A defined enum value should be provided");

        stringBuilder.Append(Constant.Words.Auto);
        stringBuilder.Append(Constant.Words.Activate);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(mode.ToString().ToLowerInvariant());
        stringBuilder.AppendNewLine();
    }
}
