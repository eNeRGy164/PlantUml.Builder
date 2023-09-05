namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Set the direction of the diagram
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void Direction(this StringBuilder stringBuilder, DiagramDirection direction)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        if (!Enum.IsDefined(direction)) throw new ArgumentOutOfRangeException(nameof(direction), "A defined enum value should be provided");

        switch (direction)
        {
            case DiagramDirection.LeftToRight:
                stringBuilder.Append(Constant.Words.Left);
                stringBuilder.Append(Constant.Symbols.Space);
                stringBuilder.Append(Constant.Words.To);
                stringBuilder.Append(Constant.Symbols.Space);
                stringBuilder.Append(Constant.Words.Right);
                break;

            case DiagramDirection.TopToBottom:
                stringBuilder.Append(Constant.Words.Top);
                stringBuilder.Append(Constant.Symbols.Space);
                stringBuilder.Append(Constant.Words.To);
                stringBuilder.Append(Constant.Symbols.Space);
                stringBuilder.Append(Constant.Words.Bottom);
                break;
        }

        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.Append(Constant.Words.Direction);
        stringBuilder.AppendNewLine();
    }
}
