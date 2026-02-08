using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.Tests;

[TestClass]
public class SetNamespaceSeparatorTests
{
    [TestMethod]
    public void SetNamespaceSeparatorValueIsUsed()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.SetNamespaceSeparator("::");

        // Assert
        stringBuilder.ToString().ShouldBe("set namespaceSeparator ::\n");
    }

    [DataRow(null, DisplayName = "SetNamespaceSeparator - Separator is ignored if it is `null`")]
    [DataRow(EmptyString, DisplayName = "SetNamespaceSeparator - Separator is ignored if it is an empty string")]
    [DataRow(AllWhitespace, DisplayName = "SetNamespaceSeparator - Separator is ignored if it is contains only whitespaces")]
    [TestMethod]
    public void SetNamespaceSeparatorWithoutAValueSetsSeparatorToNone(string separator)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.SetNamespaceSeparator(separator);

        // Assert
        stringBuilder.ToString().ShouldBe("set namespaceSeparator none\n");
    }
}
