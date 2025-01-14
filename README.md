# EmployeeManagement
Employee Management using vertical slicing

## Technologies
- Backend: ASP.NET Core Web API, Entity Framework Core
- Database: MSSQL
- Authentication: JWT
- Authorization: JWT
- Architectural Pattern: Vertical Slicing with CQRS
- API Versioning: v1
- Containerization: Docker (optional)

## Setup
1. Clone the repository.
2. Configure `appsettings.json` with your database connection string.
3. Configure `appsettings.json` for serilog folder location.
4. Configure `appsettings.json` for jwt change secretkey
5. Run the project using `dotnet run` or from Visual Studio.

## Endpoints
- `POST /api/v1/auth/login` - Login and get JWT
- `GET /api/v1/employees/GetAll` - Get all employees.
- `GET /api/v1/employees/1` - Get employee by id.
- `POST /api/v1/employees` - Add a new employee.
- `POST /api/v1/employees` - Add a new employee.
- `DELETE /api/v1/employees/{id}` - Delete an employee.


- `GET /api/v1/departments/GetAll` - Get all departments.
- `GET /api/v1/departments/1` - Get department by id.
- `POST /api/v1/departments` - Add a new department.
- `POST /api/v1/departments` - Add a new department.
- `DELETE /api/v1/departments/{id}` - Delete a department.

- `GET /api/v1/designations/GetAll` - Get all designations.
- `GET /api/v1/designations/1` - Get designation by id.
- `POST /api/v1/designations` - Add a new designation.
- `POST /api/v1/designations` - Add a new designation.
- `DELETE /api/v1/designations/{id}` - Delete a designation.


## Logging
Logs are saved in the `logs` directory.

## UserName: admin, Password: admin
