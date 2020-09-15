using System;

namespace PlantUml.Builder
{
    /// <seealso cref="https://github.com/plantuml/plantuml/blob/master/src/net/sourceforge/plantuml/activitydiagram3/ForkStyle.java"/>
    public enum ForkStyle
        : byte
    {
        None,

        Fork,
        Split,
        Merge
    }
}
