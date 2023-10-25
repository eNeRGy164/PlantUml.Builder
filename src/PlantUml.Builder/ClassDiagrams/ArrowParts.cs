namespace PlantUml.Builder.ClassDiagrams;

internal class ArrowParts
{
    // Line types
    public const char DashedLine = '.';
    public const char SolidLine = '-';

    // Arrowhead types
    public const char Aggregation = 'o';
    public const char Composition = '*';
    public const char Generalization = '|';
    public const char LeftRequiredInterface = '}';
    public const char Note = '#';
    public const char ProvidedInterface = '+';
    public const char RightRequiredInterface = '{';
    public const char Termination = 'x';

    // Directional arrowheads
    public const char Left = '<';
    public const char Right = '>';
}
