using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantUml.Builder.SequenceDiagrams;

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
            stringBuilder.Arrow("Alice", Arrow.Right, "Bob", "Authentication Request");
            stringBuilder.Arrow("Bob", Arrow.AsyncReplyRight, "Alice", "Authentication Response");
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow("Alice", Arrow.Right, "Bob", "Another authentication Request");
            stringBuilder.Arrow("Alice", Arrow.AsyncReplyLeft, "Bob", "Another authentication Response");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void DeclaringParticipant01()
        {
            // Assign
            var example = @"@startuml
participant participant as Foo
actor actor as Foo1
boundary boundary as Foo2
control control as Foo3
entity entity as Foo4
database database as Foo5
collections collections as Foo6
queue queue as Foo7
Foo -> Foo1 : To actor
Foo -> Foo2 : To boundary
Foo -> Foo3 : To control
Foo -> Foo4 : To entity
Foo -> Foo5 : To database
Foo -> Foo6 : To collections
Foo -> Foo7 : To queue
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Participant("Foo", "participant");
            stringBuilder.Actor("Foo1", "actor");
            stringBuilder.Boundary("Foo2", "boundary");
            stringBuilder.Control("Foo3", "control");
            stringBuilder.Entity("Foo4", "entity");
            stringBuilder.Database("Foo5", "database");
            stringBuilder.Collections("Foo6", "collections");
            stringBuilder.Queue("Foo7", "queue");
            stringBuilder.Arrow("Foo", "->", "Foo1", "To actor");
            stringBuilder.Arrow("Foo", "->", "Foo2", "To boundary");
            stringBuilder.Arrow("Foo", "->", "Foo3", "To control");
            stringBuilder.Arrow("Foo", "->", "Foo4", "To entity");
            stringBuilder.Arrow("Foo", "->", "Foo5", "To database");
            stringBuilder.Arrow("Foo", "->", "Foo6", "To collections");
            stringBuilder.Arrow("Foo", "->", "Foo7", "To queue");
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
            stringBuilder.Actor("Bob", color: NamedColor.Red);
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
            stringBuilder.Arrow("Alice", "->", "Bob()", "Hello");
            stringBuilder.Arrow("Bob()", "->", "This is very\nlong as Long");
            stringBuilder.Comment("You can also declare:");
            stringBuilder.Comment("\"Bob()\" -> Long as \"This is very\\nlong\"");
            stringBuilder.Arrow("Long", "-->", "\"Bob()\"", "ok");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void MessageToSelf01()
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
        public void MessageToSelf02()
        {
            // Assign
            var example = @"@startuml
Alice <- Alice : This is a signal to self.\nIt also demonstrates\nmultiline \ntext
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "<-", "Alice", "This is a signal to self.\nIt also demonstrates\nmultiline \ntext");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void TextAlignment01()
        {
            // Assign
            var example = @"@startuml
skinparam sequenceMessageAlignment right
Bob -> Alice : Request
Alice -> Bob : Response
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.SkinParameter(SkinParameter.SequenceMessageAlignment, "right");
            stringBuilder.Arrow("Bob", "->", "Alice", "Request");
            stringBuilder.Arrow("Alice", "->", "Bob", "Response");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().BeEquivalentTo(example.Replace("\r", ""));
        }

        [TestMethod]
        public void TextAlignment02()
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
        public void ChangeArrowStyle01()
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
        public void ChangeArrowStyle02()
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
            var bob = new Bob();
            var alice = new Alice();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow(bob, Arrow.Right.Destroy(), alice);
            stringBuilder.Arrow(bob, Arrow.Right, alice);
            stringBuilder.Arrow(bob, Arrow.ThinRight, alice);
            stringBuilder.Arrow(bob, Arrow.TopRight, alice);
            stringBuilder.Arrow(bob, Arrow.ThinTopLeft, alice);
            stringBuilder.Arrow(bob, Arrow.DottedThinBottomLeft, alice);
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow(bob, Arrow.Right.Lost(), alice);
            stringBuilder.Arrow(bob, Arrow.DottedThinTopLeft.Lost(), alice);
            stringBuilder.AppendNewLine();
            stringBuilder.Arrow(bob, Arrow.LeftRight, alice);
            stringBuilder.Arrow(bob, Arrow.LeftRight.LostRight(), alice);
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
Alice --[#0000FF]> Bob : ok
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
        public void MessageSequenceNumbering05()
        {
            // Assign
            var example = @"@startuml
autonumber 1.1.1
Alice -> Bob : Authentication request
Bob --> Alice : Response

autonumber inc A
' Now we have 2.1.1
Alice -> Bob : Another authentication request
Bob --> Alice : Response

autonumber inc B
' Now we have 2.2.1
Alice -> Bob : Another authentication request
Bob --> Alice : Response

autonumber inc A
' Now we have 3.1.1
Alice -> Bob : Another authentication request
autonumber inc B
' Now we have 3.2.1
Bob --> Alice : Response
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.AutoNumber(start: "1.1.1");
            stringBuilder.Arrow("Alice", "->", "Bob", "Authentication request");
            stringBuilder.Arrow("Bob", "-->", "Alice", "Response");
            stringBuilder.AppendNewLine();
            stringBuilder.IncreaseAutoNumber('A');
            stringBuilder.Comment("Now we have 2.1.1");
            stringBuilder.Arrow("Alice", "->", "Bob", "Another authentication request");
            stringBuilder.Arrow("Bob", "-->", "Alice", "Response");
            stringBuilder.AppendNewLine();
            stringBuilder.IncreaseAutoNumber('B');
            stringBuilder.Comment("Now we have 2.2.1");
            stringBuilder.Arrow("Alice", "->", "Bob", "Another authentication request");
            stringBuilder.Arrow("Bob", "-->", "Alice", "Response");
            stringBuilder.AppendNewLine();
            stringBuilder.IncreaseAutoNumber('A');
            stringBuilder.Comment("Now we have 3.1.1");
            stringBuilder.Arrow("Alice", "->", "Bob", "Another authentication request");
            stringBuilder.IncreaseAutoNumber('B');
            stringBuilder.Comment("Now we have 3.2.1");
            stringBuilder.Arrow("Bob", "-->", "Alice", "Response");
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
        public void SecondaryGroupLabel()
        {
            // Assign
            var example = @"@startuml
Alice -> Bob : Authentication Request
Bob -> Alice : Authentication Failure
group My own label [My own label 2]
Alice -> Log : Log attack start
loop 1000 times
Alice -> Bob : DNS Attack
end
Alice -> Log : Log attack end
end
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "->", "Bob", "Authentication Request");
            stringBuilder.Arrow("Bob", "->", "Alice", "Authentication Failure");
            stringBuilder.GroupStart(label: "My own label", text: "My own label 2");
            stringBuilder.Arrow("Alice", "->", "Log", "Log attack start");
            stringBuilder.StartLoop("1000 times");
            stringBuilder.Arrow("Alice", "->", "Bob", "DNS Attack");
            stringBuilder.EndLoop();
            stringBuilder.Arrow("Alice", "->", "Log", "Log attack end");
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
rnote over server
 this is
 on several
 lines
end rnote
hnote over caller
 this is
 on several
 lines
end hnote
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
            stringBuilder.StartRNote("server");
            stringBuilder.Text(" this is");
            stringBuilder.Text(" on several");
            stringBuilder.Text(" lines");
            stringBuilder.EndRNote();
            stringBuilder.StartHNote("caller");
            stringBuilder.Text(" this is");
            stringBuilder.Text(" on several");
            stringBuilder.Text(" lines");
            stringBuilder.EndHNote();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void NoteOverAllParticipants()
        {
            // Assign
            var example = @"@startuml
Alice -> Bob : m1
Bob -> Charlie : m2
note over Alice,Charlie : Old method for note over all part. with:\n """"note over //FirstPart, LastPart//"""".
note across : New method with:\n""""note across""""
Bob -> Alice
hnote across : Note across all part.
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("Alice", "->", "Bob", "m1");
            stringBuilder.Arrow("Bob", "->", "Charlie", "m2");
            stringBuilder.Note("Alice", "Charlie", "Old method for note over all part. with:\n \"\"note over //FirstPart, LastPart//\"\".");
            stringBuilder.Note(NotePosition.Across, "New method with:\n\"\"note across\"\"");
            stringBuilder.Arrow("Bob", "->", "Alice");
            stringBuilder.HNote(NotePosition.Across, "Note across all part.");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void SeveralNotesAlignedAtTheSameLevel01()
        {
            // Assign
            var example = @"@startuml
note over Alice : initial state of Alice
note over Bob : initial state of Bob
Bob -> Alice : hello
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Note(NotePosition.Over, "Alice", "initial state of Alice");
            stringBuilder.Note(NotePosition.Over, "Bob", "initial state of Bob");
            stringBuilder.Arrow("Bob", "->", "Alice", "hello");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void SeveralNotesAlignedAtTheSameLevel02()
        {
            // Assign
            var example = @"@startuml
note over Alice : initial state of Alice
/ note over Bob : initial state of Bob
Bob -> Alice : hello
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Note(NotePosition.Over, "Alice", "initial state of Alice");
            stringBuilder.Note(NotePosition.Over, "Bob", "initial state of Bob", alignWithPrevious: true);
            stringBuilder.Arrow("Bob", "->", "Alice", "hello");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void CreoleAndHtml()
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
        public void DividerOrSeparator()
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
            stringBuilder.Actor("Bob");
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
Bob --> Alice : Good Bye !

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
            stringBuilder.Arrow("Bob", "-->", "Alice", "Good Bye !");
            stringBuilder.AppendNewLine();
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void TextWrapping()
        {
            // Assign
            var example = @"@startuml
skinparam MaxMessageSize 50
participant a
participant b
a -> b : this\nis\nmanually\ndone
a -> b : this is a very long message on several words
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.SkinParameter(SkinParameter.MaxMessageSize, 50);
            stringBuilder.Participant("a");
            stringBuilder.Participant("b");
            stringBuilder.Arrow("a", "->", "b", "this\nis\nmanually\ndone");
            stringBuilder.Arrow("a", "->", "b", "this is a very long message on several words");
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
            stringBuilder.Arrow("bob", "->", "george", "create", LifeLineEvents.CreateTargetInstance);
            stringBuilder.Return("done in thread 2");
            stringBuilder.Return("rc");
            stringBuilder.Arrow("bob", "->", "george", "delete", LifeLineEvents.DestroyTargetInstance);
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
            stringBuilder.Arrow("alice", "->", "bob", "hello", LifeLineEvents.Activate);
            stringBuilder.Arrow("bob", "->", "bob", "self call", LifeLineEvents.Activate);
            stringBuilder.Arrow("bob", "->", "bib", "hello", LifeLineEvents.Activate, activationColor: "#005500");
            stringBuilder.Arrow("bob", "->", "george", "create", LifeLineEvents.Create);
            stringBuilder.Return("done");
            stringBuilder.Return("rc");
            stringBuilder.Arrow("bob", "->", "george", "delete", LifeLineEvents.Destroy);
            stringBuilder.Return("success");
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void MixActivationAndDeactivationOnSameLine01()
        {
            // Assign
            var example = @"@startuml
alice -> bob ++ : hello1
bob -> charlie --++ : hello2
charlie --> alice -- : ok
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("alice", Arrow.Right, "bob", "hello1", LifeLineEvents.Activate);
            stringBuilder.Arrow("bob", Arrow.Right, "charlie", "hello2", LifeLineEvents.DeactivateActivate);
            stringBuilder.Arrow("charlie", Arrow.DottedRight, "alice", "ok", LifeLineEvents.Deactivate);
            stringBuilder.UmlDiagramEnd();

            // Assert
            stringBuilder.ToString().Should().Be(example.Replace("\r", ""));
        }

        [TestMethod]
        public void MixActivationAndDeactivationOnSameLine02()
        {
            // Assign
            var example = @"@startuml
alice -> bob --++ #Gold : hello
bob -> alice --++ #Gold : you too
alice -> bob -- : step1
alice -> bob : step2
@enduml
";

            var stringBuilder = new StringBuilder();

            // Act
            stringBuilder.UmlDiagramStart();
            stringBuilder.Arrow("alice", Arrow.Right, "bob", "hello", LifeLineEvents.DeactivateSourceActivateTarget, NamedColor.Gold);
            stringBuilder.Arrow("bob", Arrow.Right, "alice", "you too", LifeLineEvents.DeactivateSourceActivateTarget, NamedColor.Gold);
            stringBuilder.Arrow("alice", Arrow.Right, "bob", "step1", LifeLineEvents.DeactivateSource);
            stringBuilder.Arrow("alice", Arrow.Right, "bob", "step2");
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

        public class Bob : ParticipantName
        {
            public Bob() : base("Bob")
            {
            }
        }

        public class Alice : ParticipantName
        {
            public Alice() : base("Alice")
            {
            }
        }
    }
}
