# Project 401 E-Commerce Site

---
### We are deployed on Azure!

[https://ecommerceappsuejoe.azurewebsites.net/]

---
## Web Application

The web application consists of a frontend written in Razor views, HTML, CSS,
Bootstrap. The backend was written in C# using ASP.NET Core 2, Entity Framework Core, and the MVC framework.

---

## Tools Used
Microsoft Visual Studio Community 2017 (Version 15.5.7)

- C#
- ASP.Net Core
- Entity Framework
- MVC
- Bootstrap
- Razor Pages
- Azure
- Azure DevOps

---

## Getting Started

Clone this repository to your local machine.

```
$ git clone https://401EComm@dev.azure.com/401EComm/401ECommSite/_git/401ECommSite
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the 401ECommSite subdirectory at the root of the repository.
```
cd YourRepo/YourProject
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in the /401ECommSite/401ECommSite/appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd YourRepo/YourProject
dotnet run
```
Unit testing is included in the 401ECommSite/FrontendTesting project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

---

## Usage
***[Provide some images of your app with brief description as title]***

### Overview of Recent Posts
![Overview of Recent Posts]()

### Creating a Post
![Post Creation]()

### Enriching a Post
![Enriching Post]()

### Viewing Post Details
![Details of Post]()

---
## Data Flow (Frontend, Backend, REST API)
***[Add a clean and clear explanation of what the data flow is. Walk me through it.]***
![Data Flow Diagram]()

---
## Data Model

### Overall Project Schema
***[Add a description of your DB schema. Explain the relationships to me.]***
![Database Schema]()

---
## Model Properties and Requirements

### Blog

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Test | string | YES |



### User

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Name/Author | string | YES |
| Posts | list | YES |

---

## Change Log
***[The change log will list any changes made to the code base. This includes any changes from TA/Instructor feedback]***    
* 1.1: *MVC Scaffolding* - 20 April 2020  

---

## Authors
* Joseph Hangarter
* Sue Tarazi

---

For more information on Markdown: https://www.markdownguide.org/cheat-sheet
