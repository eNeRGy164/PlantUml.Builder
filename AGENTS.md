# AGENTS.md

This repository is PlantUML Builder, a .NET library that exposes `StringBuilder` extension
methods to emit valid PlantUML diagram text.

> [!IMPORTANT]
> Always read the arc42 documentation in `docs/arc42` before contributing code or
> documentation. The arc42 docs are the source of truth for architecture decisions,
> repository layout, and contribution guidelines.

## Architecture alignment (arc42)

- Follow the arc42 documentation in `docs/arc42`, especially:
  - Solution strategy: extension methods map to PlantUML commands and are tracked in
    `docs/commands.md`; diagram framing is standardized with `UmlDiagramStart` and
    `UmlDiagramEnd`; typed helpers avoid stringly-typed mistakes.
  - Building blocks: core extensions in `PlantUml.Builder`, diagram-specific extensions in
    `PlantUml.Builder.ClassDiagrams`, `PlantUml.Builder.ObjectDiagrams`, and
    `PlantUml.Builder.SequenceDiagrams`.
  - Crosscutting concepts: guard against null/invalid inputs, use `AppendNewLine` for output
    consistency, and provide XML docs for public extensions with parameter constraints and
    exceptions.

> [!WARNING]
> The arc42 documentation is the source of truth for architecture decisions.
> You are not allowed to create non-conforming code or documentation without
> explicit approval from the architecture owner. Always confirm, and put out a warning
> if you see non-conforming code or documentation.

## Repository layout

- `src/PlantUml.Builder`: library source.
  - `StringBuilderExtensions`: general PlantUML commands.
  - `ClassDiagrams`, `ObjectDiagrams`, `SequenceDiagrams`: diagram-specific helpers and their
    `StringBuilderExtensions`.
- `tests/PlantUml.Builder.Tests`: tests mirroring the source layout.
- `tests/PlantUml.Builder.Examples`: example tests that mirror official PlantUML website samples.
- `docs/commands.md`: catalog of implemented/missing commands.
- `docs/arc42`: architecture documentation (source of truth).

## Contribution checklist

- Add new commands as `StringBuilder` extension methods in the appropriate diagram folder.
- Keep `UmlDiagramStart`/`UmlDiagramEnd` as the standard wrappers for diagrams.
- Validate inputs and throw standard exceptions consistently.
- Add XML documentation comments (summary, parameters, constraints, and exceptions).
- Add tests that assert exact PlantUML output and cover key parameter combinations.
- Add example tests under `tests/PlantUml.Builder.Examples` that match the exact samples from
  the official PlantUML documentation (for example, [Sequence Diagram][plantuml-sequence-diagram]).
  These examples should both showcase usage and verify the emitted text matches the
  published samples exactly.
- Use reference-style links when linking to source code files in documentation.
- Run the test suite after every code change (use `dotnet test PlantUml.Builder.sln`).

[plantuml-sequence-diagram]: https://plantuml.com/sequence-diagram
