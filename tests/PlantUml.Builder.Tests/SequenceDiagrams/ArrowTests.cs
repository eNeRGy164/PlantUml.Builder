using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public class ArrowTests
    {
        [TestMethod]
        public void Arrow_NullStringConstructor_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow = new Arrow((string)null);

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void Arrow_NullCharArrayConstructor_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow = new Arrow((char[])null);

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void Arrow_EmptyConstructor_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow = new Arrow(string.Empty);

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void Arrow_WhitespaceConstructor_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow = new Arrow("  ");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void Arrow_ShortStringConstructor_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow = new Arrow("-");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The arrow type must be at least 2 characters long*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void Arrow_NoLineConstructor_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow = new Arrow("<>");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The arrow must contain at least 1 line character*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void Arrow_NoArrowHeadConstructor_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow = new Arrow("--");

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The arrow must contain at least 1 arrow head character ('>', '<', 'o', '/', '\\', 'x', ']', '[').*")
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void Arrow_StringConstructor_ToString_Should_ReturnValue()
        {
            // Assign
            var arrow = new Arrow("->");

            // Assert
            arrow.ToString().Should().Be("->");
        }

        [TestMethod]
        public void Arrow_CharArrayConstructor_ToString_Should_ReturnValue()
        {
            // Assign
            var arrow = new Arrow('-', '>');

            // Assert
            arrow.ToString().Should().Be("->");
        }

        [TestMethod]
        public void Arrow_StringConstructorBidirectional_ToString_Should_ReturnValue()
        {
            // Assign
            var arrow = new Arrow("<->");

            // Assert
            arrow.ToString().Should().Be("<->");
        }

        [TestMethod]
        public void Arrow_StringConstructorWithColor_ToString_Should_ReturnValue()
        {
            // Assign
            var arrow = new Arrow("<-[#red]>");

            // Assert
            arrow.ToString().Should().Be("<-[#red]>");
        }

        [TestMethod]
        public void Arrow_ArrowConstructorWithColor_Should_ChangeColor()
        {
            // Assign
            var originalArrow = new Arrow("-[#red]>");

            // Act
            var arrow = new Arrow(originalArrow, NamedColor.AliceBlue);

            // Assert
            arrow.ToString().Should().Be("-[#AliceBlue]>");
        }

        [TestMethod]
        public void Arrow_ArrowConstructorWithDotted_Should_ChangeLineToDotted()
        {
            // Assign
            var originalArrow = new Arrow("-[#red]>");

            // Act
            var arrow = new Arrow(originalArrow, dottedLine: true);

            // Assert
            arrow.ToString().Should().Be("--[#red]>");
        }

        [TestMethod]
        public void Arrow_ArrowConstructorWithNotDotted_Should_ChangeLineToSolid()
        {
            // Assign
            var originalArrow = new Arrow("--[#red]>");

            // Act
            var arrow = new Arrow(originalArrow, dottedLine: false);

            // Assert
            arrow.ToString().Should().Be("-[#red]>");
        }

        [TestMethod]
        public void Arrow_FullConstructor_Should_BuildCompleteArrow()
        {
            // Act
            var arrow = new Arrow("<", dottedLine: false, ">", NamedColor.AliceBlue);

            // Assert
            arrow.ToString().Should().Be("<-[#AliceBlue]>");
        }

        [TestMethod]
        public void Arrow_StartWithColor_ToString_Should_ReturnValue()
        {
            // Act
            var arrow = new Arrow("[#red]->");

            // Assert
            arrow.ToString().Should().Be("-[#red]>");
        }

        [TestMethod]
        public void Arrow_StartWithColor_Should_HaveEmptyLeft()
        {
            // Act
            var arrow = new Arrow("[#red]->");

            // Assert
            arrow.LeftHead.Should().BeEmpty();
        }

        [TestMethod]
        public void Arrow_LeftWithColor_Should_HaveColor()
        {
            // Act
            var arrow = new Arrow("<[#red]-");

            // Assert
            arrow.Color.ToString().Should().Be("#red");
        }

        [TestMethod]
        public void Arrow_ColorStartCharacterAsLastChar_Should_NotBeAColor()
        {
            // Act
            var arrow = new Arrow("<-[");

            // Assert
            arrow.Color.Should().BeNull();
        }

        [TestMethod]
        public void Arrow_ExternalStart_Should_HaveNoColor()
        {
            // Act
            var arrow = new Arrow("[->");

            // Assert
            arrow.Color.Should().BeNull();
        }

        [TestMethod]
        public void Arrow_ExternalEnd_Should_HaveCorrectRightHead()
        {
            // Act
            var arrow = new Arrow("->]");

            // Assert
            arrow.RightHead.Should().Be(">]");
        }

        [TestMethod]
        public void Arrow_RightArrow_LeftHead_Should_BeEmpty()
        {
            // Assign
            var arrow = new Arrow("->");

            // Assert
            arrow.LeftHead.Should().BeEmpty();
        }

        [TestMethod]
        public void Arrow_LeftArrowRightHead_Should_BeEmpty()
        {
            // Assign
            var arrow = new Arrow("<-");

            // Assert
            arrow.RightHead.Should().BeEmpty();
        }

        [TestMethod]
        public void Arrow_StartWithColor_LeftHead_Should_BeEmpty()
        {
            // Assign
            var arrow = new Arrow("[#red]->");

            // Assert
            arrow.LeftHead.Should().BeEmpty();
        }

        [TestMethod]
        public void Arrow_StartWithColor_LeftHead_Should_HaveColor()
        {
            // Assign
            var arrow = new Arrow("[#red]->");

            // Assert
            arrow.Color.ToString().Should().Be("#red");
        }

        [TestMethod]
        public void Arrow_ArrowRight_ToString_Should_ReturnCorrectArrow()
        {
            // Assign
            var arrow = Arrow.Right;

            // Assert
            arrow.ToString().Should().Be("->");
        }

        [TestMethod]
        public void Arrow_ArrowRightWithColor_ToString_Should_ReturnCorrectArrow()
        {
            // Assign
            var arrow = Arrow.Right.Color(NamedColor.AliceBlue);

            // Assert
            arrow.ToString().Should().Be("-[#AliceBlue]>");
        }

        [TestMethod]
        public void Arrow_StringCast_Should_GiveCorrectArrow()
        {
            // Assign
            var value = "->";

            // Act
            var arrow = (Arrow)value;

            // Assert
            arrow.ToString().Should().Be("->");
        }

        [TestMethod]
        public void Arrow_CastString_Should_GiveCorrectString()
        {
            // Assign
            var arrow = new Arrow("->");

            // Act
            var value = (string)arrow;

            // Assert
            value.Should().Be("->");
        }
    }
}
