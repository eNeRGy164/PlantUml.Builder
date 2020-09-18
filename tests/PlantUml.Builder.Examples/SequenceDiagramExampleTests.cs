using System.Drawing;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.Examples
{
    [TestClass]
    public class SequenceDiagramExampleTests
    {
        [TestMethod]
        public void BasicExamples()
        {
            // Assign
            // Had to add spaces before the `:`
            var example = @"@startuml
Alice -> Bob : Authentication Request
Bob --> Alice : Authentication Response

Alice -> Bob : Another authentication Request
Alice <-- Bob : Another authentication Response
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "->", "Bob", "Authentication Request");
            stringBuilder.Arrow("Bob", "-->", "Alice", "Authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "Another authentication Request");
            stringBuilder.Arrow("Alice", "<--", "Bob", "Another authentication Response");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void DeclaringParticipant01()
        {
            // Assign
            var example = @"@startuml
actor Foo1
boundary Foo2
control Foo3
entity Foo4
database Foo5
collections Foo6
Foo1 -> Foo2 : To boundary
Foo1 -> Foo3 : To control
Foo1 -> Foo4 : To entity
Foo1 -> Foo5 : To database
Foo1 -> Foo6 : To collections

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("Foo1", type: ParticipantType.Actor);
            stringBuilder.Participant("Foo2", type: ParticipantType.Boundary);
            stringBuilder.Participant("Foo3", type: ParticipantType.Control);
            stringBuilder.Participant("Foo4", type: ParticipantType.Entity);
            stringBuilder.Participant("Foo5", type: ParticipantType.Database);
            stringBuilder.Participant("Foo6", type: ParticipantType.Collections);
            stringBuilder.Arrow("Foo1", "->", "Foo2", "To boundary");
            stringBuilder.Arrow("Foo1", "->", "Foo3", "To control");
            stringBuilder.Arrow("Foo1", "->", "Foo4", "To entity");
            stringBuilder.Arrow("Foo1", "->", "Foo5", "To database");
            stringBuilder.Arrow("Foo1", "->", "Foo6", "To collections");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void DeclaringParticipant02()
        {
            // Assign
            var example = @"@startuml
actor Bob #red
' The only difference between actor
' and participant is the drawing
participant Alice
participant ""I have a really\nlong name"" as L #99FF99
/' You can also declare:
   participant L as ""I have a really\nlong name""  #99FF99
  '/

Alice -> Bob : Authentication Request
Bob -> Alice : Authentication Response
Bob -> L : Log transaction
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("Bob", type: ParticipantType.Actor, color: NamedColor.Red);
            stringBuilder.Comment("The only difference between actor");
            stringBuilder.Comment("and participant is the drawing");
            stringBuilder.Participant("Alice");
            stringBuilder.Participant("L", "I have a really\\nlong name", color: new Color("#99FF99"));
            stringBuilder.Comment("You can also declare:\n   participant L as \"I have a really\\nlong name\"  #99FF99\n ");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "Authentication Request");
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Response");
            stringBuilder.Arrow("Bob", "->", "L", "Log transaction");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().BeEquivalentTo(example.Replace("\r", ""));
        }
    }
}
