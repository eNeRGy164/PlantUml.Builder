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

        stringBuilder.Append(Constant.Auto);
        stringBuilder.Append(Constant.Activate);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(mode.ToString().ToLowerInvariant());
        stringBuilder.AppendNewLine();
    }
}
