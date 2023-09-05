namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Base for rendering a participant.
    /// </summary>
    /// <param name="participantType">The type of participant.</param>
    /// <param name="name">The name of the participant.</param>
    /// <param name="color">Color for the participant.</param>
    /// <param name="order">Order of the participant.</param>
    /// <param name="stereotype">Stereotype of the participant.</param>
    /// <param name="customSpot">Custom spot of the stereotype.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    internal static void ParticipantBase(this StringBuilder stringBuilder, ParticipantType participantType, ParticipantName name, Color color, int? order, string stereotype, CustomSpot customSpot)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (participantType >= ParticipantType.Participant)
        {
            stringBuilder.Append(participantType.ToString().ToLowerInvariant());
            stringBuilder.Append(Constant.Symbols.Space);
        }

        stringBuilder.Append(name);

        if (stereotype is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.StereoType(stereotype, customSpot);
        }

        if (order.HasValue)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(Constant.Words.Order);
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(order.Value);
        }

        if (color is not null)
        {
            stringBuilder.Append(Constant.Symbols.Space);
            stringBuilder.Append(color);
        }

        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Base for rendering creating a participant.
    /// </summary>
    /// <param name="name">The name of the participant.</param>
    /// <param name="participantType">The type of participant.</param>
    /// <param name="color">Color for the participant.</param>
    /// <param name="order">Order of the participant.</param>
    /// <param name="stereotype">Stereotype of the participant.</param>
    /// <param name="customSpot">Custom spot of the stereotype.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    internal static void CreateParticipantBase(this StringBuilder stringBuilder, ParticipantName name, ParticipantType participantType, Color color, int? order, string stereotype, CustomSpot customSpot)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Words.Create);
        stringBuilder.Append(Constant.Symbols.Space);
        stringBuilder.ParticipantBase(participantType, name, color, order, stereotype, customSpot);
    }
}
