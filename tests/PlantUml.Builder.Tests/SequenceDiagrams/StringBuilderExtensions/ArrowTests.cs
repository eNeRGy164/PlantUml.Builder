using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests
{
    [TestClass]
    public class ArrowTests
    {
        [TestMethod]
        public void StringBuilderExtensions_Arrow_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.Arrow("l", "->", "r");

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_NullLeft_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow(null, "->", "r");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("left");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_EmptyLeft_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow(string.Empty, "->", "r");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("left");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WhitespaceLeft_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow(" ", "->", "r");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("left");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_NullType_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow("l", null, "r");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_EmptyType_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow("l", string.Empty, "r");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WhitespaceType_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow("l", " ", "r");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_NullRight_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow("l", "->", null);

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("right");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_EmptyRight_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow("l", "->", string.Empty);

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("right");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WhitespaceRight_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow("l", "->", " ");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("right");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_ArrowShouldBeAtLeastTwoLong_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Arrow("l", "-", "r");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The arrow type must be at least 2 characters long*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_Should_ContainArrowLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r");

            // Assert
            stringBuilder.ToString().Should().Be("l -> r\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithLabel_Should_ContainArrowLineWithLabel()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", label: "label1");

            // Assert
            stringBuilder.ToString().Should().Be("l -> r : label1\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithMultiLineLabel_Should_ContainArrowLineWithLabelWithEscapedNewLines()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", label: "label1\nlabel2");

            // Assert
            stringBuilder.ToString().Should().Be("l -> r : label1\\nlabel2\n");
        }

        //[TestMethod]
        //public void StringBuilderExtensions_Arrow_WithColor_Should_ContainArrowLineWithColor()
        //{
        //    // Assign
        //    var stringBuilder = new StringBuilder();

        //    // Act
        //    stringBuilder.Arrow("l", Arrow.Right(NamedColor.Blue), "r");

        //    // Assert
        //    stringBuilder.ToString().Should().Be("l -[#Blue]> r\n");
        //}

        //[TestMethod]
        //public void StringBuilderExtensions_Arrow_WithColorWithHashtag_Should_ContainArrowLineWithColor()
        //{
        //    // Assign
        //    var stringBuilder = new StringBuilder();

        //    // Act
        //    stringBuilder.Arrow("l", Arrow.Right("#Blue"), "r");

        //    // Assert
        //    stringBuilder.ToString().Should().Be("l -[#Blue]> r\n");
        //}

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithActivateTarget_Should_ContainArrowLineWithTargetActivation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", lifeEvents: LifeLineEvents.Activate);

            // Assert
            stringBuilder.ToString().Should().Be("l -> r ++\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithActivateTargetAndActivationColor_Should_ContainArrowLineWithTargetActivationWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", lifeEvents: LifeLineEvents.Activate, activationColor: "Blue");

            // Assert
            stringBuilder.ToString().Should().Be("l -> r ++ #Blue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithActivateTargetAndActivationColorWithHashTag_Should_ContainArrowLineWithTargetActivationWithColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", lifeEvents: LifeLineEvents.Activate, activationColor: "#Blue");

            // Assert
            stringBuilder.ToString().Should().Be("l -> r ++ #Blue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithActivationColorB_Should_ContainArrowLineWithActivationColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", activationColor: "#Blue");

            // Assert
            stringBuilder.ToString().Should().Be("l -> r #Blue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithDeactivateSource_Should_ContainArrowLineWithSourceDeactivation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", lifeEvents: LifeLineEvents.Deactivate);

            // Assert
            stringBuilder.ToString().Should().Be("l -> r --\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithCreateTargetInstance_Should_ContainArrowLineWithTargetInstanceCreation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", lifeEvents: LifeLineEvents.Create);

            // Assert
            stringBuilder.ToString().Should().Be("l -> r **\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithDestroyTargetInstance_Should_ContainArrowLineWithTargetInstanceDestruction()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l", "->", "r", lifeEvents: LifeLineEvents.Destroy);

            // Assert
            stringBuilder.ToString().Should().Be("l -> r !!\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Arrow_WithNewLineInParticipantName_Should_EscapeNewLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Arrow("l\nl", "->", "r\nr");

            // Assert
            stringBuilder.ToString().Should().Be("l\\nl -> r\\nr\n");
        }
    }
}
