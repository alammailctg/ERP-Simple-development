SELECT TOP (1000) [Id]
      ,[DeliveryPlane]
      ,[SalesOrderNo]
      ,[Description]
      ,[CreatedDate]
      ,[OrderedDate]
      ,[SalesOrderStatusId]
      ,[CustomerId]
  FROM [AenDbEnterprise].[dbo].[SalesOrders]

   

UPDATE [AenDbEnterprise].[dbo].[OrderItems]
SET Quantity = FLOOR(13000 + (RAND(CHECKSUM(NEWID())) * (100000 - 13000 + 1)));

SELECT * FROM OrderItems
SELECT * FROM SalesOrders

UPDATE [AenDbEnterprise].[dbo].[OrderItems]
SET Amount=OrderItems.Price*Quantity

UPDATE [AenDbEnterprise].[dbo].[SalesOrders]
SET OrderedDate = DATEADD(DAY, 
    FLOOR(RAND(CHECKSUM(NEWID())) * DATEDIFF(DAY, '2010-01-01', '2024-12-31')), 
    '2010-01-01');

 
SELECT 
    MIN(OrderedDate) AS FirstOrderedDate,
    MAX(OrderedDate) AS LastOrderedDate
FROM 
    [AenDbEnterprise].[dbo].[SalesOrders];