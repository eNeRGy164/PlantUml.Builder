using System.Linq;
using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.RegexOptions;

namespace PlantUml.Builder;

/// <summary>
/// Represents a class member.
/// </summary>
public class ClassMember
{
    private static readonly Regex modifiers = new("{(?<modifier>abstract|static)}", Singleline | Compiled | IgnoreCase);

    /// <summary>
    /// Gets the name of the class member.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a value indicating whether the class member is static.
    /// </summary>
    public bool IsStatic { get; }

    /// <summary>
    /// Gets a value indicating whether the class member is abstract.
    /// </summary>
    public bool IsAbstract { get; }

    /// <summary>
    /// Gets the visibility modifier of the class member.
    /// </summary>
    public VisibilityModifier Visibility { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClassMember"/> class.
    /// </summary>
    /// <param name="name">The name of the class member.</param>
    /// <param name="isStatic">Whether the member is public; default <see langword="false"/>.</param>
    /// <param name="isAbstract">Whether the member is abstract; default <see langword="false"/>.</param>
    /// <param name="visibility">Whether the members has a specific visibility; default <c>None</c>.</param>
    public ClassMember(string name, bool isStatic = false, bool isAbstract = false, VisibilityModifier visibility = VisibilityModifier.None)
    {
        ArgumentNullException.ThrowIfNull(name);
        if ((name.Length > 0 && string.IsNullOrWhiteSpace(name)) || (name.Length == 0 && !isStatic && !isAbstract)) throw new System.ArgumentException("A non-empty value should be provided", nameof(name));

        this.Name = name;
        this.IsStatic = isStatic;
        this.IsAbstract = isAbstract;
        this.Visibility = visibility;
    }

    /// <summary>
    /// Converts a string representation of a class member to its <see cref="ClassMember"/> equivalent.
    /// </summary>
    /// <param name="member">The string representation of the class member.</param>
    /// <returns>The equivalent <see cref="ClassMember"/> object.</returns>

    public static implicit operator ClassMember(string member)
    {
        ArgumentNullException.ThrowIfNull(member);

        var isAbstract = false;
        var isStatic = false;
        var visibilityModifier = VisibilityModifier.None;

        string value = member.Trim();

        if (!string.IsNullOrWhiteSpace(value))
        {
            var matches = modifiers.Matches(value).Cast<Match>();

            isAbstract = matches.Any(m => string.Equals(m.Groups["modifier"].Value, Constant.Abstract, StringComparison.OrdinalIgnoreCase));
            isStatic = matches.Any(m => string.Equals(m.Groups["modifier"].Value, Constant.Static, StringComparison.OrdinalIgnoreCase));

            value = modifiers.Replace(value, string.Empty).Trim();

            if (value.Length > 2 && value[0] != value[1])
            {
                switch (value[0])
                {
                    case Constant.Private:
                        visibilityModifier = VisibilityModifier.Private;
                        break;
                    case Constant.Protected:
                        visibilityModifier = VisibilityModifier.Protected;
                        break;
                    case Constant.PackagePrivate:
                        visibilityModifier = VisibilityModifier.PackagePrivate;
                        break;
                    case Constant.Public:
                        visibilityModifier = VisibilityModifier.Public;
                        break;
                }

                if (visibilityModifier != VisibilityModifier.None)
                {
                    value = value[1..].TrimStart();
                }
            }
        }

        return new ClassMember(value, isStatic, isAbstract, visibilityModifier);
    }
}
