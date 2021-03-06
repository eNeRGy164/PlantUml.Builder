using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Base for rendering a note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="style">The style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <param name="color"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        internal static void NoteBase(this StringBuilder stringBuilder, NotePosition position, string participant = null, NoteStyle style = NoteStyle.Normal, Color color = null)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            switch (style)
            {
                case NoteStyle.Hexagonal:
                    stringBuilder.Append(Constant.NoteHexagon);
                    break;

                case NoteStyle.Box:
                    stringBuilder.Append(Constant.NoteBox);
                    break;
            }

            stringBuilder.Append(Constant.Note);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(position.ToString().ToLowerInvariant());

            if (!string.IsNullOrWhiteSpace(participant))
            {
                if (position != NotePosition.Over)
                {
                    stringBuilder.Append(Constant.Space);
                    stringBuilder.Append(Constant.Of);
                }

                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(participant);
            }

            if (!(color is null))
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(color);
            }
        }

        /// <summary>
        /// Base for rendering the end of a class.
        /// </summary>
        internal static void NoteBaseEnd(this StringBuilder stringBuilder, NoteStyle style = NoteStyle.Normal)
        {
            stringBuilder.Append(Constant.End);
            stringBuilder.Append(Constant.Space);

            switch (style)
            {
                case NoteStyle.Hexagonal:
                    stringBuilder.Append(Constant.NoteHexagon);
                    break;
                case NoteStyle.Box:
                    stringBuilder.Append(Constant.NoteBox);
                    break;
            }
            
            stringBuilder.Append(Constant.Note);
            stringBuilder.AppendNewLine();
        }
    }
}
