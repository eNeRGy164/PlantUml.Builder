namespace PlantUml.Builder;

/// <summary>
/// Represents a custom spot with a character symbol and color.
/// </summary>
public class CustomSpot
{
    /// <summary>
    /// Gets the character symbol of the custom spot.
    /// </summary>
    public char Character { get; }

    /// <summary>
    /// Gets the color of the custom spot.
    /// </summary>
    public Color Color { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomSpot"/> class.
    /// </summary>
    /// <param name="symbol">The character symbol of the custom spot.</param>
    /// <param name="color">The color of the custom spot.</param>

    public CustomSpot(char symbol, Color color)
    {
        this.Character = symbol;
        this.Color = color;
    }
}
