using System;
using System.Text;

namespace PlantUml.Builder
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Renders a class member.
        /// </summary>
        /// <param name="classMember">The class member.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="stringBuilder"/> or <paramref name="classMember"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is <c>null</c>, empty of only white space.</exception>
        public static void InlineClassMember(this StringBuilder stringBuilder, ClassMember classMember)
        {
            if (stringBuilder is null) throw new ArgumentNullException(nameof(stringBuilder));
            if (classMember is null) throw new ArgumentNullException(nameof(classMember));

            if (classMember.IsAbstract)
            {
                stringBuilder.Append(Constant.ModifierStart);
                stringBuilder.Append(Constant.Abstract);
                stringBuilder.Append(Constant.ModifierEnd);
            }

            if (classMember.IsStatic)
            {
                stringBuilder.Append(Constant.ModifierStart);
                stringBuilder.Append(Constant.Static);
                stringBuilder.Append(Constant.ModifierEnd);
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
                    stringBuilder.Append(Constant.Private);
                    break;
                case VisibilityModifier.Protected:
                    stringBuilder.Append(Constant.Protected);
                    break;
                case VisibilityModifier.PackagePrivate:
                    stringBuilder.Append(Constant.PackagePrivate);
                    break;
                case VisibilityModifier.Public:
                    stringBuilder.Append(Constant.Public);
                    break;
            }
        }
    }
}
