namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Define another namespace separator.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void SetNamespaceSeparator(this StringBuilder stringBuilder, string separator = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Set);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(Constant.Namespace);
        stringBuilder.Append(char.ToUpper(Constant.Separator[0]));
        stringBuilder.Append(Constant.Separator[1..]);
        stringBuilder.Append(Constant.Space);

        if (!string.IsNullOrWhiteSpace(separator))
        {
            stringBuilder.Append(separator);
        } else
        {
            stringBuilder.Append(Constant.None);
        }

        stringBuilder.AppendNewLine();
    }
}
