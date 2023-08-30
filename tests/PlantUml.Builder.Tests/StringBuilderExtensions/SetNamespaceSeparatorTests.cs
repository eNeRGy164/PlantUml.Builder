
namespace PlantUml.Builder.Tests;

[TestClass]
public class SetNamespaceSeparatorTests
{
    [TestMethod]
    public void StringBuilderExtensions_SetNamespaceSeparator_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.SetNamespaceSeparator();

        // Assert
        action.Should().Throw<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_SetNamespaceSeparator_WithSeparator_Should_ContainSetNamespaceSeparatorLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.SetNamespaceSeparator("::");

        // Assert
        stringBuilder.ToString().Should().Be("set namespaceSeparator ::\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_SetNamespaceSeparator_WithoutSeparator_Should_ContainSetNamespaceSeparatorNoneLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.SetNamespaceSeparator();

        // Assert
        stringBuilder.ToString().Should().Be("set namespaceSeparator none\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_SetNamespaceSeparator_WithSeparatorNull_Should_ContainSetNamespaceSeparatorNoneLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.SetNamespaceSeparator(null);

        // Assert
        stringBuilder.ToString().Should().Be("set namespaceSeparator none\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_SetNamespaceSeparator_WithSeparatorEmpty_Should_ContainSetNamespaceSeparatorNoneLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.SetNamespaceSeparator(string.Empty);

        // Assert
        stringBuilder.ToString().Should().Be("set namespaceSeparator none\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_SetNamespaceSeparator_WithSeparatorWhitespace_Should_ContainSetNamespaceSeparatorNoneLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.SetNamespaceSeparator(" ");

        // Assert
        stringBuilder.ToString().Should().Be("set namespaceSeparator none\n");
    }
}
