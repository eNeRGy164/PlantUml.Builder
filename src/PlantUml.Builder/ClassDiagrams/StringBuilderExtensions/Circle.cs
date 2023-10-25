namespace PlantUml.Builder.ClassDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a circle.
    /// </summary>
    /// <param name="name">The name of the circle. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="generics">Optional class extension. <b>This will not be rendered.</b></param>
    /// <param name="stereotype">Optional stereo type.</param>
    /// <param name="customSpot">Optional custom spot. <b>This will not be rendered.</b></param>
    /// <param name="tag">Optional tag.</param>
    /// <param name="url">Optional URL.</param>
    /// <param name="backgroundColor">Optional background color.</param>
    /// <param name="lineColor">Optional line color.</param>
    /// <param name="lineStyle">Optional line style. See <see cref="LineStyle"/> for possible values.</param>
    /// <param name="extends">Optional extends.</param>
    /// <param name="implements">Optional implementations.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    /// <seealso href="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/classdiagram/command/CommandCreateClass.java"/>
    public static void Circle(this StringBuilder stringBuilder, string name, string displayName = default, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.ClassBase(ClassType.Circle, name, displayName, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
        stringBuilder.AppendNewLine();
    }
}
