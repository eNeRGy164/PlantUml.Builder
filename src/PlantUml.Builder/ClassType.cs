namespace PlantUml.Builder;

/// <summary>
/// Represents different types of classes in a UML diagram.
/// </summary>
public enum ClassType
    : byte
{
    /// <summary>
    /// Represents an annotation in UML.
    /// </summary>
    Annotation = 0,

    /// <summary>
    /// Represents an interface in UML.
    /// </summary>
    Interface,

    /// <summary>
    /// Represents an enumeration in UML.
    /// </summary>
    Enum,

    /// <summary>
    /// Represents a class in UML.
    /// </summary>
    Class,

    /// <summary>
    /// Represents an entity. Often used in Entity-Relationship diagrams.
    /// </summary>
    Entity,

    /// <summary>
    /// Represents a circle shape. This can be useful for specific diagram types or custom representations.
    /// </summary>
    Circle,

    /// <summary>
    /// Represents a diamond shape, often used to denote decisions or aggregations.
    /// </summary>
    Diamond
}
