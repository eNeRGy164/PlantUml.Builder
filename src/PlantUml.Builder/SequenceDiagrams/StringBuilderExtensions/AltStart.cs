namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the beginning of an alt.
    /// </summary>
    /// <param name="text">Optional text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void AltStart(this StringBuilder stringBuilder, string text = null)
    {
        stringBuilder.GroupStart(Constant.Words.Alt, text);
    }
}
