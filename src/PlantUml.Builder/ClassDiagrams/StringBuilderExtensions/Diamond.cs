namespace PlantUml.Builder.ClassDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a diamond.
    /// </summary>
    /// <param name="name">The name of the diamond. The name can't contain spaces. <b>This will not be rendered.</b></param>
    /// <param name="displayName">Optional display name. The display name can contain spaces. <b>This will not be rendered.</b></param>
    /// <param name="generics">Optional class extension. <b>This will not be rendered.</b></param>
    /// <param name="stereotype">Optional stereo type <b>This will not be rendered.</b>.</param>
    /// <param name="customSpot">Optional custom spot. <b>This will not be rendered.</b></param>
    /// <param name="tag">Optional tag.</param>
    /// <param name="url">Optional URL. <b>This will not be rendered.</b></param>
    /// <param name="backgroundColor">Optional background color. <b>This will not be rendered.</b></param>
    /// <param name="lineColor">Optional line color. <b>This will not be rendered.</b></param>
    /// <param name="lineStyle">Optional line style. See <see cref="LineStyle"/> for possible values. <b>This will not be rendered.</b></param>
    /// <param name="extends">Optional extends.</param>
    /// <param name="implements">Optional implementations.</param>
    /// <param name="shortForm">Indicates whether to use the short form. Default is <see langword="false"/>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    /// <seealso href="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/classdiagram/command/CommandCreateClass.java"/>
    public static void Diamond(this StringBuilder stringBuilder, string name, string displayName = default, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default, bool shortForm = false)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.ClassBase(!shortForm ? ClassType.Diamond : ClassType.ShortDiamond, name, displayName, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
        stringBuilder.AppendNewLine();
    }
}
