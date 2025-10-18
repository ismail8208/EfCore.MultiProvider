# EF Core Multi-Provider

A .NET 9.0 web API project demonstrating multi-database provider support with Entity Framework Core, currently configured for SQL Server and PostgreSQL.

## Features

- Clean Architecture with Domain, Application, and Infrastructure layers
- Support for multiple database providers (SQL Server and PostgreSQL)
- Database migrations for each provider
- Dependency Injection configuration

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (for SQL Server provider)
- PostgreSQL (for PostgreSQL provider)
- Your preferred IDE (Visual Studio, VS Code, or JetBrains Rider)

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/ismail8208/EfCore.MultiProvider.git
   cd EfCore.MultiProvider
   ```

2. **Configure the database connection**
   - Update the connection strings in `appsettings.json` or `appsettings.Development.json`:
     ```json
     "DatabaseOptions": {
       "Provider": "MSSQL", // or "PostgreSQL"
       "ConnectionString": "YourConnectionStringHere"
     }
     ```

3. **Apply database migrations**
   - For SQL Server:
   - **Visual Studio Console**
     ```bash
     Update-Database -Project Infrastructure -StartupProject Web -Context SqlServerApplicationDbContext
     ```
   - For PostgreSQL:
   - **Visual Studio Console**
     ```bash
     Update-Database -Project Infrastructure -StartupProject Web -Context PostgreSqlApplicationDbContext
     ```
4. **Add migrations**
   - For SQL Server:
   - **Visual Studio Console**
     ```bash
     Add-Migration Initial_MSSQL -Project Infrastructure -StartupProject Web -Context SqlServerApplicationDbContext -OutputDir "Migrations\SqlServer"
     ```
   - For PostgreSQL:
   - **Visual Studio Console**
     ```bash
     Add-Migration Initial_PostgreSQL -Project Infrastructure -StartupProject Web -Context PostgreSqlApplicationDbContext -OutputDir "Migrations\PostgreSQL"
     ```

5. **Run the application**
   ```bash
   dotnet run --project Web
   ```

5. **Access the API**
   - Use `https://localhost:7232/api` with your requets.

## Project Structure

- **Domain**: Contains the core business logic and entities
- **Application**: Implements business logic and use cases
- **Infrastructure**: Handles data access and external services
- **Web**: API layer with controllers and configuration

## Available Endpoints

- `GET /TodoItems` - Get all todos endpoint
- `POST /TodoItems` - Create new todo endpoint
     ```bash
     {
      "Title" : "Todo Title"
     }
     ```

## Configuration

The application can be configured using `appsettings.json` or environment variables. The following settings are available:

- `DatabaseOptions:Provider`: Database provider (MSSQL or PostgreSQL)
- `DatabaseOptions:ConnectionString`: Connection string for the database

## Adding a New Database Provider

1. Add a new Context Type for the provider
2. Update the `ApplicationDbContext` configuration in `DependencyInjection.cs`
3. Add the provider-specific configuration in `Program.cs`

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a new branch for your feature or bugfix
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request
