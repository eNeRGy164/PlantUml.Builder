using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders a stereotype.
        /// </summary>
        /// <param name="stereotype">Optional sterotype name.</param>
        /// <param name="customSpot">Optional custom spot.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StereoType(this StringBuilder stringBuilder, string stereotype = default, CustomSpot customSpot = default)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.SterotypeStart);

            if (!(customSpot is null))
            {
                stringBuilder.Append(Constant.CustomSpotStart);
                stringBuilder.Append(customSpot.Character);
                stringBuilder.Append(Constant.Comma);
                stringBuilder.Append(customSpot.Color);
                stringBuilder.Append(Constant.CustomSpotEnd);
            }

            stringBuilder.Append(stereotype);
            stringBuilder.Append(Constant.SterotypeEnd);
        }
    }
}
