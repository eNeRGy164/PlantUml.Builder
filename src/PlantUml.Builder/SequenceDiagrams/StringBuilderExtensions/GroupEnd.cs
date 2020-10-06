using System;
using System.Text;

namespace PlantUml.Builder.SequenceDiagrams
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders the end of a group.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void GroupEnd(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.End);
            stringBuilder.AppendNewLine();
        }
    }
}
