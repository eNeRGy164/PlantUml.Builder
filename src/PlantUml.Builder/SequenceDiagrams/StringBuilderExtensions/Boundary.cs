namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Create a boundary participant.
    /// </summary>
    /// <param name="name">The name of the boundary.</param>
    /// <param name="displayName">Optional display name of the boundary.</param>
    /// <param name="color">Optional color of the boundary.</param>
    /// <param name="order">Optional order of the boundary.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Boundary(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.ParticipantBase(ParticipantType.Boundary, new ParticipantName(name, displayName), color, order);
    }

    /// <summary>
    /// Create a boundary participant using the 'create' keyword.
    /// </summary>
    /// <param name="name">The name of the boundary.</param>
    /// <param name="displayName">Optional display name of the boundary.</param>
    /// <param name="color">Optional color of the boundary.</param>
    /// <param name="order">Optional order of the boundary.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void CreateBoundary(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.CreateParticipantBase(new ParticipantName(name, displayName), ParticipantType.Boundary, color, order);
    }
}
