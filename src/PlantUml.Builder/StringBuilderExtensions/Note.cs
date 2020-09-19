using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders a note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="style">The style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Note(this StringBuilder stringBuilder, NotePosition position, string note, NoteStyle style = NoteStyle.Normal, Color color = null)
        {
            stringBuilder.NoteBase(position, participant: null, style, color);

            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Colon);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(note.Replace("\n", "\\n"));
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders a note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="style">The style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Note(this StringBuilder stringBuilder, NotePosition position, string participant, string note, NoteStyle style = NoteStyle.Normal, Color color = null)
        {
            stringBuilder.NoteBase(position, participant, style, color);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Colon);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(note.Replace("\n", "\\n"));
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders a note over a participant.
        /// </summary>
        /// <param name="participant">The participant the note is positioned over.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="style">The style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Note(this StringBuilder stringBuilder, string participant, string note, NoteStyle style = NoteStyle.Normal, Color color = null)
        {
            stringBuilder.Note(NotePosition.Over, participant, note, style, color);
        }

        /// <summary>
        /// Renders a note over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="style">The style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Note(this StringBuilder stringBuilder, string participantA, string participantB, string note, NoteStyle style = NoteStyle.Normal, Color color = null)
        {
            stringBuilder.Note(NotePosition.Over, participantA + Constant.Comma + participantB, note, style, color);
        }

        /// <summary>
        /// Renders the start of a multiline note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="style">The style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartNote(this StringBuilder stringBuilder, NotePosition position, string participant = null, NoteStyle style = NoteStyle.Normal, Color color = null)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBase(position, participant, style, color);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the start of multiline note over a participant.
        /// </summary>
        /// <param name="participant">The participant the note is positioned over.</param>
        /// <param name="style">The style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartNote(this StringBuilder stringBuilder, string participant, NoteStyle style = NoteStyle.Normal, Color color = null)
        {
            stringBuilder.StartNote(NotePosition.Over, participant, style, color);
        }

        /// <summary>
        /// Renders the start of multiline over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="style">The style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartNote(this StringBuilder stringBuilder, string participantA, string participantB, NoteStyle style = NoteStyle.Normal, Color color = null)
        {
            stringBuilder.StartNote(NotePosition.Over, participantA + Constant.Comma + participantB, style, color);
        }

        /// <summary>
        /// Renders the end of a multiline note.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void EndNote(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBaseEnd();
        }

        /// <summary>
        /// Renders the end of a multiline rectangle note.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void EndRNote(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBaseEnd(NoteStyle.Box);
        }

        /// <summary>
        /// Renders the end of a multiline hexagonal note.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void EndHNote(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBaseEnd(NoteStyle.Hexagonal);
        }
    }
}
