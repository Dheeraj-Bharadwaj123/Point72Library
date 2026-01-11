# Point72Library - Simple Library API

A backend REST API for managing a library. Clients can borrow and return books. Books and clients are persisted using **SQLite**.

This project is built with:
- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core** with SQLite
- **Swagger** for testing API endpoints

---

## 📦 Project Structure
```
Point72Library/
├─ Controllers/
│ ├─ BooksController.cs
│ ├─ ClientsController.cs
│ └─ LoansController.cs
├─ Data/
│ └─ LibraryContext.cs
├─ Models/
│ ├─ Book.cs
│ ├─ Client.cs
│ └─ Loan.cs
├─ Program.cs
└─ Point72Library.csproj
```
---

## ⚡ Setup Instructions

### 1. Clone the repository
```
git clone https://github.com/<your-username>/Point72Library.git
cd Point72Library
```

### 2. Install EF Core CLI (if not installed)
```
dotnet tool install --global dotnet-ef
```

### 3. Install NuGet Packages
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### 4. Create and Update the Database
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
### 5. Run the Application
```
dotnet run
```

-API will start at https://localhost:7233 (or check console)
-Swagger UI: https://localhost:7233/swagger

---

## 🚀 API Endpoints

### Clients
- GET /api/clients → List all clients
- POST /api/clients → Add a new client
  - Body: {"name": "Alice", "email": "alice@library.com", "isLibrarian": true}

### Books
- GET /api/books → List all books
- POST /api/books?librarianId={id} → Add a new book (librarian only)
- DELETE /api/books/{id}?librarianId={id} → Delete a book (librarian only)

### Loans (Borrow / Return)
- POST /api/loans/borrow?bookId={id}&clientId={id} → Borrow a book
- POST /api/loans/return?loanId={id} → Return a book

---

## ⚙️ Notes
- **Librarian role:** Only clients with isLibrarian = true can add or delete books.
- **Data:** Persisted in SQLite (library.db)
- **Models:**
  - Book: Id, Title, Author
  - Client: Id, Name, Email, IsLibrarian
  - Loan: Id, BookId, ClientId, Returned

---

## ✅ Testing in Swagger
1. Create clients via POST /api/clients.
2. Add books via POST /api/books?librarianId={id}.
3. Borrow books via POST /api/loans/borrow.
4. Return books via POST /api/loans/return.
