## [1.0.2](https://github.com/gurame/Flowrex/compare/v1.0.1...v1.0.2) (2025-10-02)


### Bug Fixes

* **ci:** fix release workflow conditions ([9fe854a](https://github.com/gurame/Flowrex/commit/9fe854a7bc45edec971d0c4ae2f911789ed06bf4))
* **nuget:** disable signers validation ([bd67693](https://github.com/gurame/Flowrex/commit/bd676930a790430f9229ce03293d4861abbec746))
* **workflowstep:** log exceptions ([bc8759f](https://github.com/gurame/Flowrex/commit/bc8759f3eedde80be1335f8e77c8c4f374e23c9c))

## [1.0.1](https://github.com/gurame/Flowrex/compare/v1.0.0...v1.0.1) (2025-10-02)


### Bug Fixes

* **nuget:** trust all NuGet.org signed packages for CI compatibility ([499917a](https://github.com/gurame/Flowrex/commit/499917a0768fdc9df3d2aae4027cbd6b4f8dfd4d))

# 1.0.0 (2025-10-02)


### Bug Fixes

* **commitlintrc:** update limits of body ([c9993fd](https://github.com/gurame/Flowrex/commit/c9993fde7c1f4bbc9095350c84c8353510e55a2c))
* **nuget:** add microsoft signature ([902c679](https://github.com/gurame/Flowrex/commit/902c67977c264f2bd014a9082d2834ef84fd734d))
* **package:** remove icon.png reference until icon is created ([8513799](https://github.com/gurame/Flowrex/commit/8513799a94fdb0d5edc4f0bc7e1bb0c40e137cff))


### Features

* **ci:** implement automatic release with semantic-release ([267888d](https://github.com/gurame/Flowrex/commit/267888de483a77ba1aa595763dd463f51a7f2cff))

# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Initial workflow orchestration engine
- Fluent workflow builder API
- Saga pattern with compensation support
- Dependency injection integration
- In-memory workflow store
- Structured logging with OpenTelemetry traces
- Thread-safe workflow execution with proper service scoping
- Type-safe context and step output management
- Comprehensive input validation
- XML documentation for all public APIs

### Fixed
- Service lifetime issues with scoped dependencies
- Thread safety in workflow executor
- Type casting in context output retrieval

### Security
- No known vulnerabilities in dependencies
- Regular automated security scanning

## [0.1.0] - TBD

- Initial release

[Unreleased]: https://github.com/gurame/Flowrex/compare/v0.1.0...HEAD
[0.1.0]: https://github.com/gurame/Flowrex/releases/tag/v0.1.0
