namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a comment.
    /// </summary>
    /// <param name="comment">Optional comment text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void Comment(this StringBuilder stringBuilder, string comment = "")
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Comment);

        if (!string.IsNullOrEmpty(comment))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(comment.Replace("\n", "\\n"));
        }
        
        stringBuilder.AppendNewLine();
    }
}
