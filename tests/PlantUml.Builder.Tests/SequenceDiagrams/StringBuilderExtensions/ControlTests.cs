using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ControlTests
{
    [TestMethod]
    public void ControlNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Control(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Control - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Control - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void ControlNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Control(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void ControlIsRenderedCorreclty(MethodExpectationTestData testData)
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
        // Define the valid notations and expected results for different overloads
        yield return new object[] { new MethodExpectationTestData("Control", "control controlA", "controlA") };
        yield return new object[] { new MethodExpectationTestData("Control", "control \"Control A\" as controlA", "controlA", "Control A") };
        yield return new object[] { new MethodExpectationTestData("Control", "control controlA #AliceBlue", "controlA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("Control", "control controlA order 10", "controlA", null, null, 10) };

        yield return new object[] { new MethodExpectationTestData("CreateControl", "create control controlA", "controlA") };
        yield return new object[] { new MethodExpectationTestData("CreateControl", "create control \"Control A\" as controlA", "controlA", "Control A") };
        yield return new object[] { new MethodExpectationTestData("CreateControl", "create control controlA #AliceBlue", "controlA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("CreateControl", "create control controlA order 10", "controlA", null, null, 10) };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
