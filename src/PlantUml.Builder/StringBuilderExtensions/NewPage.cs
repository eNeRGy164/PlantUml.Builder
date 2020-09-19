using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Creates a new page.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void NewPage(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));
            
            stringBuilder.Append(Constant.New);
            stringBuilder.Append(Constant.Page);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Creates a new page.
        /// </summary>
        /// <param name="title">Title of the new page.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void NewPage(this StringBuilder stringBuilder, string title)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("A non-empty value should be provided", nameof(title));

            stringBuilder.Append(Constant.New);
            stringBuilder.Append(Constant.Page);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(title.Replace("\n", "\\n"));
            stringBuilder.AppendNewLine();
        }
    }
}
