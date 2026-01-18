# 4. Solution Strategy

- Provide extension methods that correspond to PlantUML commands, recorded in the [commands catalog][commands-catalog] for traceability.
- Standardize diagram start/end using [`UmlDiagramStart`][uml-diagram-start-source] and [`UmlDiagramEnd`][uml-diagram-end-source]
  so every diagram follows the required PlantUML wrappers.
- Use typed helpers for structured inputs like diagram direction and sequence arrow semantics to avoid stringly-typed mistakes.

[uml-diagram-start-source]: https://github.com/eNeRGy164/PlantUml.Builder/blob/main/src/PlantUml.Builder/StringBuilderExtensions/UmlDiagramStart.cs
[uml-diagram-end-source]: https://github.com/eNeRGy164/PlantUml.Builder/blob/main/src/PlantUml.Builder/StringBuilderExtensions/UmlDiagramEnd.cs
[commands-catalog]: ../commands.md
