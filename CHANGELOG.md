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
