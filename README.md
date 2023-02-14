# Taller Code Challenge
## Coding Assessment

### C#/Razor
You have a model that is a car. You want to define its make, model, year, doors, colors, price. Build a simple service that contains some basic CRUD operations against a list of cars:

```
private List<Car> cars = new (){
        new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
        new Car { Id = 2, Make = “Tesla", Model = “3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
        new Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
        new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
        new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
    };
```    
Build a simple page markup with where you display the car information and allow the user to guess the price. If within 5,000 of the guess, display a great job message in green. 


### SQL
You have three different tables
A Customer Table with FirstName, LastName, Age, Occupation, MartialStatus, PersonID

An Orders Table with OrderID, PersonID, DateCreated, MethodofPurchase

An Orders Details table with OrderID, OrderDetailID, ProductNumber, ProductID, ProductOrigin



Please return a result of the customers who ordered product ID = 1112222333 and return
FirstName and LastName as full name, age, orderid, datecreated, MethodOfPurchase as Purchase Method, ProductNumber and ProductOrigin

### Solution

The solution is composed of a Rest API and a Web App.

The API uses .Net 6 and contains only one Controller with the CRUD for the Car entity. I used Entity Framework with SqLite and Code First approach to create the database through Migrations. 

The Web App uses Razor Pages to create the Single Page showing the car data and giving the user the option to guess the price of the cars.

The Web App consumes the API to access the car data.

#### The answer to the SQL question follows below.

```
SELECT 		CONCAT(Cust.FirstName,' ',Cust.LastName) as 'full name'
, 		Cust.age
, 		Order.orderid
, 		Order.datecreated
, 		Order.MethodOfPurchase as 'Purchase Method'
, 		ODet.ProductNumber 
,		ODet.ProductOrigin
FROM 		Customer Cust
INNER JOIN 	Order
ON 		Cust.PersonID  = Order.PersonID
INNER JOIN	OrderDetail	     ODet
ON 		ODet.OrderID   = Order.OrderID
WHERE		ODet.ProductID = 1112222333
```

