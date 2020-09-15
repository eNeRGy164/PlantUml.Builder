using System;

namespace PlantUml.Builder
{
    public class ClassMember
    {
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
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("A non-empty value should be provided", nameof(name));

            this.Name = name;
            this.IsStatic = isStatic;
            this.IsAbstract = isAbstract;
            this.Visibility = visibility;
        }
    }
}
