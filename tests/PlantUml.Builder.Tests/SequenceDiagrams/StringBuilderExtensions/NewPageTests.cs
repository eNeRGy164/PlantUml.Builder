using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class NewPageTests
{
    [TestMethod]
    public void NewPageTitleCannotBeNull()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.NewPage(null);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("title");
    }

    [DataRow(EmptyString, DisplayName = "NewPage - Title argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "NewPage - Title argument cannot be any whitespace character")]
    [TestMethod]
    public void NewPageTitleMustContainAValue(string name)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.NewPage(name);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithParameterName("title");
    }

    [DataRow(null, "newpage", DisplayName = "NewPage - Should Contain NewPage Line")]
    [DataRow("Page header", "newpage Page header", DisplayName = "NewPage - With Title Should Contain NewPage Line")]
    [DataRow("Page\nheader", "newpage Page\\nheader", DisplayName = "NewPage - With NewLine Should Escape NewLine")]
    [TestMethod]
    public void NewPageIsRenderedCorrectly(string title, string expected)
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        if (title is not null)
        {
            stringBuilder.NewPage(title);
        }
        else
        {
            stringBuilder.NewPage();
        }

        // Assert
        stringBuilder.ToString().Should().Be($"{expected}\n");
    }
}
