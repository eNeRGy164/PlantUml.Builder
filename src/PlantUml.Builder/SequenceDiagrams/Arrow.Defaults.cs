using System;

namespace PlantUml.Builder.SequenceDiagrams
{
    public partial class Arrow
    {
        /// <summary>
        /// A solid arrow to the right with a solid line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>rightwards triangle-headed arrow</c>.
        /// </remarks>
        public static Arrow Right = new Arrow(ArrowParts.Line, ArrowParts.Right);

        /// <summary>
        /// A solid arrow to the right with a solid line.
        /// </summary>
        public static Arrow AsyncRight = Right;

        /// <summary>
        /// A solid arrow to the right with a dotted line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>rightwards triangle-headed arrow</c>.
        /// </remarks>
        public static Arrow DottedRight = new Arrow(ArrowParts.Line, ArrowParts.Line, ArrowParts.Right);

        /// <summary>
        /// A solid arrow to the right with a dotted line.
        /// </summary>
        public static Arrow AsyncReplyRight = DottedRight;

        /// <summary>
        /// A thin arrow to the right with a solid line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>rightwards arrow</c>.
        /// </remarks>
        public static Arrow ThinRight = new Arrow(ArrowParts.Line, ArrowParts.Right, ArrowParts.Right);

        /// <summary>
        /// A thin arrow to the right with a solid line.
        /// </summary>
        public static Arrow SyncRight = ThinRight;

        /// <summary>
        /// A thin arrow to the right with a dotted line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>rightwards arrow</c>.
        /// </remarks>
        public static Arrow DottedThinRight = new Arrow(ArrowParts.Line, ArrowParts.Line, ArrowParts.Right, ArrowParts.Right);

        /// <summary>
        /// A thin arrow to the right with a dotted line.
        /// </summary>
        public static Arrow SyncReplyRight = DottedThinRight;

        /// <summary>
        /// A bottom half solid arrow to the right with a solid line.
        /// </summary>
        public static Arrow BottomRight = new Arrow(ArrowParts.Line, ArrowParts.Bottom);

        /// <summary>
        /// A bottom half solid arrow to the right with a dotted line.
        /// </summary>
        public static Arrow DottedBottomRight = new Arrow(ArrowParts.Line, ArrowParts.Line, ArrowParts.Bottom);

        /// <summary>
        /// A bottom half thin arrow to the right with a solid line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>rightwards harpoon with barb downwards</c>.
        /// </remarks>
        public static Arrow ThinBottomRight = new Arrow(ArrowParts.Line, ArrowParts.Bottom, ArrowParts.Bottom);

        /// <summary>
        /// A bottom half solid arrow to the right with a dotted line.
        /// </summary>
        public static Arrow DottedThinBottomRight = new Arrow(ArrowParts.Line, ArrowParts.Line, ArrowParts.Bottom, ArrowParts.Bottom);

        /// <summary>
        /// A top half solid arrow to the right with a solid line.
        /// </summary>
        public static Arrow TopRight = new Arrow(ArrowParts.Line, ArrowParts.Top);

        /// <summary>
        /// A top half solid arrow to the right with a dotted line.
        /// </summary>
        public static Arrow DottedTopRight = new Arrow(ArrowParts.Line, ArrowParts.Line, ArrowParts.Top);

        /// <summary>
        /// A top half thin arrow to the right with a solid line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>rightwards harpoon with barb upwards</c>.
        /// </remarks>
        public static Arrow ThinTopRight = new Arrow(ArrowParts.Line, ArrowParts.Top, ArrowParts.Top);

        /// <summary>
        /// A top half thin arrow to the right with a dotted line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>rightwards harpoon with barb upwards</c>.
        /// </remarks>
        public static Arrow DottedThinTopRight = new Arrow(ArrowParts.Line, ArrowParts.Line, ArrowParts.Top, ArrowParts.Top);

        /// <summary>
        /// A solid arrow to the left with a solid line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>leftwards triangle-headed arrow</c>.
        /// </remarks>
        public static Arrow Left = new Arrow(ArrowParts.Left, ArrowParts.Line);

        /// <summary>
        /// A solid arrow to the left with a solid line.
        /// </summary>
        public static Arrow AsyncLeft = Left;

        /// <summary>
        /// A solid arrow to the left with a dotted line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>leftwards triangle-headed arrow</c>.
        /// </remarks>
        public static Arrow DottedLeft = new Arrow(ArrowParts.Left, ArrowParts.Line, ArrowParts.Line);

        /// <summary>
        /// A solid arrow to the left with a dotted line.
        /// </summary>
        public static Arrow AsyncReplyLeft = DottedLeft;

        /// <summary>
        /// A thin arrow to the left with a solid line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>leftwards arrow</c>.
        /// </remarks>
        public static Arrow ThinLeft = new Arrow(ArrowParts.Left, ArrowParts.Left, ArrowParts.Line);

        /// <summary>
        /// A thin arrow to the left with a solid line.
        /// </summary>
        public static Arrow SyncLeft = ThinLeft;

        /// <summary>
        /// A thin arrow to the left with a dotted line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>leftwards arrow</c>.
        /// </remarks>
        public static Arrow DottedThinLeft = new Arrow(ArrowParts.Left, ArrowParts.Left, ArrowParts.Line, ArrowParts.Line);

        /// <summary>
        /// A thin arrow to the left with a dotted line.
        /// </summary>
        public static Arrow SyncReplyLeft = DottedThinLeft;

        /// <summary>
        /// A bottom half solid arrow to the left with a solid line.
        /// </summary>
        public static Arrow BottomLeft = new Arrow(ArrowParts.Bottom, ArrowParts.Line);

        /// <summary>
        /// A bottom half solid arrow to the left with a dotted line.
        /// </summary>
        public static Arrow DottedBottomLeft = new Arrow(ArrowParts.Bottom, ArrowParts.Line, ArrowParts.Line);

        /// <summary>
        /// A bottom half thin arrow to the left with a solid line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>leftwards harpoon with barb downwards</c>.
        /// </remarks>
        public static Arrow ThinBottomLeft = new Arrow(ArrowParts.Bottom, ArrowParts.Bottom, ArrowParts.Line);

        /// <summary>
        /// A bottom half solid arrow to the left with a dotted line.
        /// </summary>
        public static Arrow DottedThinBottomLeft = new Arrow(ArrowParts.Bottom, ArrowParts.Bottom, ArrowParts.Line, ArrowParts.Line);

        /// <summary>
        /// A top half solid arrow to the left with a solid line.
        /// </summary>
        public static Arrow TopLeft = new Arrow(ArrowParts.Top, ArrowParts.Line);

        /// <summary>
        /// A top half solid arrow to the left with a dotted line.
        /// </summary>
        public static Arrow DottedTopLeft = new Arrow(ArrowParts.Top, ArrowParts.Line, ArrowParts.Line);

        /// <summary>
        /// A top half thin arrow to the left with a solid line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>leftwards harpoon with barb upwards</c>.
        /// </remarks>
        public static Arrow ThinTopLeft = new Arrow(ArrowParts.Top, ArrowParts.Top, ArrowParts.Line);

        /// <summary>
        /// A top half thin arrow to the left with a dotted line.
        /// </summary>
        /// <remarks>
        /// Also known as a <c>leftwards harpoon with barb upwards</c>.
        /// </remarks>
        public static Arrow DottedThinTopLeft = new Arrow(ArrowParts.Top, ArrowParts.Top, ArrowParts.Line, ArrowParts.Line);
    }
}
