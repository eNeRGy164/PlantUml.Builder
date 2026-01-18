namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a mainframe title for the diagram.
    /// </summary>
    /// <param name="title">The mainframe title.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="title"/> is <see langword="null"/>, empty or only white space.</exception>
    public static void Mainframe(this StringBuilder stringBuilder, string title)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(title);

        stringBuilder.Append(Constant.Words.Mainframe);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(title);
        stringBuilder.AppendNewLine();
    }
}
