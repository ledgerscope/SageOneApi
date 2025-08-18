# GitHub Actions Setup Instructions

## What was completed:

✅ **GitHub Actions Workflow Created**: `.github/workflows/build.yml` 
- Builds, tests, and publishes .NET 9.0 project
- Runs on `ubuntu-latest` (Linux runners)
- Triggered on push to `master` and pull requests

✅ **Azure Pipeline Deprecated**: Marked as deprecated with migration notice

✅ **Testing Verified**: 
- .NET 9.0 build and test successful
- 7 tests run (5 passed, 2 skipped, 0 failed)
- NuGet package generation working

## Required Actions for Repository Maintainers:

### 1. Configure Repository Secrets
Add these secrets in GitHub repository settings (Settings → Secrets and variables → Actions):

- **`NUGET_FEED_URL`**: URL of your NuGet feed (e.g., from Azure DevOps Artifacts)
- **`NUGET_API_KEY`**: API key for authenticating to your NuGet feed

**Note**: PFX code signing has been removed as it's no longer required.

### 2. Test the Workflow
- Create a test branch and open a pull request to verify the workflow runs correctly
- Merge to `master` to test the build and publish process

### 3. Disable Azure Pipeline (Optional)
- In Azure DevOps, disable or delete the old pipeline: `CI-SageOneApi-Client-NuGet`

## Workflow Features:

- **Conditional Publishing**: Only publishes to NuGet feed on `master` branch when feed is configured
- **Test Reports**: Automatically generates test result reports in GitHub
- **Build Artifacts**: Uploads build outputs and debugging information
- **Version Management**: Uses `1.0.{github.run_number}` format matching original pipeline
- **Cross-Platform**: Runs on Linux (ubuntu-latest) for better performance and cost