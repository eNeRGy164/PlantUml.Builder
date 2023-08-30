
namespace PlantUml.Builder.Tests;

[TestClass]
public class HideEntityPortionTests
{
    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_NullWithNameAndPortion_Should_ThrowArgumentNullException()
    {
        // Arrange
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.HideEntityPortion("classA", EntityPortion.Members);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_NullWithPortion_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.HideEntityPortion(EntityPortion.Members);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithNullNameAndPortion_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.HideEntityPortion(null, EntityPortion.Members);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithEmptyNameAndPortion_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.HideEntityPortion(string.Empty, EntityPortion.Members);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithWhitespaceNameAndPortion_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.HideEntityPortion(" ", EntityPortion.Members);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("A non-empty value should be provided*")
            .And.ParamName.Should().Be("name");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithPortionNone_Should_ThrowArgumentException()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.HideEntityPortion(EntityPortion.None);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("An entity portion should be supplied*")
            .And.ParamName.Should().Be("portion");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithNameAndEntityPortionNone_Should_ThrowArgumentException()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        Action action = () => stringBuilder.HideEntityPortion("classA", EntityPortion.None);

        // Assert
        action.Should().ThrowExactly<ArgumentException>()
            .WithMessage("An entity portion should be supplied*")
            .And.ParamName.Should().Be("portion");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithNameAndPortion_Should_ContainHideEntityPortionLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HideEntityPortion("classA", EntityPortion.Members);

        // Assert
        stringBuilder.ToString().Should().Be("hide classA members\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithNameAndPortionEmpty_Should_ContainHideEntityPortionLineWithEmpty()
    {
        // Arrange
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HideEntityPortion("classA", EntityPortion.Members, empty: true);

        // Assert
        stringBuilder.ToString().Should().Be("hide classA empty members\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithPortion_Should_ContainHideEntityPortionLineWithPortion()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HideEntityPortion(EntityPortion.Members);

        // Assert
        stringBuilder.ToString().Should().Be("hide members\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithPortionAndVisibility_Should_ContainHideEntityPortionLineWithPortionAndVisibility()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HideEntityPortion(EntityPortion.Members, VisibilityModifier.Public);

        // Assert
        stringBuilder.ToString().Should().Be("hide public members\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_HideEntityPortion_WithPortionAndVisibilities_Should_ContainHideEntityPortionLineWithPortionAndVisibilities()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.HideEntityPortion(EntityPortion.Members, VisibilityModifier.Public, VisibilityModifier.Private);

        // Assert
        stringBuilder.ToString().Should().Be("hide public,private members\n");
    }
}
