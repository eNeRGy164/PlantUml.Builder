using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.ObjectDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a class.
    /// </summary>
    /// <param name="name">The name of the class. The name can't contain spaces.</param>
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
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
    public static void Diamond(this StringBuilder stringBuilder, string name, string displayName = default, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.ClassBase(ClassType.Diamond, name, displayName, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
        stringBuilder.AppendNewLine();
    }
}
