using System;
using System.Text;

namespace PlantUml.Builder.SequenceDiagrams
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders the auto number keyword.
        /// </summary>
        /// <param name="start">Optional start number.</param>
        /// <param name="step">Optional step size.</param>
        /// <param name="format">Optional format.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void AutoNumber(this StringBuilder stringBuilder, int? start = null, int? step = null, string format = null)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.Auto);
            stringBuilder.Append(Constant.Number);

            if (start.HasValue)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(start.Value);

                if (step.HasValue)
                {
                    stringBuilder.Append(Constant.Space);
                    stringBuilder.Append(step.Value);
                }
            }

            if (!string.IsNullOrEmpty(format))
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.Quote);
                stringBuilder.Append(format);
                stringBuilder.Append(Constant.Quote);
            }

            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the autonumber stop keyword.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StopAutoNumber(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.Auto);
            stringBuilder.Append(Constant.Number);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Stop);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the autonumber resume keyword.
        /// </summary>
        /// <param name="step">Optional step size.</param>
        /// <param name="format">Optional format.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="format"/> is empty of only white space.</exception>
        public static void ResumeAutoNumber(this StringBuilder stringBuilder, int? step = null, string format = null)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (!(format is null) && string.IsNullOrWhiteSpace(format)) throw new ArgumentException("A non-empty value should be provided", nameof(format));

            stringBuilder.Append(Constant.Auto);
            stringBuilder.Append(Constant.Number);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Resume);

            if (step.HasValue)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(step.Value);
            }

            if (!(format is null))
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.Quote);
                stringBuilder.Append(format);
                stringBuilder.Append(Constant.Quote);
            }

            stringBuilder.AppendNewLine();
        }
    }
}
