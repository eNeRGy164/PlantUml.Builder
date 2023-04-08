using System;
using System.Text;

namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Deactivates the life line for an actor.
    /// </summary>
    /// <param name="name">The name of the life line to deactivate.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
    public static void Deactivate(this StringBuilder stringBuilder, string name)
    {
        if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));

        stringBuilder.Append(Constant.Deactivate);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(name);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Deactivates a life line.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void Deactivate(this StringBuilder stringBuilder)
    {
        if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

        stringBuilder.Append(Constant.Deactivate);
        stringBuilder.AppendNewLine();
    }
}
