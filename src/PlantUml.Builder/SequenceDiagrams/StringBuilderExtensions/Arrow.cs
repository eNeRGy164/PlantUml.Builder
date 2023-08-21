namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a sequence arrow.
    /// </summary>
    /// <param name="left">The left side of the arrow.</param>
    /// <param name="arrow">The arrow configuration.</param>
    /// <param name="right">The right side of the arrow.</param>
    /// <param name="message">Optional message for the arrow.</param>
    /// <param name="lifeEvents">Optional changes to the life of the <em>source</em> or <em>target</em>.</param>
    /// <param name="activationColor">Optional color for the target activation.</param>
    /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="arrow"/> is <c>null</c>, empty of only white space.</exception>
    /// <exception cref="ArgumentException"><paramref name="left"/> or <paramref name="right"/> is empty of only white space.</exception>
    /// <exception cref="ArgumentException"><paramref name="arrow"/> consists of less then 2 characters.</exception>
    /// <exception cref="NotSupportedException"><paramref name="left"/> and <paramref name="right"/> are both <c>null</c>, or the arrow has an external symbol on the other side of the undefined participant.</exception>
    public static void Arrow(this StringBuilder stringBuilder, ParticipantName left, Arrow arrow, ParticipantName right, string message = default, LifeLineEvents lifeEvents = default, Color activationColor = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentNullException.ThrowIfNull(arrow);

        if (left is null && right is null) throw new NotSupportedException("It is not possible for both partipants to be outside the diagram.");
        if (left is null && arrow.IsExternalRight()) throw new NotSupportedException("It is not possible for both partipants to be outside the diagram.");
        if (right is null && arrow.IsExternalLeft()) throw new NotSupportedException("It is not possible for both partipants to be outside the diagram.");

        if (left is null)
        {
            stringBuilder.Append(arrow.ExternalLeft());
        }
        else
        {
            stringBuilder.Append(left);
        }

        stringBuilder.Append(Constant.Space);

        if (left is not null && right is not null)
        {
            stringBuilder.Append(arrow);
            stringBuilder.Append(Constant.Space);
        }

        if (right is null)
        {
            stringBuilder.Append(arrow.ExternalRight());
        }
        else
        {
            stringBuilder.Append(right);
        }

        if (lifeEvents is not null && lifeEvents != LifeLineEvents.None)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(lifeEvents);
        }

        if (activationColor is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(activationColor);
        }

        if (!string.IsNullOrEmpty(message))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Colon);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(message.Replace("\n", "\\n"));
        }

        stringBuilder.AppendNewLine();
    }
}
