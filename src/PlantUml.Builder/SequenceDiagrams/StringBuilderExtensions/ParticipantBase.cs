namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Base for rendering a participant.
    /// </summary>
    /// <param name="participantType">The type of participant.</param>
    /// <param name="name">The name of the participant.</param>
    /// <param name="color">Optional color for the participant.</param>
    /// <param name="order">Optional order of the participant.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    internal static void ParticipantBase(this StringBuilder stringBuilder, ParticipantType participantType, ParticipantName name, Color color, int? order)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (participantType >= ParticipantType.Participant)
        {
            stringBuilder.Append(participantType.ToString().ToLowerInvariant());
            stringBuilder.Append(Constant.Space);
        }

        stringBuilder.Append(name);

        if (order.HasValue)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Order);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(order.Value);
        }

        if (color is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(color);
        }

        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Base for rendering creating a participant.
    /// </summary>
    /// <param name="name">The name of the participant.</param>
    /// <param name="participantType">The type of participant.</param>
    /// <param name="color">Optional color for the participant.</param>
    /// <param name="order">Optional order of the participant.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    internal static void CreateParticipantBase(this StringBuilder stringBuilder, ParticipantName name, ParticipantType participantType = ParticipantType.None, Color color = null, int? order = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Create);
        stringBuilder.Append(Constant.Space);
        stringBuilder.ParticipantBase(participantType, name, color, order);
    }
}
