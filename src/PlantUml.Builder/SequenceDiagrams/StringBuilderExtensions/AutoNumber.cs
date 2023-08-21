namespace PlantUml.Builder.SequenceDiagrams;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders the auto number keyword.
    /// </summary>
    /// <param name="start">Start number.</param>
    /// <param name="step">Optional step size.</param>
    /// <param name="format">Optional format.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    /// <remarks>
    /// <paramref name="start"/> can also be a 2 or 3 digit sequence using a field delimiter such as <c>.</c>, <c>;</c>, <c>,</c>, <c>:</c> or a mix of these.
    /// For example: <em>1.1.1</em> or <em>1.1:1</em>.
    /// </remarks>
    public static void AutoNumber(this StringBuilder stringBuilder, string start, int? step = null, string format = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (start is not null && string.IsNullOrWhiteSpace(start)) throw new ArgumentException("A non-empty value should be provided", nameof(start));
        if (format is not null && string.IsNullOrWhiteSpace(format)) throw new ArgumentException("A non-empty value should be provided", nameof(format));

        stringBuilder.Append(Constant.Auto);
        stringBuilder.Append(Constant.Number);

        if (!string.IsNullOrWhiteSpace(start))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(start);

            if (step.HasValue)
            {
                stringBuilder.Append(Constant.Space);
                stringBuilder.Append(step.Value);
            }
        }

        if (!string.IsNullOrEmpty(format))
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Quote);
            stringBuilder.Append(format);
            stringBuilder.Append(Constant.Quote);
        }

        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the auto number keyword.
    /// </summary>
    /// <param name="start">Optional start number.</param>
    /// <param name="step">Optional step size.</param>
    /// <param name="format">Optional format.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void AutoNumber(this StringBuilder stringBuilder, int? start = default, int? step = default, string format = default)
    {
        stringBuilder.AutoNumber(start.HasValue ? start.Value.ToString() : default, step, format);
    }

    /// <summary>
    /// Renders the autonumber stop keyword.
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void StopAutoNumber(this StringBuilder stringBuilder)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        stringBuilder.Append(Constant.Auto);
        stringBuilder.Append(Constant.Number);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(Constant.Stop);
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the autonumber resume keyword.
    /// </summary>
    /// <param name="step">Optional step size.</param>
    /// <param name="format">Optional format.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="format"/> is empty of only white space.</exception>
    public static void ResumeAutoNumber(this StringBuilder stringBuilder, int? step = null, string format = null)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (format is not null && string.IsNullOrWhiteSpace(format)) throw new ArgumentException("A non-empty value should be provided", nameof(format));

        stringBuilder.Append(Constant.Auto);
        stringBuilder.Append(Constant.Number);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(Constant.Resume);

        if (step.HasValue)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(step.Value);
        }

        if (format is not null)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(Constant.Quote);
            stringBuilder.Append(format);
            stringBuilder.Append(Constant.Quote);
        }

        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Renders the autonumber increase keyword.
    /// </summary>
    /// <param name="position">Optional digit to increase. <em>A</em> = first, <em>B</em> = second, etc.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <c>null</c>.</exception>
    public static void IncreaseAutoNumber(this StringBuilder stringBuilder, char? position = default)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (position.HasValue && (char.ToLower(position.Value) < 'a' || char.ToLower(position.Value) > 'z')) throw new ArgumentOutOfRangeException(nameof(position), "Only the characters A - Z are allowed");

        stringBuilder.Append(Constant.Auto);
        stringBuilder.Append(Constant.Number);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(Constant.Increase);

        if (position.HasValue)
        {
            stringBuilder.Append(Constant.Space);
            stringBuilder.Append(position);
        }

        stringBuilder.AppendNewLine();
    }
}
