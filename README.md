# Inventory Management System (IMS)

## Overview
The Inventory Management System (IMS) is an ASP.NET Core Web API project that allows employees to manage inventory efficiently. It includes functionalities to manage products, set minimum stock levels, and generate basic inventory reports.

### Key Features
- Product Management: Add, update, and delete products.
- Inventory Alerts: Flag products as "Low Stock" when stock falls below the minimum level.
- Reporting: Generate reports for low-stock products and calculate the total inventory value.

## Prerequisites
Make sure the following are installed on your system before running the project:

- .NET SDK (version 7.0 or above) [Download Here](https://dotnet.microsoft.com/en-us/download)  
- SQL Server Ensure you have access to an SQL Server instance.
- Visual Studio [Download Here](https://visualstudio.microsoft.com/downloads/)
- Postman (optional, for API testing)

## Installation Steps
#### Step 1: Clone the Repository
```bash
git clone https://github.com/your-repository/inventory-management-system.git
cd inventory-management-system
```

### Step 2: Set Up the Database
- Open the project in Visual Studio.
- Modify the appsettings.json file with your SQL Server connection string:
```bash
"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=IMS;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
- If you want a new database you could create through `Server Explore` --> `Database connection`. And add the `ConnectionString` in the `appsettings.json`
- Run the following commands in the Package Manager Console to create and update the database
```bash
PM> Add-Migration InitialCreate
PM> Update-Database
```

### Step 3: Run the Application
- Using Visual Studio: Press `F5` to launch the application in debug mode.
- Using the Command Line: Run the following command
```bash
dotnet run
```
- Access the API: Once the application starts, Swagger UI will be available at the following URL
```bash
http://localhost:<port>/swagger
```

## Using the API
### Authentication
The API requires authentication. After logging in, use the generated token for authorization. In Swagger, click the "Authorize" button, input the token, and proceed to test the secured endpoints.


