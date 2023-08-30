namespace PlantUml.Builder;

public readonly record struct MethodExpectationTestData(string Method, string Expected, params object[] Parameters)
{
    public readonly string DisplayName { get; init; } = null;

    public MethodExpectationTestData WithDisplayName(string displayName) => this with { DisplayName = displayName };
}
