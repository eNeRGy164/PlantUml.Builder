namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a relationship.
    /// </summary>
    /// <param name="left">The left side of the relationship.</param>
    /// <param name="type">The type of relationship.</param>
    /// <param name="right">The right side of the relationship.</param>
    /// <param name="label">Optional label for the relationship.</param>
    /// <param name="leftCardinality">Optional cardinality on the left side of the relationship.</param>
    /// <param name="rightCardinality">Optional cardinality on the right side of the relationship.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="left"/>, <paramref name="type"/> or <paramref name="right"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Relationship(this StringBuilder stringBuilder, string left, string type, string right, string label = default, string leftCardinality = default, string rightCardinality = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(left);
        ArgumentException.ThrowIfNullOrWhitespace(type);
        ArgumentException.ThrowIfNullOrWhitespace(right);

        stringBuilder.Append(left);
        stringBuilder.Append(Constant.Symbols.Space);

        if (!string.IsNullOrEmpty(leftCardinality))
        {
            stringBuilder.Append(Constant.Symbols.Quote);
            stringBuilder.Append(leftCardinality);
            stringBuilder.Append(Constant.Symbols.Quote);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(type);
        stringBuilder.Append(Constant.Symbols.Space);

        if (!string.IsNullOrEmpty(rightCardinality))
        {
            stringBuilder.Append(Constant.Symbols.Quote);
            stringBuilder.Append(rightCardinality);
            stringBuilder.Append(Constant.Symbols.Quote);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(right);

        if (!string.IsNullOrEmpty(label))
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.Symbols.Colon);
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(label);
        }

        stringBuilder.AppendNewLine();
    }
}
