namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a delay.
    /// </summary>
    /// <param name="message">Optional message for the delay.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    public static void Delay(this StringBuilder stringBuilder, string message = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Delay, 3);

        if (message is not null)
        {
            stringBuilder.Append(message);
            stringBuilder.Append(Constant.Delay, 3);
        }

        stringBuilder.AppendNewLine();
    }
}
