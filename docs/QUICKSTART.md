# 🚀 Quick Start Guide for Developers

Welcome to Flowrex development! This guide will get you up and running in minutes.

## 📋 Prerequisites

Before you start, ensure you have:

- ✅ [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- ✅ **Node.js v22** (for commit tooling) - See installation options below
- ✅ [Git](https://git-scm.com/)
- ✅ A code editor ([VS Code](https://code.visualstudio.com/), [Rider](https://www.jetbrains.com/rider/), or Visual Studio)

### Installing Node.js

**🌟 Recommended: Use a Node version manager**

This project includes a `.node-version` file that specifies Node.js v22. Using a version manager makes it easy:

**Option 1: fnm (Fast Node Manager) - Fastest ⚡**
```bash
# Install fnm
brew install fnm

# Add to your shell config (~/.zshrc or ~/.bashrc)
eval "$(fnm env --use-on-cd)"

# Install Node.js (will read .node-version automatically)
fnm install
```

**Option 2: nvm (Node Version Manager) - Popular 👍**
```bash
# Install nvm
brew install nvm

# Add to your shell config (~/.zshrc or ~/.bashrc)
export NVM_DIR="$HOME/.nvm"
[ -s "/opt/homebrew/opt/nvm/nvm.sh" ] && \. "/opt/homebrew/opt/nvm/nvm.sh"

# Install Node.js (will read .nvmrc automatically)
nvm install
```

**Option 3: Direct install**
```bash
brew install node@22
```

## 🏁 First-Time Setup (5 minutes)

```bash
# 1. Clone the repository
git clone https://github.com/gurame/Flowrex.git
cd Flowrex

# 2. Install all development dependencies
make install
```

This single command will:
- 📦 Install Node.js packages (commitizen, husky, commitlint)
- 🪝 Configure git hooks for commit validation
- 🛠️ Install .NET tools (dotnet-format, reportgenerator)
- 📚 Restore all NuGet packages

**Expected output:**
```
🔧 Installing development dependencies...
✓ npm found
✓ Git hooks configured
✓ .NET tools installed
✅ All development dependencies installed!

Quick Start:
  make status      - Check git status
  make stage-all   - Stage all changes
  make commit      - Commit with conventional commits (interactive)
  make push        - Push to origin
  make dev         - Quick dev cycle (build + test)
```

## 🎯 Your First Contribution (10 minutes)

### 1️⃣ Create a Branch

```bash
git checkout -b feat/my-awesome-feature
```

### 2️⃣ Make Changes & Test

```bash
# Quick build + test cycle
make dev
```

### 3️⃣ Format & Check Quality

```bash
# Auto-format your code
make format

# Run all quality checks
make check
```

### 4️⃣ Commit Your Changes

```bash
# Stage all changes
make stage-all

# Interactive commit (guided)
make commit
```

**What happens when you run `make commit`?**

You'll see an interactive prompt:

```
? Select the type of change that you're committing: (Use arrow keys)
❯ feat:     A new feature
  fix:      A bug fix
  docs:     Documentation only changes
  style:    Changes that do not affect the meaning of the code
  refactor: A code change that neither fixes a bug nor adds a feature
  perf:     A code change that improves performance
  test:     Adding missing tests or correcting existing tests
```

Just follow the prompts! The tool ensures your commit message is valid.

### 5️⃣ Push & Create PR

```bash
# Push to remote
make push

# Then create a PR on GitHub
```

## 📚 Common Commands Cheat Sheet

### Daily Workflow
```bash
make status      # 📊 What changed?
make dev         # ⚡ Quick: build + test
make stage-all   # 📝 Stage everything
make commit      # 💬 Commit (interactive)
make push        # 🚀 Push to remote
```

### Code Quality
```bash
make format      # 🎨 Auto-format code
make lint        # 🔍 Static analysis
make security    # 🔒 Security scan
make check       # ✅ All quality checks
```

### Testing
```bash
make test             # 🧪 Run all tests
make test-coverage    # 📊 Tests + coverage report
```

### Before Committing
```bash
make all         # 🎯 Full CI simulation (recommended!)
```

## 💡 Pro Tips

### Tip 1: Check Before Committing
Always run `make all` before creating a PR:
```bash
make all
```
This runs the same checks as CI, so you'll catch issues early.

### Tip 2: Watch Mode for Development
Open two terminals:
```bash
# Terminal 1: Watch tests
dotnet watch test

# Terminal 2: Make your changes
```

### Tip 3: Interactive Staging
If you don't want to stage everything:
```bash
make stage  # Interactive mode
# or
git add path/to/specific/file
make commit
```

### Tip 4: Quick Fixes
For small fixes while developing:
```bash
make dev  # Faster than 'make all'
```

### Tip 5: View Coverage Report
After running tests with coverage:
```bash
make test-coverage
open coverage/report/index.html  # macOS
# or
xdg-open coverage/report/index.html  # Linux
```

## 🐛 Troubleshooting

### "npm: command not found"
**Solution:** Install Node.js from https://nodejs.org/

### "dotnet: command not found"
**Solution:** Install .NET SDK from https://dotnet.microsoft.com/download

### "Tests are failing"
**Solution:**
```bash
# Clean and rebuild
make clean
make build
make test
```

### "Commit is rejected (validation error)"
**Solution:** Your commit message doesn't follow Conventional Commits.

Use `make commit` instead of `git commit` - it will guide you!

Or manually follow this format:
```
type(scope): subject

body

footer
```

Example:
```
feat(core): add retry policy to workflow executor

Implements exponential backoff retry mechanism for transient failures.

Closes #123
```

### "Format check failing in CI"
**Solution:**
```bash
make format       # Auto-fix
make format-check # Verify
```

## 📖 Next Steps

- Read [CONTRIBUTING.md](../CONTRIBUTING.md) for detailed guidelines
- Check [Architecture Decision Records](adr/) to understand design choices
- Browse [examples](../samples/) for usage patterns
- Run `make help` to see all available commands

## 🆘 Need Help?

- 💬 [GitHub Discussions](https://github.com/gurame/Flowrex/discussions)
- 🐛 [Open an Issue](https://github.com/gurame/Flowrex/issues)
- 📧 Ask in your PR comments

---

**Happy coding! 🎉**
