namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ParticipantNameTests
{
    [DataRow("name", "name", DisplayName = "A simple word is good as name")]
    [DataRow("Foo0123456789", "Foo0123456789", DisplayName = "0 to 9 are accepted as valid characters")]
    [DataRow("Also@_.", "Also@_.", DisplayName = "Some characters are also allowed in the name")]
    [DataRow("Bob()", "\"Bob()\"", DisplayName = "Symbols required the name to be surrounded by quotes")]
    [DataRow("New\nLine", "\"New\\nLine\"", DisplayName = "New lines are escaped")]
    [DataRow("Bobby D as b", "\"Bobby D\" as b", DisplayName = "Long name without quotes and an alias are correctly recognized")]
    [DataRow("\"Bobby D\" as b", "\"Bobby D\" as b", DisplayName = "Long name without quotes and an alias are correctly recognized")]
    [DataRow("\"Bobby D\"as b", "\"Bobby D\" as b", DisplayName = "A space between quote and 'as' is optional")]
    [DataRow("b as Bobby D", "\"Bobby D\" as b", DisplayName = "Long name without quotes and an alias are correctly recognized")]
    [DataRow("b as\"Bobby D\"", "\"Bobby D\" as b", DisplayName = "Long name without quotes and an alias are correctly recognized")]
    [DataRow("b as \"Bobby D\"", "\"Bobby D\" as b", DisplayName = "Long name without quotes and an alias are correctly recognized")]
    [TestMethod]
    public void CanCastStringToParticipantName(string original, string expected)
    {
        // Arrange & Act
        ParticipantName participantName = original;

        // Assert
        participantName.ToString().Should().Be(expected);
    }
}
