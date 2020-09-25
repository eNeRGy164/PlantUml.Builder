using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    public partial class ArrowExtensionsTests
    {
        [TestMethod]
        public void ArrowExtensions_Dotted_Null_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow.Dotted();

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void ArrowExtensions_Dotted_FromSolid_Should_BecomeDotted()
        {
            // Assign
            var originalArrow = new Arrow("->");

            // Act
            var arrow = originalArrow.Dotted();

            // Assert
            arrow.ToString().Should().Be("-->");
        }

        [TestMethod]
        public void ArrowExtensions_Dotted_FromDotted_Should_StayDotted()
        {
            // Assign
            var originalArrow = new Arrow("-->");

            // Act
            var arrow = originalArrow.Dotted();

            // Assert
            arrow.ToString().Should().Be("-->");
        }
    }
}
