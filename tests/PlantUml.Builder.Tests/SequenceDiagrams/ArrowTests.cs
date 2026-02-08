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
        action.ShouldThrowExactly<ArgumentNullException>()
            .WithParameterName("arrow");
    }

        [TestMethod]
    public void ArrowCannotBeNullCharacterArray()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow((char[])null);

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
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
        action.ShouldThrowExactly<ArgumentException>()
              .WithParameterName("arrow");
    }

    [TestMethod]
    public void ArrowCannotBeConstructedWithOnlyASingleCharacter()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow("-");

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithMessage("The arrow type must be at least 2 characters long*")
            .WithParameterName("arrow");
    }

    [TestMethod]
    public void ArrowCannotBeConstructedWithoutALineCharacter()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow("<>");

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithMessage("The arrow must contain at least 1 line character*")
            .WithParameterName("arrow");
    }

    [TestMethod]
    public void ArrowCannotBeConstructedWithoutAHeadElement()
    {
        // Arrange & Act
        Action action = () => _ = new Arrow("--");

        // Assert
        action.ShouldThrowExactly<ArgumentException>()
            .WithMessage("The arrow must contain at least 1 arrow head character ('>', '<', 'o', '/', '\\', 'x', ']', '[', '?').*")
            .WithParameterName("arrow");
    }

    [TestMethod]
    public void ArrowShouldConstructArrowFromCharacterArray()
    {
        // Arrange & Act
        var arrow = new Arrow('-', '>');

        // Assert
        arrow.ToString().ShouldBe("->");
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
        arrow.ToString().ShouldBe(input);
    }

    [TestMethod]
    public void ArrowConstructorChangesColor()
    {
        // Arrange
        var originalArrow = new Arrow("-[#red]>");

        // Act
        var arrow = new Arrow(originalArrow, NamedColor.AliceBlue);

        // Assert
        arrow.ToString().ShouldBe("-[#AliceBlue]>");
    }

    [TestMethod]
    public void ArrowConstructorChangesLineToDotted()
    {
        // Arrange
        var originalArrow = new Arrow("-[#red]>");

        // Act
        var arrow = new Arrow(originalArrow, dottedLine: true);

        // Assert
        arrow.ToString().ShouldBe("--[#red]>");
    }

    [TestMethod]
    public void ArrowConstructorChangesLineToSolid()
    {
        // Arrange
        var originalArrow = new Arrow("--[#red]>");

        // Act
        var arrow = new Arrow(originalArrow, dottedLine: false);

        // Assert
        arrow.ToString().ShouldBe("-[#red]>");
    }

    [TestMethod]
    public void ArrowFullConstructorIsRenderedCorrectly()
    {
        // Act
        var arrow = new Arrow("<", dottedLine: false, ">", NamedColor.AliceBlue);

        // Assert
        arrow.ToString().ShouldBe("<-[#AliceBlue]>");
    }

    [TestMethod]
    public void ArrowWithStartColorIsRenderedCorrectly()
    {
        // Act
        var arrow = new Arrow("[#red]->");

        // Assert
        arrow.ToString().ShouldBe("-[#red]>");
    }

    [TestMethod]
    public void ArrowWithStartColorHasEmptyLeftHead()
    {
        // Act
        var arrow = new Arrow("[#red]->");

        // Assert
        arrow.LeftHead.ShouldBeEmpty();
    }

    [TestMethod]
    public void ArrowWithLeftColorHasColor()
    {
        // Act
        var arrow = new Arrow("<[#red]-");

        // Assert
        arrow.Color.ToString().ShouldBe("#red");
    }

    [TestMethod]
    public void ArrowWithIncompleteColorHasNoColor()
    {
        // Act
        var arrow = new Arrow("<-[");

        // Assert
        arrow.Color.ShouldBeNull();
    }

    [TestMethod]
    public void ArrowWithExternalStartHasNoColor()
    {
        // Act
        var arrow = new Arrow("[->");

        // Assert
        arrow.Color.ShouldBeNull();
    }

    [TestMethod]
    public void ArrowWithExternalEndHasCorrectRightHead()
    {
        // Act
        var arrow = new Arrow("->]");

        // Assert
        arrow.RightHead.ShouldBe(">]");
    }

    [TestMethod]
    public void ArrowRightHasEmptyLeftHead()
    {
        // Arrange
        var arrow = new Arrow("->");

        // Assert
        arrow.LeftHead.ShouldBeEmpty();
    }

    [TestMethod]
    public void ArrowLeftHasEmptyRightHead()
    {
        // Arrange
        var arrow = new Arrow("<-");

        // Assert
        arrow.RightHead.ShouldBeEmpty();
    }

    [TestMethod]
    public void ArrowWithRightColorHasColor()
    {
        // Arrange
        var arrow = new Arrow("[#red]->");

        // Assert
        arrow.Color.ToString().ShouldBe("#red");
    }

    [TestMethod]
    public void ArrowRightIsRenderedCorrectly()
    {
        // Arrange
        var arrow = Arrow.Right;

        // Assert
        arrow.ToString().ShouldBe("->");
    }

    [TestMethod]
    public void ArrowRightWithColorIsRenderedCorrectly()
    {
        // Arrange
        var arrow = Arrow.Right.Color(NamedColor.AliceBlue);

        // Assert
        arrow.ToString().ShouldBe("-[#AliceBlue]>");
    }

    [TestMethod]
    public void ArrowStringCastIsRenderedCorrectly()
    {
        // Arrange
        var value = "->";

        // Act
        var arrow = (Arrow)value;

        // Assert
        arrow.ToString().ShouldBe("->");
    }

    [TestMethod]
    public void ArrowStringCastReturnsCorrectString()
    {
        // Arrange
        var arrow = new Arrow("->");

        // Act
        var value = (string)arrow;

        // Assert
        value.ShouldBe("->");
    }
}
