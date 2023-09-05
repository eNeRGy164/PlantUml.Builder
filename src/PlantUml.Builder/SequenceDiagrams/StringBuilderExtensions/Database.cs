namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Create a database participant.
    /// </summary>
    /// <param name="name">The name of the database.</param>
    /// <param name="displayName">Optional display name of the database.</param>
    /// <param name="color">Optional color of the database.</param>
    /// <param name="order">Optional order of the database.</param>
    /// <param name="stereotype">Optional stereotype of the database.</param>
    /// <param name="customSpot">Optional custom spot of the stereotype.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Database(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null, string stereotype = default, CustomSpot customSpot = default)
    {
        stringBuilder.ParticipantBase(ParticipantType.Database, new ParticipantName(name, displayName), color, order, stereotype, customSpot);
    }

    /// <summary>
    /// Create a database participant using the 'create' keyword.
    /// </summary>
    /// <param name="name">The name of the database.</param>
    /// <param name="displayName">Optional display name of the database.</param>
    /// <param name="color">Optional color of the database.</param>
    /// <param name="order">Optional order of the database.</param>
    /// <param name="stereotype">Optional stereotype of the database.</param>
    /// <param name="customSpot">Optional custom spot of the stereotype.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void CreateDatabase(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null, string stereotype = default, CustomSpot customSpot = default)
    {
        stringBuilder.CreateParticipantBase(new ParticipantName(name, displayName), ParticipantType.Database, color, order, stereotype, customSpot);
    }
}
