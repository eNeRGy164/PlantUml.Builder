using System;

namespace PlantUml.Builder.SequenceDiagrams
{
    public static class ArrowExtenstions
    {
        public static Arrow Color(this Arrow arrow, Color color)
        {
            if (arrow is null) throw new ArgumentNullException(nameof(arrow));

            return new Arrow(arrow, color);
        }

        public static Arrow Solid(this Arrow arrow)
        {
            if (arrow is null) throw new ArgumentNullException(nameof(arrow));

            return new Arrow(arrow, dottedLine: false);
        }

        public static Arrow Dotted(this Arrow arrow)
        {
            if (arrow is null) throw new ArgumentNullException(nameof(arrow));

            return new Arrow(arrow, dottedLine: true);
        }

        public static Arrow LostRight(this Arrow arrow)
        {
            if (arrow is null) throw new ArgumentNullException(nameof(arrow));

            if (arrow.RightHead.Length > 0)
            {
                if (arrow.RightHead[arrow.RightHead.Length - 1] == char.ToLowerInvariant(ArrowParts.Lost))
                {
                    return arrow;
                }
                if (arrow.RightHead[arrow.RightHead.Length - 1] == char.ToLowerInvariant(ArrowParts.Destroy))
                {
                    throw new NotSupportedException("You can not combine the lost and deleted message notation in the same arrow head.");
                }
            }

            return new Arrow(arrow.LeftHead, arrow.Dotted, arrow.RightHead + ArrowParts.Lost, arrow.Color);
        }

        public static Arrow LostLeft(this Arrow arrow)
        {
            if (arrow is null) throw new ArgumentNullException(nameof(arrow));

            if (arrow.LeftHead.Length > 0)
            {
                if (arrow.LeftHead[0] == char.ToLowerInvariant(ArrowParts.Lost))
                {
                    return arrow;
                }

                if (arrow.LeftHead[0] == char.ToLowerInvariant(ArrowParts.Destroy))
                {
                    throw new NotSupportedException("You can not combine the lost and deleted message notation in the same arrow head.");
                }
            }

            return new Arrow(ArrowParts.Lost + arrow.LeftHead, arrow.Dotted, arrow.RightHead, arrow.Color);
        }
    }
}
