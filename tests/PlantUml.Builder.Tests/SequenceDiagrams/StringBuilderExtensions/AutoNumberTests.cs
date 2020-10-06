using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.SequenceDiagrams.Tests
{
    [TestClass]
    public class AutoNumberTests
    {
        [TestMethod]
        public void StringBuilderExtensions_AutoNumber_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.AutoNumber();

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_AutoNumber_Should_ContainAutoNumberLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.AutoNumber();

            // Assert
            stringBuilder.ToString().Should().Be("autonumber\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_AutoNumber_WithStart_Should_ContainAutoNumberLineWithStart()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.AutoNumber(start: 10);

            // Assert
            stringBuilder.ToString().Should().Be("autonumber 10\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_AutoNumber_WithOnlyStep_Should_IgnoreStep()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.AutoNumber(step: 1);

            // Assert
            stringBuilder.ToString().Should().Be("autonumber\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_AutoNumber_WithStartAndStep_Should_ContainAutoNumberLineWithStartAndStep()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.AutoNumber(start: 10, step: 20);

            // Assert
            stringBuilder.ToString().Should().Be("autonumber 10 20\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_AutoNumber_WithFormat_Should_ContainAutoNumberLineWithFormat()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.AutoNumber(format: "<b>[000]");

            // Assert
            stringBuilder.ToString().Should().Be("autonumber \"<b>[000]\"\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_AutoNumber_AllParamters_Should_ContainAutoNumberLineWithCorrectOrderedParameters()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.AutoNumber(10, 20, "<b>[000]");

            // Assert
            stringBuilder.ToString().Should().Be("autonumber 10 20 \"<b>[000]\"\n");
        }
    }
}
