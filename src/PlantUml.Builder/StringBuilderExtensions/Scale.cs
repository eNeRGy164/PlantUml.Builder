namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a scale command with a raw scale expression.
    /// </summary>
    /// <param name="scale">The scale factor or dimension expression (for example: <c>2</c>, <c>2/3</c>, <c>180*90</c>).</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="scale"/> is <see langword="null"/>, empty or only white space.</exception>
    public static void Scale(this StringBuilder stringBuilder, string scale)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentException.ThrowIfNullOrWhitespace(scale);

        AppendScale(stringBuilder, scale);
    }

    /// <summary>
    /// Renders a scale command from width and height values as <c>&lt;width&gt;*&lt;height&gt;</c>.
    /// </summary>
    /// <param name="width">The width value.</param>
    /// <param name="height">The height value.</param>
    /// <param name="max">Whether to render the command with <c>max</c>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="width"/> or <paramref name="height"/> is less than or equal to zero.</exception>
    public static void Scale(this StringBuilder stringBuilder, int width, int height, bool max = false)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "A positive width should be supplied.");
        if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "A positive height should be supplied.");

        AppendScale(stringBuilder, $"{width}*{height}", max);
    }

    /// <summary>
    /// Renders a scale command with a pixel value and dimension.
    /// </summary>
    /// <param name="pixels">The pixel size.</param>
    /// <param name="dimension">The dimension used by the scale command.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pixels"/> is less than or equal to zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="dimension"/> is not a defined enum value.</exception>
    public static void Scale(this StringBuilder stringBuilder, int pixels, ScaleDimension dimension)
    {
        Scale(stringBuilder, pixels, false, dimension);
    }

    /// <summary>
    /// Renders a scale command with optional <c>max</c>, pixel value and dimension.
    /// </summary>
    /// <param name="pixels">The pixel size.</param>
    /// <param name="max">Whether to render the command with <c>max</c>.</param>
    /// <param name="dimension">The dimension used by the scale command.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pixels"/> is less than or equal to zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="dimension"/> is not a defined enum value.</exception>
    public static void Scale(this StringBuilder stringBuilder, int pixels, bool max, ScaleDimension dimension)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        if (pixels <= 0) throw new ArgumentOutOfRangeException(nameof(pixels), "A positive pixel size should be supplied.");
        if (!Enum.IsDefined(dimension)) throw new ArgumentOutOfRangeException(nameof(dimension), "A defined enum value should be provided");

        AppendScale(stringBuilder, pixels.ToString(), max, dimension);
    }

    private static void AppendScale(StringBuilder stringBuilder, string scale, bool max = false, ScaleDimension? dimension = null)
    {
        stringBuilder.Append(Constant.Words.Scale);
        stringBuilder.Append(Constant.Symbols.Space);

        if (max)
        {
            stringBuilder.Append(Constant.Words.Max);
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(scale);

        if (dimension is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(dimension.Value.ToString().ToLowerInvariant());
        }

        stringBuilder.AppendNewLine();
    }
}
