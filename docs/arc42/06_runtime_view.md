# 6. Runtime View

## 6.1 Diagram Construction (common flow)

1. Create a [`StringBuilder`][stringbuilder-docs].
2. Call [`UmlDiagramStart`][uml-diagram-start-source] to open the diagram and [`UmlDiagramEnd`][uml-diagram-end-source] to close it.
3. Add diagram-specific commands (see flows below and the [commands catalog][commands-catalog]).

## 6.2 Sequence Diagram Flow

Use sequence helpers such as `Arrow` to express interactions between participants in the diagram.

```csharp
var stringBuilder = new StringBuilder();

stringBuilder.UmlDiagramStart();
stringBuilder.Arrow("Alice", "->", "Bob", "Authentication Request");
stringBuilder.Arrow("Bob", "-->", "Alice", "Authentication Response");
stringBuilder.UmlDiagramEnd();
```

## 6.3 Class Diagram Flow

Use class-specific extensions like `Class` to add classes and relationships to a class diagram.

```csharp
var stringBuilder = new StringBuilder();

stringBuilder.UmlDiagramStart();
stringBuilder.Class("User");
stringBuilder.Interface("IUserRepository");
stringBuilder.UmlDiagramEnd();
```

## 6.4 Object Diagram Flow

Use object-specific extensions like `Object` or `MapStart` to render object diagrams and associative maps.

```csharp
var stringBuilder = new StringBuilder();

stringBuilder.UmlDiagramStart();
stringBuilder.Object("User");
stringBuilder.MapStart("Settings");
stringBuilder.MapEnd();
stringBuilder.UmlDiagramEnd();
```

[stringbuilder-docs]: https://learn.microsoft.com/dotnet/api/system.text.stringbuilder?view=net-10.0&wt.mc_id=AZ-MVP-5004268
[uml-diagram-start-source]: https://github.com/eNeRGy164/PlantUml.Builder/blob/main/src/PlantUml.Builder/StringBuilderExtensions/UmlDiagramStart.cs
[uml-diagram-end-source]: https://github.com/eNeRGy164/PlantUml.Builder/blob/main/src/PlantUml.Builder/StringBuilderExtensions/UmlDiagramEnd.cs
[commands-catalog]: ../commands.md
