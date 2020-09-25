using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public partial class ArrowExtensionsTests
    {
        [TestMethod]
        public void ArrowExtensions_Color_Null_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow.Color(NamedColor.Red);

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void ArrowExtensions_Color_NullColor_Should_ChangeNothing()
        {
            // Assign
            var originalArrow = new Arrow("->");

            // Act
            var arrow = originalArrow.Color(null);

            // Assert
            arrow.ToString().Should().Be("->");
        }

        [TestMethod]
        public void ArrowExtensions_Color_WithColorOnArrowWithoutColor_Should_AddColor()
        {
            // Assign
            var originalArrow = new Arrow("->");

            // Act
            var arrow = originalArrow.Color(NamedColor.Red);

            // Assert
            arrow.ToString().Should().Be("-[#Red]>");
        }

        [TestMethod]
        public void ArrowExtensions_Color_WithColorOnArrowWithOtherColor_Should_ChangeColor()
        {
            // Assign
            var originalArrow = new Arrow("-[#Orange]>");

            // Act
            var arrow = originalArrow.Color(NamedColor.Blue);

            // Assert
            arrow.ToString().Should().Be("-[#Blue]>");
        }
    }
}
