# Solution

The solution is composed of a Rest API and a Web App.

The API uses .Net 6 and contains only one Controller with the CRUD for the Car entity. I used Entity Framework with SqLite and Code First approach to create the database through Migrations. 

The Web App uses Razor Pages to create the Single Page showing the car data and giving the user the option to guess the price of the cars.

The Web App consumes the API to access the car data.

## The answer to the SQL question follows below.

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

