namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Create an actor.
    /// </summary>
    /// <param name="name">The name of the actor.</param>
    /// <param name="displayName">Optional display name of the actor.</param>
    /// <param name="color">Optional color of the actor.</param>
    /// <param name="order">Optional order of the actor.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Actor(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.ParticipantBase(ParticipantType.Actor, new ParticipantName(name, displayName), color, order);
    }

    /// <summary>
    /// Create an actor participant using the 'create' keyword.
    /// </summary>
    /// <param name="name">The name of the actor.</param>
    /// <param name="displayName">Optional display name of the actor.</param>
    /// <param name="color">Optional color of the actor.</param>
    /// <param name="order">Optional order of the actor.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void CreateActor(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.CreateParticipantBase(new ParticipantName(name, displayName), ParticipantType.Actor, color, order);
    }
}
