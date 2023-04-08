namespace PlantUml.Builder;

/// <seealso cref="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/skin/VisibilityModifier.java"/>
public enum VisibilityModifier
    : byte
{
    None = 0,

    Private,
    Protected,
    PackagePrivate,
    Public
}
