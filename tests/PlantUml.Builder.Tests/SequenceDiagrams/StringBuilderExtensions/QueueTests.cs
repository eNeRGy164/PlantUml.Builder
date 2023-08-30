
namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class QueueTests
{
    [TestMethod]
    public void StringBuilderExtensions_Queue_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Queue("queueA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Queue_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Queue(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Queue_EmptyName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Queue(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Queue_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Queue(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Queue_Should_ContainQueueLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Queue("queueA");

        // Assert
        stringBuilder.ToString().Should().Be("queue queueA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Queue_WithDisplayName_Should_ContainQueueLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Queue("queueA", displayName: "Queue A");

        // Assert
        stringBuilder.ToString().Should().Be("queue \"Queue A\" as queueA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Queue_WithColor_Should_ContainQueueLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Queue("queueA", color: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("queue queueA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Queue_WithColorWithHashtag_Should_ContainQueueLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Queue("queueA", color: "#AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("queue queueA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Queue_WithOrder_Should_ContainQueueLineWithOrder()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Queue("queueA", order: 10);

        // Assert
        stringBuilder.ToString().Should().Be("queue queueA order 10\n");
    }
}
