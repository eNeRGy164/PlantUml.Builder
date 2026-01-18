# 9. Architecture Decisions

- **Use partial extension classes:**  
  The API is split across partial `StringBuilderExtensions` classes so diagram-specific commands live in their own namespaces while sharing a common naming pattern.
- **Typed helpers for complex syntax:**  
  Use typed structures like `Arrow` and `DiagramDirection` instead of raw strings to make PlantUML composition safer and more discoverable.
- **Document command coverage:**  
  Maintain a command matrix to show which PlantUML commands are implemented or partial in the library.
