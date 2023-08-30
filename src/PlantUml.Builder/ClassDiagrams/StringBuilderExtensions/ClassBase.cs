namespace PlantUml.Builder.ClassDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Base for rendering a class.
    /// </summary>
    /// <param name="name">The name of the namespace. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="generics">Optional class extension.</param>
    /// <param name="stereotype">Optional stereo type.</param>
    /// <param name="customSpot">Optional custom spot.</param>
    /// <param name="tag">Optional tag.</param>
    /// <param name="url">Optional URL.</param>
    /// <param name="backgroundColor">Optional background color.</param>
    /// <param name="lineColor">Optional line color.</param>
    /// <param name="lineStyle">Optional line style. See <see cref="LineStyle"/> for possible values.</param>
    /// <param name="extends">Optional extends.</param>
    /// <param name="implements">Optional implementations.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    internal static void ClassBase(this StringBuilder stringBuilder, ClassType type, string name, string displayName, string generics, string stereotype, CustomSpot customSpot, string tag, Uri url, Color backgroundColor, Color lineColor, LineStyle lineStyle, string[] extends, string[] implements)
    {
        ArgumentException.ThrowIfNullOrWhitespace(name);

        stringBuilder.Append(type.ToString().ToLowerInvariant());
        stringBuilder.Append(Constant.Symbols.Space);

        if (displayName is not null)
        {
            stringBuilder.Append(Constant.Symbols.Quote);
            stringBuilder.Append(displayName);
            stringBuilder.Append(Constant.Symbols.Quote);
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.Words.As);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(name);

        if (generics is not null)
        {
            stringBuilder.Append(Constant.GenericsStart);
            stringBuilder.Append(generics);
            stringBuilder.Append(Constant.GenericsEnd);
        }

        if (stereotype is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.StereoType(stereotype, customSpot);
        }

        if (tag is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.TagPrefix);
            stringBuilder.Append(tag);
        }

        if (url is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.UrlStart);
            stringBuilder.Append(url);
            stringBuilder.Append(Constant.UrlEnd);
        }

        if (backgroundColor is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(backgroundColor);
        }

        if (lineColor is not null || lineStyle != LineStyle.None)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.Color.Prefix);
            stringBuilder.Append(Constant.Color.Prefix);

            if (lineStyle > LineStyle.None)
            {
                stringBuilder.Append(Constant.Styling.Border.Start);
                stringBuilder.Append(lineStyle.ToString().ToLowerInvariant());
                stringBuilder.Append(Constant.Styling.Border.End);
            }

            if (lineColor is not null)
            {
                stringBuilder.Append(lineColor.ToString().TrimStart(Constant.Color.Prefix));
            }
        }

        if (extends is not null && extends.Length > 0)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.Words.Extends);
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.AppendJoin(',', extends);
        }

        if (implements is not null && implements.Length > 0)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.Words.Implements);
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.AppendJoin(',', implements);
        }
    }

    /// <summary>
    /// Base for rendering the start of a class.
    /// </summary>
    internal static void ClassBaseStart(this StringBuilder stringBuilder)
    {
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Class.Start);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Base for rendering the end of a class.
    /// </summary>
    internal static void ClassBaseEnd(this StringBuilder stringBuilder)
    {
        stringBuilder.Append(Constant.Class.End);
        stringBuilder.AppendNewLine();
    }
}
