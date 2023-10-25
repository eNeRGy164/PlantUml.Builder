namespace PlantUml.Builder.ClassDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Removes the specified elenent from the PlantUML diagram.
    /// </summary>
    /// <param name="what">The name of the element to hide.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="what"/> is <see langword="null"/> or whitespace.</exception>
    /// <seealso href="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/classdiagram/command/CommandRemoveRestore.java"/>
    public static void Remove(this StringBuilder stringBuilder, string what)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(what);

        stringBuilder.Append(Constant.Words.Remove);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(what);

        stringBuilder.AppendNewLine();
    }
}
