using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class DatabaseTests
{
    [TestMethod]
    public void DatabaseNameCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Database(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("name");
    }

    [DataRow(EmptyString, DisplayName = "Database - Name argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Database - Name argument cannot be any whitespace character")]
    [TestMethod]
    public void DatabaseNameMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.Database(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("name");
    }

    [DynamicData(nameof(GetValidNotations), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetValidNotationTestDisplayName))]
    [TestMethod]
    public void DatabaseIsRenderedCorreclty(MethodExpectationTestData testData)
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
        yield return new object[] { new MethodExpectationTestData("Database", "database databaseA", "databaseA") };
        yield return new object[] { new MethodExpectationTestData("Database", "database \"Database A\" as databaseA", "databaseA", "Database A") };
        yield return new object[] { new MethodExpectationTestData("Database", "database databaseA #AliceBlue", "databaseA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("Database", "database databaseA order 10", "databaseA", null, null, 10) };

        yield return new object[] { new MethodExpectationTestData("CreateDatabase", "create database databaseA", "databaseA") };
        yield return new object[] { new MethodExpectationTestData("CreateDatabase", "create database \"Database A\" as databaseA", "databaseA", "Database A") };
        yield return new object[] { new MethodExpectationTestData("CreateDatabase", "create database databaseA #AliceBlue", "databaseA", null, (Color)"AliceBlue") };
        yield return new object[] { new MethodExpectationTestData("CreateDatabase", "create database databaseA order 10", "databaseA", null, null, 10) };
    }

    public static string GetValidNotationTestDisplayName(MethodInfo _, object[] data) => TestHelpers.GetValidNotationTestDisplayName(data);
}
