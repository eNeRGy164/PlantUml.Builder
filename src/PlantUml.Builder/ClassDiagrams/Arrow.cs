namespace PlantUml.Builder.ClassDiagrams;

public partial class Arrow
{
    private readonly string arrowHeads = new(new[] {
        ArrowParts.Right,
        ArrowParts.Left,
        ArrowParts.Generalization,
        ArrowParts.Composition,
        ArrowParts.Aggregation,
        ArrowParts.ProvidedInterface,
        ArrowParts.LeftRequiredInterface,
        ArrowParts.RightRequiredInterface,
        ArrowParts.Note,
        ArrowParts.Termination
        }
    );

    public readonly string LeftHead = string.Empty;
    public readonly string RightHead = string.Empty;
    public readonly bool Dashed = false;

    public Arrow(string arrow)
    {
        ArgumentException.ThrowIfNullOrWhitespace(arrow);

        var value = arrow.Trim();

        if (value.Length < 2) throw new System.ArgumentException("The arrow type must be at least 2 characters long", nameof(arrow));
        if (!value.Contains(ArrowParts.SolidLine) && !value.Contains(ArrowParts.DashedLine)) throw new System.ArgumentException("The arrow must contain at least 1 line character ('-', '.')", nameof(arrow));
        if (value.Contains(ArrowParts.SolidLine) && value.Contains(ArrowParts.DashedLine)) throw new System.ArgumentException("The arrow must contain either a dashed line ('.') or a solid line ('-'), but not both.", nameof(arrow));

        this.Parse(value, out List<char> left, out List<char> line, out List<char> right);

        if (left.Count > 0)
        {
            this.LeftHead = new string(left.ToArray());
        }

        if (line.Contains(ArrowParts.DashedLine))
        {
            this.Dashed = true;
        }

        if (right.Count > 0)
        {
            this.RightHead = new string(right.ToArray());
        }
    }

    public override string ToString()
    {
        return $"{this.LeftHead}{(this.Dashed ? ".." : "--")}{this.RightHead}";
    }

    public static implicit operator Arrow(string arrow)
    {
        return new Arrow(arrow);
    }

    public static implicit operator string(Arrow arrow)
    {
        return arrow.ToString();
    }

    private void Parse(string value, out List<char> left, out List<char> line, out List<char> right)
    {
        left = new List<char>(value.Length);
        line = new List<char>(value.Length);
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
                else
                {
                    left.Add(value[i]);
                }
            }

            if (mode == ArrowPart.Body)
            {
                if (this.arrowHeads.Contains(value[i]))
                {
                    mode = ArrowPart.RightHead;
                }
                else
                {
                    line.Add(value[i]);
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
        RightHead
    }
}
