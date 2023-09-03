using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class QueueTests
{
    [TestMethod]
    public void QueueNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Queue(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Queue - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Queue - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void QueueNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Queue(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void QueueIsRenderedCorreclty(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Queue", "queue queueA", "queueA").WithDisplayName("Queue - Basic notation") };
        yield return new object[] { new MethodExpectationTestData("Queue", "queue \"Queue A\" as queueA", "queueA", "Queue A").WithDisplayName("Queue - With display name") };
        yield return new object[] { new MethodExpectationTestData("Queue", "queue queueA #AliceBlue", "queueA", null, (Color)"AliceBlue").WithDisplayName("Queue - With color") };
        yield return new object[] { new MethodExpectationTestData("Queue", "queue queueA order 10", "queueA", null, null, 10).WithDisplayName("Queue - With order 10") };

        yield return new object[] { new MethodExpectationTestData("CreateQueue", "create queue queueA", "queueA").WithDisplayName("CreateQueue - Basic notation") };
        yield return new object[] { new MethodExpectationTestData("CreateQueue", "create queue \"Queue A\" as queueA", "queueA", "Queue A").WithDisplayName("CreateQueue - With display name") };
        yield return new object[] { new MethodExpectationTestData("CreateQueue", "create queue queueA #AliceBlue", "queueA", null, (Color)"AliceBlue").WithDisplayName("CreateQueue - With color") };
        yield return new object[] { new MethodExpectationTestData("CreateQueue", "create queue queueA order 10", "queueA", null, null, 10).WithDisplayName("CreateQueue - With order 10") };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
