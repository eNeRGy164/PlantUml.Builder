namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the end of an UML diagram.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void UmlDiagramEnd(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Symbols.At);
        stringBuilder.Append(Constant.Words.End);
        stringBuilder.Append(Constant.Words.Uml);
        stringBuilder.AppendNewLine();
    }
}
