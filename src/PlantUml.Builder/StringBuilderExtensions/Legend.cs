namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the start of a legend block.
    /// </summary>
    /// <param name="alignment">Optional legend alignment and position. See <see cref="LegendAlignment"/> for possible values.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="alignment"/> is not a defined enum value.</exception>
    public static void LegendStart(this StringBuilder stringBuilder, LegendAlignment alignment = LegendAlignment.None)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        if (!Enum.IsDefined(alignment))
        {
            throw new ArgumentOutOfRangeException(nameof(alignment), "A defined enum value should be provided");
        }

        stringBuilder.Append(Constant.Words.Legend);

        var formattedAlignment = FormatLegendAlignment(alignment);
        if (formattedAlignment != string.Empty)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(formattedAlignment);
        }

        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the end of a legend block.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void EndLegend(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.End);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Legend);
        stringBuilder.AppendNewLine();
    }

    private static string FormatLegendAlignment(LegendAlignment alignment)
    {
        if (alignment == LegendAlignment.None)
        {
            return string.Empty;
        }

        var vertical = (alignment & LegendAlignment.Top) == LegendAlignment.Top
            ? Constant.Words.Top
            : (alignment & LegendAlignment.Bottom) == LegendAlignment.Bottom
                ? Constant.Words.Bottom
                : string.Empty;

        var horizontal = (alignment & LegendAlignment.Left) == LegendAlignment.Left
            ? Constant.Words.Left
            : (alignment & LegendAlignment.Center) == LegendAlignment.Center
                ? Constant.Words.Center
                : (alignment & LegendAlignment.Right) == LegendAlignment.Right
                    ? Constant.Words.Right
                    : string.Empty;

        if (vertical == string.Empty)
        {
            return horizontal;
        }

        if (horizontal == string.Empty)
        {
            return vertical;
        }

        return $"{vertical} {horizontal}";
    }
}
