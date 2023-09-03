namespace PlantUml.Builder;

/// <summary>
/// Represents different types of groupings in a sequence diagram.
/// </summary>
/// <seealso cref="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/sequencediagram/GroupingType.java"/>
public enum GroupingType
    : byte
{
    /// <summary>
    /// Represents an optional sequence or branch.
    /// </summary>
    Opt,

    /// <summary>
    /// Represents an alternative sequence or branch.
    /// </summary>
    Alt,

    /// <summary>
    /// Represents a looped sequence.
    /// </summary>
    Loop,

    /// <summary>
    /// Represents parallel execution.
    /// </summary>
    Par,

    /// <summary>
    /// Represents another type of parallel execution. Often used for variations of parallel flow.
    /// </summary>
    Par2,

    /// <summary>
    /// Represents a break in the sequence.
    /// </summary>
    Break,

    /// <summary>
    /// Represents a grouped sequence.
    /// </summary>
    Group,

    /// <summary>
    /// Represents a critical section of a sequence.
    /// </summary>
    Critical,

    /// <summary>
    /// Represents another alternative or additional sequence.
    /// </summary>
    Also,

    /// <summary>
    /// Represents an else condition in decision-making.
    /// </summary>
    Else,

    /// <summary>
    /// Represents the end of a grouping.
    /// </summary>
    End

}
