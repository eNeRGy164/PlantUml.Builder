namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the beginning of a group with an 'else' condition.
    /// </summary>
    /// <param name="text">Optional text for the 'else' condition.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void ElseStart(this StringBuilder stringBuilder, string text = null)
    {
        stringBuilder.GroupStart(Constant.Words.Else, text);
    }
}
