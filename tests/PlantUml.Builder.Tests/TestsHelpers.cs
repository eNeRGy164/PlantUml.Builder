namespace PlantUml.Builder;

public static class TestHelpers
{
    /// <summary>
    /// Generates a descriptive display name for a test case based on the provided method information and data.
    /// </summary>
    /// <param name="data">An array of objects containing the test data. The first element should be a <see cref="MethodExpectationTestData"/> instance that encapsulates the details of the test case.</param>
    /// <returns>A string that represents a descriptive display name for the test case.</returns>
    /// <exception cref="ArgumentException">Thrown if the data array does not contain a <see cref="MethodExpectationTestData"/> instance as its first element.</exception>

    public static string GetValidNotationTestDisplayName(object[] data)
    {
        if (data[0] is not MethodExpectationTestData testData)
        {
            throw new ArgumentException($"Data array must contain a {nameof(MethodExpectationTestData)} instance.", nameof(data));
        }

        if (testData.DisplayName is not null)
        {
            return testData.DisplayName;
        }

        return BuildTestDescriptionForExtensionMethodWithOptionalParameters(testData);
    }

    /// <summary>
    /// Generates a descriptive display name for a test case that verifies if a method throws an exception when StringBuilder is null.
    /// </summary>
    /// <param name="data">An array of objects containing the test data. The first element should be a <see cref="MethodWithArgumentData"/> instance that encapsulates the details of the test case.</param>
    /// <returns>A string that represents a descriptive display name for the test case.</returns>
    /// <exception cref="ArgumentException">Thrown if the data array does not contain a <see cref="MethodWithArgumentData"/> instance as its first element.</exception>
    public static string GetStringBuilderExtensionMethodTestDisplayName(object[] data)
    {
        if (data[0] is not MethodWithArgumentData testData)
        {
            throw new ArgumentException($"Data array must contain a {nameof(MethodWithArgumentData)} instance.", nameof(data));
        }

        return $"{testData.Method} - Method \"{testData.Method}\" should throw an argument exception when StringBuilder is `null`";
    }

    /// <summary>
    /// Builds a test description for an extension method with optional parameters.
    /// </summary>
    /// <param name="methodName">The name of the method being tested.</param>
    /// <param name="methodParameters">The parameters for the method.</param>
    /// <param name="expected">The expected result of the method.</param>
    /// <returns>A string description of the test case.</returns>
    private static string BuildTestDescriptionForExtensionMethodWithOptionalParameters(MethodExpectationTestData testData)
    {
        var types = new StringBuilder();
        var values = new StringBuilder();

        for (var i = 0; i < testData.Parameters.Length; i++)
        {
            var type = testData.Parameters[i]?.GetType().Name ?? "Missing";
            var value = testData.Parameters[i] is null ? "null" : $"\"{testData.Parameters[i]}\"";

            if (i > 0)
            {
                types.Append(", ");
                values.Append(", ");
            }

            types.Append(type);
            values.Append(value);
        }

        var pluralS = testData.Parameters.Length == 1 ? "" : "s";

        return $"{testData.Method} - Method \"{testData.Method}({types})\" with parameter{pluralS} ({values}) should render as \"{testData.Expected}\\n\"";
    }
}
