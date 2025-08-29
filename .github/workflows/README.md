# GitHub Actions Workflows

This directory contains GitHub Actions workflows for the Periodic Table MAUI application.

## Workflows

### CI (`ci.yml`)
**Purpose**: Continuous Integration for development

**Triggers**:
- Push to `main` or `develop` branches
- Pull requests to `main` branch

**Jobs**:
- **Build and Test**: Builds the entire solution and runs any available tests
- **Validate Android**: Validates Android builds for both MAUI Controls and Blazor Hybrid versions
- **Validate Windows**: Validates Windows builds for both MAUI Controls and Blazor Hybrid versions

### Build and Publish (`publish.yml`)
**Purpose**: Build platform-specific applications and create releases

**Triggers**:
- Push to tags matching `v*.*.*` (e.g., `v1.0.0`)
- Push to `main` branch
- Pull requests to `main` branch
- Manual workflow dispatch with optional release creation

**Matrix Strategy**: Builds for multiple platforms:
- **Android**: Both MAUI Controls and Blazor Hybrid versions
- **Windows**: Both MAUI Controls and Blazor Hybrid versions  
- **macOS Catalyst**: Both MAUI Controls and Blazor Hybrid versions
- **iOS**: Blazor Hybrid version only

**Artifacts**: Creates downloadable artifacts for each platform build

**Release Creation**: 
- Automatically creates releases for version tags
- Can be manually triggered via workflow dispatch
- Packages all artifacts as both `.tar.gz` and `.zip` files
- Includes comprehensive release notes

## Platform Support

| Platform | MAUI Controls | Blazor Hybrid | Status |
|----------|---------------|---------------|---------|
| Android | ✅ | ✅ | Full support |
| Windows | ✅ | ✅ | Full support |
| macOS Catalyst | ✅ | ✅ | Full support |
| iOS | ❌ | ✅ | Blazor Hybrid only |

## Usage

### Running CI
CI runs automatically on pushes and pull requests. No manual intervention required.

### Creating a Release
1. **Automatic**: Create and push a version tag:
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

2. **Manual**: Use the "Actions" tab in GitHub:
   - Go to "Build and Publish" workflow
   - Click "Run workflow"
   - Check "Create a release" if desired
   - Click "Run workflow"

### Downloading Artifacts
- Artifacts are available for 30 days after workflow completion
- Access via the "Actions" tab → specific workflow run → "Artifacts" section
- Release artifacts are permanently available on the "Releases" page

## Requirements

The workflows automatically handle:
- .NET 9.0 SDK installation
- MAUI workload installation
- Dependencies restoration
- Multi-platform builds

No additional setup is required for the repository.