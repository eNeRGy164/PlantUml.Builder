using System;
using System.Text;

namespace PlantUml.Builder.ClassDiagrams
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders an interface.
        /// </summary>
        /// <param name="name">The name of the interface. The name can't contain spaces.</param>
        /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
        /// <param name="generics">Optional interface extension.</param>
        /// <param name="stereotype">Optional stereo type.</param>
        /// <param name="customSpot">Optional custom spot.</param>
        /// <param name="tag">Optional tag.</param>
        /// <param name="url">Optional URL.</param>
        /// <param name="backgroundColor">Optional background color.</param>
        /// <param name="lineColor">Optional line color.</param>
        /// <param name="lineStyle">Optional line style.</param>
        /// <param name="extends">Optional extends.</param>
        /// <param name="implements">Optional implementations.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void Interface(this StringBuilder stringBuilder, string name, string displayName = default, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.ClassBase(ClassType.Interface, name, displayName, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the beginning of an interface.
        /// </summary>
        /// <param name="name">The name of the interface. The name can't contain spaces.</param>
        /// <param name="displayName">Optional display name. The display name can contain spaces.</param>
        /// <param name="visibility">Optional visibility.</param>
        /// <param name="generics">Optional interface extension.</param>
        /// <param name="stereotype">Optional stereo type.</param>
        /// <param name="customSpot">Optional custom spot.</param>
        /// <param name="tag">Optional tag.</param>
        /// <param name="url">Optional URL.</param>
        /// <param name="backgroundColor">Optional background color.</param>
        /// <param name="lineColor">Optional line color.</param>
        /// <param name="lineStyle">Optional line style.</param>
        /// <param name="extends">Optional extends.</param>
        /// <param name="implements">Optional implements.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void InterfaceStart(this StringBuilder stringBuilder, string name, string displayName = default, VisibilityModifier visibility = VisibilityModifier.None, string generics = default, string stereotype = default, CustomSpot customSpot = default, string tag = default, Uri url = default, Color backgroundColor = default, Color lineColor = default, LineStyle lineStyle = LineStyle.None, string[] extends = default, string[] implements = default)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.VisibilityChar(visibility);
            stringBuilder.ClassBase(ClassType.Interface, name, displayName, generics, stereotype, customSpot, tag, url, backgroundColor, lineColor, lineStyle, extends, implements);
            stringBuilder.ClassBaseStart();
        }

        /// <summary>
        /// Renders the end of an interface.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void InterfaceEnd(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.ClassBaseEnd();
        }
    }
}
