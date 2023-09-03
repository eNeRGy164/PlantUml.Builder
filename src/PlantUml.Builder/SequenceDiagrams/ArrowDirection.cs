namespace PlantUml.Builder.SequenceDiagrams;

[Flags]
public enum ArrowDirection
    : sbyte
{
    None = 0,
    Left = 1,
    Right = 2,
    Both = Left | Right
}
