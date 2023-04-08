using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantUml.Builder.SequenceDiagrams;

public partial class Arrow
{
    private readonly char[] arrowHeads = new[] {
        ArrowParts.Right,
        ArrowParts.Left,
        ArrowParts.Lost,
        ArrowParts.Bottom,
        ArrowParts.Top,
        ArrowParts.Destroy,
        ArrowParts.RightExternal,
        ArrowParts.LeftExternal,
        ArrowParts.ShortExternal
    };

    public readonly string LeftHead = string.Empty;
    public readonly string RightHead = string.Empty;
    public readonly bool Dotted = false;
    public readonly Color Color = null;
    public readonly ArrowDirection Direction = ArrowDirection.None;

    public Arrow(params char[] chars)
        : this(new string(chars))
    {
    }

    public Arrow(string arrow)
    {
        if (string.IsNullOrWhiteSpace(arrow)) throw new ArgumentException("A non-empty value should be provided", nameof(arrow));

        var value = arrow.Trim();

        if (value.Length < 2) throw new ArgumentException("The arrow type must be at least 2 characters long", nameof(arrow));

        if (value.IndexOf(ArrowParts.Line) == -1) throw new ArgumentException("The arrow must contain at least 1 line character ('-')", nameof(arrow));
        if (value.IndexOfAny(this.arrowHeads) == -1) throw new ArgumentException($"The arrow must contain at least 1 arrow head character ('{string.Join("', '", this.arrowHeads)}').", nameof(arrow));

        this.Parse(value, out List<char> left, out List<char> line, out List<char> color, out List<char> right);

        if (left.Count > 0)
        {
            this.LeftHead = new string(left.ToArray());

            if (this.LeftHead.TrimStart(ArrowParts.Lost).Length > 0)
            {
                this.Direction |= ArrowDirection.Left;
            }
        }

        if (line.Count > 1)
        {
            this.Dotted = true;
        }

        if (color.Count > 0)
        {
            this.Color = new string(color.ToArray());
        }

        if (right.Count > 0)
        {
            this.RightHead = new string(right.ToArray());

            if (this.RightHead.TrimEnd(ArrowParts.Lost).Length > 0)
            {
                this.Direction |= ArrowDirection.Right;
            }
        }
    }

    public Arrow(Arrow arrow, bool dottedLine)
    {
        this.LeftHead = arrow.LeftHead;
        this.RightHead = arrow.RightHead;
        this.Color = arrow.Color;

        this.Dotted = dottedLine;
    }

    public Arrow(Arrow arrow, Color color)
    {
        this.LeftHead = arrow.LeftHead;
        this.RightHead = arrow.RightHead;
        this.Dotted = arrow.Dotted;

        this.Color = color;
    }

    public Arrow(string leftHead, bool dottedLine, string rightHead, Color color = null)
    {
        this.LeftHead = leftHead;
        this.RightHead = rightHead;
        this.Dotted = dottedLine;
        this.Color = color;
    }

    public override string ToString()
    {
        return $"{this.LeftHead}{(this.Dotted ? "--" : "-")}{this.Color:b}{this.RightHead}";
    }

    public static implicit operator Arrow(string arrow)
    {
        return new Arrow(arrow);
    }

    public static implicit operator string(Arrow arrow)
    {
        return arrow.ToString();
    }

    private void Parse(string value, out List<char> left, out List<char> line, out List<char> color, out List<char> right)
    {
        left = new List<char>(value.Length);
        line = new List<char>(value.Length);
        color = new List<char>(value.Length);
        right = new List<char>(value.Length);

        var mode = ArrowPart.LeftHead;

        for (var i = 0; i < value.Length; i++)
        {
            if (mode == ArrowPart.LeftHead)
            {
                if (!this.arrowHeads.Contains(value[i]))
                {
                    mode = ArrowPart.Body;
                }
                else if (value[i] == Constant.ColorStart && (i < value.Length - 1) && value[i + 1] == Constant.ColorPrefix)
                {
                    // Left arrow head can start with a '[', but should not be a color.
                    mode = ArrowPart.Color;
                }
                else
                {
                    left.Add(value[i]);
                }
            }

            if (mode == ArrowPart.Body)
            {
                if (value[i] == Constant.ColorStart && (i < value.Length - 1) && value[i + 1] == Constant.ColorPrefix)
                {
                    mode = ArrowPart.Color;
                }
                else if (this.arrowHeads.Contains(value[i]))
                {
                    mode = ArrowPart.RightHead;
                }
                else
                {
                    line.Add(value[i]);
                }
            }

            if (mode == ArrowPart.Color)
            {
                if (value[i] == Constant.ColorStart)
                {
                    continue;
                }
                else if (value[i] == Constant.ColorEnd)
                {
                    mode = ArrowPart.Body;
                    continue;
                }
                else
                {
                    color.Add(value[i]);
                }
            }

            if (mode == ArrowPart.RightHead)
            {
                right.Add(value[i]);
            }
        }
    }

    private enum ArrowPart
    {
        LeftHead,
        Body,
        Color,
        RightHead
    }
}
