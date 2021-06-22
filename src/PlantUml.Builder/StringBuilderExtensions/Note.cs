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
        /// <param name="style">Optional style of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Note(this StringBuilder stringBuilder, NotePosition position, string note, NoteStyle style = NoteStyle.Normal, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.NoteBase(position, participant: null, style, color, alignWithPrevious);

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
        /// <param name="style">Optional of note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Note(this StringBuilder stringBuilder, NotePosition position, string participant, string note, NoteStyle style = NoteStyle.Normal, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.NoteBase(position, participant, style, color, alignWithPrevious);
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
        /// <param name="style">Optional styleof note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Note(this StringBuilder stringBuilder, string participant, string note, NoteStyle style = NoteStyle.Normal, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(NotePosition.Over, participant, note, style, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a note over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="style">Optional styleof note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void Note(this StringBuilder stringBuilder, string participantA, string participantB, string note, NoteStyle style = NoteStyle.Normal, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(NotePosition.Over, participantA + Constant.Comma + participantB, note, style, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a hexagonal note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void HNote(this StringBuilder stringBuilder, NotePosition position, string note, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(position, note, NoteStyle.Hexagonal, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a hexagonal note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void HNote(this StringBuilder stringBuilder, NotePosition position, string participant, string note, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(position, participant, note, NoteStyle.Hexagonal, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a hexagonal note over a participant.
        /// </summary>
        /// <param name="participant">The participant the note is positioned over.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void HNote(this StringBuilder stringBuilder, string participant, string note, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(NotePosition.Over, participant, note, NoteStyle.Hexagonal, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a hexagonal note over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void HNote(this StringBuilder stringBuilder, string participantA, string participantB, string note, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(participantA, participantB, note, NoteStyle.Hexagonal, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a rectangle note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void RNote(this StringBuilder stringBuilder, NotePosition position, string note, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(position, note, NoteStyle.Box, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a rectangle note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void RNote(this StringBuilder stringBuilder, NotePosition position, string participant, string note, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(position, participant, note, NoteStyle.Box, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a rectangle note over a participant.
        /// </summary>
        /// <param name="participant">The participant the note is positioned over.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void RNote(this StringBuilder stringBuilder, string participant, string note, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(NotePosition.Over, participant, note, NoteStyle.Box, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders a rectangle note over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void RNote(this StringBuilder stringBuilder, string participantA, string participantB, string note, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.Note(participantA, participantB, note, NoteStyle.Box, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders the start of a multiline note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="style">Optional styleof note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartNote(this StringBuilder stringBuilder, NotePosition position, string participant = null, NoteStyle style = NoteStyle.Normal, Color color = null, bool alignWithPrevious = false)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBase(position, participant, style, color, alignWithPrevious);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the start of multiline note over a participant.
        /// </summary>
        /// <param name="participant">The participant the note is positioned over.</param>
        /// <param name="style">Optional styleof note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartNote(this StringBuilder stringBuilder, string participant, NoteStyle style = NoteStyle.Normal, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.StartNote(NotePosition.Over, participant, style, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders the start of multiline note over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="style">Optional styleof note. Default <see cref="NoteStyle.Normal"/>.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartNote(this StringBuilder stringBuilder, string participantA, string participantB, NoteStyle style = NoteStyle.Normal, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.StartNote(NotePosition.Over, participantA + Constant.Comma + participantB, style, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders the start of a multiline hexagonal note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartHNote(this StringBuilder stringBuilder, NotePosition position, string participant = null, Color color = null, bool alignWithPrevious = false)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBase(position, participant, NoteStyle.Hexagonal, color, alignWithPrevious);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the start of multiline hexagonal note over a participant.
        /// </summary>
        /// <param name="participant">The participant the note is positioned over.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartHNote(this StringBuilder stringBuilder, string participant, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.StartNote(NotePosition.Over, participant, NoteStyle.Hexagonal, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders the start of multiline hexagonal note over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartHNote(this StringBuilder stringBuilder, string participantA, string participantB, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.StartNote(NotePosition.Over, participantA + Constant.Comma + participantB, NoteStyle.Hexagonal, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders the start of a multiline rectangle note.
        /// </summary>
        /// <param name="position">The position of the note.</param>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartRNote(this StringBuilder stringBuilder, NotePosition position, string participant = null, Color color = null, bool alignWithPrevious = false)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBase(position, participant, NoteStyle.Box, color, alignWithPrevious);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the start of multiline rectangle note over a participant.
        /// </summary>
        /// <param name="participant">The participant the note is positioned over.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartRNote(this StringBuilder stringBuilder, string participant, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.StartNote(NotePosition.Over, participant, NoteStyle.Box, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders the start of multiline rectangle note over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="color">Optional backgrond color.</param>
        /// <param name="alignWithPrevious">Optional alignment with the previous note. Default <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void StartRNote(this StringBuilder stringBuilder, string participantA, string participantB, Color color = null, bool alignWithPrevious = false)
        {
            stringBuilder.StartNote(NotePosition.Over, participantA + Constant.Comma + participantB, NoteStyle.Box, color, alignWithPrevious);
        }

        /// <summary>
        /// Renders the end of a multiline note.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void EndNote(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBaseEnd();
        }

        /// <summary>
        /// Renders the end of a multiline rectangle note.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void EndRNote(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBaseEnd(NoteStyle.Box);
        }

        /// <summary>
        /// Renders the end of a multiline hexagonal note.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void EndHNote(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.NoteBaseEnd(NoteStyle.Hexagonal);
        }
    }
}
