namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Create an entity participant.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    /// <param name="displayName">Optional display name of the entity.</param>
    /// <param name="color">Optional color of the entity.</param>
    /// <param name="order">Optional order of the entity.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Entity(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.ParticipantBase(ParticipantType.Entity, new ParticipantName(name, displayName), color, order);
    }

    /// <summary>
    /// Create an entity participant using the 'create' keyword.
    /// </summary>
    /// <param name="name">The name of the entity.</param>
    /// <param name="displayName">Optional display name of the entity.</param>
    /// <param name="color">Optional color of the entity.</param>
    /// <param name="order">Optional order of the entity.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void CreateEntity(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.CreateParticipantBase(new ParticipantName(name, displayName), ParticipantType.Entity, color, order);
    }
}
