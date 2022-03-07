using System;
using System.Text;

namespace PlantUml.Builder.SequenceDiagrams
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders a reference over a participant.
        /// </summary>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="participant"/> is <c>null</c>, empty of only white space.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="note"/> is <c>null</c>, empty of only white space.</exception>
        public static void Ref(this StringBuilder stringBuilder, string participant, string note)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (string.IsNullOrWhiteSpace(participant)) throw new ArgumentException("A non-empty value should be provided", nameof(participant));
            if (string.IsNullOrWhiteSpace(note)) throw new ArgumentException("A non-empty value should be provided", nameof(note));

            stringBuilder.Append(Constant.Ref);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Over);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(participant);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Colon);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(note.Replace("\n", "\\n"));
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders a reference over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <param name="note">The text of the note.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="participantA"/> is <c>null</c>, empty of only white space.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="participantB"/> is <c>null</c>, empty of only white space.</exception>
        public static void Ref(this StringBuilder stringBuilder, string participantA, string participantB, string note)
        {
            if (string.IsNullOrWhiteSpace(participantA)) throw new ArgumentException("A non-empty value should be provided", nameof(participantA));
            if (string.IsNullOrWhiteSpace(participantB)) throw new ArgumentException("A non-empty value should be provided", nameof(participantB));

            stringBuilder.Ref(participantA + Constant.Comma + participantB, note);
        }

        /// <summary>
        /// Renders the start of a multiline note.
        /// </summary>
        /// <param name="participant">Optional participant. The position is relative to this participant.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="participant"/> is <c>null</c>, empty of only white space.</exception>
        public static void StartRef(this StringBuilder stringBuilder, string participant)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            if (string.IsNullOrWhiteSpace(participant)) throw new ArgumentException("A non-empty value should be provided", nameof(participant));

            stringBuilder.Append(Constant.Ref);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Over);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(participant);
            stringBuilder.AppendNewLine();
        }

        /// <summary>
        /// Renders the start of multiline over multiple participants.
        /// </summary>
        /// <param name="participantA">The first participant.</param>
        /// <param name="participantB">The second participant.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="participantA"/> is <c>null</c>, empty of only white space.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="participantB"/> is <c>null</c>, empty of only white space.</exception>
        public static void StartRef(this StringBuilder stringBuilder, string participantA, string participantB)
        {
            if (string.IsNullOrWhiteSpace(participantA)) throw new ArgumentException("A non-empty value should be provided", nameof(participantA));
            if (string.IsNullOrWhiteSpace(participantB)) throw new ArgumentException("A non-empty value should be provided", nameof(participantB));

            stringBuilder.StartRef(participantA + Constant.Comma + participantB);
        }

        /// <summary>
        /// Renders the end of a multiline note.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
        public static void EndRef(this StringBuilder stringBuilder)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

            stringBuilder.Append(Constant.End);
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Ref);
            stringBuilder.AppendNewLine();
        }
    }
}
