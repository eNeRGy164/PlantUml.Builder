using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Tests.ClassDiagrams
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void StringBuilderExtensions_Entity_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.Entity("EntityA");

            // Assert
            action.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_NullName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Entity(null);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_EmptyName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Entity(string.Empty);

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WhitespaceName_Should_ThrowArgumentException()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            Action action = () => stringBuilder.Entity(" ");

            // Assert
            action.Should().Throw<ArgumentException>()
                .WithMessage("A non-empty value should be provided*")
                .And.ParamName.Should().Be("name");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_Should_ContainEntityLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA");

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithDisplayName_Should_ContainEntityLineWithDisplayName()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", displayName: "Entity A");

            // Assert
            stringBuilder.ToString().Should().Be("entity \"Entity A\" as EntityA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithStereotype_Should_ContainEntityLineWithStereotype()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", stereotype: "entity");

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA <<entity>>\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithStereotypeAndCustomSpot_Should_ContainEntityLineWithStereotypeAndCustomSpot()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", stereotype: "entity", customSpot: new CustomSpot('R', "Blue"));

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA <<(R,#Blue)entity>>\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithGenerics_Should_ContainEntityLineWithGenerics()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", generics: "Object");

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA<Object>\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithBackgroundColor_Should_ContainEntityLineWithBackgroundColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", backgroundColor: "#AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithBackgroundColorWithHashtag_Should_ContainEntityLineWithBackgroundColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", backgroundColor: "AliceBlue");

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA #AliceBlue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithTag_Should_ContainEntityLineWithTag()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", tag: "tag");

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA $tag\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithUrl_Should_ContainEntityLineWithUrl()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", url: new Uri("https://blog.hompus.nl"));

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA [[https://blog.hompus.nl/]]\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithLineStyle_Should_ContainEntityLineWithLineStyle()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", lineStyle: LineStyle.Bold);

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA ##[bold]\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithLineColor_Should_ContainEntityLineWithLineColor()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", lineColor: "Blue");

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA ##Blue\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithExtends_Should_ContainEntityLineWithExtends()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", extends: new[] { "BaseClass" });

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA extends BaseClass\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithMultipleExtends_Should_ContainEntityLineWithSeperatedExtends()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", extends: new[] { "BaseClass", "BaseClass2" });

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA extends BaseClass,BaseClass2\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithNoImplements_Should_ContainEntityLineWithoutImplements()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", implements: new string[0]);

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithImplements_Should_ContainEntityLineWithImplements()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", implements: new[] { "IInterface" });

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA implements IInterface\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_Entity_WithMultipleImplements_Should_ContainEntityLineWithSeperatedImplements()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.Entity("EntityA", implements: new[] { "IInterface", "IInterface2" });

            // Assert
            stringBuilder.ToString().Should().Be("entity EntityA implements IInterface,IInterface2\n");
        }
    }
}
