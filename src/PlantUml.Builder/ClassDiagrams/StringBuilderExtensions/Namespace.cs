namespace PlantUml.Builder.ClassDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the beginning of a namespace.
    /// </summary>
    /// <param name="name">The name of the namespace. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="stereotype">Optional stereo type.</param>
    /// <param name="backgroundColor">Optional background color.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void NamespaceStart(this StringBuilder stringBuilder, string name, string displayName = null, string stereotype = null, Color backgroundColor = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(name);

        stringBuilder.Append(Constant.Namespace);

        if (displayName is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Quote);
            stringBuilder.Append(displayName);
            stringBuilder.Append(Constant.Quote);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.As);
        }

        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(name);

        if (stereotype is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.StereoType(stereotype);
        }

        if (backgroundColor is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(backgroundColor);
        }

        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(Constant.NamespaceStart);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the end of a namespace.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void NamespaceEnd(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.NamespaceEnd);
        stringBuilder.AppendNewLine();
    }
}
