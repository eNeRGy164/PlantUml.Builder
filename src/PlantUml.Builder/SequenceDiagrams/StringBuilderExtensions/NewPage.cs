namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Creates a new page.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void NewPage(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        
        stringBuilder.Append(Constant.New);
        stringBuilder.Append(Constant.Page);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Creates a new page.
    /// </summary>
    /// <param name="title">Title of the new page.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="title"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void NewPage(this StringBuilder stringBuilder, string title)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("A non-empty value should be provided", nameof(title));

        stringBuilder.Append(Constant.New);
        stringBuilder.Append(Constant.Page);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(title.Replace("\n", "\\n"));
        stringBuilder.AppendNewLine();
    }
}
