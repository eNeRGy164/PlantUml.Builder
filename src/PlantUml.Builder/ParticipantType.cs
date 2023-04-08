namespace PlantUml.Builder;

/// <seealso cref="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/sequencediagram/ParticipantType.java"/>
public enum ParticipantType
    : byte
{
    None = 0,

    Participant,
    Actor,
    Boundary,
    Control,
    Entity,
    Queue,
    Database,
    Collections
}
