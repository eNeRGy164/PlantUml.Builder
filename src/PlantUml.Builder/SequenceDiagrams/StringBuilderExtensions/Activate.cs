namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Activates a life line.
    /// </summary>
    /// <param name="name">The name of the life line to activate.</param>
    /// <param name="color">Optional color of the activation line.</param>
    /// <param name="borderColor">Optional border color of the activation line. Can only be set if <paramref name="color"/> is set.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
    public static void Activate(this StringBuilder stringBuilder, string name, Color color = null, Color borderColor = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));

        stringBuilder.Append(Constant.Activate);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(name);

        if (color is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(color);

            if (borderColor is not null)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(borderColor);
            }
        }

        stringBuilder.AppendNewLine();
    }
}
