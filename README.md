# Merchandising Management System
A merchandising management application using .Net Core, Entity Framework Core and xUnit. This application helps create a stock management system and enables basic CRUD operations. Products with different stocks and categories might be added to the system. 

# Technologies and Architecture
The project is written in **C#** with **.Net Core.**
The database is managed with **Entity Framework Core**
The unit tests are written with **xUnit**
The applications follows **Domain-Driven Design** with **Specification Design Pattern**
For read/write the application makes use of a basic **CQRS** pattern
The application follows **SOLID** principles and
The project makes use of several third party libraries such as:

 - **Automapper** is used to map entites and viewmodels
 - **MediatR** is used for **Mediator Design Patter**
 
# WebApi
The web api accepts **commands** and **queries** for CRUD operations. Commands are used for database write actions and queries are used for querying and reading the database. Specifications are used to manage business logic and use them for different commands and queries in order to prevent duplication.
