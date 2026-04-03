# 📝 Todo REST API (CQRS & Clean Architecture)

A high-performance, scalable To-Do management REST API following **Clean Architecture** and **CQRS (Command Query Responsibility Segregation)** patterns. This project demonstrates high-quality code standards with decoupled logic and a strict separation of concerns.

---

## 🚀 Key Features

*   🏙️ **Clean Architecture**: Strong isolation of business logic from infrastructure and UI.
*   ⚡ **CQRS with MediatR**: Efficiently handling reads and writes through dedicated commands and queries.
*   🔍 **Fluent Validation**: Declarative and powerful request validation integrated into the MediatR pipeline.
*   🛡️ **Result Pattern**: Eliminates exceptions for flow control, providing expressive and explicit error handling.
*   🧪 **Modular Structure**: Designed for easy testability and extension.
*   💾 **Persistence Layer**: Effortless database management using **Entity Framework Core** with SQLite.

---

## 📂 Visual Project Structure

```bash
CRUD_Usings_CQRS/
├── 🏢 TodoCQRS.slnx         # Solution file
├── 🌐 Api/                  # Presentation Layer
│   ├── Controllers/         # API Endpoints
│   ├── Extensions/          # Dependency Injection & Middleware
│   └── Program.cs           # Entry Point
├── ⚙️ Application/          # Core - Business Logic Layer
│   ├── Todos/               # Feature-based logic (CQRS)
│   │   ├── Commands/        # Create, Update, Delete
│   │   └── Queries/         # Read operations
│   ├── Common/              # Shared logic (Errors, Behaviors)
│   ├── Interfaces/          # Abstractions for Infrastructure
│   └── Contracts/           # DTOs & Request/Response models
├── 🏗️ Domain/               # Core - Domain Layer
│   ├── Entities/            # Core business entities (e.g., Todo.cs)
│   └── Common/              # Domain-specific common types
└── 🛠️ Infrastructure/       # Infrastructure Layer
    ├── Persistence/         # DB Context, Repo implementations
    └── Services/            # External service implementations
```

---

## 🏗️ Architecture Breakdown

### 🎯 Clean Architecture
The project is strictly divided into four main layers to ensure maintainability:
1.  **Domain**: Core entities and business logic (no dependencies).
2.  **Application**: Application logic, ports (interfaces), and CQRS handlers.
3.  **Infrastructure**: Implementation of adapters (DB access, APIs, file logs).
4.  **Api**: Controllers, routing, and HTTP-specific logic.

---

## 🛠️ Tech Stack & Libraries

- **Framework**: [.NET 10](https://dotnet.microsoft.com/)
- **Messaging**: [MediatR](https://github.com/jbogard/MediatR) for in-process CQRS.
- **Validation**: [FluentValidation](https://fluentvalidation.net/) for strong request rules.
- **ORM**: [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) for database mapping.
- **DB**: [SQLite](https://sqlite.org/) for local, portable storage.
- **Docs**: [Swagger/OpenAPI](https://swagger.io/) for API exploration.

---

## 🏁 Getting Started

### 📋 Prerequisites
- Install [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).

### 🛠️ Local Setup
1. **Clone the Repo:**
   ```bash
   git clone https://github.com/AbdelrahmanY25/CRUD_Usings_CQRS.git
   ```
2. **Restore Packages:**
   ```bash
   dotnet restore
   ```
3. **Database Setup:**
   ```bash
   dotnet ef database update --project Infrastructure --startup-project Api
   ```
4. **Run Project:**
   ```bash
   dotnet run --project Api
   ```

---

## 📡 API Endpoints

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/todos` | List all tasks |
| `GET` | `/api/todos/{id}` | Find task by ID |
| `POST` | `/api/todos` | Create a new task |
| `PUT` | `/api/todos/{id}` | Update existing task |
| `DELETE` | `/api/todos/{id}` | Remove a task |

---