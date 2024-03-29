namespace PlantUml.Builder.ClassDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders an enum.
    /// </summary>
    /// <param name="name">The name of the enum. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="generics">Optional enum extension.</param>
    /// <param name="stereotype">Optional stereo type.</param>
    /// <param name="customSpot">Optional custom spot.</param>
    /// <param name="tag">Optional tag.</param>
    /// <param name="url">Optional URL.</param>
    /// <param name="backgroundColor">Optional background color.</param>
    /// <param name="lineColor">Optional line color.</param>
    /// <param name="lineStyle">Optional line style.</param>
    /// <param name="extends">Optional extends.</param>
    /// <param name="implements">Optional implementations.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Enum(this StringBuilder stringBuilder, string name, string displayName = default, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder, nameof(stringBuilder));

        stringBuilder.ClassBase(ClassType.Enum, name, displayName, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the beginning of an enum.
    /// </summary>
    /// <param name="name">The name of the enum. The name can't contain spaces.</param>
    /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
    /// <param name="visibility">Optional visibility.</param>
    /// <param name="generics">Optional enum extension.</param>
    /// <param name="stereotype">Optional stereo type.</param>
    /// <param name="customSpot">Optional custom spot.</param>
    /// <param name="tag">Optional tag.</param>
    /// <param name="url">Optional URL.</param>
    /// <param name="backgroundColor">Optional background color.</param>
    /// <param name="lineColor">Optional line color.</param>
    /// <param name="lineStyle">Optional line style.</param>
    /// <param name="extends">Optional extends.</param>
    /// <param name="implements">Optional implements.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void EnumStart(this StringBuilder stringBuilder, string name, string displayName = default, VisibilityModifier visibility = VisibilityModifier.None, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder, nameof(stringBuilder));

        stringBuilder.VisibilityChar(visibility);
        stringBuilder.ClassBase(ClassType.Enum, name, displayName, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
        stringBuilder.ClassBaseStart();
    }

    /// <summary>
    /// Renders the end of an enum.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void EnumEnd(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder, nameof(stringBuilder));

        stringBuilder.ClassBaseEnd();
    }
}
