namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Removes all the trailing white-space characters from the current <see cref="StringBuilder"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void TrimEnd(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (stringBuilder.Length == 0)
        {
            return;
        }

        while (stringBuilder.Length > 0 && char.IsWhiteSpace(stringBuilder[stringBuilder.Length - 1]))
        {
            stringBuilder.Length--;
        }
    }
}
