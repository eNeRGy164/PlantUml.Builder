namespace PlantUml.Builder;

/// <summary>
/// Represents the dimension used by the <c>scale</c> command.
/// </summary>
public enum ScaleDimension
    : byte
{
    /// <summary>
    /// Scale against width.
    /// </summary>
    Width = 0,

    /// <summary>
    /// Scale against height.
    /// </summary>
    Height,
}
