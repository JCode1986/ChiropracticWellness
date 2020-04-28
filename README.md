# Project 401 E-Commerce Site

---
### We are deployed on Azure!

* Deployed site - https://ecommerceappjoesue.azurewebsites.net/

* Database server names
  * User database - userdbcontext.database.windows.net
  * Store database - productdb.database.windows.net


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
$ git clone https://401ECommerceSueJoe@dev.azure.com/401ECommerceSueJoe/401ECommerceSite/_git/401ECommerceSite
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
Unit testing is included in the XunitTestECommApp project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

---

## Pages
Deployed App - https://ecommerceappsuejoe.azurewebsites.net/
* **route/account/register** - Page where a user can register. Information inputted are then saved to a database.
* **route/account/login** - Page where a user can login if information given exists in the database.
* **route/store/store** - Page that shows all available services.
* **route/product/details/id** - Page that shows a specific service with details.
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

### User

| Parameter | Type | Required |
| --- | --- | --- |
| FirstName  | string | YES |
| LastName | string | YES |
| BirthDate | DateTime | YES |



### Inventory

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| ServiceType | enum | YES |
| Description | string | YES |
| Price | decimal | YES |
| Duration | string | YES |
| Image | string | YES |

---

## Change Log
* 1.8: *Leads the user to details page after clicking a specific product* - 25 April 2020
* 1.7: *Page for all products to show up; still need functionality to click a specific product to redirect to details page.* - 25 April 2020
* 1.6: *Page for specific product with details added, and able to retrieve data from database* - 24 April 2020
* 1.5: *Both databases (user & store) deployed and connected to Web App* - 22 April 2020
* 1.4: *Register and login operational; Saves to database* - 22 April 2020 
* 1.3: *Model, Service, and CRUD functionality for products added. Data seeded to database; tests added for getters/ setter, and CRUD.
* 1.2: *Added Razor pages with route to account/register* - 21 April 2020
* 1.1: *MVC Scaffolding* - 20 April 2020  

---

## Authors
* Joseph Hangarter
* Sue Tarazi

---

For more information on Markdown: https://www.markdownguide.org/cheat-sheet
