using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders the beginning of an object.
        /// </summary>
        /// <param name="name">The name of the namespace. The name can't contain spaces.</param>
        /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
        /// <param name="isAbstract">Indicates wheter the class is abstract. Default <c>false</c>.</param>
        /// <param name="stereotype">Optional stereo type.</param>
        /// <param name="customSpot">Optional custom spot.</param>
        /// <param name="backgroundColor">Optional background color.</param>
        /// <param name="extends">Optional class extension.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void ObjectStart(this StringBuilder stringBuilder, string name, string displayName = default, string stereotype = default, Uri url = default, Color backgroundColor = default)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Object(name, displayName, stereotype, url, backgroundColor);

            if (char.IsWhiteSpace(stringBuilder[stringBuilder.Length - 1]))
            {
                stringBuilder.Length--;
            }

            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.ObjectStart);
            stringBuilder.AppendNewLine();
        }
    }
}
