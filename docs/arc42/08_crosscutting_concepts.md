# 8. Crosscutting Concepts

## 8.1 Error Handling

Extension methods consistently guard against `null` [`StringBuilder`][stringbuilder-docs] instances and invalid inputs,
throwing standard exceptions when needed (for example, [`ArgumentNullException`][argument-null-exception-docs] or [`ArgumentException`][argument-exception-docs]).

## 8.2 Output Formatting

Line breaks are standardized through a shared `AppendNewLine` helper to keep PlantUML text output consistent across commands.

## 8.3 PlantUML Extension Methods

### 8.3.1 Project Layout and File Structure

The library is organized by diagram type. General-purpose `StringBuilder` extensions live under `src/PlantUml.Builder/StringBuilderExtensions`,
while diagram-specific extensions live in diagram folders such as `ClassDiagrams`, `ObjectDiagrams`, and `SequenceDiagrams`, each with their own
`StringBuilderExtensions` subfolder for command methods.
Use existing neighboring files as a template for where new commands should reside.

Tests mirror this structure under `tests/PlantUml.Builder.Tests`, with diagram-specific folders and `StringBuilderExtensions` tests that validate
the emitted PlantUML text.

### 8.3.2 XML Documentation Expectations

Public extension methods should include XML documentation comments that describe the PlantUML syntax, outline parameter usage, and link to relevant
PlantUML references. This ensures IntelliSense guidance matches the actual command behavior.
Use existing diagram methods (for example the class diagram extensions in [`StringBuilderExtensions`][class-stringbuilderextensions]) as patterns for
how to be explicit about naming rules, optional arguments, and error conditions.

Recommended detail level:

- **Summary that matches the PlantUML keyword**  
  Start with a concise summary such as “Renders a class” or “Renders the beginning of a namespace”,
  mirroring how `Class` and `NamespaceStart` are described today in [`Class.cs`][class-stringbuilderextensions] and
  [`Namespace.cs`][namespace-stringbuilderextensions].
- **Parameter semantics and constraints**  
  Document naming rules (“name can’t contain spaces”), optional arguments (stereotypes, tags, URLs, colors), and defaults (for example, `bool` flags or `enum` defaults).
  Include notes about how aliases or display names are handled if the API supports them.
- **Reference other types**  
  Use `<see cref="..."/>` for related enums or value objects (for example, [`LineStyle`][line-style], [`VisibilityModifier`][visibility-modifier], or [`Color`][color])
  so that IntelliSense links users to the allowed values.
- **Exception coverage**  
  Call out `ArgumentNullException` for the `StringBuilder` argument and `ArgumentException`/`ArgumentOutOfRangeException` for invalid inputs,
  matching the existing extension methods.

### 8.3.3 Unit Testing Guidance

Add tests alongside the PlantUML commands.
Use the existing expectation helpers to assert the exact PlantUML output for the new
method and cover representative input combinations.

There are two primary patterns:

- focused validation via `[DataRow]`
- broader notation coverage via `[DynamicData]`.

When to use each test style:

- **`[DataRow]` for small, explicit cases.**  
  Use this for argument validation or straightforward rendering variations.
  For example, [`ClassTests.cs`][class-tests] uses `DataRow` to validate empty/whitespace names, and [`AutoNumberTests.cs`][auto-number-tests] uses `DataRow`
  to cover a handful of start/step/format combinations.
- **`[DynamicData]` for rich notations or multiple overloads.**  
  Use this when you need a list of test data that map to many overloads or parameter permutations.
  For example, [`ClassTests.cs`][class-tests] and [`NamespaceTests.cs`][namespace-tests] assemble large datasets to cover optional parameters in one place.
  The [`GetExtensionMethodAndParameters`][test-extensions] helper method is used to invoke the correct overload based on the test data.

### 8.4 Command Overview and External References

The `docs/commands.md` document is used as the canonical overview of implemented and missing commands so new methods can be scoped and tracked.
For example syntax and behavior, consult the official [PlantUML website][plantuml-site] and the [PlantUML source repository][plantuml-repo],
which often reveals options that are not fully documented.

[stringbuilder-docs]: https://learn.microsoft.com/dotnet/api/system.text.stringbuilder?view=net-10.0&wt.mc_id=AZ-MVP-5004268
[argument-null-exception-docs]: https://learn.microsoft.com/dotnet/api/system.argumentnullexception?view=net-10.0&wt.mc_id=AZ-MVP-5004268
[argument-exception-docs]: https://learn.microsoft.com/dotnet/api/system.argumentexception?view=net-10.0&wt.mc_id=AZ-MVP-5004268
[plantuml-site]: https://plantuml.com/
[plantuml-repo]: https://github.com/plantuml/plantuml
[class-stringbuilderextensions]: ../../src/PlantUml.Builder/ClassDiagrams/StringBuilderExtensions/Class.cs
[namespace-stringbuilderextensions]: ../../src/PlantUml.Builder/ClassDiagrams/StringBuilderExtensions/Namespace.cs
[line-style]: ../../src/PlantUml.Builder/LineStyle.cs
[visibility-modifier]: ../../src/PlantUml.Builder/VisibilityModifier.cs
[color]: ../../src/PlantUml.Builder/Color.cs
[class-tests]: ../../tests/PlantUml.Builder.Tests/ClassDiagrams/ClassTests.cs
[auto-number-tests]: ../../tests/PlantUml.Builder.Tests/SequenceDiagrams/StringBuilderExtensions/AutoNumberTests.cs
[namespace-tests]: ../../tests/PlantUml.Builder.Tests/ClassDiagrams/NamespaceTests.cs
[test-extensions]: ../../tests/PlantUml.Builder.Tests/TestExtensions.cs
