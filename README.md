# .Net 8 - Backend (N-layer) with Angular UI


This project serves as a recall and skill-testing exercise after a year-long break from software development. It implements a multi-layered enterprise software architecture, adhering to SOLID principles. The backend is built with .Net 8, and the UI is developed using Angular. This project utilizes Microsoft's **Northwind** database, demonstrating real-world scenarios in data management and business logic implementation.

[![SOLID Principles](https://img.shields.io/badge/SOLID-Compliant-green)](https://en.wikipedia.org/wiki/SOLID)

---

## Related Project

You can explore the UI counterpart of this project developed using Angular:

**[Angular UI Project](https://github.com/NurhatMentes/northwind)**

---

## Technologies and Architectures Used

This project integrates several modern technologies and development patterns to ensure scalability, maintainability, and performance.

- **.NET 8**
- **Autofac 8.1.0**: Dependency Injection framework
- **Entity Framework Core 6.5.1**: ORM for database operations
- **FluentValidation 11.0.0**: Validation framework
- **Aspect-Oriented Programming (AOP)**: Used for logging, authorization, and performance
- **Interceptors**: For cross-cutting concerns like caching and transaction handling
- **MemoryCache**: In-memory caching for performance optimization
- **Transaction Management**: Ensures data consistency across operations
- **Performance Aspects**: Monitors and improves runtime efficiency
- **Authorization**: Role-based access control implemented using .NET security mechanisms

---

## Project Structure

The project follows a clean architecture with well-separated concerns, ensuring long-term maintainability and testability.

```bash
├── src
│   ├── Application
│   ├── Domain
│   ├── Infrastructure
│   └── UI
├── tests (will be made)
│   ├── UnitTests 
│   └── IntegrationTests
└── docs
