namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a comment block.
    /// </summary>
    /// <param name="comment">Optional comment text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void CommentBlock(this StringBuilder stringBuilder, string comment = "")
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.CommentStart);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(comment);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(Constant.CommentEnd);
        stringBuilder.AppendNewLine();
    }
}
