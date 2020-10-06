using System;
using System.Text;

namespace PlantUml.Builder.SequenceDiagrams
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Return to the previous participant.
        /// </summary>
        /// <param name="message">Optional message.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Return(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.Return);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Return to the previous participant.
        /// </summary>
        /// <param name="message">The return message.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="message"/> is <c>null</c>, empty of only white space.</exception>
        public static void Return(this StringBuilder stringBuilder, string message)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentException("A non-empty value should be provided", nameof(message));

            stringBuilder.Append(Constant.Return);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(message);
            stringBuilder.AppendNewLine();
        }
    }
}
