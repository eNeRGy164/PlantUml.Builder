namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the beginning of an alt.
    /// </summary>
    /// <param name="text">Optional text.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void AltStart(this StringBuilder stringBuilder, string text = null)
    {
        stringBuilder.GroupStart(Constant.Alt, text);
    }
}
