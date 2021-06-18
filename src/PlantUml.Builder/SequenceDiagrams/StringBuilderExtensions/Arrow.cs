using System;
using System.Text;
using PlantUml.Builder.SequenceDiagrams;

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
        /// <param name="label">Optional label for the arrow.</param>
        /// <param name="activateTarget">Whether the target is activated.</param>
        /// <param name="activationColor">Optional color for the target activation.</param>
        /// <param name="deactivateSource">Whether the source is deactivated.</param>
        /// <param name="createInstanceTarget">Whether the target instance is created.</param>
        /// <param name="destroyInstanceTarget">Whether the target instance is destroyed.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="left"/>, <paramref name="type"/> or <paramref name="right"/> is <c>null</c>, empty of only white space.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="type"/> consists of less then 2 characters.</exception>
        public static void Arrow(this StringBuilder stringBuilder, string left, Arrow arrow, string right, string label = null, bool activateTarget = false, Color activationColor = null, bool deactivateSource = false, bool createInstanceTarget = false, bool destroyInstanceTarget = false)
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

            if (activateTarget)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.TargetActivation);
            }

            if (activationColor is not null)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(activationColor);
            }

            if (deactivateSource)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.SourceDeactivation);
            }

            if (createInstanceTarget)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.TargetInstanceCreation);
            }

            if (destroyInstanceTarget)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.TargetInstanceDestruction);
            }

            if (!string.IsNullOrEmpty(label))
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.Colon);
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(label.Replace("\n", "\\n"));
            }

            stringBuilder.AppendNewLine();
        }
    }
}
