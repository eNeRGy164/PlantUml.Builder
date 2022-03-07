namespace PlantUml.Builder.SequenceDiagrams
{
    public class LifeLineEvents
    {
        private readonly string value;

        private LifeLineEvents(params string[] values)
        {
            this.value = string.Join(string.Empty, values);
        }

        /// <summary>
        /// Makes no changes to any life lines.
        /// </summary>
        public static LifeLineEvents None => new();

        /// <summary>
        /// Creates an instance of the <em>target</em>.
        /// </summary>
        public static LifeLineEvents Create => new(Constant.TargetInstanceCreation);

        /// <inheritdoc cref="Create"/>
        public static LifeLineEvents CreateTargetInstance => Create;

        /// <summary>
        /// Destroys an instance of the <em>target</em>.
        /// </summary>
        public static LifeLineEvents Destroy => new(Constant.TargetInstanceDestruction);

        /// <inheritdoc cref="Destroy"/>
        public static LifeLineEvents DestroyTargetInstance => Destroy;

        /// <summary>
        /// Activates the <em>target</em>.
        /// </summary>
        /// <remarks>
        /// Optionally a <see cref="Color"/> may follow this.
        /// </remarks>
        public static LifeLineEvents Activate => new(Constant.TargetActivation);

        /// <inheritdoc cref="Activate"/>
        public static LifeLineEvents ActivateTarget => Activate;

        /// <summary>
        /// Deactivates the <em>source</em>.
        /// </summary>
        public static LifeLineEvents Deactivate => new(Constant.SourceDeactivation);

        /// <inheritdoc cref="Deactivate"/>
        public static LifeLineEvents DeactivateSource => Deactivate;

        /// <summary>
        /// Activates the <em>target</em>, then deactivates the <em>source</em>.
        /// </summary>
        public static LifeLineEvents ActivateDeactivate => new(Constant.TargetActivation, Constant.SourceDeactivation);

        /// <inheritdoc cref="ActivateDeactivate"/>
        public static LifeLineEvents ActivateTargetDeactivateSource => ActivateDeactivate;

        /// <summary>
        /// Deactivates the <em>source</em>, then activates the <em>target</em>.
        /// </summary>
        public static LifeLineEvents DeactivateActivate => new(Constant.SourceDeactivation, Constant.TargetActivation);

        /// <inheritdoc cref="DeactivateActivate"/>
        public static LifeLineEvents DeactivateSourceActivateTarget => DeactivateActivate;

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.value;
        }
    }
}
