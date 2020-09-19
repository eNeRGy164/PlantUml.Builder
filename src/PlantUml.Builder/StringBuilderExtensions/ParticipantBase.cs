using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Base for rendering a participant.
        /// </summary>
        /// <param name="name">The name of the participant.</param>
        /// <param name="displayName">Optional display name of the participant.</param>
        /// <param name="color">Optional color of the participant.</param>
        /// <param name="order">Optional order of the participant.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        internal static void ParticipantBase(this StringBuilder stringBuilder, string name, string displayName, Color color, int? order)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));

            if (!string.IsNullOrEmpty(displayName))
            {
                stringBuilder.Append(Constant.Quote);
                stringBuilder.Append(displayName);
                stringBuilder.Append(Constant.Quote);
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.As);
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

            if (!(color is null))
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(color);
            }
        }
    }
}
