using System;
using System.Text;

namespace PlantUml.Builder.SequenceDiagrams
{
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
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="left"/>, <paramref name="arrow"/> or <paramref name="right"/> is <c>null</c>, empty of only white space.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="arrow"/> consists of less then 2 characters.</exception>
        public static void Arrow(this StringBuilder stringBuilder, string left, Arrow arrow, string right, string message = default, LifeLineEvents lifeEvents = default, Color activationColor = default)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (string.IsNullOrWhiteSpace(left)) throw new ArgumentException("A non-empty value should be provided", nameof(left));
            if (arrow is null) throw new ArgumentException("A non-empty value should be provided", nameof(arrow));
            if (string.IsNullOrWhiteSpace(right)) throw new ArgumentException("A non-empty value should be provided", nameof(right));

            stringBuilder.Append(left.Replace("\n", "\\n"));
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(arrow);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(right.Replace("\n", "\\n"));

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
}
