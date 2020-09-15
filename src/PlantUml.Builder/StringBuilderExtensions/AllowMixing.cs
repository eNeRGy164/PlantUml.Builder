using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Allows mixing of chart types.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void AllowMixing(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.Allow);
            stringBuilder.Append(Constant.Underscore);
            stringBuilder.Append(Constant.Mixing);

            stringBuilder.AppendNewLine();
        }
    }
}
