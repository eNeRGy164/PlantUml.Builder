namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the hide foot box command.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void HideFootBox(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Hide);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Footbox);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the show foot box command.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void ShowFootBox(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Show);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Footbox);
        stringBuilder.AppendNewLine();
    }
}
