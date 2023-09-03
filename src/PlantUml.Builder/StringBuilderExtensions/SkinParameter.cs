namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a skin parameter.
    /// </summary>
    /// <param name="name">The name of the skin parameter.</param>
    /// <param name="value">The value of the skin parameter.</param>
    /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="value"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void SkinParameter(this StringBuilder stringBuilder, string name, string value)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(name);
        ArgumentException.ThrowIfNullOrWhitespace(value);

        stringBuilder.Append(Constant.Words.SkinParam);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(name.Trim());
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(value.Trim());
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders a skin parameter.
    /// </summary>
    /// <param name="skinParameter">The skin parameter.</param>
    /// <param name="value">The value of the skin parameter.</param>
    /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="skinParameter"/> is not a <see cref="SkinParameter"/> value.</exception>
    public static void SkinParameter(this StringBuilder stringBuilder, SkinParameter skinParameter, string value)
    {
        if (!Enum.IsDefined(skinParameter)) throw new ArgumentOutOfRangeException(nameof(skinParameter), "A defined enum value should be provided");

        stringBuilder.SkinParameter(skinParameter.ToString(), value);
    }

    /// <summary>
    /// Renders a skin parameter.
    /// </summary>
    /// <param name="name">The skin parameter.</param>
    /// <param name="value">The value of the skin parameter.</param>
    /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void SkinParameter(this StringBuilder stringBuilder, string name, int value)
    {
        stringBuilder.SkinParameter(name, value.ToString());
    }

    /// <summary>
    /// Renders a skin parameter.
    /// </summary>
    /// <param name="skinParameter">The skin parameter.</param>
    /// <param name="value">The value of the skin parameter.</param>
    /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="skinParameter"/> is not a <see cref="SkinParameter"/> value.</exception>
    public static void SkinParameter(this StringBuilder stringBuilder, SkinParameter skinParameter, int value)
    {
        stringBuilder.SkinParameter(skinParameter.ToString(), value.ToString());
    }

    /// <summary>
    /// Renders a skin parameter.
    /// </summary>
    /// <param name="name">The skin parameter.</param>
    /// <param name="value">The value of the skin parameter.</param>
    /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void SkinParameter(this StringBuilder stringBuilder, string name, bool value)
    {
        stringBuilder.SkinParameter(name, value.ToString().ToLowerInvariant());
    }

    /// <summary>
    /// Renders a skin parameter.
    /// </summary>
    /// <param name="skinParameter">The skin parameter.</param>
    /// <param name="value">The value of the skin parameter.</param>
    /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="skinParameter"/> is not a <see cref="SkinParameter"/> value.</exception>
    public static void SkinParameter(this StringBuilder stringBuilder, SkinParameter skinParameter, bool value)
    {
        stringBuilder.SkinParameter(skinParameter.ToString(), value.ToString().ToLowerInvariant());
    }
}
