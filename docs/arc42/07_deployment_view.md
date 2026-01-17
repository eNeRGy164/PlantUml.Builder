# 7. Deployment View

## 7.1 Using the Library in a Project

- Target .NET 6.0 (or a compatible framework) to align with the library’s baseline.
- Reference the `PlantUml.Builder` library and import the namespaces you need,
  such as `PlantUml.Builder` for common commands and `PlantUml.Builder.ClassDiagrams` for class diagram helpers.
- Compose a diagram by invoking [`UmlDiagramStart`][uml-diagram-start-source], diagram-specific methods,
  and [`UmlDiagramEnd`][uml-diagram-end-source] in your application code.

## Build and release pipeline

- Versioning uses [GitVersion mainline configuration][gitversion-config] to calculate package versions for **main**, **feature**, and **pull request** branches.
- GitHub Actions runs the [CI workflow][ci-workflow] on pushes and pull requests to `main`,
  restoring, building, and testing the solution.
- The workflow produces coverage reports (coverlet/coveralls), packs the NuGet package,
  uploads artifacts, and publishes to NuGet when changes land on `main`.

[uml-diagram-start-source]: https://github.com/eNeRGy164/PlantUml.Builder/blob/main/src/PlantUml.Builder/StringBuilderExtensions/UmlDiagramStart.cs
[uml-diagram-end-source]: https://github.com/eNeRGy164/PlantUml.Builder/blob/main/src/PlantUml.Builder/StringBuilderExtensions/UmlDiagramEnd.cs
[gitversion-config]: https://github.com/eNeRGy164/PlantUml.Builder/blob/main/GitVersion.yml
[ci-workflow]: https://github.com/eNeRGy164/PlantUml.Builder/blob/main/.github/workflows/continuous-integration-workflow.yml
