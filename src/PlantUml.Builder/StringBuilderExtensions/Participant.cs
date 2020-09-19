using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders a participant.
        /// </summary>
        /// <param name="name">The name of the participant.</param>
        /// <param name="displayName">Optional display name of the participant.</param>
        /// <param name="type">Optional type of the participant.</param>
        /// <param name="color">Optional color of the participant.</param>
        /// <param name="order">Optional order of the participant.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void Participant(this StringBuilder stringBuilder, string name, string displayName = null, ParticipantType type = ParticipantType.Participant, Color color = null, int? order = null)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));
                        
            stringBuilder.Append(type.ToString().ToLowerInvariant());
            stringBuilder.Append(Constant.Space);
            stringBuilder.ParticipantBase(name, displayName, color, order);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Create a participant.
        /// </summary>
        /// <param name="name">The name of the participant.</param>
        /// <param name="order">Optional order of the participant.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void Create(this StringBuilder stringBuilder, string name, int? order = null)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.Create);
            stringBuilder.Append(Constant.Space);
            stringBuilder.ParticipantBase(name, null, null, order);
            stringBuilder.AppendNewLine();
        }
    }
}
