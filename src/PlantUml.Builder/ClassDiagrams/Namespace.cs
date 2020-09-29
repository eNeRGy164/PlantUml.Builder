using System;
using System.Text;

namespace PlantUml.Builder.ClassDiagrams
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders the beginning of a namespace.
        /// </summary>
        /// <param name="name">The name of the namespace. The name can't contain spaces.</param>
        /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
        /// <param name="stereotype">Optional stereo type.</param>
        /// <param name="backgroundColor">Optional background color.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void NamespaceStart(this StringBuilder stringBuilder, string name, string displayName = null, string stereotype = null, Color backgroundColor = null)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));

            stringBuilder.Append(Constant.Namespace);

            if (!(displayName is null))
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.Quote);
                stringBuilder.Append(displayName);
                stringBuilder.Append(Constant.Quote);
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.As);
            }

            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(name);

            if (!(stereotype is null))
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.StereoType(stereotype);
            }

            if (!(backgroundColor is null))
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(backgroundColor);
            }

            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.NamespaceStart);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the end of a namespace.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void NamespaceEnd(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.NamespaceEnd);
            stringBuilder.AppendNewLine();
        }
    }
}
