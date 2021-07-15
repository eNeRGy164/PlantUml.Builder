using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.ClassDiagrams.Tests
{
    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void StringBuilderExtensions_Class_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.Class("classA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Class(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Class(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Class(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_Should_ContainClassLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA");

            // Assert
            stringBuilder.ToString().Should().Be("class classA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithDisplayName_Should_ContainClassLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", displayName: "Class A");

            // Assert
            stringBuilder.ToString().Should().Be("class \"Class A\" as classA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_IsAbstract_Should_ContainClassLineWithAbstract()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", isAbstract: true);

            // Assert
            stringBuilder.ToString().Should().Be("abstract class classA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithStereotype_Should_ContainClassLineWithStereotype()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", stereotype: "entity");

            // Assert
            stringBuilder.ToString().Should().Be("class classA <<entity>>\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithStereotypeAndCustomSpot_Should_ContainClassLineWithStereotypeAndCustomSpot()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", stereotype: "entity", customSpot: new CustomSpot('R', "Blue"));

            // Assert
            stringBuilder.ToString().Should().Be("class classA <<(R,#Blue)entity>>\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithGenerics_Should_ContainClassLineWithGenerics()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", generics: "Object");

            // Assert
            stringBuilder.ToString().Should().Be("class classA<Object>\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithBackgroundColor_Should_ContainClassLineWithBackgroundColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", backgroundColor: "#AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("class classA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithBackgroundColorWithHashtag_Should_ContainClassLineWithBackgroundColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", backgroundColor: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("class classA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithTag_Should_ContainClassLineWithTag()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", tag: "tag");

            // Assert
            stringBuilder.ToString().Should().Be("class classA $tag\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithUrl_Should_ContainClassLineWithUrl()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", url: new Uri("https://blog.hompus.nl"));

            // Assert
            stringBuilder.ToString().Should().Be("class classA [[https://blog.hompus.nl/]]\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithLineStyle_Should_ContainClassLineWithLineStyle()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", lineStyle: LineStyle.Bold);

            // Assert
            stringBuilder.ToString().Should().Be("class classA ##[bold]\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithLineColor_Should_ContainClassLineWithLineColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", lineColor: "Blue");

            // Assert
            stringBuilder.ToString().Should().Be("class classA ##Blue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithExtends_Should_ContainClassLineWithExtends()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", extends: new[] { "BaseClass" });

            // Assert
            stringBuilder.ToString().Should().Be("class classA extends BaseClass\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithMultipleExtends_Should_ContainClassLineWithSeperatedExtends()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", extends: new[] { "BaseClass", "BaseClass2" });

            // Assert
            stringBuilder.ToString().Should().Be("class classA extends BaseClass,BaseClass2\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithNoImplements_Should_ContainClassLineWithoutImplements()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", implements: new string[0]);

            // Assert
            stringBuilder.ToString().Should().Be("class classA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithImplements_Should_ContainClassLineWithImplements()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", implements: new[] { "IInterface" });

            // Assert
            stringBuilder.ToString().Should().Be("class classA implements IInterface\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Class_WithMultipleImplements_Should_ContainClassLineWithSeperatedImplements()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Class("classA", implements: new[] { "IInterface", "IInterface2" });

            // Assert
            stringBuilder.ToString().Should().Be("class classA implements IInterface,IInterface2\n");
        }
    }
}
