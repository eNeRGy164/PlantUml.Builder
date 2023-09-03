namespace PlantUml.Builder;

public static partial class StringBuilderExtensions
{
    /// <summary>
    /// Renders a class member.
    /// </summary>
    /// <param name="classMember">The class member.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> or <paramref name="classMember"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <see langword="null"/>, empty of only white space.</exception>
    public static void InlineClassMember(this StringBuilder stringBuilder, ClassMember classMember)
    {
        ArgumentNullException.ThrowIfNull(stringBuilder);
        ArgumentNullException.ThrowIfNull(classMember);

        if (classMember.IsAbstract)
        {
            stringBuilder.Append(Constant.Modifiers.Start);
            stringBuilder.Append(Constant.Words.Abstract);
            stringBuilder.Append(Constant.Modifiers.End);
        }

        if (classMember.IsStatic)
        {
            stringBuilder.Append(Constant.Modifiers.Start);
            stringBuilder.Append(Constant.Words.Static);
            stringBuilder.Append(Constant.Modifiers.End);
        }

        stringBuilder.VisibilityChar(classMember.Visibility);
        stringBuilder.Append(classMember.Name);
        stringBuilder.AppendNewLine();
    }

    internal static void VisibilityChar(this StringBuilder stringBuilder, VisibilityModifier visibility)
    {
        switch (visibility)
        {
            case VisibilityModifier.Private:
                stringBuilder.Append(Constant.Visibility.Private);
                break;
            case VisibilityModifier.Protected:
                stringBuilder.Append(Constant.Visibility.Protected);
                break;
            case VisibilityModifier.PackagePrivate:
                stringBuilder.Append(Constant.Visibility.PackagePrivate);
                break;
            case VisibilityModifier.Public:
                stringBuilder.Append(Constant.Visibility.Public);
                break;
        }
    }
}
