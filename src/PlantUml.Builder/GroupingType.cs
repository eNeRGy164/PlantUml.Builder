namespace PlantUml.Builder
{
    /// <seealso cref="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/sequencediagram/GroupingType.java"/>
    public enum GroupingType
        : byte
    {
        Opt,
        Alt,
        Loop,
        Par,
        Par2,
        Break,
        Group,
        Critical,
        Also,
        Else,
        End
    }
}
