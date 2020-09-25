using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

namespace PlantUml.Builder.Tests.SequenceDiagrams
{
    [TestClass]
    public class ArrowDefaultsTests
    {
        [TestMethod]
        public void Arrow_Default_Right()
        {
            // Act
            var arrow = Arrow.Right;

            // Assert
            arrow.ToString().Should().Be("->");
        }

        [TestMethod]
        public void Arrow_Default_DottedRight()
        {
            // Act
            var arrow = Arrow.DottedRight;

            // Assert
            arrow.ToString().Should().Be("-->");
        }

        [TestMethod]
        public void Arrow_Default_ThinRight()
        {
            // Act
            var arrow = Arrow.ThinRight;

            // Assert
            arrow.ToString().Should().Be("->>");
        }

        [TestMethod]
        public void Arrow_Default_DottedThinRight()
        {
            // Act
            var arrow = Arrow.DottedThinRight;

            // Assert
            arrow.ToString().Should().Be("-->>");
        }

        [TestMethod]
        public void Arrow_Default_AsyncRight()
        {
            // Act
            var arrow = Arrow.AsyncRight;

            // Assert
            arrow.ToString().Should().Be("->");
        }

        [TestMethod]
        public void Arrow_Default_SyncRight()
        {
            // Act
            var arrow = Arrow.SyncRight;

            // Assert
            arrow.ToString().Should().Be("->>");
        }

        [TestMethod]
        public void Arrow_Default_AsyncReplyRight()
        {
            // Act
            var arrow = Arrow.AsyncReplyRight;

            // Assert
            arrow.ToString().Should().Be("-->");
        }

        [TestMethod]
        public void Arrow_Default_SyncReplyRight()
        {
            // Act
            var arrow = Arrow.SyncReplyRight;

            // Assert
            arrow.ToString().Should().Be("-->>");
        }

        [TestMethod]
        public void Arrow_Default_BottomRight()
        {
            // Act
            var arrow = Arrow.BottomRight;

            // Assert
            arrow.ToString().Should().Be("-/");
        }

        [TestMethod]
        public void Arrow_Default_DottedBottomRight()
        {
            // Act
            var arrow = Arrow.DottedBottomRight;

            // Assert
            arrow.ToString().Should().Be("--/");
        }

        [TestMethod]
        public void Arrow_Default_ThinBottomRight()
        {
            // Act
            var arrow = Arrow.ThinBottomRight;

            // Assert
            arrow.ToString().Should().Be("-//");
        }

        [TestMethod]
        public void Arrow_Default_DottedThinBottomRight()
        {
            // Act
            var arrow = Arrow.DottedThinBottomRight;

            // Assert
            arrow.ToString().Should().Be("--//");
        }

        [TestMethod]
        public void Arrow_Default_TopRight()
        {
            // Act
            var arrow = Arrow.TopRight;

            // Assert
            arrow.ToString().Should().Be("-\\");
        }

        [TestMethod]
        public void Arrow_Default_DottedTopRight()
        {
            // Act
            var arrow = Arrow.DottedTopRight;

            // Assert
            arrow.ToString().Should().Be("--\\");
        }

        [TestMethod]
        public void Arrow_Default_ThinTopRight()
        {
            // Act
            var arrow = Arrow.ThinTopRight;

            // Assert
            arrow.ToString().Should().Be("-\\\\");
        }

        [TestMethod]
        public void Arrow_Default_DottedThinTopRight()
        {
            // Act
            var arrow = Arrow.DottedThinTopRight;

            // Assert
            arrow.ToString().Should().Be("--\\\\");
        }

        [TestMethod]
        public void Arrow_Default_Left()
        {
            // Act
            var arrow = Arrow.Left;

            // Assert
            arrow.ToString().Should().Be("<-");
        }

        [TestMethod]
        public void Arrow_Default_DottedLeft()
        {
            // Act
            var arrow = Arrow.DottedLeft;

            // Assert
            arrow.ToString().Should().Be("<--");
        }

        [TestMethod]
        public void Arrow_Default_ThinLeft()
        {
            // Act
            var arrow = Arrow.ThinLeft;

            // Assert
            arrow.ToString().Should().Be("<<-");
        }

        [TestMethod]
        public void Arrow_Default_DottedThinLeft()
        {
            // Act
            var arrow = Arrow.DottedThinLeft;

            // Assert
            arrow.ToString().Should().Be("<<--");
        }

        [TestMethod]
        public void Arrow_Default_AsyncLeft()
        {
            // Act
            var arrow = Arrow.AsyncLeft;

            // Assert
            arrow.ToString().Should().Be("<-");
        }

        [TestMethod]
        public void Arrow_Default_SyncLeft()
        {
            // Act
            var arrow = Arrow.SyncLeft;

            // Assert
            arrow.ToString().Should().Be("<<-");
        }

        [TestMethod]
        public void Arrow_Default_AsyncReplyLeft()
        {
            // Act
            var arrow = Arrow.AsyncReplyLeft;

            // Assert
            arrow.ToString().Should().Be("<--");
        }

        [TestMethod]
        public void Arrow_Default_SyncReplyLeft()
        {
            // Act
            var arrow = Arrow.SyncReplyLeft;

            // Assert
            arrow.ToString().Should().Be("<<--");
        }

        [TestMethod]
        public void Arrow_Default_BottomLeft()
        {
            // Act
            var arrow = Arrow.BottomLeft;

            // Assert
            arrow.ToString().Should().Be("/-");
        }

        [TestMethod]
        public void Arrow_Default_DottedBottomLeft()
        {
            // Act
            var arrow = Arrow.DottedBottomLeft;

            // Assert
            arrow.ToString().Should().Be("/--");
        }

        [TestMethod]
        public void Arrow_Default_ThinBottomLeft()
        {
            // Act
            var arrow = Arrow.ThinBottomLeft;

            // Assert
            arrow.ToString().Should().Be("//-");
        }

        [TestMethod]
        public void Arrow_Default_DottedThinBottomLeft()
        {
            // Act
            var arrow = Arrow.DottedThinBottomLeft;

            // Assert
            arrow.ToString().Should().Be("//--");
        }

        [TestMethod]
        public void Arrow_Default_TopLeft()
        {
            // Act
            var arrow = Arrow.TopLeft;

            // Assert
            arrow.ToString().Should().Be("\\-");
        }

        [TestMethod]
        public void Arrow_Default_DottedTopLeft()
        {
            // Act
            var arrow = Arrow.DottedTopLeft;

            // Assert
            arrow.ToString().Should().Be("\\--");
        }

        [TestMethod]
        public void Arrow_Default_ThinTopLeft()
        {
            // Act
            var arrow = Arrow.ThinTopLeft;

            // Assert
            arrow.ToString().Should().Be("\\\\-");
        }

        [TestMethod]
        public void Arrow_Default_DottedThinTopLeft()
        {
            // Act
            var arrow = Arrow.DottedThinTopLeft;

            // Assert
            arrow.ToString().Should().Be("\\\\--");
        }
    }
}
