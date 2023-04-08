using System;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.Tests;

[TestClass]
public class CommentTests
{
    [TestMethod]
    public void StringBuilderExtensions_Comment_Null_Should_ThrowArgumentNullException()
    {
        // Assign
        var stringBuilder = (StringBuilder)null;

        // Act
        Action action = () => stringBuilder.Comment();

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>()
            .And.ParamName.Should().Be("stringBuilder");
    }

    [TestMethod]
    public void StringBuilderExtensions_Comment_Should_ContainEmptyCommentLine()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Comment();

        // Assert
        stringBuilder.ToString().Should().Be("'\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Comment_WithComment_Should_ContainCommentWithComment()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Comment("This is a comment");

        // Assert
        stringBuilder.ToString().Should().Be("' This is a comment\n");
    }

    [TestMethod]
    public void StringBuilderExtensions_Comment_WithNewLineComment_Should_CommentWithEscapedNewLineComment()
    {
        // Assign
        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.Comment("This is a comment\non a single line");

        // Assert
        stringBuilder.ToString().Should().Be("' This is a comment\\non a single line\n");
    }
}
