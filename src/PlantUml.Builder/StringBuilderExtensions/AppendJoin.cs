using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Appends the <paramref name="values"/> joined by <paramref name="separator"/>.
        /// </summary>
        /// <param name="separator">The character to use as a separator. <paramref name="separator"/> is included in the concatenated and appended string only if <paramref name="values"/> has more than one element.</param>
        /// <param name="values">An array that contains the strings to concatenate and append to the current instance of the string builder.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static StringBuilder AppendJoin(this StringBuilder stringBuilder, char separator, params string[] values)
        {
            return stringBuilder.AppendJoin(separator, values.AsEnumerable());
        }

        public static StringBuilder AppendJoin(this StringBuilder stringBuilder, char separator, IEnumerable<object> values)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));
            if (values is null) throw new ArgumentNullException(nameof(values));

            var item = values.GetEnumerator();
            if (!item.MoveNext())
            {
                return stringBuilder;
            }

            var value = (string)item.Current;
            if (!(value is null))
            {
                stringBuilder.Append(value.ToString());
            }

            while (item.MoveNext())
            {
                stringBuilder.Append(separator);
                value = (string)item.Current;
                if (!(value is null))
                {
                    stringBuilder.Append(value.ToString());
                }
            }

            return stringBuilder;
        }
    }
}
