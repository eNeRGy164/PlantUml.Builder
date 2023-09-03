namespace PlantUml.Builder;

/// <summary>
/// Represents different styles of forks in an activity diagram.
/// </summary>
/// <seealso cref="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/activitydiagram3/ForkStyle.java"/>
public enum ForkStyle
    : byte
{
    /// <summary>
    /// Default style, no specific fork behavior.
    /// </summary>
    None = 0,

    /// <summary>
    /// Represents a fork in activity diagrams where multiple activities start concurrently.
    /// </summary>
    Fork,

    /// <summary>
    /// Represents a decision point where one of several branches is chosen.
    /// </summary>
    Split,

    /// <summary>
    /// Represents a point where multiple branches converge.
    /// </summary>
    Merge
}
