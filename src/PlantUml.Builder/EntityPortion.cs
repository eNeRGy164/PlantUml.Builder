namespace PlantUml.Builder;

/// <summary>
/// Represents different portions or parts of an entity in a UML diagram.
/// </summary>
public enum EntityPortion
    : byte
{
    None = 0,
    Members,
    Attributes,
    Fields,
    Methods,
    Circles,
    Circled,
    StereoTypes
}
