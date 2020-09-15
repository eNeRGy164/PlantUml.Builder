using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class MemberDeclarationTests
    {
        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.MemberDeclaration("class", new ClassMember("member"));

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_NullName_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.MemberDeclaration(null, new ClassMember("member"));

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.MemberDeclaration(string.Empty, new ClassMember("member"));

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.MemberDeclaration(" ", new ClassMember("member"));

            // Assert
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_NullData_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.MemberDeclaration("class", null);

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("data");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_WithName_Should_ContainMemberDeclaration()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.MemberDeclaration("class", new ClassMember("data"));

            // Assert
            stringBuilder.ToString().Should().Be("class : data\n");
        }


        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_Should_ContainMemberDeclarationLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.MemberDeclaration("class", new ClassMember("member"));

            // Assert
            stringBuilder.ToString().Should().Be("class : member\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_WithPublicVisibility_Should_ContainMemberDeclarationLineWithPublicAnnotation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.MemberDeclaration("class", new ClassMember("member", visibility: VisibilityModifier.Public));

            // Assert
            stringBuilder.ToString().Should().Be("class : +member\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_WithPackagePrivateVisibility_Should_ContainMemberDeclarationLineWithPackagePrivateAnnotation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.MemberDeclaration("class", new ClassMember("member", visibility: VisibilityModifier.PackagePrivate));

            // Assert
            stringBuilder.ToString().Should().Be("class : ~member\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_WithProtectedVisibility_Should_ContainMemberDeclarationLineWithProtectedAnnotation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.MemberDeclaration("class", new ClassMember("member", visibility: VisibilityModifier.Protected));

            // Assert
            stringBuilder.ToString().Should().Be("class : #member\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_WithPrivateVisibility_Should_ContainMemberDeclarationLineWithPrivateAnnotation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.MemberDeclaration("class", new ClassMember("member", visibility: VisibilityModifier.Private));

            // Assert
            stringBuilder.ToString().Should().Be("class : -member\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_IsAbstract_Should_ContainMemberDeclarationLineWithAbstractAnnotation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.MemberDeclaration("class", new ClassMember("member", isAbstract: true));

            // Assert
            stringBuilder.ToString().Should().Be("class : {abstract}member\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_MemberDeclaration_IsStatic_Should_ContainMemberDeclarationLineWithStaticAnnotation()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.MemberDeclaration("class", new ClassMember("member", isStatic: true));

            // Assert
            stringBuilder.ToString().Should().Be("class : {static}member\n");
        }
    }
}
