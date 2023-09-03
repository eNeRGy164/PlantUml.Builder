namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Create a control participant.
    /// </summary>
    /// <param name="name">The name of the control.</param>
    /// <param name="displayName">Optional display name of the control.</param>
    /// <param name="color">Optional color of the control.</param>
    /// <param name="order">Optional order of the control.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void Control(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.ParticipantBase(ParticipantType.Control, new ParticipantName(name, displayName), color, order);
    }

    /// <summary>
    /// Create a control participant using the 'create' keyword.
    /// </summary>
    /// <param name="name">The name of the control.</param>
    /// <param name="displayName">Optional display name of the participant.</param>
    /// <param name="color">Optional color of the control.</param>
    /// <param name="order">Optional order of the control.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void CreateControl(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
    {
        stringBuilder.CreateParticipantBase(new ParticipantName(name, displayName), ParticipantType.Control, color, order);
    }
}
