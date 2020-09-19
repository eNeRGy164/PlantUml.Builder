using System;
using System.Collections.Generic;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Create a control.
        /// </summary>
        /// <param name="name">The name of the control.</param>
        /// <param name="displayName">Optional display name of the control.</param>
        /// <param name="color">Optional color of the control.</param>
        /// <param name="order">Optional order of the control.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void Control(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
        {
            stringBuilder.Participant(name, displayName, ParticipantType.Control, color, order);
        }

        /// <summary>
        /// Create a control.
        /// </summary>
        /// <param name="name">The name of the control.</param>
        /// <param name="displayName">Optional display name of the control.</param>
        /// <param name="color">Optional color of the control.</param>
        /// <param name="order">Optional order of the control.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void CreateControl(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.Create);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Participant(name, displayName, ParticipantType.Control, color, order);
        }
    }
}
