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
            yield return new object[] { "Dotted", new object[0] };
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
        [DataRow("x->", "LostLeft", DisplayName = "If the left side is already deleted, it can't become lost")]
        [DataRow("x-x", "LostLeft", DisplayName = "If the left side is already deleted, it can't become lost")]
        [DataRow("<-x", "LostRight", DisplayName = "If the right side is already deleted, it can't become lost")]
        [DataRow("x-x", "LostRight", DisplayName = "If the right side is already deleted, it can't become lost")]
        public void TheDeletedSideCannotBecomeLost(string original, string methodName)
        {
            // Assign
            Arrow originalArrow = original;

            var method = typeof(ArrowExtenstions).GetMethod(methodName);

            // Act
            Action action = () => method.Invoke(null, new object[] { originalArrow });

            // Assert
            action.Should().ThrowExactly<TargetInvocationException>()
                .WithInnerExceptionExactly<NotSupportedException>()
                .WithMessage("You can not combine the lost and deleted message notation in the same arrow head.");
        }

        [TestMethod]
        [DataRow("<-", "o<-", DisplayName = "Become lost")]
        [DataRow("->", "o->", DisplayName = "Become found")]
        [DataRow("-->", "o-->", DisplayName = "Become dotted found")]
        [DataRow("o-->", "o-->", DisplayName = "Stay lost")]

        public void AddTheLostNotationOnTheLeftOfTheArrowOnce(string original, string expected)
        {
            // Assign
            Arrow originalArrow = original;

            // Act
            var arrow = originalArrow.LostLeft();

            // Assert
            arrow.ToString().Should().Be(expected);
        }

        [TestMethod]
        [DataRow("->", "->o", DisplayName = "Become lost")]
        [DataRow("<-", "<-o", DisplayName = "Become found")]
        [DataRow("<--", "<--o", DisplayName = "Become dotted found")]
        [DataRow("<--o", "<--o", DisplayName = "Stay lost")]

        public void AddTheLostNotationOnTheRightOfTheArrowOnce(string original, string expected)
        {
            // Assign
            Arrow originalArrow = original;

            // Act
            var arrow = originalArrow.LostRight();

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
    }
}
