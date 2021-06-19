using System;

namespace PlantUml.Builder.SequenceDiagrams
{
    public partial class Arrow
    {
        /// <summary>
        /// A solid arrow to the right with a solid line.
        /// </summary>
        /// <remarks>
        /// Symbol: <c>➝</c>.
        /// Also known as a <em>rightwards triangle-headed arrow</em>.
        /// </remarks>
        public static Arrow Right => new(ArrowParts.Line, ArrowParts.Right);

        /// <inheritdoc cref="Right"/>
        public static Arrow AsyncRight => Right;

        /// <summary>
        /// A solid arrow to the right with a dotted line.
        /// </summary>
        /// <inheritdoc cref="Right"/>
        public static Arrow DottedRight => new(ArrowParts.Line, ArrowParts.Line, ArrowParts.Right);

        /// <inheritdoc cref="DottedRight"/>
        public static Arrow AsyncReplyRight => DottedRight;

        /// <summary>
        /// A thin arrow to the right with a solid line.
        /// </summary>
        /// <remarks>
        /// Symbol: <c>→</c>
        /// Also known as a <em>rightwards arrow</em>.
        /// </remarks>
        public static Arrow ThinRight => new(ArrowParts.Line, ArrowParts.Right, ArrowParts.Right);

        /// <inheritdoc cref="ThinRight"/>
        public static Arrow SyncRight => ThinRight;

        /// <summary>
        /// A thin arrow to the right with a dotted line.
        /// </summary>
        /// <inheritdoc cref="ThinRight"/>
        public static Arrow DottedThinRight => new(ArrowParts.Line, ArrowParts.Line, ArrowParts.Right, ArrowParts.Right);

        /// <inheritdoc cref="DottedThinRight"/>
        public static Arrow SyncReplyRight => DottedThinRight;

        /// <summary>
        /// A bottom half solid arrow to the right with a solid line.
        /// </summary>
        public static Arrow BottomRight => new(ArrowParts.Line, ArrowParts.Bottom);

        /// <summary>
        /// A bottom half solid arrow to the right with a dotted line.
        /// </summary>
        public static Arrow DottedBottomRight => new(ArrowParts.Line, ArrowParts.Line, ArrowParts.Bottom);

        /// <summary>
        /// A bottom half thin arrow to the right with a solid line.
        /// </summary>
        /// <remarks>
        /// Symbol: <c>⇁</c>
        /// Also known as a <em>rightwards harpoon with barb downwards</em>.
        /// </remarks>
        public static Arrow ThinBottomRight => new(ArrowParts.Line, ArrowParts.Bottom, ArrowParts.Bottom);

        /// <summary>
        /// A bottom half solid arrow to the right with a dotted line.
        /// </summary>
        /// <inheritdoc cref="ThinBottomRight"/>
        public static Arrow DottedThinBottomRight => new(ArrowParts.Line, ArrowParts.Line, ArrowParts.Bottom, ArrowParts.Bottom);

        /// <summary>
        /// A top half solid arrow to the right with a solid line.
        /// </summary>
        public static Arrow TopRight => new(ArrowParts.Line, ArrowParts.Top);

        /// <summary>
        /// A top half solid arrow to the right with a dotted line.
        /// </summary>
        public static Arrow DottedTopRight => new(ArrowParts.Line, ArrowParts.Line, ArrowParts.Top);

        /// <summary>
        /// A top half thin arrow to the right with a solid line.
        /// </summary>
        /// <remarks>
        /// Symbol: <c>⇀</c>
        /// Also known as a <em>rightwards harpoon with barb upwards</em>.
        /// </remarks>
        public static Arrow ThinTopRight => new(ArrowParts.Line, ArrowParts.Top, ArrowParts.Top);

        /// <summary>
        /// A top half thin arrow to the right with a dotted line.
        /// </summary>
        /// <inheritdoc cref="ThinTopRight"/>
        public static Arrow DottedThinTopRight => new(ArrowParts.Line, ArrowParts.Line, ArrowParts.Top, ArrowParts.Top);

        /// <summary>
        /// A solid arrow to the left with a solid line.
        /// </summary>
        /// <remarks>
        /// Symbol: <c>⭠</c>
        /// Also known as a <em>leftwards triangle-headed arrow</em>.
        /// </remarks>
        public static Arrow Left => new(ArrowParts.Left, ArrowParts.Line);

        /// <inheritdoc cref="Left"/>
        public static Arrow AsyncLeft => Left;

        /// <summary>
        /// A solid arrow to the left with a dotted line.
        /// </summary>
        /// <inheritdoc cref="Left"/>
        public static Arrow DottedLeft => new(ArrowParts.Left, ArrowParts.Line, ArrowParts.Line);

        /// <inheritdoc cref="DottedLeft"/>
        public static Arrow AsyncReplyLeft => DottedLeft;

        /// <summary>
        /// A thin arrow to the left with a solid line.
        /// </summary>
        /// <remarks>
        /// Symbol <c>←</c>.
        /// Also known as a <em>leftwards arrow</em>.
        /// </remarks>
        public static Arrow ThinLeft => new(ArrowParts.Left, ArrowParts.Left, ArrowParts.Line);

        /// <inheritdoc cref="ThinLeft"/>
        public static Arrow SyncLeft => ThinLeft;

        /// <summary>
        /// A thin arrow to the left with a dotted line.
        /// </summary>
        /// <inheritdoc cref="ThinLeft"/>
        public static Arrow DottedThinLeft => new(ArrowParts.Left, ArrowParts.Left, ArrowParts.Line, ArrowParts.Line);

        /// <inheritdoc cref="DottedThinLeft"/>
        public static Arrow SyncReplyLeft => DottedThinLeft;

        /// <summary>
        /// A bottom half solid arrow to the left with a solid line.
        /// </summary>
        public static Arrow BottomLeft => new(ArrowParts.Bottom, ArrowParts.Line);

        /// <summary>
        /// A bottom half solid arrow to the left with a dotted line.
        /// </summary>
        public static Arrow DottedBottomLeft => new(ArrowParts.Bottom, ArrowParts.Line, ArrowParts.Line);

        /// <summary>
        /// A bottom half thin arrow to the left with a solid line.
        /// </summary>
        /// <remarks>
        /// Symbol <c>↽</c>.
        /// Also known as a <em>leftwards harpoon with barb downwards</em>.
        /// </remarks>
        public static Arrow ThinBottomLeft => new(ArrowParts.Bottom, ArrowParts.Bottom, ArrowParts.Line);

        /// <summary>
        /// A bottom half solid arrow to the left with a dotted line.
        /// </summary>
        /// <inheritdoc cref="ThinBottomLeft"/>
        public static Arrow DottedThinBottomLeft => new(ArrowParts.Bottom, ArrowParts.Bottom, ArrowParts.Line, ArrowParts.Line);

        /// <summary>
        /// A top half solid arrow to the left with a solid line.
        /// </summary>
        public static Arrow TopLeft => new(ArrowParts.Top, ArrowParts.Line);

        /// <summary>
        /// A top half solid arrow to the left with a dotted line.
        /// </summary>
        public static Arrow DottedTopLeft => new(ArrowParts.Top, ArrowParts.Line, ArrowParts.Line);

        /// <summary>
        /// A top half thin arrow to the left with a solid line.
        /// </summary>
        /// <remarks>
        /// Symbol <c>↼</c>.
        /// Also known as a <em>leftwards harpoon with barb upwards</em>.
        /// </remarks>
        public static Arrow ThinTopLeft => new(ArrowParts.Top, ArrowParts.Top, ArrowParts.Line);

        /// <summary>
        /// A top half thin arrow to the left with a dotted line.
        /// </summary>
        /// <inheritdoc cref="ThinTopLeft"/>
        public static Arrow DottedThinTopLeft => new(ArrowParts.Top, ArrowParts.Top, ArrowParts.Line, ArrowParts.Line);
    }
}
