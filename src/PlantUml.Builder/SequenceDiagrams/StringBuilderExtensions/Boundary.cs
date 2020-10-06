using System;
using System.Text;

namespace PlantUml.Builder.SequenceDiagrams
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Create a boundary.
        /// </summary>
        /// <param name="name">The name of the control.</param>
        /// <param name="displayName">Optional display name of the control.</param>
        /// <param name="color">Optional color of the control.</param>
        /// <param name="order">Optional order of the control.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void Boundary(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
        {
            stringBuilder.ParticipantBase(ParticipantType.Boundary, name, displayName, color, order);
        }

        /// <summary>
        /// Create a boundary.
        /// </summary>
        /// <param name="name">The name of the control.</param>
        /// <param name="displayName">Optional display name of the participant.</param>
        /// <param name="color">Optional color of the control.</param>
        /// <param name="order">Optional order of the control.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void CreateBoundary(this StringBuilder stringBuilder, string name, string displayName = null, Color color = null, int? order = null)
        {
            stringBuilder.CreateParticipantBase(name, ParticipantType.Boundary, displayName, color, order);
        }
    }
}