namespace PlantUml.Builder.ClassDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a class.
    /// </summary>
    /// <param name="name">The name of the class. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="isAbstract">Indicates wheter the class is abstract. Default is <see langword="false"/>.</param>
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
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Class(this StringBuilder stringBuilder, string name, string displayName = default, bool isAbstract = false, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder, nameof(stringBuilder));

        if (isAbstract)
        {
            stringBuilder.Append(Constant.Abstract);
            stringBuilder.Append(Constant.Space);
        }

        stringBuilder.ClassBase(ClassType.Class, name, displayName, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the beginning of a class.
    /// </summary>
    /// <param name="name">The name of the class. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="visibility">Optional visibility. See <see cref="VisibilityModifier"/> for possible values.</param>
    /// <param name="isAbstract">Indicates wheter the class is abstract. Default <see langword="false"/>.</param>
    /// <param name="generics">Optional class extension.</param>
    /// <param name="stereotype">Optional stereo type.</param>
    /// <param name="customSpot">Optional custom spot.</param>
    /// <param name="tag">Optional tag.</param>
    /// <param name="url">Optional URL.</param>
    /// <param name="backgroundColor">Optional background color.</param>
    /// <param name="lineColor">Optional line color.</param>
    /// <param name="lineStyle">Optional line style. See <see cref="LineStyle"/> for possible values.</param>
    /// <param name="extends">Optional extends.</param>
    /// <param name="implements">Optional implements.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void ClassStart(this StringBuilder stringBuilder, string name, string displayName = default, VisibilityModifier visibility = VisibilityModifier.None, bool isAbstract = false, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default)
    {
        stringBuilder.VisibilityChar(visibility);
        stringBuilder.Class(name, displayName, isAbstract, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
        stringBuilder.TrimEnd();
        stringBuilder.ClassBaseStart();
    }

    /// <summary>
    /// Renders the end of a class.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void ClassEnd(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.ClassBaseEnd();
    }
}
