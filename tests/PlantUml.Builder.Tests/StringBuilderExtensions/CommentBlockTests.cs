using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.Tests
{
    [TestClass]
    public class CommentBlockBlockTests
    {
        [TestMethod]
        public void StringBuilderExtensions_CommentBlock_Null_Should_ThrowArgumentNullException()
        {
            // Assign
            var stringBuilder = (StringBuilder)null;

            // Act
            Action action = () => stringBuilder.CommentBlock();

            // Assert
            action.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("stringBuilder");
        }

        [TestMethod]
        public void StringBuilderExtensions_CommentBlock_Should_ContainEmptyCommentBlockLine()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CommentBlock();

            // Assert
            stringBuilder.ToString().Should().Be("/'  '/\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CommentBlock_WithCommentBlock_Should_ContainCommentBlockWithCommentBlock()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CommentBlock("This is a comment");

            // Assert
            stringBuilder.ToString().Should().Be("/' This is a comment '/\n");
        }

        [TestMethod]
        public void StringBuilderExtensions_CommentBlock_WithNewLineCommentBlock_Should_CommentBlockWithEscapedNewLineCommentBlock()
        {
            // Assign
            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.CommentBlock("This is a comment\non a single line");

            // Assert
            stringBuilder.ToString().Should().Be("/' This is a comment\non a single line '/\n");
        }
    }
}
