# GitHub Actions Migration

This repository has been migrated from Azure Pipelines to GitHub Actions for CI/CD.

## Workflow Configuration

The main build workflow is defined in `.github/workflows/build.yml` and includes:

- **Build and Test**: Compiles the solution and runs unit tests
- **Package Generation**: Creates NuGet packages with version `1.0.{github.run_number}`
- **Code Signing**: Signs packages using PFX certificate (when secrets are configured)
- **Package Publishing**: Publishes to NuGet feed (when secrets are configured)
- **Artifact Upload**: Stores build artifacts for download

## Required Secrets

For full functionality, configure these repository secrets:

- `PFX_BASE64`: Base64-encoded PFX certificate file for code signing
- `PFX_PASSWORD`: Password for the PFX certificate
- `NUGET_FEED_URL`: URL of the NuGet feed for package publishing
- `NUGET_API_KEY`: API key for NuGet feed authentication

## Triggers

The workflow runs on:
- Push to `master` branch (full build, test, sign, and publish)
- Pull requests to `master` branch (build and test only, no signing/publishing)

## Migration Notes

- Maintains compatibility with existing `.NET 9.0` target framework
- Preserves the same build configuration (`Debug`) as the original Azure Pipeline
- Includes the same debugging outputs (environment variables, directory structure)
- Generates equivalent build artifacts