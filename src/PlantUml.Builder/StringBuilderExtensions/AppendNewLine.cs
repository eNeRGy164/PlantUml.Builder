using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Appends a new line.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void AppendNewLine(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.NewLine);
        }
    }
}
