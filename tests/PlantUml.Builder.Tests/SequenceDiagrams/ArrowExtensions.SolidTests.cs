using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    public partial class ArrowExtensionsTests
    {
        [TestMethod]
        public void ArrowExtensions_Solid_Null_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow.Solid();

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void ArrowExtensions_Solid_FromSolid_Should_StaySolid()
        {
            // Assign
            var originalArrow = new Arrow("->");

            // Act
            var arrow = originalArrow.Solid();

            // Assert
            arrow.ToString().Should().Be("->");
        }

        [TestMethod]
        public void ArrowExtensions_Solid_FromDotted_Should_BecomeSolid()
        {
            // Assign
            var originalArrow = new Arrow("-->");

            // Act
            var arrow = originalArrow.Solid();

            // Assert
            arrow.ToString().Should().Be("->");
        }
    }
}
