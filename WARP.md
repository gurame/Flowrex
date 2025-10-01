# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Project Overview

Flowrex is a professional .NET workflow orchestration library built on .NET 9.0 using a modular architecture. The project follows a clean architecture pattern with separate layers for abstractions, core implementation, persistence, configuration, and extensions.

## Common Commands

### Building
- **Build entire solution**: `dotnet build Flowrex.sln` or `make build`
- **Build specific project**: `dotnet build src/Flowrex.Core/Flowrex.Core.csproj`
- **Build in Release mode**: `dotnet build Flowrex.sln -c Release`

### Testing  
- **Run all tests**: `dotnet test`
- **Run tests with coverage**: `dotnet test --collect:"XPlat Code Coverage"`
- **Run specific test project**: `dotnet test tests/Flowrex.Tests/Flowrex.Tests.csproj`
- **Run single test**: `dotnet test --filter "MethodName=TestMethodName"`

### Development
- **Run sandbox sample**: `dotnet run --project samples/Flowrex.Sandbox/Flowrex.Sandbox.csproj`
- **Clean build artifacts**: `dotnet clean`
- **Restore NuGet packages**: `dotnet restore`
- **Watch for changes**: `dotnet watch --project samples/Flowrex.Sandbox/Flowrex.Sandbox.csproj`

## Architecture Overview

### Core Components

**Flowrex.Abstractions** - Contains all interfaces and contracts:
- `IWorkflow` - Represents a complete workflow definition with steps
- `IWorkflowDefinition` - Declarative workflow definition using builder pattern
- `IWorkflowBuilder` & `IStepBuilder` - Fluent API for workflow construction
- `IWorkflowExecutor` - Orchestrates workflow execution
- `IWorkflowStep` - Individual executable units within workflows
- `IWorkflowContext` - Provides scoped services and step output sharing
- `ICompensableStep` - Steps that support compensation/rollback logic
- `IWorkflowStore` - Persistence abstraction for workflow state

**Flowrex.Core** - Core implementation of the workflow engine:
- `WorkflowExecutor` - Main execution engine
- `WorkflowBuilder` - Builder implementation for workflow construction
- `WorkflowContext` - Runtime context for step execution
- `DefaultCompensationStrategy` - Default rollback behavior

**Flowrex.Results** - Result types and status enums:
- `StepResult` - Encapsulates step execution outcomes
- `WorkflowStatus` - Enum for workflow states (Pending, Running, Completed, Failed, Compensated, Canceled)

**Flowrex.Configuration** - Dependency injection and configuration:
- `FlowrexOptions` - Configuration options for the workflow engine
- `ServiceCollectionExtensions` - DI container registration

**Flowrex.Persistence** - Data persistence layers:
- `Flowrex.Persistence.InMemory` - In-memory storage implementation
- `Flowrex.Persistence.EfCore` - Entity Framework Core integration (placeholder)

**Flowrex.Extensions** - Builder pattern extensions and utilities

### Workflow Execution Flow

1. **Definition**: Implement `IWorkflowDefinition` with steps defined via `IWorkflowBuilder`
2. **Registration**: Register workflows using `services.AddFlowrex()` 
3. **Execution**: Use `IWorkflowExecutor.ExecuteAsync<TWorkflowDefinition>()` to run workflows
4. **Context**: Each step receives `IWorkflowContext` for service access and output sharing
5. **Compensation**: Failed workflows trigger compensation for `ICompensableStep` instances

### Project Structure

```
src/
├── Flowrex/              # Main library package (aggregates all components)
├── Flowrex.Abstractions/ # Core interfaces and contracts
├── Flowrex.Core/         # Workflow engine implementation
├── Flowrex.Results/      # Result types and enums
├── Flowrex.Configuration/# DI setup and configuration
├── Flowrex.Extensions/   # Builder extensions
├── Flowrex.Persistence.InMemory/ # In-memory persistence
└── Flowrex.Persistence.EfCore/   # EF Core persistence

build/
└── Flowrex.Build/        # Build-related utilities

tests/
└── Flowrex.Tests/        # Unit tests using xUnit

samples/
└── Flowrex.Sandbox/      # Example usage and development sandbox
```

## Key Patterns

### Workflow Definition Pattern
Workflows are defined declaratively using `IWorkflowDefinition` and built using the fluent `IWorkflowBuilder` API.

### Compensation Pattern  
Steps implementing `ICompensableStep` provide rollback logic that's automatically invoked on workflow failures.

### Context Sharing Pattern
The `IWorkflowContext` allows steps to share outputs and access scoped services throughout workflow execution.

### Builder Pattern
Fluent APIs in `IWorkflowBuilder` and `IStepBuilder` provide type-safe workflow construction with method chaining.

## Development Notes

- All projects target .NET 9.0 with nullable reference types enabled
- The solution uses `Directory.Build.props` for consistent project configuration  
- Test framework is xUnit with coverlet for code coverage
- The main `Flowrex` project is a meta-package that references all core components
- Use the `Flowrex.Sandbox` project for testing new features and workflows