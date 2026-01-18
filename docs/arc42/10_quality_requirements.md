# 10. Quality Requirements

- **Correctness:**  
  The library must generate syntactically valid PlantUML text to be processed by downstream renderers.
- **Documentation sample fidelity:**  
  Example tests must match the samples published on the PlantUML website and verify output parity to ensure the library stays aligned with documented behavior.
  As the output of this library is very strict, insignificant whitespace differences between the website and our tests are allowed.
- **Coverage transparency:**  
  The documentation must clearly state which PlantUML commands are implemented, partial, or missing to set expectations for users.
- **Open-source clarity:**  
  Licensing and reuse terms must remain clear for contributors and international users of the open-source library.
