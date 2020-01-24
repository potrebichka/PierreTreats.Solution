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

* The application have user authentication. A user is be able to log in and log out. Only logged in users have create, update and delete functionality. All users have read functionality. Logged in users are able to upadte and delete only treats and flavors added by them.
* There is a many-to-many relationship between Treats and Flavors. A treat can have many flavors (such as sweet, savory, spicy, or creamy) and a flavor can have many treats. For instance, the "sweet" flavor could include chocolate croissants, cheesecake, and so on.
* A user is be able to navigate to a splash page that lists all treats and flavors. Users is be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

## Technologies Used

_C#, .NET, CSS, ASP.NET Core MVC, Entity Framework Core, HTML, Bootstrap_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*