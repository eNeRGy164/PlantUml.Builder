using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class HideEntityPortionTests
{
    [TestMethod]
    public void HideEntityPortionNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.HideEntityPortion(null, EntityPortion.Members);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EntityPortion.None, DisplayName = "HideEntityPortion - Portion argument is None")]
    [DataRow(-1, DisplayName = "HideEntityPortion - Portion argument is an invalid enum value")]
    [TestMethod]
    public void HideEntityPortionMustBeValidEnumValue(int portion)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action1 = () => stringBuilder.HideEntityPortion(AnyString, (EntityPortion)portion);
        Action action2 = () => stringBuilder.HideEntityPortion((EntityPortion)portion);

        // Assert
        action1.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithParameterName("portion");

        action2.Should()
            .ThrowExactly<ArgumentOutOfRangeException>()
            .WithParameterName("portion");
    }

    [DataRow(EmptyString, DisplayName = "HideEntityPortion - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "HideEntityPortion - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void HideEntityPortionNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.HideEntityPortion(name, EntityPortion.Members);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetMethodTestDisplayName))]
    [TestMethod]
    public void HideEntityPortionIsRenderedCorrectly(MethodExpectationTestData testData)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        var (method, parameters) = typeof(StringBuilderExtensions).GetExtensionMethodAndParameters(stringBuilder, testData.Method, testData.Parameters);

        // Act
        method.Invoke(null, parameters);

        // Assert
        stringBuilder.ToString().Should().Be($"{testData.Expected}\n");
    }

    private static IEnumerable<object[]> GetValidNotations()
    {
        yield return new object[] { new MethodExpectationTestData("HideEntityPortion", "hide classA members", "classA", EntityPortion.Members) };
        yield return new object[] { new MethodExpectationTestData("HideEntityPortion", "hide classA empty members", "classA", EntityPortion.Members, true) };
        yield return new object[] { new MethodExpectationTestData("HideEntityPortion", "hide members", EntityPortion.Members) };
        yield return new object[] { new MethodExpectationTestData("HideEntityPortion", "hide public members", EntityPortion.Members, VisibilityModifier.Public) };
        yield return new object[] { new MethodExpectationTestData("HideEntityPortion", "hide public,private members", EntityPortion.Members, VisibilityModifier.Public, VisibilityModifier.Private) };
    }

    public static string GetMethodTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
