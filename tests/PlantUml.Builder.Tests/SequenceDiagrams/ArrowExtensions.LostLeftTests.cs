using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    public partial class ArrowExtensionsTests
    {
        [TestMethod]
        public void ArrowExtensions_LostLeft_Null_Should_ThrowArgumentException()
        {
            // Assign
            Arrow arrow = null;

            // Act
            Action action = () => arrow.LostLeft();

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("arrow");
        }

        [TestMethod]
        public void ArrowExtensions_LostLeft_FromDestroyedArrowRight_Should_ThrowNotSupportedException()
        {
            // Assign
            var originalArrow = new Arrow("x->");

            // Act
            Action action = () => originalArrow.LostLeft();

            // Assert
            action.Should().ThrowExactly<NotSupportedException>()
                .WithMessage("You can not combine the lost and deleted message notation in the same arrow head.*");
        }

        [TestMethod]
        public void ArrowExtensions_LostLeft_ArrowLeft_Should_BecomeLost()
        {
            // Assign
            var originalArrow = new Arrow("<-");
            // Act
            var arrow = originalArrow.LostLeft();
            // Assert
            arrow.ToString().Should().Be("o<-");
        }

        [TestMethod]
        public void ArrowExtensions_LostLeft_ArrowRight_Should_BecomeFound()
        {
            // Assign
            var originalArrow = new Arrow("->");

            // Act
            var arrow = originalArrow.LostLeft();

            // Assert
            arrow.ToString().Should().Be("o->");
        }

        [TestMethod]
        public void ArrowExtensions_LostLeft_DottedArrowRight_Should_BecomeDottedFound()
        {
            // Assign
            var originalArrow = new Arrow("-->");

            // Act
            var arrow = originalArrow.LostLeft();

            // Assert
            arrow.ToString().Should().Be("o-->");
        }

        [TestMethod]
        public void ArrowExtensions_LostLeft_LostArrowRight_Should_StayLost()
        {
            // Assign
            var originalArrow = new Arrow("o-->");

            // Act
            var arrow = originalArrow.LostLeft();

            // Assert
            arrow.ToString().Should().Be("o-->");
        }
    }
}
