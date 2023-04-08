using System;
using System.Text;

namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a object or class member declaration.
    /// </summary>
    /// <param name="name">The name of the object. The name can't contain spaces.</param>
    /// <param name="data">The member of the object or class.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> or <paramref name="data"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
    public static void MemberDeclaration(this StringBuilder stringBuilder, string name, ClassMember data)
    {
        if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));

        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));
        if (data is null) throw new ArgumentNullException(nameof(data));

        stringBuilder.Append(name);
        stringBuilder.Append(Constant.Space);
        stringBuilder.Append(Constant.Colon);
        stringBuilder.Append(Constant.Space);
        stringBuilder.InlineClassMember(data);
    }
}
