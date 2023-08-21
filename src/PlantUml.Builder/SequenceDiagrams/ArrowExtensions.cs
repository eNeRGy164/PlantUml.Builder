namespace PlantUml.Builder.SequenceDiagrams;

public static class ArrowExtensions
{
    /// <summary>
    /// Changes the color of the <paramref name="arrow"/> to <paramref name="color"/>.
    /// </summary>
    /// <returns>The arrow with the new color applied.</returns>
    public static Arrow Color(this Arrow arrow, Color color)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        return new Arrow(arrow, color);
    }

    /// <summary>
    /// Makes the line of the <paramref name="arrow"/> solid.
    /// </summary>
    /// <returns>The arrow with a solid line.</returns>
    public static Arrow Solid(this Arrow arrow)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        return new Arrow(arrow, dottedLine: false);
    }

    /// <summary>
    /// Makes the line of the <paramref name="arrow"/> dotted.
    /// </summary>
    /// <returns>The arrow with a dotted line.</returns>
    public static Arrow Dotted(this Arrow arrow)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        return new Arrow(arrow, dottedLine: true);
    }

    public static Arrow Destroy(this Arrow arrow)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        if (arrow.Direction == ArrowDirection.Left)
        {
            if (arrow.LeftHead[0] == char.ToLowerInvariant(ArrowParts.Destroy))
            {
                return arrow;
            }

            return new Arrow(ArrowParts.Destroy + arrow.LeftHead, arrow.Dotted, arrow.RightHead, arrow.Color);
        }

        if (arrow.Direction == ArrowDirection.Right)
        {
            if (arrow.RightHead[arrow.RightHead.Length - 1] == char.ToLowerInvariant(ArrowParts.Destroy))
            {
                return arrow;
            }

            return new Arrow(arrow.LeftHead, arrow.Dotted, arrow.RightHead + ArrowParts.Destroy, arrow.Color);
        }

        throw new NotSupportedException("This method only destroys an arrow if it is in a clear left or right direction.");
    }

    public static Arrow Lost(this Arrow arrow)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        if (arrow.Direction == ArrowDirection.Left)
        {
            return arrow.LostLeft();
        }

        if (arrow.Direction == ArrowDirection.Right)
        {
            return arrow.LostRight();
        }

        throw new NotSupportedException("This method only loses an arrow if it is in a clear left or right direction.");
    }

    /// <summary>
    /// Adds the <em>lost</em> indication to the right side of the <paramref name="arrow"/>.
    /// </summary>
    /// <returns>The arrow with the lost indication on the right side.</returns>
    /// <exception cref="NotSupportedException">The right side is already destroyed.</exception>
    public static Arrow LostRight(this Arrow arrow)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        string newRightHead;

        if (arrow.RightHead.Length > 0)
        {
            var lastChar = arrow.RightHead[arrow.RightHead.Length - 1];

            if (arrow.RightHead.ToLowerInvariant().Count(c => c == ArrowParts.Lost) == 1)
            {
                return arrow;
            }

            if (arrow.RightHead.ToLowerInvariant().IndexOf(ArrowParts.Destroy) > -1)
            {
                throw new NotSupportedException("You can not combine the lost and deleted message notation in the same arrow head.");
            }

            newRightHead = (lastChar == ArrowParts.RightExternal || lastChar == ArrowParts.ShortExternal)
                ? arrow.RightHead.Substring(0, Math.Max(0, arrow.RightHead.Length - 1)) + ArrowParts.Lost + lastChar
                : arrow.RightHead + ArrowParts.Lost;
        }
        else
        {
            newRightHead = new string(ArrowParts.Lost, 1);
        }

        return new Arrow(arrow.LeftHead, arrow.Dotted, newRightHead, arrow.Color);
    }

    /// <summary>
    /// Adds the <em>lost</em> indication to the left side of the <paramref name="arrow"/>.
    /// </summary>
    /// <returns>The arrow with the lost indication on the left side.</returns>
    /// <exception cref="NotSupportedException">The left side is already destroyed.</exception>
    public static Arrow LostLeft(this Arrow arrow)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        string newLeftHead;

        if (arrow.LeftHead.Length > 0)
        {
            if (arrow.LeftHead.ToLowerInvariant().Count(c => c == ArrowParts.Lost) == 1)
            {
                return arrow;
            }

            if (arrow.LeftHead.ToLowerInvariant().IndexOf(ArrowParts.Destroy) > -1)
            {
                throw new NotSupportedException("You can not combine the lost and deleted message notation in the same arrow head.");
            }

            newLeftHead = (arrow.LeftHead[0] == ArrowParts.LeftExternal || arrow.LeftHead[0] == ArrowParts.ShortExternal)
                ? string.Empty + arrow.LeftHead[0] + ArrowParts.Lost + arrow.LeftHead.Substring(1)
                : ArrowParts.Lost + arrow.LeftHead;
        }
        else
        {
            newLeftHead = new string(ArrowParts.Lost, 1);
        }

        return new Arrow(newLeftHead, arrow.Dotted, arrow.RightHead, arrow.Color);
    }

    /// <summary>
    /// Adds the <em>external</em> indication to the left side of the <paramref name="arrow"/>.
    /// </summary>
    /// <returns>The arrow with the external indication on the left side.</returns>
    public static Arrow ExternalLeft(this Arrow arrow)
    {
        if (arrow.IsExternalLeft())
        {
            return arrow;
        }

        return new Arrow(ArrowParts.LeftExternal + arrow.LeftHead, arrow.Dotted, arrow.RightHead, arrow.Color);
    }

    /// <summary>
    /// Adds the <em>external</em> indication to the right side of the <paramref name="arrow"/>.
    /// </summary>
    /// <returns>The arrow with the external indication on the right side.</returns>
    public static Arrow ExternalRight(this Arrow arrow)
    {
        if (arrow.IsExternalRight())
        {
            return arrow;
        }

        return new Arrow(arrow.LeftHead, arrow.Dotted, arrow.RightHead + ArrowParts.RightExternal, arrow.Color);
    }

    /// <summary>
    /// Determines if the left side is outside the diagram.
    /// </summary>
    /// <returns><c>true</c> if the left side is outside the diagram.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="arrow"/> is <c>null</c>.</exception>
    public static bool IsExternalLeft(this Arrow arrow)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        if (arrow.LeftHead.Length > 0)
        {
            var leftChar = arrow.LeftHead[0];
            return leftChar == ArrowParts.LeftExternal || leftChar == ArrowParts.ShortExternal;
        }

        return false;
    }

    /// <summary>
    /// Determines if the right side is outside the diagram.
    /// </summary>
    /// <returns><c>true</c> if the right side is outside the diagram.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="arrow"/> is <c>null</c>.</exception>
    public static bool IsExternalRight(this Arrow arrow)
    {
        ArgumentNullException.ThrowIfNull(arrow, nameof(arrow));

        if (arrow.RightHead.Length > 0)
        {
            var rightChar = arrow.RightHead[^1];

            return rightChar == ArrowParts.RightExternal || rightChar == ArrowParts.ShortExternal;
        }

        return false;
    }
}
