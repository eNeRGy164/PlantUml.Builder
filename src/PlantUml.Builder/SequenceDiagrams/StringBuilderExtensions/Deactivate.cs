namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Deactivates the life line for an actor.
    /// </summary>
    /// <param name="name">The name of the life line to deactivate.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Deactivate(this StringBuilder stringBuilder, string name)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(name);

        stringBuilder.Append(Constant.Words.Deactivate);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(name);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Deactivates the last active lifeline.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void Deactivate(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Deactivate);
        stringBuilder.AppendNewLine();
    }
}
