# Blazor TreeGrid with Entity Framework CRUD Operations

## Overview

This sample demonstrates how to use the Syncfusion [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) component together with Entity form data binding and CRUD operations in a Blazor application. The sample shows how hierarchical records can be retrieved, displayed, edited, inserted, and deleted while keeping the TreeGrid synchronized with the underlying data source. It provides a practical reference for developers building database-driven applications that require structured parent-child data management.

## Key Features

- Binds TreeGrid data using an Entity Framework-backed data source.
- Demonstrates Create, Read, Update, and Delete (CRUD) operations from the TreeGrid interface.
- Displays hierarchical records using the TreeGrid component.
- Uses controller-based data access for handling database operations.
- Demonstrates integration between Blazor UI components and Entity Framework data services.
- Supports editing workflows for maintaining hierarchical datasets.
- Provides an end-to-end example of database-driven TreeGrid implementation.
- Includes project structure for configuring data access and UI rendering within the same application.

## Prerequisites

- Visual Studio 2022 or Visual Studio Code
- .NET SDK compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download this repository.
2. Open the solution file:

   `TreeGrdiWithEF.sln`

3. Restore NuGet packages.
4. Ensure the startup project is:

   `TreeGrdiWithEF`

5. Build the solution.
6. Run the application using `Ctrl+F5`.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Open the integrated terminal.
3. Navigate to the project directory containing:

   `TreeGrdiWithEF.csproj`

4. Restore packages and run the application:

```bash
dotnet restore
dotnet run
```

## Project Structure

`Pages/Index.razor` —  contains the primary TreeGrid implementation and CRUD configuration.

`Controllers/*.cs` — Handles data requests and database operations for the TreeGrid.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- Official TreeGrid documentation: https://help.syncfusion.com/grid-sdk/blazor/tree-grid/data-binding#entity-framework

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.