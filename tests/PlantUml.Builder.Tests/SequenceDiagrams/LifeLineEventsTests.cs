namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class LifeLineEventsTests
{
    [TestMethod]
    [DynamicData(nameof(GetLifeLineEvents), DynamicDataSourceType.Method)]
    public void ReturnCorrectLifeLineEvent(string name, string expected)
    {
        // Arrange & Act
        var lifeLineEvents = typeof(LifeLineEvents).GetProperty(name).GetValue(null);

        // Assert
        lifeLineEvents.ToString().Should().Be(expected);
    }

    private static IEnumerable<object[]> GetLifeLineEvents()
    {
        yield return new[] { "None", "" };
        yield return new[] { "Activate", "++" };
        yield return new[] { "ActivateDeactivate", "++--" };
        yield return new[] { "ActivateTarget", "++" };
        yield return new[] { "ActivateTargetDeactivateSource", "++--" };
        yield return new[] { "Create", "**" };
        yield return new[] { "CreateTargetInstance", "**" };
        yield return new[] { "Deactivate", "--" };
        yield return new[] { "DeactivateActivate", "--++" };
        yield return new[] { "DeactivateSource", "--" };
        yield return new[] { "DeactivateSourceActivateTarget", "--++" };
        yield return new[] { "Destroy", "!!" };
        yield return new[] { "DestroyTargetInstance", "!!" };
    }

    public static string GetLifeLineEventsDisplayName(MethodInfo _, object[] data)
    {
        return $"The life line events \"{data[0]}\" should have the \"{data[1]}\" notation";
    }
}
