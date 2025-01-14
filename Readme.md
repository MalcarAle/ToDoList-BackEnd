# ToDo List App

## Description
The **ToDo List App** is a simple .NET Web API application for managing a list of tasks. It provides endpoints to create, read, update, and delete ToDo items, with proper separation of concerns and a clean architecture. The backend uses Entity Framework Core for database interactions and supports SQL Server as the database provider.

---

## Features
- Create, Read, Update, and Delete (CRUD) ToDo items.
- Modular architecture with clear separation of concerns:
    - **Models**: Represents the data structure.
    - **Data**: Database context and migrations.
    - **Services**: Business logic for ToDo operations.
    - **Handlers**: Manages HTTP requests.
    - **Responses**: Standardized API response formats.
- Dependency injection for better maintainability.
- Standardized API responses.
- Configurable SQL Server database connection.

---

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/) (6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- An IDE or text editor (e.g., Visual Studio, Visual Studio Code)

---

## Getting Started

### 1. Clone the Repository
To start using the ToDo List App, clone this repository to your local machine:
```bash
git clone https://github.com/MalcarAle/ToDoList-BackEnd.git
cd ToDoListApp
```

### 2. Configure the Database Connection
- Open the `appsettings.json` file.
- Update the `DefaultConnection` string with your SQL Server connection details:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ToDoListDb;Trusted_Connection=True;"
  }
}
```

### 3. Apply Migrations
Run the following commands to create the database and apply migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application
Use the following command to start the application:
```bash
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000` by default.

---

## API Endpoints
Here are the main endpoints provided by the ToDo List App:

| Method | Endpoint             | Description                     |
|--------|----------------------|---------------------------------|
| GET    | `/v1/todos`          | Retrieves all ToDo items.       |
| GET    | `/v1/todos/{id}`     | Retrieves a ToDo item by ID.    |
| POST   | `/v1/todos`          | Creates a new ToDo item.        |
| PUT    | `/v1/todos/{id}`     | Updates an existing ToDo item.  |
| DELETE | `/v1/todos/{id}`     | Deletes a ToDo item by ID.      |

---

## Troubleshooting
- Ensure SQL Server is running and accessible.
- Verify the connection string in `appsettings.json` is correct.
- Check for any migration issues and resolve them using the `dotnet ef` commands.

---

## Future Improvements
- Add authentication and authorization.
- Implement pagination for large datasets.
- Create a frontend using Angular or another framework.

---

## License
This project is licensed under the MIT License. Feel free to use and modify it as needed.

---

## Contact
For any questions or support, feel free to reach out at [alexandre.malcar@gmail.com].
