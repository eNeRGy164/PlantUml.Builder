namespace PlantUml.Builder;

/// <summary>
/// Represents valid legend alignments and positions.
/// </summary>
[Flags]
public enum LegendAlignment
    : byte
{
    /// <summary>
    /// No legend alignment is specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// Left legend alignment.
    /// </summary>
    Left = 1,

    /// <summary>
    /// Center legend alignment.
    /// </summary>
    Center = 2,

    /// <summary>
    /// Right legend alignment.
    /// </summary>
    Right = 4,

    /// <summary>
    /// Top legend position.
    /// </summary>
    Top = 8,

    /// <summary>
    /// Bottom legend position.
    /// </summary>
    Bottom = 16,

    /// <summary>
    /// Top-left legend position and alignment.
    /// </summary>
    TopLeft = Top | Left,

    /// <summary>
    /// Top-center legend position and alignment.
    /// </summary>
    TopCenter = Top | Center,

    /// <summary>
    /// Top-right legend position and alignment.
    /// </summary>
    TopRight = Top | Right,

    /// <summary>
    /// Bottom-left legend position and alignment.
    /// </summary>
    BottomLeft = Bottom | Left,

    /// <summary>
    /// Bottom-center legend position and alignment.
    /// </summary>
    BottomCenter = Bottom | Center,

    /// <summary>
    /// Bottom-right legend position and alignment.
    /// </summary>
    BottomRight = Bottom | Right,
}
