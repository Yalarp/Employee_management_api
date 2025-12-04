

# Employee Management API

A full-stack solution for managing employee records. This project consists of a RESTful API built with **.NET 8 (ASP.NET Core Web API)** and a lightweight frontend user interface built with **HTML** and **Tailwind CSS**.

## 🚀 Features

  * **CRUD Operations**: Create, Read, Update, and Delete employee records.
  * **Repository Pattern**: Decoupled business logic using Service and Repository layers.
  * **Database**: SQL Server integration using Entity Framework Core (Code-First approach).
  * **Swagger/OpenAPI**: Automatic API documentation and testing interface.
  * **CORS Enabled**: Configured to allow cross-origin requests for the frontend.
  * **Responsive UI**: A dark-mode, responsive dashboard using Tailwind CSS.

## 🛠 Tech Stack

  * **Backend Framework**: .NET 8.0
  * **Language**: C\#
  * **ORM**: Entity Framework Core 8.0
  * **Database**: Microsoft SQL Server (configured for LocalDB)
  * **Frontend**: HTML5, JavaScript (Fetch API), Tailwind CSS (via CDN)
  * **Documentation**: Swashbuckle (Swagger UI)

## 📋 Prerequisites

Before running the application, ensure you have the following installed:

1.  **[.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**
2.  **Microsoft SQL Server** or **SQL Server Express LocalDB** (often included with Visual Studio).
3.  **Visual Studio 2022** or **VS Code**.

## ⚙️ Setup and Installation

### 1\. Clone or Download

Download the project files to your local machine.

### 2\. Configure the Database

The project is configured to use `(localdb)\ProjectModels` by default. You can view or change this in `twotable/twotable/appsettings.json`.

```json
"ConnectionStrings": {
  "EmployeeDBConnection": "Server=(localdb)\\ProjectModels;Database=TwoTables;Integrated Security=True;TrustServerCertificate=True;"
}
```

### 3\. Apply Migrations

Navigate to the project directory containing the `.csproj` file (inside `twotable/twotable/`) and run the database update command to create the database and tables based on the models.

```bash
cd twotable/twotable
dotnet ef database update
```

*Note: If you do not have the EF Core tool installed globally, install it first:*
`dotnet tool install --global dotnet-ef`

## 🏃‍♂️ Running the Application

### Backend (API)

1.  Navigate to the project folder:
    ```bash
    cd twotable/twotable
    ```
2.  Run the application:
    ```bash
    dotnet run
    ```
3.  Once running, the API will likely listen on `https://localhost:7196` or `http://localhost:5200` (check your console output).
4.  You can access the Swagger UI to test endpoints directly at:
    `https://localhost:<port>/swagger`

### Frontend (UI)

The frontend consists of static HTML files located in the root `Employee_management_api` folder (e.g., `Landingpage.html`, `Getallemployees.html`).

1.  Ensure the Backend API is running.
2.  Open `Landingpage.html` in your web browser.
3.  Navigate through the dashboard to Add, View, Update, or Delete employees.

*Note: If the frontend cannot connect to the backend, ensure the API port in your JavaScript fetch calls matches the port your .NET application is running on.*

## 🔌 API Endpoints

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/Employee` | Get a list of all employees |
| `GET` | `/api/Employee/{id}` | Get details of a specific employee by ID |
| `POST` | `/api/Employee` | Add a new employee |
| `PUT` | `/api/Employee/{id}` | Update an existing employee |
| `DELETE` | `/api/Employee/{id}` | Delete an employee |

## 📂 Project Structure

```text
Employee_management_api/
├── Landingpage.html      # Main Dashboard UI
├── Getallemployees.html  # UI to list employees
├── addemployee.html      # UI to create employee
├── ...                   # Other HTML files
└── twotable/
    └── twotable/
        ├── Controllers/  # API Controllers (EmployeeController)
        ├── Models/       # DB Models (Employee, Department)
        ├── Services/     # Business Logic (SqlEmployeeService)
        ├── Repository/   # DB Context (AppdbContextRepository)
        ├── Program.cs    # App entry point & Configuration
        └── ...
```
