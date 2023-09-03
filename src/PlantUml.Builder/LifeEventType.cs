namespace PlantUml.Builder;

/// <summary>
/// Represents different types of life events in a sequence diagram.
/// </summary>
/// <seealso cref="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/sequencediagram/LifeEventType.java"/>
public enum LifeEventType
    : byte
{
    /// <summary>
    /// Default type, no specific life event.
    /// </summary>
    None = 0,

    /// <summary>
    /// Represents the activation of an entity in a sequence diagram. It starts a period where the entity is active.
    /// </summary>
    Activate,

    /// <summary>
    /// Represents the deactivation of an entity in a sequence diagram. It ends the active period of the entity.
    /// </summary>
    Deactivate,

    /// <summary>
    /// Represents the destruction of an entity in a sequence diagram. The entity will no longer exist after this event.
    /// </summary>
    Destroy,

    /// <summary>
    /// Represents the creation of an entity in a sequence diagram. The entity begins its existence from this event.
    /// </summary>
    Create
}
