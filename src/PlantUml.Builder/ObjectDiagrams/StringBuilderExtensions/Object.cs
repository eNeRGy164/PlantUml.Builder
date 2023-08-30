namespace PlantUml.Builder.ObjectDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders an object.
    /// </summary>
    /// <param name="name">The name of the object. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="stereotype">Optional stereo type.</param>
    /// <param name="url">Optional url.</param>
    /// <param name="backgroundColor">Optional background color.</param>
    public static void Object(this StringBuilder stringBuilder, string name, string displayName = default, string stereotype = default, Uri url = default, Color backgroundColor = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(name);

        stringBuilder.Append(Constant.Object);
        stringBuilder.Append(Constant.Space);

        if (displayName is not null)
        {
            stringBuilder.Append(Constant.Quote);
            stringBuilder.Append(displayName);
            stringBuilder.Append(Constant.Quote);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.As);
            stringBuilder.Append(Constant.Space);
        }

        stringBuilder.Append(name);

        if (stereotype is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.StereoType(stereotype);
        }

        if (url is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.UrlStart);
            stringBuilder.Append(url);
            stringBuilder.Append(Constant.UrlEnd);
        }

        if (backgroundColor is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(backgroundColor);
        }

        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the beginning of an object.
    /// </summary>
    /// <param name="name">The name of the namespace. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="stereotype">Optional stereo type.</param>
    /// <param name="backgroundColor">Optional background color.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void ObjectStart(this StringBuilder stringBuilder, string name, string displayName = default, string stereotype = default, Uri url = default, Color backgroundColor = default)
    {
        stringBuilder.Object(name, displayName, stereotype, url, backgroundColor);

        if (char.IsWhiteSpace(stringBuilder[^1]))
        {
            stringBuilder.Length--;
        }

        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(Constant.ObjectStart);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the end of an object.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void ObjectEnd(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.ObjectEnd);
        stringBuilder.AppendNewLine();
    }
}
