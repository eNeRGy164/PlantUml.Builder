using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class RelationshipDefaultsTests
{
    [DynamicData(nameof(GetDefaultRelationships), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetDefaultRelationshipsDisplayName))]
    [TestMethod]
    public void ReturnCorrectDefaultRelationshipNotation(string name, string expected)
    {
        // Arrange & Act
        var relationship = typeof(Relationship).GetField(name).GetValue(null);

        // Assert
        relationship.ToString().ShouldBe(expected);
    }

    private static IEnumerable<object[]> GetDefaultRelationships()
    {
        yield return new[] { "Associates", "--" };
        yield return new[] { "IsAssociatedWith", "--" };
        yield return new[] { "AssociatesDirectlyWith", "<--" };
        yield return new[] { "IsDirectlyAssociatedWith", "-->" };
        yield return new[] { "AssociatesStrongly", "--+" };
        yield return new[] { "IsStronglyAssociatedWith", "+--" };
        yield return new[] { "AssociatesSpeciallyWith", "--#" };
        yield return new[] { "IsSpeciallyAssociatedWith", "#--" };
        yield return new[] { "Disallows", "--x" };
        yield return new[] { "IsDisallowedBy", "x--" };
        yield return new[] { "Aggregates", "--o" };
        yield return new[] { "IsAggregatedBy", "o--" };
        yield return new[] { "Composes", "--*" };
        yield return new[] { "IsComposedBy", "*--" };
        yield return new[] { "ComposesDirectly", "*-->" };
        yield return new[] { "IsDirectlyComposedBy", "<--*" };
        yield return new[] { "InheritsFrom", "<|--" };
        yield return new[] { "IsInheritedBy", "--|>" };
        yield return new[] { "Realizes", "<|.." };
        yield return new[] { "IsRealizedBy", "..|>" };
        yield return new[] { "DependsOn", ".." };
        yield return new[] { "IsDependedUponBy", ".." };
        yield return new[] { "DependsDirectlyOn", "..>" };
        yield return new[] { "IsDirectlyDependedUponBy", "<.." };
        yield return new[] { "ContainsManyOf", "}--" };
        yield return new[] { "IsContainedBy", "--{" };
    }

    public static string GetDefaultRelationshipsDisplayName(MethodInfo _, object[] data) => $"The default \"{data[0]}\" should have the \"{data[1]}\" notation";
}
