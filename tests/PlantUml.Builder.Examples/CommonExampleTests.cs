namespace PlantUml.Builder.Examples;

/// <summary>
/// Examples from https://plantuml.com/commons
/// </summary>
[TestClass]
public class CommonExampleTests
{
    /// <seealso href="https://plantuml.com/commons#comments"/>
    [TestMethod]
    public void Comments01()
    {
        // Arrange
        var example =
            """
            @startuml
            ' Line comments use a single apostrophe
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Comment("Line comments use a single apostrophe");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/commons#comments"/>
    [TestMethod]
    public void Comments02()
    {
        // Arrange
        var example =
            """
            @startuml
            /'
            many lines comments
            here
            '/
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Text("/'");
        stringBuilder.Text("many lines comments");
        stringBuilder.Text("here");
        stringBuilder.Text("'/");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/commons#comments"/>
    [TestMethod]
    public void Comments03()
    {
        // Arrange
        var example =
            """
            @startuml
            /' case 1 '/   A -> B : AB-First step
            B -> C : BC-Second step
            /' case 2 '/   D -> E : DE-Third step
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Text("/' case 1 '/   A -> B : AB-First step");
        stringBuilder.Arrow("B", Arrow.Right, "C", "BC-Second step");
        stringBuilder.Text("/' case 2 '/   D -> E : DE-Third step");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/commons#comments"/>
    [TestMethod]
    public void Comments04()
    {
        // Arrange
        var example =
            """
            @startuml
            skinparam activity {
                ' this is a comment
                BackgroundColor White
                BorderColor Black /' this is a comment '/
                BorderColor Red  ' this is not a comment and this line is ignored
            }

            start
            :foo1;
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Text("skinparam activity {");
        stringBuilder.Text("    ' this is a comment");
        stringBuilder.Text("    BackgroundColor White");
        stringBuilder.Text("    BorderColor Black /' this is a comment '/");
        stringBuilder.Text("    BorderColor Red  ' this is not a comment and this line is ignored");
        stringBuilder.Text("}");
        stringBuilder.AppendNewLine();
        stringBuilder.Text("start");
        stringBuilder.Text(":foo1;");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/commons#title"/>
    [TestMethod]
    public void Title01()
    {
        // Arrange
        var example =
            """
            @startuml
            skinparam TitleBorderRoundCorner 15
            skinparam TitleBorderThickness 2
            skinparam TitleBorderColor red
            skinparam TitleBackgroundColor Aqua-CadetBlue

            title Simple communication\nexample

            Alice -> Bob : Authentication Request
            Bob --> Alice : Authentication Response

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.SkinParameter(SkinParameter.TitleBorderRoundCorner, 15);
        stringBuilder.SkinParameter(SkinParameter.TitleBorderThickness, 2);
        stringBuilder.SkinParameter(SkinParameter.TitleBorderColor, "red");
        stringBuilder.SkinParameter(SkinParameter.TitleBackgroundColor, "Aqua-CadetBlue");
        stringBuilder.AppendNewLine();
        stringBuilder.Title("Simple communication\\nexample");
        stringBuilder.AppendNewLine();
        stringBuilder.Arrow("Alice", Arrow.Right, "Bob", "Authentication Request");
        stringBuilder.Arrow("Bob", Arrow.AsyncReplyRight, "Alice", "Authentication Response");
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/commons#footer-and-header"/>
    [TestMethod]
    public void FooterAndHeader()
    {
        // Arrange
        var example =
            """
            @startuml
            Alice -> Bob : Authentication Request

            header
            <font color=red>Warning:</font>
            Do not use in production.
            end header

            center footer Generated for demonstration

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Arrow("Alice", Arrow.Right, "Bob", "Authentication Request");
        stringBuilder.AppendNewLine();
        stringBuilder.HeaderStart();
        stringBuilder.Text("<font color=red>Warning:</font>");
        stringBuilder.Text("Do not use in production.");
        stringBuilder.EndHeader();
        stringBuilder.AppendNewLine();
        stringBuilder.Footer("Generated for demonstration", Alignment.Center);
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/commons#mainframe"/>
    [TestMethod]
    public void Mainframe()
    {
        // Arrange
        var example =
            """
            @startuml
            mainframe This is a **mainframe**
            Alice -> Bob : Hello
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Mainframe("This is a **mainframe**");
        stringBuilder.Arrow("Alice", Arrow.Right, "Bob", "Hello");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }
}
