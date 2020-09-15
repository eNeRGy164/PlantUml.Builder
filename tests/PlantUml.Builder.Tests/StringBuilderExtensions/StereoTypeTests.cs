using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class StereoTypeTests
    {
        [TestMethod]
        public void StringBuilderExtensions_StereoType_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.StereoType();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_StereoType_NoParameters_Should_EmptyStereoType()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StereoType();

            // Assert
            stringBuilder.ToString().Should().Be("<<>>");
        }

        [TestMethod]
        public void StringBuilderExtensions_StereoType_WithName_Should_StereoTypeWithName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StereoType("name");

            // Assert
            stringBuilder.ToString().Should().Be("<<name>>");
        }

        [TestMethod]
        public void StringBuilderExtensions_StereoType_WithSpot_Should_StereoTypeWithSpot()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StereoType(customSpot: new CustomSpot('T', NamedColor.Aqua));

            // Assert
            stringBuilder.ToString().Should().Be("<<(T,#Aqua)>>");
        }

        [TestMethod]
        public void StringBuilderExtensions_StereoType_WithNameAndSpot_Should_StereoTypeWithNameAndSpot()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.StereoType("name", new CustomSpot('T', NamedColor.Aqua));

            // Assert
            stringBuilder.ToString().Should().Be("<<(T,#Aqua)name>>");
        }
    }
}
