USE [AenDbEnterprise]
GO
/****** Object:  StoredProcedure [dbo].[spGetCustomerOrderDetails]    Script Date: 10/20/2024 12:45:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  ALTER PROCEDURE [dbo].[spGetCustomerOrderDetails]
    @CustomerId INT
AS
BEGIN SELECT 
    -- Sales Order details
    SalesOrders.SalesOrderNo, 
    SalesOrders.OrderedDate, 
    Customers.Name AS CustomerName,

    -- Order Item details
    OrderItems.Id AS OrderItemId, 
    Products.Name AS ProductName, 
    OrderItems.Quantity AS OrderItemQuantity, 
    OrderItems.Price AS OrderItemPrice, 
    OrderItems.NetAmount AS OrderItemNetAmount,

    -- Invoice details
    Invoices.InvoiceNo, 
    InvoiceItem.InvoiceQuantity, 
    CAST(InvoiceItem.InvoiceQuantity * OrderItems.Price AS DECIMAL(18, 2)) AS InvoiceAmount,

    -- Delivery Order details
    DeliveryOrders.DeliveryOrderNo, 
    DeliveryOrders.CreatedDate AS DeliveryOrderDate, 
    DeliveryOrderItem.DeliveryQuantity, 
    DeliveryOrderItem.DeliveryAmount,

    -- Dispatch Order details
    DispatchOrders.DispatcheNo, 
    DispatchOrders.CreatedDate AS DispatchDate, 
    DispatchItems.VehicalLoadWeight, 
    DispatchItems.DispatchQuantity
FROM 
    SalesOrders 
    LEFT JOIN Customers ON SalesOrders.CustomerId = Customers.Id
    LEFT JOIN OrderItems ON SalesOrders.Id = OrderItems.SalesOrderId
    LEFT JOIN Products ON OrderItems.ProductId = Products.Id
    LEFT JOIN Invoices ON SalesOrders.Id = Invoices.SalesOrderId
    LEFT JOIN InvoiceItem ON Invoices.Id = InvoiceItem.InvoiceId AND OrderItems.Id = InvoiceItem.OrderItemId
    LEFT JOIN DeliveryOrders ON Invoices.Id = DeliveryOrders.InvoiceId AND SalesOrders.Id = DeliveryOrders.SalesOrderId
    LEFT JOIN DeliveryOrderItem ON DeliveryOrders.Id = DeliveryOrderItem.DeliveryOrderId AND OrderItems.Id = DeliveryOrderItem.OrderItemId
    LEFT JOIN DispatchOrders ON Invoices.Id = DispatchOrders.InvoiceId AND SalesOrders.Id = DispatchOrders.SalesOrderId AND DeliveryOrders.Id = DispatchOrders.DeliveryOrderId
    LEFT JOIN DispatchItems ON DispatchOrders.Id = DispatchItems.DispatchOrderId AND OrderItems.Id = DispatchItems.OrderItemId
WHERE 
    Customers.Id =1 AND
    InvoiceItem.InvoiceQuantity > 0 AND 
    OrderItems.Quantity > 0
ORDER BY 
    SalesOrders.SalesOrderNo, 
    Invoices.InvoiceNo, 
    OrderItems.Id, 
    DeliveryOrders.DeliveryOrderNo, 
    DispatchOrders.DispatcheNo;

END;

SELECT 
    YEAR(SalesOrders.OrderedDate) AS SalesYear, 
    MONTH(SalesOrders.OrderedDate) AS SalesMonth, 
    CONCAT(YEAR(SalesOrders.OrderedDate), '-', MONTH(SalesOrders.OrderedDate)) AS YearMonth, 
    SUM(CAST(OrderItems.Quantity * OrderItems.Price AS DECIMAL(18, 2))) AS TotalSalesRevenue

FROM 
    SalesOrders 
    LEFT JOIN OrderItems ON SalesOrders.Id = OrderItems.SalesOrderId
    LEFT JOIN Invoices ON SalesOrders.Id = Invoices.SalesOrderId

WHERE 
    SalesOrders.OrderedDate >= DATEADD(YEAR, -2, GETDATE())  -- Last 2 years
    AND OrderItems.Quantity > 0 

GROUP BY 
    YEAR(SalesOrders.OrderedDate), 
    MONTH(SalesOrders.OrderedDate)

ORDER BY 
    YEAR(SalesOrders.OrderedDate), 
    MONTH(SalesOrders.OrderedDate);
