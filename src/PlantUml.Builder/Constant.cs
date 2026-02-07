namespace PlantUml.Builder;

/// <summary>
/// Contains constant values used across the PlantUML builder.
/// </summary>
public class Constant
{
    public const char Delay = Symbols.Dot;
    public const char Divider = Symbols.Equal;
    public const char Spacing = Symbols.Pipe;
    public const char NoteBox = 'r';
    public const char NoteHexagon = 'h';
    public const char Comment = Symbols.SingleQuote;
    public const char AlignNote = '/';

    public const string CommentStart = "/'";
    public const string CommentEnd = "'/";

    public const string SterotypeStart = "<<";
    public const string SterotypeEnd = ">>";

    public const string UrlStart = "[[";
    public const string UrlEnd = "]]";

    public const char TagPrefix = '$';

    public const char GenericsStart = '<';
    public const char GenericsEnd = '>';

    public const char GroupLabelStart = '[';
    public const char GroupLabelEnd = ']';

    public const string TargetActivation = "++";
    public const string SourceDeactivation = "--";
    public const string TargetInstanceCreation = "**";
    public const string TargetInstanceDestruction = "!!";

    /// <summary>
    /// Constants representing symbols.
    /// </summary>
    public static class Symbols
    {
        public const char At = '@';
        public const char Colon = ':';
        public const char Comma = ',';
        public const char Dot = '.';
        public const char Equal = '=';
        public const char Exclamation = '!';
        public const char NewLine = '\n';
        public const char Pipe = '|';
        public const char Quote = '\"';
        public const char SingleQuote = '\'';
        public const char Space = ' ';
        public const char Underscore = '_';
    }

    /// <summary>
    /// Constants representing words.
    /// </summary>
    public static class Words
    {
        public const string Abstract = "abstract";
        public const string Activate = "activate";
        public const string Allow = "allow";
        public const string Alt = "alt";
        public const string As = "as";
        public const string Auto = "auto";
        public const string Bottom = "bottom";
        public const string Center = "center";
        public const string Box = "box";
        public const string Create = "create";
        public const string Deactivate = "deactivate";
        public const string Destroy = "destroy";
        public const string Direction = "direction";
        public const string Else = "else";
        public const string Empty = "empty";
        public const string End = "end";
        public const string Extends = "extends";
        public const string Footbox = "footbox";
        public const string Footer = "footer";
        public const string Group = "group";
        public const string Header = "header";
        public const string Hide = "hide";
        public const string Implements = "implements";
        public const string Increase = "inc";
        public const string Left = "left";
        public const string Legend = "legend";
        public const string Loop = "loop";
        public const string Mainframe = "mainframe";
        public const string Map = "map";
        public const string Mixing = "mixing";
        public const string Namespace = "namespace";
        public const string New = "new";
        public const string None = "none";
        public const string Note = "note";
        public const string Number = "number";
        public const string Object = "object";
        public const string Of = "of";
        public const string On = "on";
        public const string Order = "order";
        public const string Over = "over";
        public const string Page = "page";
        public const string Pragma = "pragma";
        public const string Ref = "ref";
        public const string Remove = "remove";
        public const string Resume = "resume";
        public const string Return = "return";
        public const string Right = "right";
        public const string Separator = "separator";
        public const string Set = "set";
        public const string Show = "show";
        public const string SkinParam = "skinparam";
        public const string Start = "start";
        public const string Static = "static";
        public const string Stop = "stop";
        public const string Title = "title";
        public const string To = "to";
        public const string Top = "top";
        public const string Unlinked = "unlinked";
        public const string Uml = "uml";
    }

    /// <summary>
    /// Constants related to colors.
    /// </summary>
    public static class Color
    {
        public const char Prefix = '#';
        public const char Start = '[';
        public const char End = ']';
    }

    /// <summary>
    /// Constants related to visibility.
    /// </summary>
    public static class Visibility
    {
        public const char Public = '+';
        public const char Private = '-';
        public const char Protected = '#';
        public const char PackagePrivate = '~';
    }

    /// <summary>
    /// Constants related to modifiers.
    /// </summary>
    public static class Modifiers
    {
        public const char Start = '{';
        public const char End = '}';
    }

    /// <summary>
    /// Constants related to class.
    /// </summary>
    public static class Class
    {
        public const char Start = '{';
        public const char End = '}';
    }

    /// <summary>
    /// Constants related to object.
    /// </summary>
    public static class Object
    {
        public const char Start = '{';
        public const char End = '}';
    }

    /// <summary>
    /// Constants related to namespace.
    /// </summary>
    public static class Namespace
    {
        public const char Start = '{';
        public const char End = '}';
    }

    /// <summary>
    /// Constants related to map.
    /// </summary>
    public static class Map
    {
        public const char Start = '{';
        public const char End = '}';
    }

    /// <summary>
    /// Constants related to styling and customization in various diagrams.
    /// </summary>
    public static class Styling
    {
        public static class CustomSpot
        {
            public const char Start = '(';
            public const char End = ')';
        }

        public static class Border
        {
            public const char Start = '[';
            public const char End = ']';
        }
    }
}
