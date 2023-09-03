using static PlantUml.Builder.TestData;

namespace PlantUml.Builder.SequenceDiagrams.Tests;

[TestClass]
public class ArrowClassTests
{
    [TestMethod]
    public void ArrowCannotBeNullString()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow((string)null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithParameterName("arrow");
    }

        [TestMethod]
    public void ArrowCannotBeNullCharacterArray()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow((char[])null);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
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
    public void ArrowCannotBeConstructedWithoutAHeadElement()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow("--");

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("The arrow must contain at least 1 arrow head character ('>', '<', 'o', '/', '\\', 'x', ']', '[', '?').*")
            .WithParameterName("arrow");
    }

    [TestMethod]
    public void ArrowShouldConstructArrowFromCharacterArray()
    {
        // Arrange & Act
        var arrow = new Arrow('-', '>');

        // Assert
        arrow.ToString().Should().Be("->");
    }

    [DataRow("->")]
    [DataRow("<->")]
    [DataRow("<-[#red]>")]
    [TestMethod]
    public void ArrowStringConstructorShouldNotAlterValidInput(string input)
    {
        // Arrange & Act
        var arrow = new Arrow(input);

        // Assert
        arrow.ToString().Should().Be(input);
    }

    [TestMethod]
    public void ArrowConstructorChangesColor()
    {
        // Arrange
        var originalArrow = new Arrow("-[#red]>");

        // Act
        var arrow = new Arrow(originalArrow, NamedColor.AliceBlue);

        // Assert
        arrow.ToString().Should().Be("-[#AliceBlue]>");
    }

    [TestMethod]
    public void ArrowConstructorChangesLineToDotted()
    {
        // Arrange
        var originalArrow = new Arrow("-[#red]>");

        // Act
        var arrow = new Arrow(originalArrow, dottedLine: true);

        // Assert
        arrow.ToString().Should().Be("--[#red]>");
    }

    [TestMethod]
    public void ArrowConstructorChangesLineToSolid()
    {
        // Arrange
        var originalArrow = new Arrow("--[#red]>");

        // Act
        var arrow = new Arrow(originalArrow, dottedLine: false);

        // Assert
        arrow.ToString().Should().Be("-[#red]>");
    }

    [TestMethod]
    public void ArrowFullConstructorIsRenderedCorrectly()
    {
        // Act
        var arrow = new Arrow("<", dottedLine: false, ">", NamedColor.AliceBlue);

        // Assert
        arrow.ToString().Should().Be("<-[#AliceBlue]>");
    }

    [TestMethod]
    public void ArrowWithStartColorIsRenderedCorrectly()
    {
        // Act
        var arrow = new Arrow("[#red]->");

        // Assert
        arrow.ToString().Should().Be("-[#red]>");
    }

    [TestMethod]
    public void ArrowWithStartColorHasEmptyLeftHead()
    {
        // Act
        var arrow = new Arrow("[#red]->");

        // Assert
        arrow.LeftHead.Should().BeEmpty();
    }

    [TestMethod]
    public void ArrowWithLeftColorHasColor()
    {
        // Act
        var arrow = new Arrow("<[#red]-");

        // Assert
        arrow.Color.ToString().Should().Be("#red");
    }

    [TestMethod]
    public void ArrowWithIncompleteColorHasNoColor()
    {
        // Act
        var arrow = new Arrow("<-[");

        // Assert
        arrow.Color.Should().BeNull();
    }

    [TestMethod]
    public void ArrowWithExternalStartHasNoColor()
    {
        // Act
        var arrow = new Arrow("[->");

        // Assert
        arrow.Color.Should().BeNull();
    }

    [TestMethod]
    public void ArrowWithExternalEndHasCorrectRightHead()
    {
        // Act
        var arrow = new Arrow("->]");

        // Assert
        arrow.RightHead.Should().Be(">]");
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
    public void ArrowWithRightColorHasColor()
    {
        // Arrange
        var arrow = new Arrow("[#red]->");

        // Assert
        arrow.Color.ToString().Should().Be("#red");
    }

    [TestMethod]
    public void ArrowRightIsRenderedCorrectly()
    {
        // Arrange
        var arrow = Arrow.Right;

        // Assert
        arrow.ToString().Should().Be("->");
    }

    [TestMethod]
    public void ArrowRightWithColorIsRenderedCorrectly()
    {
        // Arrange
        var arrow = Arrow.Right.Color(NamedColor.AliceBlue);

        // Assert
        arrow.ToString().Should().Be("-[#AliceBlue]>");
    }

    [TestMethod]
    public void ArrowStringCastIsRenderedCorrectly()
    {
        // Arrange
        var value = "->";

        // Act
        var arrow = (Arrow)value;

        // Assert
        arrow.ToString().Should().Be("->");
    }

    [TestMethod]
    public void ArrowStringCastReturnsCorrectString()
    {
        // Arrange
        var arrow = new Arrow("->");

        // Act
        var value = (string)arrow;

        // Assert
        value.Should().Be("->");
    }
}
