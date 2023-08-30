using static PlantUml.Builder.Constant;

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
        stringBuilder.Append(Space);

        if (displayName is not null)
        {
            stringBuilder.Append(Quote);
            stringBuilder.Append(displayName);
            stringBuilder.Append(Quote);
            stringBuilder.Append(Space);
            stringBuilder.Append(As);
            stringBuilder.Append(Space);
        }

        stringBuilder.Append(name);

        if (generics is not null)
        {
            stringBuilder.Append(GenericsStart);
            stringBuilder.Append(generics);
            stringBuilder.Append(GenericsEnd);
        }

        if (stereotype is not null)
        {
            stringBuilder.Append(Space);
            stringBuilder.StereoType(stereotype, customSpot);
        }

        if (tag is not null)
        {
            stringBuilder.Append(Space);
            stringBuilder.Append(TagPrefix);
            stringBuilder.Append(tag);
        }

        if (url is not null)
        {
            stringBuilder.Append(Space);
            stringBuilder.Append(UrlStart);
            stringBuilder.Append(url);
            stringBuilder.Append(UrlEnd);
        }

        if (backgroundColor is not null)
        {
            stringBuilder.Append(Space);
            stringBuilder.Append(backgroundColor);
        }

        if (lineColor is not null || lineStyle != LineStyle.None)
        {
            stringBuilder.Append(Space);
            stringBuilder.Append(ColorPrefix);
            stringBuilder.Append(ColorPrefix);

            if (lineStyle > LineStyle.None)
            {
                stringBuilder.Append(BorderStyleStart);
                stringBuilder.Append(lineStyle.ToString().ToLowerInvariant());
                stringBuilder.Append(BorderStyleEnd);
            }

            if (lineColor is not null)
            {
                stringBuilder.Append(lineColor.ToString().TrimStart(ColorPrefix));
            }
        }

        if (extends is not null && extends.Length > 0)
        {
            stringBuilder.Append(Space);
            stringBuilder.Append(Extends);
            stringBuilder.Append(Space);
            stringBuilder.AppendJoin(',', extends);
        }

        if (implements is not null && implements.Length > 0)
        {
            stringBuilder.Append(Space);
            stringBuilder.Append(Implements);
            stringBuilder.Append(Space);
            stringBuilder.AppendJoin(',', implements);
        }
    }

    /// <summary>
    /// Base for rendering the start of a class.
    /// </summary>
    internal static void ClassBaseStart(this StringBuilder stringBuilder)
    {
        stringBuilder.Append(Space);
        stringBuilder.Append(Constant.ClassStart);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Base for rendering the end of a class.
    /// </summary>
    internal static void ClassBaseEnd(this StringBuilder stringBuilder)
    {
        stringBuilder.Append(Constant.ClassEnd);
        stringBuilder.AppendNewLine();
    }
}
