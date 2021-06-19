using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public class ArrowExtensionsTests
    {
        [TestMethod]
        [DynamicData(nameof(GetArrowExtensionMethods), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetArrowExtensionMethodsDisplayName))]
        public void ExtensionMethodsShouldNotWorkOnANullArrow(string methodName, object[] methodParameters)
        {
            // Assign
            Arrow arrow = null;

            var method = typeof(ArrowExtenstions).GetMethod(methodName);
            var parameters = new List<object> { arrow };
            parameters.AddRange(methodParameters);

            // Act
            Action action = () => method.Invoke(null, parameters.ToArray());

            // Assert
            action.Should().ThrowExactly<TargetInvocationException>()
                .WithInnerExceptionExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("arrow");
        }

        private static IEnumerable<object[]> GetArrowExtensionMethods()
        {
            yield return new object[] { "Color", new object[] { (Color)NamedColor.Red } };
            yield return new object[] { "Destroy", new object[0] };
            yield return new object[] { "Dotted", new object[0] };
            yield return new object[] { "Lost", new object[0] };
            yield return new object[] { "LostLeft", new object[0] };
            yield return new object[] { "LostRight", new object[0] };
            yield return new object[] { "Solid", new object[0] };
        }

        public static string GetArrowExtensionMethodsDisplayName(MethodInfo _, object[] data)
        {
            return $"Extension method \"{data[0]}\" should throw an argument exception when arrow is `null`";
        }

        [TestMethod]
        [DataRow("->", null, "->", DisplayName = "A `null` color should change nothing")]
        [DataRow("->", NamedColor.Red, "-[#Red]>", DisplayName = "The arrow should become colored")]
        [DataRow("-[#Orange]>", NamedColor.Blue, "-[#Blue]>", DisplayName = "The arrow should change colors")]
        public void ChangeTheColorOfTheArrow(string original, NamedColor? color, string expected)
        {
            // Assign
            Arrow originalArrow = original;

            // Act
            var arrow = originalArrow.Color(color);

            // Assert
            arrow.ToString().Should().Be(expected);
        }

        [TestMethod]
        [DataRow("->", "-->", DisplayName = "A solid arrow line should become a dotted line")]
        [DataRow("-->", "-->", DisplayName = "A dotted arrow line should stay a dotted line")]
        [DataRow("--->", "-->", DisplayName = "A long dotted arrow line should become a short dotted line")]
        public void EnsureTheLineIsDotted(string original, string expected)
        {
            // Assign
            Arrow originalArrow = original;

            // Act
            var arrow = originalArrow.Dotted();

            // Assert
            arrow.ToString().Should().Be(expected);
        }

        [TestMethod]
        [DataRow("x<-", "Lost", DisplayName = "If the left side is already deleted, it can't become lost")]
        [DataRow("->x", "Lost", DisplayName = "If the right side is already deleted, it can't become lost")]
        [DataRow("x->", "LostLeft", DisplayName = "If the left side is already deleted, it can't become lost")]
        [DataRow("x-x", "LostLeft", DisplayName = "If the left side is already deleted, it can't become lost")]
        [DataRow("<-x", "LostRight", DisplayName = "If the right side is already deleted, it can't become lost")]
        [DataRow("x-x", "LostRight", DisplayName = "If the right side is already deleted, it can't become lost")]
        public void TheDeletedSideCannotBecomeLost(string original, string methodName)
        {
            // Assign
            Arrow originalArrow = original;

            var method = typeof(ArrowExtensions).GetMethod(methodName);
            var lostFunction = (Func<Arrow, Arrow>)Delegate.CreateDelegate(typeof(Func<Arrow, Arrow>), method);

            // Act
            Action action = () => lostFunction(originalArrow);

            // Assert
            action.Should().ThrowExactly<NotSupportedException>()
                .WithMessage("You can not combine the lost and deleted message notation in the same arrow head.");
        }

        [TestMethod]
        [DataRow("<-", "LostLeft", "o<-", DisplayName = "Arrow to the left is lost")]
        [DataRow("->", "LostLeft", "o->", DisplayName = "Arrow to the right is found")]
        [DataRow("-->", "LostLeft", "o-->", DisplayName = "Dotted arrow to the right is found")]
        [DataRow("o-->", "LostLeft", "o-->", DisplayName = "Dotted arrow to the right stays lost")]
        [DataRow("->", "LostRight", "->o", DisplayName = "Arrow to the right is lost")]
        [DataRow("<-", "LostRight", "<-o", DisplayName = "Arrow to the left is found")]
        [DataRow("<--", "LostRight", "<--o", DisplayName = "Dotted arrow to the left is found")]
        [DataRow("<--o", "LostRight", "<--o", DisplayName = "Dotted arrow to the left stays lost")]
        [DataRow("->", "Lost", "->o", DisplayName = "Arrow to the right is lost")]
        [DataRow("<-", "Lost", "o<-", DisplayName = "Arrow to the left is lost")]

        public void AddTheLostNotationOnTheLeftOfTheArrowOnce(string original, string methodName, string expected)
        {
            // Assign
            Arrow originalArrow = original;

            var method = typeof(ArrowExtensions).GetMethod(methodName);
            var function = (Func<Arrow, Arrow>)Delegate.CreateDelegate(typeof(Func<Arrow, Arrow>), method);

            // Act
            var arrow = function(originalArrow);

            // Assert
            arrow.ToString().Should().Be(expected);
        }

        [TestMethod]
        [DataRow("->", "->", DisplayName = "A solid arrow line should stay a solid line")]
        [DataRow("-->", "->", DisplayName = "A dotted arrow line should become a solid line")]
        [DataRow("--->", "->", DisplayName = "A long dotted arrow line should become a short solid line")]
        public void EnsureTheLineIsSolid(string original, string expected)
        {
            // Assign
            Arrow originalArrow = original;

            // Act
            var arrow = originalArrow.Solid();

            // Assert
            arrow.ToString().Should().Be(expected);
        }

        [TestMethod]
        [DataRow("->", "->x", DisplayName = "A message to the right is deleted")]
        [DataRow("<-", "x<-", DisplayName = "A message to the left is deleted")]
        [DataRow("<--", "x<--", DisplayName = "A dotted message is deleted")]
        [DataRow("//--", "x//--", DisplayName = "A thin bottom message is deleted")]
        [DataRow("<--o", "x<--o", DisplayName = "A found message is deleted")]
        [DataRow("x<--o", "x<--o", DisplayName = "A deleted message to the left stays deleted")]
        [DataRow("x--", "x--", DisplayName = "A deleted message to the left stays deleted")]
        [DataRow("--x", "--x", DisplayName = "A deleted message to the right stays deleted")]
        [DataRow("-->x", "-->x", DisplayName = "A deleted message to the right stays deleted")]

        public void DestroyTheMessageInTheDirectionOfTheArrow(string original, string expected)
        {
            // Assign
            Arrow originalArrow = original;

            // Act
            var arrow = originalArrow.Destroy();

            // Assert
            arrow.ToString().Should().Be(expected);
        }

        [TestMethod]
        [DataRow("<->", "Lost", DisplayName = "A left-right arrow has both directions")]
        [DataRow("<-->", "Lost", DisplayName = "A dotted left-right arrow has both directions")]
        [DataRow("x-x", "Lost", DisplayName = "A left-right destroyed arrow has both directions")]
        [DataRow("<->", "Destroy", DisplayName = "A left-right arrow has both directions")]
        [DataRow("<-->", "Destroy", DisplayName = "A dotted left-right arrow has both directions")]
        [DataRow("x-x", "Destroy", DisplayName = "A left-right destroyed arrow has both directions")]

        public void MethodsOnlyWorkIfTheArrowIsToTheLeftOrRight(string original, string methodName)
        {
            // Assign
            Arrow originalArrow = original;

            var method = typeof(ArrowExtensions).GetMethod(methodName);
            var function = (Func<Arrow, Arrow>)Delegate.CreateDelegate(typeof(Func<Arrow, Arrow>), method);

            // Act
            Action act = () => function(originalArrow);

            // Assert
            act.Should().ThrowExactly<NotSupportedException>()
                .WithMessage("This method only * an arrow if it is in a clear left or right direction.");
        }
    }
}
