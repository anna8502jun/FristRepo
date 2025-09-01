# dotnet-api-project

## Overview
This project is a RESTful API built using .NET 8 that provides weather forecast information. It includes standard endpoints for managing weather forecasts, allowing users to perform CRUD operations.

## Project Structure
```
dotnet-api-project
├── src
│   ├── Controllers
│   │   └── WeatherController.cs
│   ├── Models
│   │   └── WeatherForecast.cs
│   ├── Services
│   │   └── WeatherService.cs
│   ├── Program.cs
│   └── Startup.cs
├── dotnet-api-project.csproj
└── README.md
```

## Endpoints
The API exposes the following endpoints through the `WeatherController`:

- **GET /weather**: Retrieves all weather forecasts.
- **GET /weather/{id}**: Retrieves a specific weather forecast by ID.
- **POST /weather**: Creates a new weather forecast.
- **PUT /weather/{id}**: Updates an existing weather forecast by ID.
- **DELETE /weather/{id}**: Deletes a weather forecast by ID.

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd dotnet-api-project
   ```
3. Restore the project dependencies:
   ```
   dotnet restore
   ```
4. Run the application:
   ```
   dotnet run
   ```

## Usage
Once the application is running, you can interact with the API using tools like Postman or curl. Make sure to set the appropriate HTTP method and headers as required.

## Contributing
Contributions are welcome! Please open an issue or submit a pull request for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.