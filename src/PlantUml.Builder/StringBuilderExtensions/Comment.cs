using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders a comment.
        /// </summary>
        /// <param name="comment">Optional comment text.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Comment(this StringBuilder stringBuilder, string comment = "")
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (comment.IndexOf('\n') == -1)
            {
                stringBuilder.Append(Constant.Comment);
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(comment);
                stringBuilder.AppendNewLine();
            }
            else
            {
                stringBuilder.Append(Constant.CommentStart);
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(comment);
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(Constant.CommentEnd);
                stringBuilder.AppendNewLine();
            }
        }
    }
}
