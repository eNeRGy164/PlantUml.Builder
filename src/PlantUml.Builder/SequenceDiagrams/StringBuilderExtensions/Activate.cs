namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Activates a life line.
    /// </summary>
    /// <param name="name">The name of the life line to activate.</param>
    /// <param name="color">Optional color of the activation line.</param>
    /// <param name="borderColor">Optional border color of the activation line. Can only be set if <paramref name="color"/> is set.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Activate(this StringBuilder stringBuilder, string name, Color color = null, Color borderColor = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(name);

        stringBuilder.Append(Constant.Words.Activate);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(name);

        if (color is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(color);

            if (borderColor is not null)
            {
                stringBuilder.Append(Constant.Symbols.Space);
                stringBuilder.Append(borderColor);
            }
        }

        stringBuilder.AppendNewLine();
    }
}
