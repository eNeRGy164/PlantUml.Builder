# 2. Architecture Constraints

## Technical Constraints

| Constraint                                    | Rationale                                                                                                   | Impact                                                     |
| --------------------------------------------- | ----------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------- |
| .NET 6.0 baseline                             | Align with the current target framework in the project as a compatibility baseline for newer .NET versions. | Consumers must target a compatible runtime.                |
| [StringBuilder][stringbuilder-docs]-based API | Keep the API aligned with extension methods that build text incrementally.                                  | Diagram generation is centered around StringBuilder usage. |
| PlantUML command alignment                    | Follow PlantUML syntax and capabilities.                                                                    | Feature set tracks PlantUML command support.               |

## Organizational Constraints

| Constraint  | Rationale                                            | Impact                                          |
| ----------- | ---------------------------------------------------- | ----------------------------------------------- |
| MIT license | Keep the project open and permissive for global use. | Reuse and contributions must respect MIT terms. |

## Conventions

| Constraint                | Rationale                                             | Impact                                                                              |
| ------------------------- | ----------------------------------------------------- | ----------------------------------------------------------------------------------- |
| Documentation conventions | Maintain arc42 structure for architecture docs.       | Chapters should stay aligned with the template.                                     |
| Coding standards          | Keep style and formatting consistent across the repo. | Contributors should align changes with the repository [editorconfig][editorconfig]. |

[stringbuilder-docs]: https://learn.microsoft.com/dotnet/api/system.text.stringbuilder?view=net-10.0&wt.mc_id=AZ-MVP-5004268
[editorconfig]: ../../.editorconfig
