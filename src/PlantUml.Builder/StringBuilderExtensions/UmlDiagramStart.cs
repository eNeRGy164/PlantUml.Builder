namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{

    /// <summary>
    /// Renders the start of an UML diagram.
    /// </summary>
    /// <param name="fileName">Optional file name.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void UmlDiagramStart(this StringBuilder stringBuilder, string fileName = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.At);
        stringBuilder.Append(Constant.Start);
        stringBuilder.Append(Constant.Uml);

        if (!string.IsNullOrEmpty(fileName))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(fileName);
        }

        stringBuilder.AppendNewLine();
    }
}
