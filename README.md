# Entity Framework Core – Practice Series

## Overview

This repository contains practical assignments completed while studying **Entity Framework Core**, a modern ORM framework for .NET. The course focuses on core EF Core functionality including modeling, relationships, LINQ queries, and raw SQL execution.

## Course Structure

### 1. Introduction to Entity Framework Core
- Created a console application using a list of `Product` objects
- Populated the list with 10 entries
- Displayed products at indices 1, 5, 0, 7
- Found and displayed indexes of products by `Id` at indices 1, 5
- Found and displayed indexes of products by `Name` at indices 0, 7

> 📄 [1. Program.cs](./1.Introduction_to_Entity_Framework_Core)
---


### 2. Creating Models in Entity Framework Core
- Limited all string properties using **Data Annotations** based on their purpose
- Renamed `Id` to `(ClassName)Id` convention
- Applied `DataType.Date` for `DateTime` fields
- Applied all changes to the database via migration
- Created an **enum** `StatusCode` with values: `Ok`, `NotFound`, `Server`
- Created a new class `Error` with properties: `Message`, `Time`, `Request`, `Status`
- Added `DbSet<Error>` to the database context
- Configured an additional field `(ClassName)AlterId` as part of a composite key via **Fluent API**
- Configured the `Error` type to be **ignored** in the database via Fluent API
- Implemented exception handling that populates the `Error` collection on invalid query (e.g., negative index)
- Ensured the `Error` table is not created in the database, even though it is used in the code
- Additionally, attempted to configure all of the above without using DataAnnotations, relying only on **Fluent API**

> 📄 [2. Fluent_API, Data Annotations, migration](./2.Fluent_API,Data%20Annotations,migration)
---


### 3. Model Relationships and Inheritance *(upcoming)*
⏱ Duration: 59m 46s

### 4. LINQ to Entities Queries *(upcoming)*
⏱ Duration: 1h 07m 31s

### 5. SQL in Entity Framework Core *(upcoming)*
⏱ Duration: 31m 59s

## How to Run

1. Open the solution in **Visual Studio** or the folder in **Visual Studio Code**
2. Restore NuGet packages if needed
3. Build and run the project

## Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- Basic knowledge of C# and LINQ

## License

This project is licensed under the MIT License.
