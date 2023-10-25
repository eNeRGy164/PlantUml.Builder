namespace PlantUml.Builder.ClassDiagrams
{
    /// <summary>
    /// Defines constants for various types of UML relationships.
    /// </summary>
    public partial class Relationship
    {
#pragma warning disable CA2211 // Non-constant fields should not be visible
        /// <summary>
        /// Represents a simple association between two classes.
        /// </summary>
        public static Arrow Associates = "--";

        /// <summary>
        /// Represents a simple association from the perspective of the second class.
        /// </summary>
        public static Arrow IsAssociatedWith = "--";

        /// <summary>
        /// Represents a directed association between two classes.
        /// </summary>
        public static Arrow AssociatesDirectlyWith = "<--";

        /// <summary>
        /// Represents a directed association from the perspective of the second class.
        /// </summary>
        public static Arrow IsDirectlyAssociatedWith = "-->";

        /// <summary>
        /// Represents a strong or special form of association.
        /// </summary>
        public static Arrow AssociatesStrongly = "--+";

        /// <summary>
        /// Represents a strong or special form of association from the perspective of the second class.
        /// </summary>
        public static Arrow IsStronglyAssociatedWith = "+--";

        /// <summary>
        /// Represents a special form of association denoted by a custom symbol.
        /// </summary>
        public static Arrow AssociatesSpeciallyWith = "--#";

        /// <summary>
        /// Represents a special form of association from the perspective of the second class.
        /// </summary>
        public static Arrow IsSpeciallyAssociatedWith = "#--";

        /// <summary>
        /// Represents a disallowed or broken relationship.
        /// </summary>
        public static Arrow Disallows = "--x";

        /// <summary>
        /// Represents a disallowed or broken relationship from the perspective of the second class.
        /// </summary>
        public static Arrow IsDisallowedBy = "x--";

        /// <summary>
        /// Represents an aggregation relationship.
        /// </summary>
        public static Arrow Aggregates = "--o";

        /// <summary>
        /// Represents an aggregation relationship from the perspective of the second class.
        /// </summary>
        public static Arrow IsAggregatedBy = "o--";

        /// <summary>
        /// Represents a composition relationship.
        /// </summary>
        public static Arrow Composes = "--*";

        /// <summary>
        /// Represents a composition relationship from the perspective of the second class.
        /// </summary>
        public static Arrow IsComposedBy = "*--";

        /// <summary>
        /// Represents a directed composition relationship.
        /// </summary>
        public static Arrow ComposesDirectly = "*-->";

        /// <summary>
        /// Represents a directed composition relationship from the perspective of the second class.
        /// </summary>
        public static Arrow IsDirectlyComposedBy = "<--*";

        /// <summary>
        /// Represents an inheritance relationship.
        /// </summary>
        public static Arrow InheritsFrom = "<|--";

        /// <summary>
        /// Represents an inheritance relationship from the perspective of the second class.
        /// </summary>
        public static Arrow IsInheritedBy = "--|>";

        /// <summary>
        /// Represents a realization or implementation relationship.
        /// </summary>
        public static Arrow Realizes = "<|..";

        /// <summary>
        /// Represents a realization or implementation relationship from the perspective of the second class.
        /// </summary>
        public static Arrow IsRealizedBy = "..|>";

        /// <summary>
        /// Represents a dependency relationship.
        /// </summary>
        public static Arrow DependsOn = "..";

        /// <summary>
        /// Represents a dependency relationship from the perspective of the second class.
        /// </summary>
        public static Arrow IsDependedUponBy = "..";

        /// <summary>
        /// Represents a directed dependency relationship.
        /// </summary>
        public const string DependsDirectlyOn = "..>";

        /// <summary>
        /// Represents a directed dependency relationship from the perspective of the second class.
        /// </summary>
        public const string IsDirectlyDependedUponBy = "<..";

        /// <summary>
        /// Represents a "contains many of" relationship, often used to denote cardinality.
        /// </summary>
        public const string ContainsManyOf = "}--";

        /// <summary>
        /// Represents a "is contained by many" relationship, often used to denote cardinality.
        /// </summary>
        public const string IsContainedBy = "--{";
#pragma warning restore CA2211 // Non-constant fields should not be visible
    }
}
