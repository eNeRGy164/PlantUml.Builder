namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a box for participants.
    /// </summary>
    /// <param name="title">Optional title of the box.</param>
    /// <param name="color">Optional background color of the box.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void BoxStart(this StringBuilder stringBuilder, string title = null, Color color = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Box);

        if (!string.IsNullOrEmpty(title))
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.Symbols.Quote);
            stringBuilder.Append(title.Trim());
            stringBuilder.Append(Constant.Symbols.Quote);
        }

        if (color is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(color);
        }

        stringBuilder.AppendNewLine();
    }
}
