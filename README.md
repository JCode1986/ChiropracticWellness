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
- Azure Blob Storage
- Sendgrid
- Auth.Net

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
#### Deployed App - https://ecommerceappsuejoe.azurewebsites.net/
* **route/index** - Home page where the user can learn about the business and mobile services being offered. Also bios of the staff are available.
* **route/account/register** - Page where a user can register. Information inputted are then saved to a database.
* **route/account/login** - Page where a user can login if information given exists in the database.
* **route/account/accessdenied** - Page where unauthorized user are directed to.
* **route/account/checkout** - Page where a user can review the items they wish to purchase.
* **route/account/receipt** - Page where users are redirected after checking out with services in cart.
* **route/store/shop** - Page that shows all available services.
* **route/store/cart** - Page that shows all items the user has added to cart.
* **route/product/details/id** - Page that shows a specific service with details.
* **route/product/delete/id** - Page to delete a specific item from user's cart.
* **route/admin/dashboard** - Page where administrators have access to, and have the option to manage services, or check existing orders.
* **route/admin/order** - Page where administrators can check all existing orders
* **route/admin/orderdetails** - Page where administrators can order details after picking a specific order

#### Admin Routes
  * **route/admin/dashboard** - Page where an Administrator can pick to manage orders or services.
  * **route/admin/manageservices** - Page where Administrator can create, update, or delete a service.
 
## Usage
***[Provide some images of your app with brief description as title]***

### Home Page
![Home Page](https://i.imgur.com/yVrFZgg.png)

### Register Page
![Register Page](https://i.imgur.com/j8f6L0R.png)

### Store Page
![Store Page](https://i.imgur.com/oTuKwdz.jpg)

### Cart Page
![Cart Page](https://i.imgur.com/XL8qGvR.png)

### Admin Page
![Admin Page](https://i.imgur.com/H5S603x.png)

### Edit Service in Admin Portal
![Admin Edit Page](https://i.imgur.com/zSPIwMm.png)

---
## Data Model
ERD from CodeFellows 401 .NET Class Repo:
![ERD](https://i.imgur.com/RhRWayc.png)

---
## Model Properties and Requirements

### User

| Parameter | Type | Required |
| --- | --- | --- |
| FirstName  | string | YES |
| LastName | string | YES |
| BirthDate | DateTime | YES |
| PhoneNumber | string | YES |

### Inventory

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| ServiceType | enum | YES |
| Description | string | YES |
| Price | decimal | YES |
| Duration | string | YES |
| Image | string | YES |

### CartItems

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| CartID | int | YES |
| Quantity | int | YES |
| Inventory | Inventory object | YES |

### Cart

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| UserID | string | YES |
| CartItems | List< CartItems > | YES |

### ReceiptOrder

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| FirstName | string | YES |
| LastName | string | YES |
| Address | string | YES |
| City | string | YES |
| State | string | YES |
| Amount | string | YES |
| Date | string | YES |
| CartItemQuantity | string | YES |
| ServiceList | string | YES |
| ServicePriceList | string | YES |

---

### Claims Being Captured
| Parameter | Type | Required |
| --- | --- | --- |
| FirstName  | string | YES |
| LastName | string | YES |
| BirthDate | DateTime | YES |
| Email | string | YES |

## Change Log
* **SPRINT 3 COMPLETE**
* 1.20: *Admin can pick a specific user in order page, and it redirects to order detail page with receipt info* - 09 May 2020
* 1.19: *Added order page for admins from specific user* - 08 May 2020
* 1.18: *When an admin logs in, it redirects them to the admin page* - 07 May 2020
* 1.17: *Admin able to create and update images with Azure blob storage* - 06 May 2020
* 1.16: *User's input with total amount now passes properly to Auth.Net* - 06 May 2020
* 1.15: *Hard coded transaction working with Auth.Net* - 05 May 2020
* **SPRINT 2 COMPLETE**
* 1.14: *Email is sent after user checks out from receipt page.* - 03 May 2020
* 1.13: *Receipt page added, and some styling on details page & receipt page* - 30 April 2020
* 1.12: *Created razor pages for Administrator roles, and CRUD functionality* - 28 April 2020
* 1.11: *User can now update quantity of items, or delete an item from their cart* - 27 April 2020
* 1.10: *Email sends out to user after registering a new account* - 26 April 2020
* 1.10: *Email sends out to user after registering a new account* - 26 April 2020
* 1.9: *Cart razor page created, and renders items that were added to cart for a specific user* - 26 April 2020
* 1.8: *Leads the user to details page after clicking a specific product* - 25 April 2020
* **SPRINT 1 COMPLETE**
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
