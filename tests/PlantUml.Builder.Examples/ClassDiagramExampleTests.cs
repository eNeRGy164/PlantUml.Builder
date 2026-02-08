using PlantUml.Builder.ClassDiagrams;

namespace PlantUml.Builder.Examples;

/// <summary>
/// Examples from https://plantuml.com/class-diagram
/// </summary>
[TestClass]
public class ClassDiagramExampleTests
{
    /// <seealso href="https://plantuml.com/class-diagram#e5cec68ef9127fc4"/>
    [TestMethod]
    public void DeclaringElement()
    {
        // Arrange
        var example =
            """
            @startuml
            abstract abstract
            abstract class "abstract class"
            annotation annotation
            circle circle
            () circle_short_form
            class class
            class class_stereo <<stereotype>>
            diamond diamond
            <> diamond_short_form
            entity entity
            enum enum
            exception exception
            interface interface
            metaclass metaclass
            protocol protocol
            stereotype stereotype
            struct struct
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Text("abstract abstract"); // Todo
        stringBuilder.Class("abstract class", isAbstract: true);
        stringBuilder.Text("annotation annotation"); // Todo
        stringBuilder.Circle("circle");
        stringBuilder.Circle("circle_short_form", shortForm: true);
        stringBuilder.Class("class");
        stringBuilder.Class("class_stereo", stereotype: "stereotype");
        stringBuilder.Diamond("diamond");
        stringBuilder.Diamond("diamond_short_form", shortForm: true);
        stringBuilder.Entity("entity");
        stringBuilder.Enum("enum");
        stringBuilder.Text("exception exception"); // Todo
        stringBuilder.Interface("interface");
        stringBuilder.Text("metaclass metaclass"); // Todo
        stringBuilder.Text("protocol protocol"); // Todo
        stringBuilder.Text("stereotype stereotype"); // Todo
        stringBuilder.Text("struct struct"); // Todo
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#9dd2a6eca0c2a0e7"/>
    [TestMethod]
    public void RelationsBetweenClasses01()
    {
        // Arrange
        var example =
            """
            @startuml
            Class01 <|-- Class02
            Class03 *-- Class04
            Class05 o-- Class06
            Class07 .. Class08
            Class09 -- Class10
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Relationship("Class01", Relationship.InheritsFrom, "Class02");
        stringBuilder.Relationship("Class03", Relationship.IsComposedBy, "Class04");
        stringBuilder.Relationship("Class05", Relationship.IsAggregatedBy, "Class06");
        stringBuilder.Relationship("Class07", Relationship.IsDependedUponBy, "Class08");
        stringBuilder.Relationship("Class09", Relationship.IsAssociatedWith, "Class10");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#9dd2a6eca0c2a0e7"/>
    [TestMethod]
    public void RelationsBetweenClasses02()
    {
        // Arrange
        var example =
            """
            @startuml
            Class11 <|.. Class12
            Class13 --> Class14
            Class15 ..> Class16
            Class17 ..|> Class18
            Class19 <--* Class20
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Relationship("Class11", Relationship.Realizes, "Class12");
        stringBuilder.Relationship("Class13", Relationship.IsDirectlyAssociatedWith, "Class14");
        stringBuilder.Relationship("Class15", Relationship.DependsDirectlyOn, "Class16");
        stringBuilder.Relationship("Class17", Relationship.IsRealizedBy, "Class18");
        stringBuilder.Relationship("Class19", Relationship.IsDirectlyComposedBy, "Class20");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#9dd2a6eca0c2a0e7"/>
    [TestMethod]
    public void RelationsBetweenClasses03()
    {
        // Arrange
        var example =
            """
            @startuml
            Class21 #-- Class22
            Class23 x-- Class24
            Class25 }-- Class26
            Class27 +-- Class28
            Class29 ^-- Class30
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Relationship("Class21", Relationship.IsSpeciallyAssociatedWith, "Class22");
        stringBuilder.Relationship("Class23", Relationship.IsDisallowedBy, "Class24");
        stringBuilder.Relationship("Class25", Relationship.ContainsManyOf, "Class26");
        stringBuilder.Relationship("Class27", Relationship.IsStronglyAssociatedWith, "Class28");
        stringBuilder.Relationship("Class29", "^--", "Class30");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#4a705b44651caa59"/>
    [TestMethod]
    public void LabelOnRelations01()
    {
        // Arrange
        var example =
            """
            @startuml

            Class01 "1" *-- "many" Class02 : contains

            Class03 o-- Class04 : aggregation

            Class05 --> "1" Class06

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.AppendNewLine();
        stringBuilder.Relationship("Class01", Relationship.IsComposedBy, "Class02", label: "contains", leftCardinality: "1", rightCardinality: "many");
        stringBuilder.AppendNewLine();
        stringBuilder.Relationship("Class03", Relationship.IsAggregatedBy, "Class04", label: "aggregation");
        stringBuilder.AppendNewLine();
        stringBuilder.Relationship("Class05", Relationship.IsDirectlyAssociatedWith, "Class06", rightCardinality: "1");
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#4a705b44651caa59"/>
    [TestMethod]
    public void LabelOnRelations02()
    {
        // Arrange
        var example =
            """
            @startuml
            class Car

            Driver -- Car : drives >
            Car *-- Wheel : have 4 >
            Car -- Person : < owns

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Class("Car");
        stringBuilder.AppendNewLine();
        stringBuilder.Relationship("Driver", Relationship.IsAssociatedWith, "Car", label: "drives >");
        stringBuilder.Relationship("Car", Relationship.IsComposedBy, "Wheel", label: "have 4 >");
        stringBuilder.Relationship("Car", Relationship.IsAssociatedWith, "Person", label: "< owns");
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#bd62ba9333d08763"/>
    [TestMethod]
    public void UsingNonLettersInElementNamesAndRelationLabels01()
    {
        // Arrange
        var example =
            """
            @startuml
            class "This is my class" as class1
            class class2 as "It works this way too"

            class2 *-- "foo/dummy" : use
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Class("class1", "This is my class");
        stringBuilder.Text("class class2 as \"It works this way too\""); // This format will not be supported by the builder
        stringBuilder.AppendNewLine();
        stringBuilder.Relationship("class2", Relationship.IsComposedBy, "\"foo/dummy\"", label: "use");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#bd62ba9333d08763"/>
    [TestMethod]
    public void UsingNonLettersInElementNamesAndRelationLabels02()
    {
        // Arrange
        var example =
            """
            @startuml
            class $C1
            class $C2 $C2
            class "$C2" as dollarC2
            remove $C1
            remove $C2
            remove dollarC2
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Class("$C1");
        stringBuilder.Class("$C2", tag: "C2");
        stringBuilder.Class("dollarC2", "$C2");
        stringBuilder.Remove("$C1");
        stringBuilder.Remove("$C2");
        stringBuilder.Remove("dollarC2");
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#090967fbee930909"/>
    [TestMethod]
    public void AddingMethods01()
    {
        // Arrange
        var example =
            """
            @startuml
            Object <|-- ArrayList

            Object : equals()
            ArrayList : Object[] elementData
            ArrayList : size()

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.Relationship("Object", Relationship.InheritsFrom, "ArrayList");
        stringBuilder.AppendNewLine();
        stringBuilder.MemberDeclaration("Object", "equals()");
        stringBuilder.MemberDeclaration("ArrayList", "Object[] elementData");
        stringBuilder.MemberDeclaration("ArrayList", "size()");
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#090967fbee930909"/>
    [TestMethod]
    public void AddingMethods02()
    {
        // Arrange
        var example =
            """
            @startuml
            class Dummy {
            String data
            void methods()
            }

            class Flight {
            flightNumber : Integer
            departureTime : Date
            }
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.ClassStart("Dummy");
        stringBuilder.InlineClassMember("String data");
        stringBuilder.InlineClassMember("void methods()");
        stringBuilder.ClassEnd();
        stringBuilder.AppendNewLine();
        stringBuilder.ClassStart("Flight");
        stringBuilder.InlineClassMember("flightNumber : Integer");
        stringBuilder.InlineClassMember("departureTime : Date");
        stringBuilder.ClassEnd();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#090967fbee930909"/>
    [TestMethod]
    public void AddingMethods03()
    {
        // Arrange
        var example =
            """
            @startuml
            class Dummy {
            {field} A field (despite parentheses)
            {method} Some method
            }

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.ClassStart("Dummy");
        stringBuilder.InlineClassMember("{field} A field (despite parentheses)");
        stringBuilder.InlineClassMember("{method} Some method");
        stringBuilder.ClassEnd();
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#3644720244dd6c6a"/>
    [TestMethod]
    public void DefiningVisibility01()
    {
        // Arrange
        var example =
            """
            @startuml

            class Dummy {
            -field1
            #field2
            ~method1()
            +method2()
            }

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.AppendNewLine();
        stringBuilder.ClassStart("Dummy");
        stringBuilder.InlineClassMember(new ClassMember("field1", visibility: VisibilityModifier.Private));
        stringBuilder.InlineClassMember(new ClassMember("field2", visibility: VisibilityModifier.Protected));
        stringBuilder.InlineClassMember(new ClassMember("method1()", visibility: VisibilityModifier.PackagePrivate));
        stringBuilder.InlineClassMember(new ClassMember("method2()", visibility: VisibilityModifier.Public));
        stringBuilder.ClassEnd();
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#3644720244dd6c6a"/>
    [TestMethod]
    public void DefiningVisibility02()
    {
        // Arrange
        var example =
            """
            @startuml
            skinparam classAttributeIconSize 0
            class Dummy {
            -field1
            #field2
            ~method1()
            +method2()
            }

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.SkinParameter("classAttributeIconSize", 0);
        stringBuilder.ClassStart("Dummy");
        stringBuilder.InlineClassMember("-field1");
        stringBuilder.InlineClassMember("#field2");
        stringBuilder.InlineClassMember("~method1()");
        stringBuilder.InlineClassMember("+method2()");
        stringBuilder.ClassEnd();
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#3644720244dd6c6a"/>
    [TestMethod]
    public void DefiningVisibility03()
    {
        // Arrange
        var example =
            """
            @startuml
            class Dummy {
            field1
            field2
            method1()
            method2()
            }

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.ClassStart("Dummy");
        stringBuilder.InlineClassMember("field1");
        stringBuilder.InlineClassMember("field2");
        stringBuilder.InlineClassMember("method1()");
        stringBuilder.InlineClassMember("method2()");
        stringBuilder.ClassEnd();
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#3644720244dd6c6a"/>
    [TestMethod]
    public void DefiningVisibility04()
    {
        // Arrange
        var example =
            """
            @startuml
            class Dummy {
            field1
            \~Dummy()
            method1()
            }

            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.ClassStart("Dummy");
        stringBuilder.InlineClassMember("field1");
        stringBuilder.InlineClassMember("\\~Dummy()");
        stringBuilder.InlineClassMember("method1()");
        stringBuilder.ClassEnd();
        stringBuilder.AppendNewLine();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }

    /// <seealso href="https://plantuml.com/class-diagram#9fd9d25be2fbb118"/>
    [TestMethod]
    public void AbstractAndStatic()
    {
        // Arrange
        var example =
            """
            @startuml
            class Dummy {
            {static} String id
            {abstract} void methods()
            }
            @enduml

            """;

        var stringBuilder = new StringBuilder();

        // Act
        stringBuilder.UmlDiagramStart();
        stringBuilder.ClassStart("Dummy");
        stringBuilder.InlineClassMember(new ClassMember("String id", isStatic: true));
        stringBuilder.InlineClassMember(new ClassMember("void methods()", isAbstract: true));
        stringBuilder.ClassEnd();
        stringBuilder.UmlDiagramEnd();

        // Assert
        stringBuilder.ToString().ShouldBe(example.Replace("\r", ""));
    }
}
