using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders a skin parameter.
        /// </summary>
        /// <param name="name">The name of the skin parameter.</param>
        /// <param name="value">The value of the skin parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="value"/> is <c>null</c>, empty of only white space.</exception>
        public static void SkinParameter(this StringBuilder stringBuilder, string name, string value)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A non-empty value should be provided", nameof(value));

            stringBuilder.Append(Constant.Skin);
            stringBuilder.Append(Constant.Param);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(name.Trim());
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(value.Trim());
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders a skin parameter.
        /// </summary>
        /// <param name="skinParameter">The skin parameter.</param>
        /// <param name="value">The value of the skin parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="skinParameter"/> is not a <see cref="SkinParameter"/> value.</exception>
        public static void SkinParameter(this StringBuilder stringBuilder, SkinParameter skinParameter, string value)
        {
            if (!Enum.IsDefined(typeof(SkinParameter), skinParameter)) throw new ArgumentOutOfRangeException(nameof(skinParameter), "A defined enum value should be provided");

            stringBuilder.SkinParameter(skinParameter.ToString(), value);
        }

        /// <summary>
        /// Renders a skin parameter.
        /// </summary>
        /// <param name="name">The skin parameter.</param>
        /// <param name="value">The value of the skin parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void SkinParameter(this StringBuilder stringBuilder, string name, int value)
        {
            stringBuilder.SkinParameter(name, value.ToString());
        }

        /// <summary>
        /// Renders a skin parameter.
        /// </summary>
        /// <param name="skinParameter">The skin parameter.</param>
        /// <param name="value">The value of the skin parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="skinParameter"/> is not a <see cref="SkinParameter"/> value.</exception>
        public static void SkinParameter(this StringBuilder stringBuilder, SkinParameter skinParameter, int value)
        {
            stringBuilder.SkinParameter(skinParameter.ToString(), value.ToString());
        }

        /// <summary>
        /// Renders a skin parameter.
        /// </summary>
        /// <param name="name">The skin parameter.</param>
        /// <param name="value">The value of the skin parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void SkinParameter(this StringBuilder stringBuilder, string name, bool value)
        {
            stringBuilder.SkinParameter(name, value.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// Renders a skin parameter.
        /// </summary>
        /// <param name="skinParameter">The skin parameter.</param>
        /// <param name="value">The value of the skin parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="skinParameter"/> is not a <see cref="SkinParameter"/> value.</exception>
        public static void SkinParameter(this StringBuilder stringBuilder, SkinParameter skinParameter, bool value)
        {
            stringBuilder.SkinParameter(skinParameter.ToString(), value.ToString().ToLowerInvariant());
        }
    }
}
