namespace PlantUml.Builder;

public class CustomSpot
{
    public char Character { get; }

    public Color Color { get; }

    public CustomSpot(char symbol, Color color)
    {
        this.Character = symbol;
        this.Color = color;
    }
}
