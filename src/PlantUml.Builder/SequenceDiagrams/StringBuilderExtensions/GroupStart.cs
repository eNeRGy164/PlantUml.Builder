namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the beginning of a group.
    /// </summary>
    /// <param name="type">The type of group.</param>
    /// <param name="text">Optional text.</param>
    /// <param name="label">Optional label.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void GroupStart(this StringBuilder stringBuilder, string type = Constant.Words.Group, string text = null, string label = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(type);

        if (!string.IsNullOrWhiteSpace(label))
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(label);
        }

        if (!string.IsNullOrWhiteSpace(text))
        {
            stringBuilder.Append(Constant.Symbols.Space);
            
            if (type == Constant.Words.Group) stringBuilder.Append(Constant.GroupLabelStart);

            stringBuilder.Append(text);

            if (type == Constant.Words.Group) stringBuilder.Append(Constant.GroupLabelEnd);
        }

        stringBuilder.AppendNewLine();
    }
}
