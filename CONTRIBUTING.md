# Contributing to Flowrex

Thank you for your interest in contributing! We appreciate your time and effort.

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Node.js](https://nodejs.org/) (for commit tooling)
- [Git](https://git-scm.com/)

### First-Time Setup

```bash
# Clone the repository
git clone https://github.com/gurame/Flowrex.git
cd Flowrex

# Install all development dependencies
make install
```

This will install:
- Node.js dependencies (commitizen, husky, commitlint)
- Git hooks for commit message validation
- .NET tools (dotnet-format, reportgenerator)
- NuGet packages

## Development Workflow

### Making Changes

1. **Create a branch**
   ```bash
   git checkout -b feat/my-new-feature
   ```

2. **Make your changes and test frequently**
   ```bash
   make dev  # Quick build + test cycle
   ```

3. **Ensure code quality**
   ```bash
   make format      # Format your code
   make check       # Run all quality checks
   ```

4. **Stage and commit your changes**
   ```bash
   make stage-all   # Stage all changes
   make commit      # Interactive commit with commitizen
   ```
   
   The commit tool will guide you through creating a proper conventional commit.

5. **Push your branch**
   ```bash
   make push
   ```

6. **Create a Pull Request**
   - Go to GitHub and create a PR from your branch
   - Fill out the PR template
   - Ensure CI checks pass

## Commit Standards

We use [Conventional Commits](https://www.conventionalcommits.org/) for all commit messages. This is enforced via git hooks.

### Commit Types

- `feat:` - New feature
- `fix:` - Bug fix
- `docs:` - Documentation changes
- `style:` - Code style changes (formatting, semicolons, etc.)
- `refactor:` - Code refactoring (no functional changes)
- `perf:` - Performance improvements
- `test:` - Adding or updating tests
- `build:` - Build system or dependencies
- `ci:` - CI/CD configuration changes
- `chore:` - Other changes (maintenance, etc.)

### Examples

```bash
feat: add retry policy to workflow executor
fix: resolve thread safety issue in context
docs: update README with new examples
refactor: simplify builder API
test: add integration tests for compensation
```

### Using the Commit Tool

The easiest way to create valid commits is using `make commit`, which launches an interactive tool:

```bash
make stage-all  # Stage your changes
make commit     # Interactive commit creation
```

## Common Development Commands

**Daily Workflow**
```bash
make status      # Check what changed
make dev         # Quick build + test
make stage-all   # Stage all changes
make commit      # Create commit
make push        # Push to remote
```

**Code Quality**
```bash
make format      # Auto-format code
make lint        # Run static analysis
make security    # Check for vulnerabilities
make check       # Run all quality checks
```

**Testing**
```bash
make test              # Run all tests
make test-coverage     # Run tests with coverage report
```

**CI Simulation**
```bash
make all         # Run all checks (like CI does)
```

## Pull Request Guidelines

### Before Submitting

- [ ] All tests pass: `make test`
- [ ] Code is formatted: `make format`
- [ ] No linting errors: `make lint`
- [ ] No security vulnerabilities: `make security`
- [ ] All CI checks pass: `make all`
- [ ] Commits follow Conventional Commits
- [ ] PR is small and focused (< 400 lines changed)
- [ ] PR is linked to an issue (if applicable)

### PR Title

PR titles must also follow Conventional Commits format:

```
feat: add workflow retry functionality
fix: resolve memory leak in executor
docs: improve getting started guide
```

### Code Review

- Be respectful and constructive
- Address all review comments
- Request re-review after making changes
- At least one approval required before merge

## Architecture Decisions

For significant architectural changes, please:

1. Create an Architecture Decision Record (ADR) in `/docs/adr/`
2. Use the template: `docs/adr/NNNN-title.md`
3. Discuss the proposal in an issue first

## Questions?

Feel free to:
- Open an [issue](https://github.com/gurame/Flowrex/issues)
- Start a [discussion](https://github.com/gurame/Flowrex/discussions)
- Ask in the PR comments

---

Thank you for contributing! 🎉
