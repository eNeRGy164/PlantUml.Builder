# 8. Crosscutting Concepts

## 8.1 Error Handling

Extension methods consistently guard against `null` [`StringBuilder`][stringbuilder-docs] instances and invalid inputs,
throwing standard exceptions when needed (for example, [`ArgumentNullException`][argument-null-exception-docs] or [`ArgumentException`][argument-exception-docs]).

## 8.2 Output Formatting

Line breaks are standardized through a shared `AppendNewLine` helper to keep PlantUML text output consistent across commands.

[stringbuilder-docs]: https://learn.microsoft.com/dotnet/api/system.text.stringbuilder?view=net-10.0&wt.mc_id=AZ-MVP-5004268
[argument-null-exception-docs]: https://learn.microsoft.com/dotnet/api/system.argumentnullexception?view=net-10.0&wt.mc_id=AZ-MVP-5004268
[argument-exception-docs]: https://learn.microsoft.com/dotnet/api/system.argumentexception?view=net-10.0&wt.mc_id=AZ-MVP-5004268
