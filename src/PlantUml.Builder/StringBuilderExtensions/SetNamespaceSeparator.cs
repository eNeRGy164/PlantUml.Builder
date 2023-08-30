namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Define another namespace separator.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void SetNamespaceSeparator(this StringBuilder stringBuilder, string separator = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Set);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Namespace);
        stringBuilder.Append(char.ToUpper(Constant.Words.Separator[0]));
        stringBuilder.Append(Constant.Words.Separator[1..]);
        stringBuilder.Append(Constant.Symbols.Space);

        if (!string.IsNullOrWhiteSpace(separator))
        {
            stringBuilder.Append(separator);
        } else
        {
            stringBuilder.Append(Constant.Words.None);
        }

        stringBuilder.AppendNewLine();
    }
}
