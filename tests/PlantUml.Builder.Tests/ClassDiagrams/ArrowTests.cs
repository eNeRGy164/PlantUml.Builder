using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.ClassDiagrams.Tests;

[TestClass]
public class ArrowClassTests
{
    [TestMethod]
    public void ArrowCannotBeNullString()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow(null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("arrow");
    }

    [DataRow(EmptyString, DisplayName = "Arrow - Arrow argument cannot be empty")]
    [DataRow(AllWhitespace, DisplayName = "Arrow - Arrow argument cannot be whitespace")]
    [TestMethod]
    public void ArrowContainsAValue(string value)
    {
        // Arrange & Act
        Action action = () => _ = new Arrow(value);

        // Assert
        action.Should()
              .ThrowExactly<ArgumentException>()
              .WithParameterName("arrow");
    }

    [TestMethod]
    public void ArrowCannotBeConstructedWithOnlyASingleCharacter()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow("-");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("The arrow type must be at least 2 characters long*")
            .WithParameterName("arrow");
    }

    [TestMethod]
    public void ArrowCannotBeConstructedWithoutALineCharacter()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow("<>");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("The arrow must contain at least 1 line character*")
            .WithParameterName("arrow");
    }

    [TestMethod]
    public void ArrowCannotBeConstructedWithBothTypesOfLineCharacter()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow(".-");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("The arrow must contain either a dashed line ('.') or a solid line ('-'), but not both.*")
            .WithParameterName("arrow");
    }

    [DataRow("-->")]
    [DataRow("<|--#")]
    [DataRow("<--")]
    [DataRow("--")]
    [DataRow("..")]
    [TestMethod]
    public void ArrowStringConstructorShouldNotAlterValidInput(string input)
    {
        // Arrange & Act
        var arrow = new Arrow(input);

        // Assert
        arrow.ToString().Should().Be(input);
    }

    [TestMethod]
    public void ArrowRightHasEmptyLeftHead()
    {
        // Arrange
        var arrow = new Arrow("->");

        // Assert
        arrow.LeftHead.Should().BeEmpty();
    }

    [TestMethod]
    public void ArrowLeftHasEmptyRightHead()
    {
        // Arrange
        var arrow = new Arrow("<-");

        // Assert
        arrow.RightHead.Should().BeEmpty();
    }

    [TestMethod]
    public void ArrowStringCastIsRenderedCorrectly()
    {
        // Arrange
        var value = "-->";

        // Act
        var arrow = (Arrow)value;

        // Assert
        arrow.ToString().Should().Be("-->");
    }

    [TestMethod]
    public void ArrowStringCastReturnsCorrectString()
    {
        // Arrange
        var arrow = new Arrow("-->");

        // Act
        var value = (string)arrow;

        // Assert
        value.Should().Be("-->");
    }
}
