using System;
using System.Text;

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
    /// <param name="lineStyle">Optional line style.</param>
    /// <param name="extends">Optional extends.</param>
    /// <param name="implements">Optional implementations.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
    internal static void ClassBase(this StringBuilder stringBuilder, ClassType type, string name, string displayName, string generics, string stereotype, CustomSpot customSpot, string tag, Uri url, Color backgroundColor, Color lineColor, LineStyle lineStyle, string[] extends, string[] implements)
    {

        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));

        stringBuilder.Append(type.ToString().ToLowerInvariant());
        stringBuilder.Append(Constant.Space);

        if (!(displayName is null))
        {
            stringBuilder.Append(Constant.Quote);
            stringBuilder.Append(displayName);
            stringBuilder.Append(Constant.Quote);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.As);
            stringBuilder.Append(Constant.Space);
        }

        stringBuilder.Append(name);

        if (!(generics is null))
        {
            stringBuilder.Append(Constant.GenericsStart);
            stringBuilder.Append(generics);
            stringBuilder.Append(Constant.GenericsEnd);
        }

        if (!(stereotype is null))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.StereoType(stereotype, customSpot);
        }

        if (!(tag is null))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.TagPrefix);
            stringBuilder.Append(tag);
        }

        if (!(url is null))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.UrlStart);
            stringBuilder.Append(url);
            stringBuilder.Append(Constant.UrlEnd);
        }

        if (!(backgroundColor is null))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(backgroundColor);
        }

        if (!(lineColor is null) || lineStyle != LineStyle.None)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.ColorPrefix);
            stringBuilder.Append(Constant.ColorPrefix);

            if (lineStyle > LineStyle.None)
            {
                stringBuilder.Append(Constant.BorderStyleStart);
                stringBuilder.Append(lineStyle.ToString().ToLowerInvariant());
                stringBuilder.Append(Constant.BorderStyleEnd);
            }

            if (!(lineColor is null))
            {
                stringBuilder.Append(lineColor.ToString().TrimStart(Constant.ColorPrefix));
            }
        }

        if (!(extends is null) && extends.Length > 0)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Extends);
            stringBuilder.Append(Constant.Space);
            stringBuilder.AppendJoin(',', extends);
        }

        if (!(implements is null) && implements.Length > 0)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Implements);
            stringBuilder.Append(Constant.Space);
            stringBuilder.AppendJoin(',', implements);
        }
    }


    /// <summary>
    /// Base for rendering the end of a class.
    /// </summary>
    internal static void ClassBaseStart(this StringBuilder stringBuilder)
    {
        stringBuilder.Append(Constant.Space);
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
