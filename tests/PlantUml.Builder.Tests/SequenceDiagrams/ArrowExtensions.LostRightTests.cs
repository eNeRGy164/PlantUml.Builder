using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    public partial class ArrowExtensionsTests
    {
        [TestMethod]
        public void ArrowExtensions_LostRight_Null_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow.LostRight();

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void ArrowExtensions_LostRight_ArrowRight_Should_BecomeLost()
        {
            // Assign
            var originalArrow = new Arrow("->");

            // Act
            var arrow = originalArrow.LostRight();

            // Assert
            arrow.ToString().Should().Be("->o");
        }

        [TestMethod]
        public void ArrowExtensions_LostRight_FromDestroyedArrowLeft_Should_ThrowNotSupportedException()
        {
            // Assign
            var originalArrow = new Arrow("<-x");

            // Act
            Action action = () => originalArrow.LostRight();

            // Assert
            action.Should().ThrowExactly<NotSupportedException>()
                .WithMessage("You can not combine the lost and deleted message notation in the same arrow head.*");
        }

        [TestMethod]
        public void ArrowExtensions_LostRight_ArrowLeft_Should_BecomeFound()
        {
            // Assign
            var originalArrow = new Arrow("<-");

            // Act
            var arrow = originalArrow.LostRight();

            // Assert
            arrow.ToString().Should().Be("<-o");
        }

        [TestMethod]
        public void ArrowExtensions_LostRight_DottedArrowLeft_Should_BecomeDottedFound()
        {
            // Assign
            var originalArrow = new Arrow("<--");

            // Act
            var arrow = originalArrow.LostRight();

            // Assert
            arrow.ToString().Should().Be("<--o");
        }

        [TestMethod]
        public void ArrowExtensions_LostRight_LostArrowLeft_Should_StayLost()
        {
            // Assign
            var originalArrow = new Arrow("<--o");

            // Act
            var arrow = originalArrow.LostRight();

            // Assert
            arrow.ToString().Should().Be("<--o");
        }
    }
}
