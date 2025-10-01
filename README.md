# Flowrex

[![Build Status](https://github.com/gurame/Flowrex/actions/workflows/pull-request.yml/badge.svg)](https://github.com/gurame/Flowrex/actions/workflows/pull-request.yml)
[![Security Scan](https://github.com/gurame/Flowrex/actions/workflows/security.yml/badge.svg)](https://github.com/gurame/Flowrex/actions/workflows/security.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/download)

A professional .NET workflow orchestration library designed for building robust, scalable workflow engines.

## Features

- 🔄 **Workflow Orchestration**: Build complex workflows with ease
- 📦 **Modular Architecture**: Clean separation of concerns with pluggable components
- 🧪 **Well Tested**: Comprehensive test coverage with modern testing practices
- 🔒 **Security First**: Regular security scanning and dependency updates
- 📖 **Documentation**: Complete API documentation and examples

## Quick Start

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- [Git](https://git-scm.com/downloads)

### Installation

```bash
dotnet add package Flowrex
```

### Basic Usage

```csharp
using Flowrex;

// TODO: Add usage examples
```

## Development

### 🚀 [Quick Start Guide →](docs/QUICKSTART.md)

New to Flowrex development? Check out our [Quick Start Guide](docs/QUICKSTART.md) for a guided walkthrough!

### Setup

Clone the repository and set up the development environment:

```bash
git clone https://github.com/gurame/Flowrex.git
cd Flowrex

# Install all development dependencies (Node, .NET tools, git hooks)
make install
```

This will:
- ✅ Install Node.js dependencies (commitizen, husky, commitlint)
- ✅ Configure git hooks for commit message validation
- ✅ Install .NET tools (dotnet-format, reportgenerator)
- ✅ Restore NuGet packages

### Developer Workflow

#### Daily Development

```bash
# Check what changed
make status

# Make your changes...

# Quick build + test cycle
make dev

# Stage all changes
make stage-all

# Commit with conventional commits (interactive)
make commit

# Push to remote
make push
```

#### Available Commands

**Setup & Installation**
| Command | Description |
|---------|-------------|
| `make install` | Install all dev dependencies (first-time setup) |
| `make setup` | Alias for install + restore |
| `make help` | Show all available commands |

**Building & Testing**
| Command | Description |
|---------|-------------|
| `make build` | Build the solution |
| `make test` | Run all tests |
| `make test-coverage` | Run tests with coverage report |
| `make dev` | Quick cycle: clean + build + test |

**Code Quality**
| Command | Description |
|---------|-------------|
| `make format` | Format code with dotnet-format |
| `make format-check` | Check if code is formatted |
| `make lint` | Run static analysis |
| `make security` | Check for vulnerable packages |
| `make check` | Run all quality checks |

**Git Workflow**
| Command | Description |
|---------|-------------|
| `make status` | Show git status |
| `make stage` | Stage changes interactively |
| `make stage-all` | Stage all changes (git add -A) |
| `make commit` | Commit with commitizen (conventional commits) |
| `make push` | Push to remote |
| `make release` | Create a new release with version bump and tag |

**CI/CD**
| Command | Description |
|---------|-------------|
| `make all` | Run all CI checks (build, test, format, security) |
| `make package` | Create NuGet packages |

### Project Structure

```bash
├── src/                    # Source code
│   ├── Flowrex/           # Main library
│   ├── Flowrex.Core/      # Core components
│   └── Flowrex.*/         # Feature modules
├── tests/                  # Test projects
├── samples/                # Usage examples
├── build/                  # Build tools
├── .github/               # CI/CD workflows
└── docs/                  # Documentation
    └── adr/               # Architecture Decision Records
```

### Architecture Decisions

This project follows best practices by documenting significant architecture decisions. See [Architecture Decision Records (ADRs)](docs/adr/) for details.

## Contributing

We welcome contributions! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for details.

### Code of Conduct

This project adheres to our [Code of Conduct](CODE_OF_CONDUCT.md). Please read it before participating.

## Security

Security vulnerabilities should be reported according to our [Security Policy](SECURITY.md).

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

- 📖 [Documentation](https://github.com/gurame/Flowrex/wiki)
- 🐛 [Issues](https://github.com/gurame/Flowrex/issues)
- 💬 [Discussions](https://github.com/gurame/Flowrex/discussions)
