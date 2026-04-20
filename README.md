# 📝 Task Manager App

This is a simple **Task Management web application** built with **ASP.NET Core MVC** following clean architecture principles such as **Repository Pattern**, **Service Layer**, and **Dependency Injection**.

---

## 🚀 Features

* View all tasks (Task List)
* Create new tasks
* Edit existing tasks
* View task details
* Sorting:

  * By **Priority** (Low < Medium < High)
  * By **Deadline**
* Runtime task status calculation:

  * ✅ Done
  * ⏰ Overdue
  * ⚡ Urgent (within 24 hours)
  * 🔄 Active
* Manual validation:

  * Title cannot be empty
  * Deadline cannot be in the past
* Partial View used for task list rendering

---

## 🧠 Task Status Logic (Important)

Task **Status is NOT stored in the database**.

It is calculated at runtime using the following rules:

* If `IsCompleted = true` → **Done**
* If deadline has passed → **Overdue**
* If deadline is within 24 hours → **Urgent**
* Otherwise → **Active**

---

## 🏗️ Architecture

The project follows a layered architecture:

* **Presentation Layer**

  * MVC Controllers & Views

* **Service Layer**

  * Business logic
  * Validation

* **Repository Layer**

  * Data access logic (Generic Repository + Specific Repository)

* **Data Layer**

  * Entity Framework Core
  * PostgreSQL

---

## 🧩 Technologies

* ASP.NET Core MVC
* Entity Framework Core
* PostgreSQL
* Dependency Injection

---

## 📂 Project Structure

```
TaskManagerApp/
│
├── Controllers
├── Views
│
├── Services
├── Interfaces
├── Repositories
│
├── Data
├── Models
```

---

## ⚙️ Setup & Run

### 1. Clone repository

```
git clone https://github.com/your-username/task-manager-app.git
cd task-manager-app
```

### 2. Configure database

Update `appsettings.json`:

```
"ConnectionStrings": {
  "Default": "Host=localhost;Database=taskdb;Username=postgres;Password=yourpassword"
}
```

### 3. Apply migrations

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run application

```
dotnet run
```

---

## 🎯 Key Concepts Demonstrated

* MVC Pattern
* Generic Repository Pattern
* Service Layer Pattern
* Dependency Injection
* Clean separation of concerns

---

## 📌 Notes

* Status is computed dynamically (not persisted)
* Business logic is separated from controllers
* Repository pattern is used for abstraction over data access

---

## 📬 Author

Developed as part of a backend development task.
