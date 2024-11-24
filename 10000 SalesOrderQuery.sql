-- Insert 10,000 Sales Orders
USE [AenDbEnterprise]
GO

DECLARE @i INT = 1;
DECLARE @DeliveryPlane NVARCHAR(MAX) = 'Plane A';
DECLARE @SalesOrderNo NVARCHAR(MAX);
DECLARE @Description NVARCHAR(MAX) = 'Sample Sales Order';
DECLARE @CreatedDate DATETIME2(7) = GETDATE();
DECLARE @OrderedDate DATETIME2(7) = GETDATE();
DECLARE @SalesOrderStatusId INT = 1; -- Assuming 1 is a valid status
DECLARE @CustomerId INT = 1; -- Assuming 1 is a valid customer ID

WHILE @i <= 10000
BEGIN
    SET @SalesOrderNo = 'SO-' + CAST(@i AS NVARCHAR);
    
    INSERT INTO [dbo].[SalesOrders] 
           ([DeliveryPlane], [SalesOrderNo], [Description], [CreatedDate], [OrderedDate], [SalesOrderStatusId], [CustomerId])
    VALUES
           (@DeliveryPlane, @SalesOrderNo, @Description, @CreatedDate, @OrderedDate, @SalesOrderStatusId, @CustomerId);
    
    SET @i = @i + 1;
END
GO

-- Insert 20,000 Order Items
USE [AenDbEnterprise]
GO

DECLARE @OrderItemID INT = 1;
DECLARE @i INT = 1;  -- Declare @i for Order Items insertion
DECLARE @IsPartiallyApproved BIT = 0;
DECLARE @IsFullyApproved BIT = 0;
DECLARE @SalesOrderId INT;
DECLARE @UnitId INT = 1; -- Assuming 1 is a valid unit ID
DECLARE @Price DECIMAL(18, 2) = 100.00; -- Example price
DECLARE @Quantity DECIMAL(18, 2) = 1.00; -- Example quantity
DECLARE @Amount DECIMAL(18, 2);
DECLARE @BalanceQuantity DECIMAL(18, 2);
DECLARE @InvoicedQuantity DECIMAL(18, 2) = 0;
DECLARE @ProductId INT;
DECLARE @NetAmount DECIMAL(18, 2);
DECLARE @DiscountPercent DECIMAL(18, 2) = 0;
DECLARE @InvoicedAmount DECIMAL(18, 2);
DECLARE @StatusId INT = 1; -- Assuming 1 is a valid status
DECLARE @IsActive BIT = 1;
DECLARE @OrderItemNo NVARCHAR(MAX);
DECLARE @ProductList NVARCHAR(MAX) = 'Shop angle Garder,SS Wire,Gateball Butterfly,Bate Ball+Butter fly,Gate bulb and Butterfly,Cold Store,SS Coil Pipe,SS Coil Nojel Pipe,SS Pipe,Varieties Scrap,Joint Scrap,MS Net,Kitchen Room,Hidrolik Pump (Alumonium Body),Bit Garder,Relling,Roller,Roller Garda,Star pump,Mach Iron,Aluminium Stair,Brass Cornecer Radioter,Cast Iron,Navi Item,Furniture,General Store,MS Konakata,MS Plance,Shop angle Garder,SS Wire,Socket,5.8 Shop plate,Shop bit garder,Cable,Shopping bit. Garder,3.8 Plate Shop,Blour,1.2 Shop Plate,Ang+bit Gard,Electronics Item,Motor,CanonPCD 320 ofset paper,Gateball Butterfly';

-- Split the product list into a temporary table
DECLARE @ProductTable TABLE (Product NVARCHAR(MAX));
INSERT INTO @ProductTable (Product)
SELECT value FROM STRING_SPLIT(@ProductList, ',');

-- Insert Order Items
SET @i = 1; -- Reset @i for order items loop

WHILE @i <= 20000
BEGIN
    -- Randomly get a SalesOrderId between 1 and 10000
    SET @SalesOrderId = FLOOR(RAND() * 10000) + 1;

    -- Randomly select a product
    SELECT TOP 1 @ProductId = ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) 
    FROM @ProductTable ORDER BY NEWID();

    SET @OrderItemNo = 'OI-' + CAST(@OrderItemID AS NVARCHAR);
    
    SET @Amount = @Price * @Quantity;
    SET @BalanceQuantity = @Quantity;
    SET @NetAmount = @Amount - (@Amount * @DiscountPercent / 100);
    SET @InvoicedAmount = 0;

    INSERT INTO [dbo].[OrderItems] 
           ([IsPartiallyApproved], [IsFullyApproved], [SalesOrderId], [UnitId], [Price], [Quantity], [Amount], 
            [BalanceQuantity], [InvoicedQuantity], [ProductId], [NetAmount], [DiscountPercent], [InvoicedAmount], 
            [StatusId], [IsActive], [OrderItemNo])
    VALUES
           (@IsPartiallyApproved, @IsFullyApproved, @SalesOrderId, @UnitId, @Price, @Quantity, @Amount, 
            @BalanceQuantity, @InvoicedQuantity, @ProductId, @NetAmount, @DiscountPercent, @InvoicedAmount, 
            @StatusId, @IsActive, @OrderItemNo);
    
    SET @OrderItemID = @OrderItemID + 1;
    SET @i = @i + 1;
END
GO
