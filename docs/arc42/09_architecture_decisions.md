# 9. Architecture Decisions

- **Use partial extension classes:**  
  The API is split across partial `StringBuilderExtensions` classes so diagram-specific commands live in their own namespaces while sharing a common naming pattern.
- **Typed helpers for complex syntax:**  
  Use typed structures like `Arrow` and `DiagramDirection` instead of raw strings to make PlantUML composition safer and more discoverable.
- **Centralize PlantUML tokens:**  
  PlantUML keywords and symbols are centralized in [`Constant`][constant] so command builders emit consistent, typo-resistant output and
  formatting can be kept strict without scattering literals across the codebase.
- **Model DSL tokens as value objects and enums:**  
  Use enums (for example, [`SkinParameter`][skin-parameter]) and small value objects (for example, [`Color`][color], [`LifeLineEvents`][lifeline-events],
  and [`ParticipantName`][participant-name]) to encode formatting rules and quoting logic, while still allowing ergonomic usage through implicit conversions
  where appropriate (for example, `string` to `ParticipantName`).
- **Document command coverage:**  
  Maintain a command matrix to show which PlantUML commands are implemented or partial in the library.

[constant]: ../../src/PlantUml.Builder/Constant.cs
[skin-parameter]: ../../src/PlantUml.Builder/SkinParameter.cs
[color]: ../../src/PlantUml.Builder/Color.cs
[lifeline-events]: ../../src/PlantUml.Builder/SequenceDiagrams/LifeLineEvents.cs
[participant-name]: ../../src/PlantUml.Builder/SequenceDiagrams/ParticipantName.cs
