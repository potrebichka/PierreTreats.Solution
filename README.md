# _Pierre's Sweet and Savory Treats_

#### _Version 01/24/2020_

#### By _**Nina Potrebich**_

## Description

_A new application to market Pierre's sweet and savory treats._

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* .NET
* MySqlServer

### Installing

1. Clone this repository:
```
$ git clone url-of-this-repo
```
2. Start MySql server by using command:
```
mysql start
```
3. Access MySql by executing the command:
```
mysql -uroot -pepicodus
```
4. Update database using command
```
dotnet ef database update
```
5. Using console of your choice build and run program in Project directory:
```
dotnet run
```

## Specifications:

**** The application should have user authentication. A user should be able to log in and log out. Only logged in users should have create, update and delete functionality. All users should be able to have read functionality.
**** There should be a many-to-many relationship between Treats and Flavors. A treat can have many flavors (such as sweet, savory, spicy, or creamy) and a flavor can have many treats. For instance, the "sweet" flavor could include chocolate croissants, cheesecake, and so on.
**** A user should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.
**** Does at least one of your classes have all CRUD methods implemented in your app?
**** Are you able to view both sides of the many-many relationship? For a particular instance of a class, are you able to view all of the instances of the other class that are related to it?
**** Are users able to register, log in and log out with Identity?
**** Is Create, Update and Delete functionality limited to authenticated users?
**** Is the project in a polished, portfolio-quality state?
**** Was required functionality in place by the 5:00pm Friday deadline?
**** Does the project demonstrate all of this week's concepts? If prompted, are you able to discuss your code with an instructor using correct terminology?
**** Have separate roles for admins and logged-in users. Only admins should be able to add, update and delete.
**** Add an order form that only logged-in users can access. A logged-in user should be able to create, read, update and delete their own order.



## Technologies Used

_C#, .NET, CSS, ASP.NET Core MVC, Entity Framework Core, HTML, Bootstrap_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*