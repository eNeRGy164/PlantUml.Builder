using System;
using System.Text;

namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the beginning of a loop.
    /// </summary>
    /// <param name="text">Optional text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void StartLoop(this StringBuilder stringBuilder, string text = null)
    {
        stringBuilder.GroupStart(Constant.Loop, text);
    }

    /// <summary>
    /// Renders the end of a loop.
    /// </summary>
    /// <param name="text">Optional text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void EndLoop(this StringBuilder stringBuilder)
    {
        stringBuilder.GroupEnd();
    }
}
