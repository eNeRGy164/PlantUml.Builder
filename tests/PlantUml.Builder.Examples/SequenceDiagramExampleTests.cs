using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlantUml.Builder.Examples
{
    /// <summary>
    /// Examples from https://plantuml.com/sequence-diagram
    /// </summary>
    [TestClass]
    public class SequenceDiagramExampleTests
    {
        [TestMethod]
        public void BasicExamples()
        {
            // Assign
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
            stringBuilder.Participant("L", "I have a really\\nlong name", color: "#99FF99");
            stringBuilder.CommentBlock("You can also declare:\n   participant L as \"I have a really\\nlong name\"  #99FF99\n ");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "Authentication Request");
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Response");
            stringBuilder.Arrow("Bob", "->", "L", "Log transaction");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().BeEquivalentTo(example.Replace("\r", ""));
        }

        [TestMethod]
        public void DeclaringParticipant03()
        {
            // Assign
            var example = @"@startuml
participant Last order 30
participant Middle order 20
participant First order 10
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("Last", order: 30);
            stringBuilder.Participant("Middle", order: 20);
            stringBuilder.Participant("First", order: 10);
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void UseNonLettersInParticipants()
        {
            // Assign
            var example = @"@startuml
Alice -> ""Bob()"" : Hello
""Bob()"" -> ""This is very\nlong"" as Long
' You can also declare:
' ""Bob()"" -> Long as ""This is very\nlong""
Long --> ""Bob()"" : ok
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "->", "\"Bob()\"", "Hello");
            stringBuilder.Arrow("\"Bob()\"", "->", "\"This is very\nlong\" as Long");
            stringBuilder.Comment("You can also declare:");
            stringBuilder.Comment("\"Bob()\" -> Long as \"This is very\\nlong\"");
            stringBuilder.Arrow("Long", "-->", "\"Bob()\"", "ok");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void MessageToSelf()
        {
            // Assign
            var example = @"@startuml
Alice -> Alice : This is a signal to self.\nIt also demonstrates\nmultiline \ntext
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "->", "Alice", "This is a signal to self.\nIt also demonstrates\nmultiline \ntext");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void TextAlignment()
        {
            // Assign
            var example = @"@startuml
skinparam responseMessageBelowArrow true
Bob -> Alice : hello
Alice -> Bob : ok
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.SkinParameter(SkinParameter.ResponseMessageBelowArrow, "true");
            stringBuilder.Arrow("Bob", "->", "Alice", "hello");
            stringBuilder.Arrow("Alice", "->", "Bob", "ok");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().BeEquivalentTo(example.Replace("\r", ""));
        }

        [TestMethod]
        public void ChangeArrowStyle()
        {
            // Assign
            var example = @"@startuml
Bob ->x Alice
Bob -> Alice
Bob ->> Alice
Bob -\ Alice
Bob \\- Alice
Bob //-- Alice

Bob ->o Alice
Bob o\\-- Alice

Bob <-> Alice
Bob <->o Alice
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Bob", "->x", "Alice");
            stringBuilder.Arrow("Bob", "->", "Alice");
            stringBuilder.Arrow("Bob", "->>", "Alice");
            stringBuilder.Arrow("Bob", "-\\", "Alice");
            stringBuilder.Arrow("Bob", "\\\\-", "Alice");
            stringBuilder.Arrow("Bob", "//--", "Alice");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Bob", "->o", "Alice");
            stringBuilder.Arrow("Bob", "o\\\\--", "Alice");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Bob", "<->", "Alice");
            stringBuilder.Arrow("Bob", "<->o", "Alice");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void ChangeArrowColor()
        {
            // Assign
            var example = @"@startuml
Bob -[#red]> Alice : hello
Alice -[#0000FF]-> Bob : ok
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Bob", "-[#red]>", "Alice", "hello");
            stringBuilder.Arrow("Alice", "-[#0000FF]->", "Bob", "ok");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void MessageSequenceNumbering01()
        {
            // Assign
            var example = @"@startuml
autonumber
Bob -> Alice : Authentication Request
Bob <- Alice : Authentication Response
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AutoNumber();
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Authentication Response");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void MessageSequenceNumbering02()
        {
            // Assign
            var example = @"@startuml
autonumber
Bob -> Alice : Authentication Request
Bob <- Alice : Authentication Response

autonumber 15
Bob -> Alice : Another authentication Request
Bob <- Alice : Another authentication Response

autonumber 40 10
Bob -> Alice : Yet another authentication Request
Bob <- Alice : Yet another authentication Response

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AutoNumber();
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.AutoNumber(start: 15);
            stringBuilder.Arrow("Bob", "->", "Alice", "Another authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Another authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.AutoNumber(start: 40, step: 10);
            stringBuilder.Arrow("Bob", "->", "Alice", "Yet another authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Yet another authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void MessageSequenceNumbering03()
        {
            // Assign
            var example = @"@startuml
autonumber ""<b>[000]""
Bob -> Alice : Authentication Request
Bob <- Alice : Authentication Response

autonumber 15 ""<b>(<u>##</u>)""
Bob -> Alice : Another authentication Request
Bob <- Alice : Another authentication Response

autonumber 40 10 ""<font color=red><b>Message 0  ""
Bob -> Alice : Yet another authentication Request
Bob <- Alice : Yet another authentication Response

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AutoNumber(format: "<b>[000]");
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.AutoNumber(start: 15, format: "<b>(<u>##</u>)");
            stringBuilder.Arrow("Bob", "->", "Alice", "Another authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Another authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.AutoNumber(start: 40, step: 10, format: "<font color=red><b>Message 0  ");
            stringBuilder.Arrow("Bob", "->", "Alice", "Yet another authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Yet another authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void MessageSequenceNumbering04()
        {
            // Assign
            var example = @"@startuml
autonumber 10 10 ""<b>[000]""
Bob -> Alice : Authentication Request
Bob <- Alice : Authentication Response

autonumber stop
Bob -> Alice : dummy

autonumber resume ""<font color=red><b>Message 0  ""
Bob -> Alice : Yet another authentication Request
Bob <- Alice : Yet another authentication Response

autonumber stop
Bob -> Alice : dummy

autonumber resume 1 ""<font color=blue><b>Message 0  ""
Bob -> Alice : Yet another authentication Request
Bob <- Alice : Yet another authentication Response
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AutoNumber(start: 10, step: 10, format: "<b>[000]");
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.StopAutoNumber();
            stringBuilder.Arrow("Bob", "->", "Alice", "dummy");
            stringBuilder.AppendNewLine();
            stringBuilder.ResumeAutoNumber(format: "<font color=red><b>Message 0  ");
            stringBuilder.Arrow("Bob", "->", "Alice", "Yet another authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Yet another authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.StopAutoNumber();
            stringBuilder.Arrow("Bob", "->", "Alice", "dummy");
            stringBuilder.AppendNewLine();
            stringBuilder.ResumeAutoNumber(step: 1, format: "<font color=blue><b>Message 0  ");
            stringBuilder.Arrow("Bob", "->", "Alice", "Yet another authentication Request");
            stringBuilder.Arrow("Bob", "<-", "Alice", "Yet another authentication Response");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void PageTitleHeaderAndFooter()
        {
            // Assign
            var example = @"@startuml

header Page Header
footer Page %page% of %lastpage%

title Example Title

Alice -> Bob : message 1
Alice -> Bob : message 2

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AppendNewLine();
            stringBuilder.Header("Page Header");
            stringBuilder.Footer("Page %page% of %lastpage%");
            stringBuilder.AppendNewLine();
            stringBuilder.Title("Example Title");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "message 1");
            stringBuilder.Arrow("Alice", "->", "Bob", "message 2");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void SplittingDiagrams()
        {
            // Assign
            var example = @"@startuml
Alice -> Bob : message 1
Alice -> Bob : message 2

newpage

Alice -> Bob : message 3
Alice -> Bob : message 4

newpage A title for the\nlast page

Alice -> Bob : message 5
Alice -> Bob : message 6
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "->", "Bob", "message 1");
            stringBuilder.Arrow("Alice", "->", "Bob", "message 2");
            stringBuilder.AppendNewLine();
            stringBuilder.NewPage();
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "message 3");
            stringBuilder.Arrow("Alice", "->", "Bob", "message 4");
            stringBuilder.AppendNewLine();
            stringBuilder.NewPage("A title for the\nlast page");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "message 5");
            stringBuilder.Arrow("Alice", "->", "Bob", "message 6");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void GroupingMessages()
        {
            // Assign
            var example = @"@startuml
Alice -> Bob : Authentication Request

alt successful case

Bob -> Alice : Authentication Accepted

else some kind of failure

Bob -> Alice : Authentication Failure
group My own label
Alice -> Log : Log attack start
loop 1000 times
Alice -> Bob : DNS Attack
end
Alice -> Log : Log attack end
end

else Another type of failure

Bob -> Alice : Please repeat

end
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "->", "Bob", "Authentication Request");
            stringBuilder.AppendNewLine();
            stringBuilder.AltStart("successful case");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Accepted");
            stringBuilder.AppendNewLine();
            stringBuilder.ElseStart("some kind of failure");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Failure");
            stringBuilder.GroupStart(label: "My own label");
            stringBuilder.Arrow("Alice", "->", "Log", "Log attack start");
            stringBuilder.StartLoop("1000 times");
            stringBuilder.Arrow("Alice", "->", "Bob", "DNS Attack");
            stringBuilder.EndLoop();
            stringBuilder.Arrow("Alice", "->", "Log", "Log attack end");
            stringBuilder.GroupEnd();
            stringBuilder.AppendNewLine();
            stringBuilder.ElseStart("Another type of failure");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Bob", "->", "Alice", "Please repeat");
            stringBuilder.AppendNewLine();
            stringBuilder.GroupEnd();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void NotesOnMessages()
        {
            // Assign
            var example = @"@startuml
Alice -> Bob : hello
note left : this is a first note

Bob -> Alice : ok
note right : this is another note

Bob -> Bob : I am thinking
note left
a note
can also be defined
on several lines
end note
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "->", "Bob", "hello");
            stringBuilder.Note(NotePosition.Left, "this is a first note");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Bob", "->", "Alice", "ok");
            stringBuilder.Note(NotePosition.Right, "this is another note");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Bob", "->", "Bob", "I am thinking");
            stringBuilder.StartNote(NotePosition.Left);
            stringBuilder.Text("a note");
            stringBuilder.Text("can also be defined");
            stringBuilder.Text("on several lines");
            stringBuilder.EndNote();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void SomeOtherNotes()
        {
            // Assign
            var example = @"@startuml
participant Alice
participant Bob
note left of Alice #aqua
This is displayed
left of Alice.
end note

note right of Alice : This is displayed right of Alice.

note over Alice : This is displayed over Alice.

note over Alice,Bob #FFAAAA : This is displayed\n over Bob and Alice.

note over Bob,Alice
This is yet another
example of
a long note.
end note
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("Alice");
            stringBuilder.Participant("Bob");
            stringBuilder.StartNote(NotePosition.Left, "Alice", color: NamedColor.Aqua);
            stringBuilder.Text("This is displayed");
            stringBuilder.Text("left of Alice.");
            stringBuilder.EndNote();
            stringBuilder.AppendNewLine();
            stringBuilder.Note(NotePosition.Right, "Alice", "This is displayed right of Alice.");
            stringBuilder.AppendNewLine();
            stringBuilder.Note("Alice", "This is displayed over Alice.");
            stringBuilder.AppendNewLine();
            stringBuilder.Note("Alice", "Bob", "This is displayed\n over Bob and Alice.", color: "#FFAAAA");
            stringBuilder.AppendNewLine();
            stringBuilder.StartNote("Bob", "Alice");
            stringBuilder.Text("This is yet another");
            stringBuilder.Text("example of");
            stringBuilder.Text("a long note.");
            stringBuilder.EndNote();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().BeEquivalentTo(example.Replace("\r", ""));
        }

        [TestMethod]
        public void ChangingNotesShape()
        {
            // Assign
            var example = @"@startuml
caller -> server : conReq
hnote over caller : idle
caller <- server : conConf
rnote over server
 ""r"" as rectangle
 ""h"" as hexagon
end rnote
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("caller", "->", "server", "conReq");
            stringBuilder.Note("caller", "idle", style: NoteStyle.Hexagonal);
            stringBuilder.Arrow("caller", "<-", "server", "conConf");
            stringBuilder.StartNote("server", style: NoteStyle.Box);
            stringBuilder.Text(" \"r\" as rectangle");
            stringBuilder.Text(" \"h\" as hexagon");
            stringBuilder.EndRNote();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void CrealeAndHtml()
        {
            // Assign
            var example = @"@startuml
participant Alice
participant ""The **Famous** Bob"" as Bob

Alice -> Bob : hello --there--
... Some ~~long delay~~ ...
Bob -> Alice : ok
note left
  This is **bold**
  This is //italics//
  This is """"monospaced""""
  This is --stroked--
  This is __underlined__
  This is ~~waved~~
end note

Alice -> Bob : A //well formatted// message
note right of Alice
 This is <back:cadetblue><size:18>displayed</size></back>
 __left of__ Alice.
end note
note left of Bob
 <u:red>This</u> is <color #118888>displayed</color>
 **<color purple>left of</color> <s:red>Alice</strike> Bob**.
end note
note over Alice,Bob
 <w:#FF33FF>This is hosted</w> by <img sourceforge.jpg>
end note
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("Alice");
            stringBuilder.Participant("Bob", "The **Famous** Bob");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "hello --there--");
            stringBuilder.Delay(" Some ~~long delay~~ ");
            stringBuilder.Arrow("Bob", "->", "Alice", "ok");
            stringBuilder.StartNote(NotePosition.Left);
            stringBuilder.Text("  This is **bold**");
            stringBuilder.Text("  This is //italics//");
            stringBuilder.Text("  This is \"\"monospaced\"\"");
            stringBuilder.Text("  This is --stroked--");
            stringBuilder.Text("  This is __underlined__");
            stringBuilder.Text("  This is ~~waved~~");
            stringBuilder.EndNote();
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "A //well formatted// message");
            stringBuilder.StartNote(NotePosition.Right, "Alice");
            stringBuilder.Text(" This is <back:cadetblue><size:18>displayed</size></back>");
            stringBuilder.Text(" __left of__ Alice.");
            stringBuilder.EndNote();
            stringBuilder.StartNote(NotePosition.Left, "Bob");
            stringBuilder.Text(" <u:red>This</u> is <color #118888>displayed</color>");
            stringBuilder.Text(" **<color purple>left of</color> <s:red>Alice</strike> Bob**.");
            stringBuilder.EndNote();
            stringBuilder.StartNote("Alice", "Bob");
            stringBuilder.Text(" <w:#FF33FF>This is hosted</w> by <img sourceforge.jpg>");
            stringBuilder.EndNote();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void Divider()
        {
            // Assign
            var example = @"@startuml

== Initialization ==

Alice -> Bob : Authentication Request
Bob --> Alice : Authentication Response

== Repetition ==

Alice -> Bob : Another authentication Request
Alice <-- Bob : another authentication Response

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AppendNewLine();
            stringBuilder.Divider(" Initialization ");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "Authentication Request");
            stringBuilder.Arrow("Bob", "-->", "Alice", "Authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.Divider(" Repetition ");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "Another authentication Request");
            stringBuilder.Arrow("Alice", "<--", "Bob", "another authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void Reference()
        {
            // Assign
            var example = @"@startuml
participant Alice
actor Bob

ref over Alice,Bob : init

Alice -> Bob : hello

ref over Bob
  This can be on
  several lines
end ref
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("Alice");
            stringBuilder.Participant("Bob", type: ParticipantType.Actor);
            stringBuilder.AppendNewLine();
            stringBuilder.Ref("Alice", "Bob", "init");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "hello");
            stringBuilder.AppendNewLine();
            stringBuilder.StartRef("Bob");
            stringBuilder.Text("  This can be on");
            stringBuilder.Text("  several lines");
            stringBuilder.EndRef();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void Delay()
        {
            // Assign
            var example = @"@startuml

Alice -> Bob : Authentication Request
...
Bob --> Alice : Authentication Response
...5 minutes later...
Bob --> Alice : Bye !

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "Authentication Request");
            stringBuilder.Delay();
            stringBuilder.Arrow("Bob", "-->", "Alice", "Authentication Response");
            stringBuilder.Delay("5 minutes later");
            stringBuilder.Arrow("Bob", "-->", "Alice", "Bye !");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void Space()
        {
            // Assign
            var example = @"@startuml

Alice -> Bob : message 1
Bob --> Alice : ok
|||
Alice -> Bob : message 2
Bob --> Alice : ok
||45||
Alice -> Bob : message 3
Bob --> Alice : ok

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "->", "Bob", "message 1");
            stringBuilder.Arrow("Bob", "-->", "Alice", "ok");
            stringBuilder.Space();
            stringBuilder.Arrow("Alice", "->", "Bob", "message 2");
            stringBuilder.Arrow("Bob", "-->", "Alice", "ok");
            stringBuilder.Space(45);
            stringBuilder.Arrow("Alice", "->", "Bob", "message 3");
            stringBuilder.Arrow("Bob", "-->", "Alice", "ok");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void LifelineActivationAndDestruction01()
        {
            // Assign
            var example = @"@startuml
participant User

User -> A : DoWork
activate A

A -> B : << createRequest >>
activate B

B -> C : DoWork
activate C
C --> B : WorkDone
destroy C

B --> A : RequestCreated
deactivate B

A -> User : Done
deactivate A

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("User");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("User", "->", "A", "DoWork");
            stringBuilder.Activate("A");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("A", "->", "B", "<< createRequest >>");
            stringBuilder.Activate("B");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("B", "->", "C", "DoWork");
            stringBuilder.Activate("C");
            stringBuilder.Arrow("C", "-->", "B", "WorkDone");
            stringBuilder.Destroy("C");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("B", "-->", "A", "RequestCreated");
            stringBuilder.Deactivate("B");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("A", "->", "User", "Done");
            stringBuilder.Deactivate("A");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void LifelineActivationAndDestruction02()
        {
            // Assign
            var example = @"@startuml
participant User

User -> A : DoWork
activate A #FFBBBB

A -> A : Internal call
activate A #DarkSalmon

A -> B : << createRequest >>
activate B

B --> A : RequestCreated
deactivate B
deactivate A
A -> User : Done
deactivate A

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("User");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("User", "->", "A", "DoWork");
            stringBuilder.Activate("A", color: "#FFBBBB");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("A", "->", "A", "Internal call");
            stringBuilder.Activate("A", color: NamedColor.DarkSalmon);
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("A", "->", "B", "<< createRequest >>");
            stringBuilder.Activate("B");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("B", "-->", "A", "RequestCreated");
            stringBuilder.Deactivate("B");
            stringBuilder.Deactivate("A");
            stringBuilder.Arrow("A", "->", "User", "Done");
            stringBuilder.Deactivate("A");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void LifelineActivationAndDestruction03()
        {
            // Assign
            var example = @"@startuml
autoactivate on
alice -> bob : hello
bob -> bob : self call
bill -> bob #005500 : hello from thread 2
bob -> george ** : create
return done in thread 2
return rc
bob -> george !! : delete
return success

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AutoActivate();
            stringBuilder.Arrow("alice", "->", "bob", "hello");
            stringBuilder.Arrow("bob", "->", "bob", "self call");
            stringBuilder.Arrow("bill", "->", "bob", "hello from thread 2", activationColor: "#005500");
            stringBuilder.Arrow("bob", "->", "george", "create", createInstanceTarget: true);
            stringBuilder.Return("done in thread 2");
            stringBuilder.Return("rc");
            stringBuilder.Arrow("bob", "->", "george", "delete", destroyInstanceTarget: true);
            stringBuilder.Return("success");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void Return()
        {
            // Assign
            var example = @"@startuml
Bob -> Alice : hello
activate Alice
Alice -> Alice : some action
return bye
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Bob", "->", "Alice", "hello");
            stringBuilder.Activate("Alice");
            stringBuilder.Arrow("Alice", "->", "Alice", "some action");
            stringBuilder.Return("bye");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void ParticipantCreation()
        {
            // Assign
            var example = @"@startuml
Bob -> Alice : hello

create Other
Alice -> Other : new

create control String
Alice -> String
note right : You can also put notes!

Alice --> Bob : ok

@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Bob", "->", "Alice", "hello");
            stringBuilder.AppendNewLine();
            stringBuilder.Create("Other");
            stringBuilder.Arrow("Alice", "->", "Other", "new");
            stringBuilder.AppendNewLine();
            stringBuilder.CreateControl("String");
            stringBuilder.Arrow("Alice", "->", "String");
            stringBuilder.Note(NotePosition.Right, "You can also put notes!");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", "-->", "Bob", "ok");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void ShortcutSyntaxForActivationDeactivationCreation()
        {
            // Assign
            var example = @"@startuml
alice -> bob ++ : hello
bob -> bob ++ : self call
bob -> bib ++ #005500 : hello
bob -> george ** : create
return done
return rc
bob -> george !! : delete
return success
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("alice", "->", "bob", "hello", activateTarget: true);
            stringBuilder.Arrow("bob", "->", "bob", "self call", activateTarget: true);
            stringBuilder.Arrow("bob", "->", "bib", "hello", activateTarget: true, activationColor: "#005500");
            stringBuilder.Arrow("bob", "->", "george", "create", createInstanceTarget: true);
            stringBuilder.Return("done");
            stringBuilder.Return("rc");
            stringBuilder.Arrow("bob", "->", "george", "delete", destroyInstanceTarget: true);
            stringBuilder.Return("success");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void Template()
        {
            // Assign
            var example = @"@startuml
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }
    }
}
