# .NET 9.0 Upgrade Plan

## Execution Steps

1. Validate that an .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade SageOneApi.Client.csproj
4. Upgrade SageOneApi.Tests.csproj
5. Run unit tests to validate upgrade in the projects listed below:
  - SageOneApi.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                        | Current Version | New Version | Description                         |
|:------------------------------------|:---------------:|:-----------:|:------------------------------------|
| Microsoft.Extensions.Http           |   8.0.1         |  9.0.6      | Recommended for .NET 9.0            |
| System.Text.Json                    |   8.0.5         |  9.0.6      | Recommended for .NET 9.0            |

### Project upgrade details
This section contains details about each project upgrade and modifications that need to be done in the project.

#### SageOneApi.Client.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

NuGet packages changes:
  - Microsoft.Extensions.Http should be updated from `8.0.1` to `9.0.6` (*recommended for .NET 9.0*)
  - System.Text.Json should be updated from `8.0.5` to `9.0.6` (*recommended for .NET 9.0*)

#### SageOneApi.Tests.csproj modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net9.0`

Other changes:
  - No additional changes required
