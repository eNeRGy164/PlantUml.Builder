using System.Linq;

namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Hide entity members.
    /// </summary>
    /// <param name="name">The name to scope the members to hide.</param>
    /// <param name="portion">The portion to hide.</param>
    /// <param name="empty">Only hide the portions if there are no members present.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty, or only white space, or if <paramref name="portion"/> is not supplied.</exception>
    public static void HideEntityPortion(this StringBuilder stringBuilder, string name, EntityPortion portion, bool empty = false)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));
        if (portion == 0) throw new ArgumentException("An entity portion should be supplied", nameof(portion));

        stringBuilder.Append(Constant.Hide);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(name);
        stringBuilder.Append(Constant.Space);

        if (empty)
        {
            stringBuilder.Append(Constant.Empty);
            stringBuilder.Append(Constant.Space);
        }

        stringBuilder.Append(portion.ToString().ToLowerInvariant());
        stringBuilder.AppendNewLine();
    }

    /// <summary>
    /// Hide entity members.
    /// </summary>
    /// <param name="portion">The portion to hide.</param>
    /// <param name="visibilities">One or more visibilities to hide.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="portion"/> is not supplied.</exception>
    public static void HideEntityPortion(this StringBuilder stringBuilder, EntityPortion portion, params VisibilityModifier[] visibilities)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);

        if (portion == 0) throw new ArgumentException("An entity portion should be supplied", nameof(portion));

        stringBuilder.Append(Constant.Hide);
        stringBuilder.Append(Constant.Space);

        if (visibilities.Length > 0)
        {
            stringBuilder.AppendJoin(',', visibilities.Select(v => v.ToString().ToLowerInvariant()));
            stringBuilder.Append(Constant.Space);
        }

        stringBuilder.Append(portion.ToString().ToLowerInvariant());
        stringBuilder.AppendNewLine();
    }
}
