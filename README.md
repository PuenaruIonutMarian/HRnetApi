# HRNet API

This API provides employee management functionalities, enabling CRUD operations on employee records. It is built with .NET and integrates seamlessly with an Angular front end (typically served on `localhost:4200`) for an HR management application.

## Table of Contents

1. [Features](#features)
2. [Technologies](#technologies)
3. [Installation](#installation)
4. [Usage](#usage)
5. [API Endpoints](#api-endpoints)
6. [Swagger Integration](#swagger-integration)
7. [Contributing](#contributing)
8. [License](#license)

## Features

* **In-memory Database**: Allows quick data testing without a persistent database
* **CORS Setup**: Allows cross-origin requests specifically for Angular development on `localhost:4200`
* **Dependency Injection**: Simplifies repository management for scalability and testing
* **CRUD Operations**: Supports full create, read, update, and delete actions on employees

## Technologies

* **ASP.NET Core 7**
* **Entity Framework Core In-Memory Database**
* **Swagger**: API documentation and testing

## Installation

1. **Clone the repository**:
```bash
git clone https://github.com/your-username/HRNetApi.git
```

2. **Navigate to the project directory**:
```bash
cd HRNetApi
```

3. **Restore dependencies**:
```bash
dotnet restore
```

4. **Run the API**:
```bash
dotnet run
```

By default, the API will be available at `http://localhost:5198`.

## Usage

The API uses an in-memory database (`EmployeeDb`) and can be accessed directly by Angular or through API testing tools like Postman.

### CORS Configuration

The API allows requests from `http://localhost:4200` to enable seamless local development with an Angular front end. You can modify this configuration in the `Program.cs` file if needed.

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Employee` | Retrieves all employees |
| GET | `/api/Employee/{id}` | Retrieves an employee by ID |
| POST | `/api/Employee` | Creates a new employee |
| PUT | `/api/Employee/{id}` | Updates an existing employee |
| DELETE | `/api/Employee/{id}` | Deletes an employee by ID |

### Example Request and Response

* **Get All Employees**:
```http
GET /api/Employee
```

**Response**:
```json
[
    {
        "id": 1,
        "firstName": "John",
        "lastName": "Doe",
        "email": "john.doe@example.com",
        "phone": "1234567890",
        "position": "Manager"
    },
    ...
]
```

## Swagger Integration

This API includes Swagger for API documentation and testing. To access Swagger UI:

1. Run the API
2. Open [http://localhost:5198](http://localhost:5198) in your browser, where you can view and test all available endpoints

## Contributing

Contributions are welcome. To contribute:

1. Fork the repository
2. Create a branch for your feature or bug fix
3. Submit a pull request

## License

This project is licensed under the MIT License.
