namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a stereotype.
    /// </summary>
    /// <param name="stereotype">Optional sterotype name.</param>
    /// <param name="customSpot">Optional custom spot.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void StereoType(this StringBuilder stringBuilder, string stereotype = default, CustomSpot customSpot = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.SterotypeStart);

        if (customSpot is not null)
        {
            stringBuilder.Append(Constant.Styling.CustomSpot.Start);
            stringBuilder.Append(customSpot.Character);
            stringBuilder.Append(Constant.Symbols.Comma);
            stringBuilder.Append(customSpot.Color);
            stringBuilder.Append(Constant.Styling.CustomSpot.End);
        }

        stringBuilder.Append(stereotype);
        stringBuilder.Append(Constant.SterotypeEnd);
    }
}
