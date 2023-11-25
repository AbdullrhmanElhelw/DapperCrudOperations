# Dapper CRUD Operations Project

This project demonstrates CRUD (Create, Read, Update, Delete) operations using Dapper in a .NET Core environment. Dapper is a lightweight and high-performance Object-Relational Mapper (ORM) that simplifies database interactions.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Endpoints](#endpoints)
- [Contribution](#contribution)

## Overview

This project showcases the implementation of CRUD operations using Dapper, a micro ORM, in a .NET Core application. The goal is to provide efficient and straightforward database interactions while maintaining the power of raw SQL.

## Features

- **Create:** Add new records to the database.
- **Read:** Retrieve data from the database using various query methods.
- **Update:** Modify existing records in the database.
- **Delete:** Remove records from the database.

## Technologies Used

- **C#:** The primary programming language for the project.
- **Dapper:** A simple object mapper for .NET and SQL databases.
- **SQL Server:** The database engine used for storing and retrieving data.

## Getting Started

To run this project locally:

1. Clone the repository: `gti clone https://github.com/AbdullrhmanElhelw/DapperCrudOperations`
2. Open the solution in your preferred IDE.
3. Configure the database connection in the app settings.
4. Run the application.

## Usage

Explore the different CRUD operations implemented in the code. Understand how Dapper simplifies database interactions without sacrificing performance. Modify and extend the project to suit your specific needs.

## Endpoints

### Product Endpoints

- **Get All Products:** `GET /Product`
- **Get Product by ID:** `GET /Product/{id}`
- **Create Product:** `POST /Product`
- **Update Product:** `PUT /Product/{id}`
- **Delete Product:** `DELETE /Product/{id}`
- **Find Products by Name:** `GET /Product/FindByName/{name}`
- **Get All Products Ordered by Price:** `GET /Product/GetAllOrderByPrice`
- **Create Multiple Products:** `POST /Product/CreateMultiProduct`

Refer to the code or Swagger documentation for detailed information on each endpoint.

## Contribution

Contributions are welcome! If you find any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.

