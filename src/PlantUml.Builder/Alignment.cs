namespace PlantUml.Builder;

/// <summary>
/// Represents a horizontal alignment.
/// </summary>
public class Alignment
{
    private readonly string value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Alignment"/> class using a string value.
    /// </summary>
    /// <param name="alignment">The alignment value.</param>
    public Alignment(string alignment)
    {
        if (string.IsNullOrWhiteSpace(alignment))
        {
            this.value = string.Empty;
            return;
        }

        var normalized = alignment.Trim().ToLowerInvariant();
        this.value = normalized == Constant.Words.Left ||
                     normalized == Constant.Words.Center ||
                     normalized == Constant.Words.Right
            ? normalized
            : string.Empty;
    }

    /// <summary>
    /// Gets left alignment.
    /// </summary>
    public static Alignment Left { get; } = new Alignment(Constant.Words.Left);

    /// <summary>
    /// Gets center alignment.
    /// </summary>
    public static Alignment Center { get; } = new Alignment(Constant.Words.Center);

    /// <summary>
    /// Gets right alignment.
    /// </summary>
    public static Alignment Right { get; } = new Alignment(Constant.Words.Right);

    /// <summary>
    /// Converts the alignment to its string representation.
    /// </summary>
    /// <returns>The string representation of the alignment.</returns>
    public override string ToString()
    {
        return this.value;
    }

    /// <summary>
    /// Implicitly converts a string to an <see cref="Alignment"/>.
    /// </summary>
    /// <param name="alignment">The alignment string.</param>
    public static implicit operator Alignment(string alignment)
    {
        return new Alignment(alignment);
    }
}
