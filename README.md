# 🧠 Habit Tracker with Insights Engine

A cleanly architected **Habit Tracking System** that not only records your daily habits but also provides **data-driven insights** into your consistency, performance, and streaks — powered by an extendable analytics core.

Built with **C# and .NET**, this project demonstrates solid software architecture practices including domain-driven design, separation of concerns, and service-oriented structure.

---

## 🚀 Overview

Most habit trackers simply record completions. This project goes further: it helps users understand *how well* they are performing. The **Insights Engine** analyzes stored data to generate meaningful feedback — average completion times, streaks, and progress trends.

It’s designed with **extensibility and clean layering** in mind, suitable for both console-based and future web or desktop implementations.

---

## 🧩 Core Features

* **Create and Manage Habits**
  Define custom habits with a name, tags, and measurable goals.

* **Log Progress**
  Record daily completions with optional duration and notes.

* **Analytics & Insights**
  Get streaks, averages, and completion metrics automatically through the domain analytics engine.

* **Tag System**
  Categorize habits using comma-separated tags for smarter grouping and filtering.

* **Clean Architecture**
  Codebase organized into Domain, Application, and Infrastructure layers for maintainability and scalability.

---

## 🧱 Project Structure

```
HabitTracker/
├── 📁 Application/
│   ├── IHabitAppService.cs          → Defines habit management operations
│   └── ReportAppService.cs          → Generates user reports and insights
│
├── 📁 Domain/
│   ├── 📁 Entities/
│   │   ├── Habit.cs                 → Represents a user habit with validation and tags
│   │   └── HabitLog.cs              → Represents a log entry for a habit
│   │
│   ├── 📁 Infrastructure/
│   │   ├── FileHabitRepository.cs   → File-based persistence for habits (planned)
│   │   └── IHabitLogRepository.cs   → Interface for log persistence
│   │
│   ├── 📁 Services/
│   │   ├── HabitAnalytics.cs        → Calculates averages, totals, and last completions
│   │   └── StreakCalculator.cs      → Determines ongoing streaks (planned)
│   │
│   └── 📁 ValueObjects/
│       ├── InsightReport.cs         → Holds generated report data (planned)
│       └── StreakResult.cs          → Represents streak analysis result (planned)
│
├── Program.cs                        → Entry point (console runner)
└── Test.csproj                       → Project file
```

---

## 🧮 Architecture Philosophy

The application follows **Domain-Driven Design (DDD)** principles with clear separation between *business logic* and *application orchestration*.

**Domain Layer**

> Contains core entities, value objects, and domain services — the “rules” of the system.

**Application Layer**

> Handles use cases (e.g., creating habits, generating reports). Coordinates domain logic and repositories.

**Infrastructure Layer**

> Provides technical implementations such as file storage or database persistence.

This structure makes the system testable, maintainable, and adaptable for future UI or API layers.

---

## ⚙️ Example Usage (Conceptual Flow)

```
User → HabitAppService → HabitRepository → HabitAnalytics → InsightReport
```

A user creates a habit (e.g., *“Exercise 30 min”*).
Each day they log progress, which is stored via a repository.
The analytics engine later processes logs to produce reports like:

* Total completions: 15
* Average session time: 27.5 minutes
* Current streak: 7 days

---

## 🧩 Key Classes (Simplified)

**Habit.cs**

```csharp
var habit = new Habit(id: 1, name: "Read 30 pages", tags: "learning,focus", goal: 30);
```

**HabitLog.cs**

```csharp
var log = HabitLog.CreateNew(habitId: 1, date: DateOnly.FromDateTime(DateTime.Now), duration: 1.5m, notes: "Great focus today!");
```

**HabitAnalytics.cs**

```csharp
var analytics = new HabitAnalytics(logs);
var avg = analytics.GetAverageCompletionTime(1);
var total = analytics.GetTotalCompletions(1);
```

---

## 🧭 Roadmap

* [x] Core domain entities (`Habit`, `HabitLog`)
* [x] Analytics service (`HabitAnalytics`)
* [x] Application service for managing habits
* [ ] Repository persistence layer (JSON or file storage)
* [ ] Streak calculation engine
* [ ] Insight report generation (summaries, charts)
* [ ] Console UI or Web API integration

---

## 🛠️ Technologies

* **.NET 8 / C# 12**
* LINQ for analytics and data filtering
* Domain-driven design
* SOLID principles

---

## 📘 Author

**Developer:** Bashar Soufan
Passionate about clean architecture, data-driven design, and building intelligent systems that go beyond CRUD.
