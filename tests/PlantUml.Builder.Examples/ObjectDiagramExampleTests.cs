using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.ObjectDiagrams;

namespace PlantUml.Builder.Examples;

/// <summary>
/// Examples from https://plantuml.com/object-diagram
/// </summary>
[TestClass]
public class ObjectDiagramExampleTests
{
    [TestMethod]
    public void DefinitionOfObjects()
    {
        // Assign
        var example = @"@startuml
object firstObject
object ""My Second Object"" as o2
@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Object("firstObject");
        stringBuilder.Object("o2", "My Second Object");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void RelationsBetweenObjects()
    {
        // Assign
        var example = @"@startuml
object Object01
object Object02
object Object03
object Object04
object Object05
object Object06
object Object07
object Object08

Object01 <|-- Object02
Object03 *-- Object04
Object05 o-- ""4"" Object06
Object07 .. Object08 : some labels
@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Object("Object01");
        stringBuilder.Object("Object02");
        stringBuilder.Object("Object03");
        stringBuilder.Object("Object04");
        stringBuilder.Object("Object05");
        stringBuilder.Object("Object06");
        stringBuilder.Object("Object07");
        stringBuilder.Object("Object08");
        stringBuilder.AppendNewLine();
        stringBuilder.Relationship("Object01", "<|--", "Object02");
        stringBuilder.Relationship("Object03", "*--", "Object04");
        stringBuilder.Relationship("Object05", "o--", "Object06", rightCardinality: "4");
        stringBuilder.Relationship("Object07", "..", "Object08", "some labels");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void AssociationsObjects()
    {
        // Assign
        var example = @"@startuml
object o1
object o2
diamond dia
object o3

o1 --> dia
o2 --> dia
dia --> o3
@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Object("o1");
        stringBuilder.Object("o2");
        stringBuilder.Diamond("dia");
        stringBuilder.Object("o3");
        stringBuilder.AppendNewLine();
        stringBuilder.Relationship("o1", "-->", "dia");
        stringBuilder.Relationship("o2", "-->", "dia");
        stringBuilder.Relationship("dia", "-->", "o3");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void AddingFields01()
    {
        // Assign
        var example = @"@startuml

object user

user : name = ""Dummy""
user : id = 123

@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.AppendNewLine();
        stringBuilder.Object("user");
        stringBuilder.AppendNewLine();
        stringBuilder.MemberDeclaration("user", "name = \"Dummy\"");
        stringBuilder.MemberDeclaration("user", "id = 123");
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void AddingFields02()
    {
        // Assign
        var example = @"@startuml

object user {
name = ""Dummy""
id = 123
}

@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.AppendNewLine();
        stringBuilder.ObjectStart("user");
        stringBuilder.InlineClassMember("name = \"Dummy\"");
        stringBuilder.InlineClassMember("id = 123");
        stringBuilder.ObjectEnd();
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void MapTableOrAssociativeArray01()
    {
        // Assign
        var example = @"@startuml
map CapitalCity {
UK => London
USA => Washington
Germany => Berlin
}
@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.MapStart("CapitalCity");
        stringBuilder.InlineClassMember("UK => London");
        stringBuilder.InlineClassMember("USA => Washington");
        stringBuilder.InlineClassMember("Germany => Berlin");
        stringBuilder.MapEnd();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void MapTableOrAssociativeArray02()
    {
        // Assign
        var example = @"@startuml
map ""Map **Contry => CapitalCity**"" as CC {
UK => London
USA => Washington
Germany => Berlin
}
@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.MapStart("CC", "Map **Contry => CapitalCity**");
        stringBuilder.InlineClassMember("UK => London");
        stringBuilder.InlineClassMember("USA => Washington");
        stringBuilder.InlineClassMember("Germany => Berlin");
        stringBuilder.MapEnd();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void MapTableOrAssociativeArray03()
    {
        // Assign
        var example = @"@startuml
map ""map: Map<Integer, String>"" as users {
1 => Alice
2 => Bob
3 => Charlie
}
@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.MapStart("users", "map: Map<Integer, String>");
        stringBuilder.InlineClassMember("1 => Alice");
        stringBuilder.InlineClassMember("2 => Bob");
        stringBuilder.InlineClassMember("3 => Charlie");
        stringBuilder.MapEnd();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void MapTableOrAssociativeArray04()
    {
        // Assign
        var example = @"@startuml
object London

map CapitalCity {
UK *-> London
USA => Washington
Germany => Berlin
}
@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Object("London");
        stringBuilder.AppendNewLine();
        stringBuilder.MapStart("CapitalCity");
        stringBuilder.InlineClassMember("UK *-> London");
        stringBuilder.InlineClassMember("USA => Washington");
        stringBuilder.InlineClassMember("Germany => Berlin");
        stringBuilder.MapEnd();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }

    [TestMethod]
    public void MapTableOrAssociativeArray05()
    {
        // Assign
        var example = @"@startuml
object London
object Washington
object Berlin
object NewYork

map CapitalCity {
UK *-> London
USA *--> Washington
Germany *---> Berlin
}

NewYork --> CapitalCity::USA
@enduml
";

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Object("London");
        stringBuilder.Object("Washington");
        stringBuilder.Object("Berlin");
        stringBuilder.Object("NewYork");
        stringBuilder.AppendNewLine();
        stringBuilder.MapStart("CapitalCity");
        stringBuilder.InlineClassMember("UK *-> London");
        stringBuilder.InlineClassMember("USA *--> Washington");
        stringBuilder.InlineClassMember("Germany *---> Berlin");
        stringBuilder.MapEnd();
        stringBuilder.AppendNewLine();
        stringBuilder.Relationship("NewYork", "-->", "CapitalCity::USA");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
    }
}
