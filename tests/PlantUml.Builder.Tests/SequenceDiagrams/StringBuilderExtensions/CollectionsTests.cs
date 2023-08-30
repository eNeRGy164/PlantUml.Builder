
namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class CollectionsTests
{
    [TestMethod]
    public void StringBuilderExtensions_Collections_Null_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Collections("collectionsA");

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Collections_NullName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Collections(null);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Collections_EmptyName_Should_ThrowArgumentException()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Collections(string.Empty);

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Collections_WhitespaceName_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Collections(" ");

        // Assert
        action.Should().Throw<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_Collections_Should_ContainCollectionsLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Collections("collectionsA");

        // Assert
        stringBuilder.ToString().Should().Be("collections collectionsA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Collections_WithDisplayName_Should_ContainCollectionsLineWithDisplayName()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Collections("collectionsA", displayName: "Collections A");

        // Assert
        stringBuilder.ToString().Should().Be("collections \"Collections A\" as collectionsA\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Collections_WithColor_Should_ContainCollectionsLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Collections("collectionsA", color: "AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("collections collectionsA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Collections_WithColorWithHashtag_Should_ContainCollectionsLineWithColor()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Collections("collectionsA", color: "#AliceBlue");

        // Assert
        stringBuilder.ToString().Should().Be("collections collectionsA #AliceBlue\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Collections_WithOrder_Should_ContainCollectionsLineWithOrder()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Collections("collectionsA", order: 10);

        // Assert
        stringBuilder.ToString().Should().Be("collections collectionsA order 10\n");
    }
}
