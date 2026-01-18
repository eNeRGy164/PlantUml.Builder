# 1. Introduction and Goals

PlantUML Builder is a .NET library that provides [StringBuilder][stringbuilder-docs] extension methods to generate PlantUML diagrams programmatically.
It helps teams produce consistent diagram source text as part of code, tooling, or documentation workflows.
A developer can keep architectural diagrams in sync with code by generating PlantUML text alongside application builds and documentation updates.

**Key requirements and driving forces:**

- Provide a code-first API for creating PlantUML diagram text.
- Track the PlantUML command set and make supported commands discoverable in the [commands catalog][commands-catalog].

## 1.1 Requirements overview

- Generate valid PlantUML source text for common diagram types (sequence, class, object).
- Enable incremental diagram composition with [StringBuilder][stringbuilder-docs] extension methods.
- Make supported commands visible and easy to verify via the [commands catalog][commands-catalog].

## 1.2 Quality goals

| Goal         | Scenario                                                                | Stakeholder                  |
| ------------ | ----------------------------------------------------------------------- | ---------------------------- |
| Correctness  | Generated PlantUML text renders without manual fixes in PlantUML tools. | Developers using the library |
| Usability    | Extension methods are easy to discover and use with IntelliSense.       | Application developers       |
| Transparency | Users can see which PlantUML commands are supported or partial.         | Open-source contributors     |

## 1.3 Stakeholders

| Role or group                     | Expectation                                                 |
| --------------------------------- | ----------------------------------------------------------- |
| .NET developers                   | A simple API for generating PlantUML diagram text.          |
| Open-source contributors          | Clear guidance on what is supported and how to extend it.   |
| Documentation/tooling maintainers | Stable output that integrates with documentation pipelines. |

[stringbuilder-docs]: https://learn.microsoft.com/dotnet/api/system.text.stringbuilder?view=net-10.0&wt.mc_id=AZ-MVP-5004268
[commands-catalog]: ../commands.md
