using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class ClassMemberTests
    {
        [TestMethod]
        public void ClassMember_NullName_Should_ThrowArgumentException()
        {
            // Act
            Action action = () => new ClassMember(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void ClassMember_EmptyName_Should_ThrowArgumentException()
        {
            // Act
            Action action = () => new ClassMember(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void ClassMember_WhitespaceName_Should_ThrowArgumentException()
        {
            // Act
            Action action = () => new ClassMember(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }
    }
}
