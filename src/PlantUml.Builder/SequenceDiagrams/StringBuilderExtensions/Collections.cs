namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Create a collections participant.
    /// </summary>
    /// <param name="name">The name of the collections.</param>
    /// <param name="displayName">Optional display name of the collections.</param>
    /// <param name="color">Optional color of the collections.</param>
    /// <param name="order">Optional order of the collections.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Collections(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.ParticipantBase(ParticipantType.Collections, new ParticipantName(name, displayName), color, order);
    }

    /// <summary>
    /// Create a collections participant using the 'create' keyword.
    /// </summary>
    /// <param name="name">The name of the collections.</param>
    /// <param name="displayName">Optional display name of the collections.</param>
    /// <param name="color">Optional color of the collections.</param>
    /// <param name="order">Optional order of the collections.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void CreateCollections(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.CreateParticipantBase(new ParticipantName(name, displayName), ParticipantType.Collections, color, order);
    }
}
