namespace PlantUml.Builder;

/// <summary>
/// Represents a color.
/// </summary>
public class Color : IFormattable
{
    private readonly string value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Color"/> class using a string value.
    /// </summary>
    /// <param name="color">The color value.</param>
    public Color(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
        {
            this.value = string.Empty;
        }
        else
        {
            if (color[0] == Constant.ColorPrefix)
            {
                this.value = color.Trim();
            }
            else
            {
                this.value = Constant.ColorPrefix + color.Trim();
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Color"/> class using a named color.
    /// </summary>
    /// <param name="color">The named color.</param>
    public Color(NamedColor color)
        : this(color.ToString())
    {
    }

    /// <summary>
    /// Converts the color to its string representation.
    /// </summary>
    /// <returns>The string representation of the color.</returns>
    public override string ToString()
    {
        return this.value;
    }

    /// <summary>
    /// Converts the color to its string representation using the specified format.
    /// </summary>
    /// <param name="format">The format to use.</param>
    /// <param name="formatProvider">The format provider to use.</param>
    /// <returns>The formatted string representation of the color.</returns>
    public string ToString(string format, IFormatProvider formatProvider = null)
    {
        if (format != null && format.Equals("B", StringComparison.OrdinalIgnoreCase))
        {
            return Constant.ColorStart + this.value + Constant.ColorEnd;
        }

        return this.value;
    }

    public static implicit operator Color(NamedColor color)
    {
        return new Color(color);
    }

    public static implicit operator Color(string color)
    {
        return new Color(color);
    }
}
