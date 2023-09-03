namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Return to the previous participant.
    /// </summary>
    /// <param name="message">Optional message.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void Return(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Return);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Return to the previous participant.
    /// </summary>
    /// <param name="message">The return message.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="message"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Return(this StringBuilder stringBuilder, string message)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(message);

        stringBuilder.Append(Constant.Words.Return);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(message);
        stringBuilder.AppendNewLine();
    }
}
