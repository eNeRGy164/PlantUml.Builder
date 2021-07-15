using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlantUml.Builder
{
    public class ClassMember
    {
        private static readonly Regex modifiers = new("{(?<modifier>abstract|static)}", RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public string Name { get; }

        public bool IsStatic { get; }

        public bool IsAbstract { get; }

        public VisibilityModifier Visibility { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name of the class member.</param>
        /// <param name="isStatic">Whether the member is public; default <c>false</c>.</param>
        /// <param name="isAbstract">Whether the member is abstract; default <c>false</c>.</param>
        /// <param name="visibility">Whether the members has a specific visibility; default <c>None</c>.</param>
        public ClassMember(string name, bool isStatic = false, bool isAbstract = false, VisibilityModifier visibility = VisibilityModifier.None)
        {
            if (name is null) throw new ArgumentException("A non-empty value should be provided", nameof(name));
            if ((name.Length > 0 && string.IsNullOrWhiteSpace(name)) || (name.Length == 0 && !isStatic && !isAbstract)) throw new ArgumentException("A non-empty value should be provided", nameof(name));

            this.Name = name;
            this.IsStatic = isStatic;
            this.IsAbstract = isAbstract;
            this.Visibility = visibility;
        }

        public static implicit operator ClassMember(string member)
        {
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
                        value = value.Substring(1).TrimStart();
                    }
                }
            }

            return new ClassMember(value, isStatic, isAbstract, visibilityModifier);
        }
    }
}
