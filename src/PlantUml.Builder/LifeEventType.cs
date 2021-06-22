namespace PlantUml.Builder
{
    /// <seealso cref="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/sequencediagram/LifeEventType.java"/>
    public enum LifeEventType
        : byte
    {
        None = 0,

        Activate,
        Deactivate,
        Destroy,
        Create
    }
}
