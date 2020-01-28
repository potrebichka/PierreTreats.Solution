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
* A authenticated user is able to add treats to order. User is able to edit order, remote and treats in it. User is able to submit order.

## Screenshots

Home page. Without auth.
![Home page. Without auth.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-41-13.png)

Register new user.
![Register new user.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-41-35.png)

Log in.
![Log in.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-42-07.png)

Treats page. With auth.
![Treats page.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-42-44.png)

Treat details page. Treat added by current user. 
![Treat details page.Treat added by current user.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-45-51.png)

Edit treat page. Auth only.
![Edit treat page.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-46-09.png)

Delete treat page. Auth only.
![Delete treat page.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-46-28.png)

Add flavor to treat. Auth only.
![Add flavor to treat.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-46-52.png)

Treat details page. Treat was added by another user.
![Treat details page. Treat was added by another user.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-47-37.png)

Flavors page. With auth.
![Flavors page.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-48-55.png)

Add a new flavor. Auth only.
![Add a new flavor. Auth only.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-49-11.png)

Flavor details page. Flavor was added by another user.
![Flavor details page. Flavor was added by another user.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-49-38.png)

Flavor details page. Flavor was added by current user.
![Flavor details page. Flavor was added by current user.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-49-54.png)

Edit flavor page.
![Edit flavor page.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-50-08.png)

Delete flavor page.
![Delete flavor page.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-50-22.png)

Add a new treat.
![Add a new treat.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-50-45.png)

Orders page. Auth only.
![Orders page. Auth only.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-51-37.png)

Edit order. Auth only.
![Edit order. Auth only.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-52-08.png)

Add treat to order. Auth only.
![Add treat to order. Auth only.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-52-33.png)

Order details page. Auth only.
![Order details page. Auth only.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-53-04.png)

Submit order page. Auth only
![Submit order page. Auth only](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-53-46.png)

Delete order page. Auth only.
![Delete order page. Auth only.](https://github.com/potrebichka/PierreTreats.Solution/blob/master/PierreSweets/wwwroot/img/2020-01-27_22-54-09.png)

## Technologies Used

_C#, .NET, CSS, ASP.NET Core MVC, Entity Framework Core, HTML, Bootstrap_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*