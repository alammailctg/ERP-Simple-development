USE [AenDbEnterprise]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/29/2024 9:35:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[MobileNo] [nvarchar](max) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 10/29/2024 9:35:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsPartiallyApproved] [bit] NOT NULL,
	[IsFullyApproved] [bit] NOT NULL,
	[SalesOrderId] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[BalanceQuantity] [decimal](18, 2) NOT NULL,
	[InvoicedQuantity] [decimal](18, 2) NOT NULL,
	[ProductId] [int] NOT NULL,
	[NetAmount] [decimal](18, 2) NOT NULL,
	[DiscountPercent] [decimal](18, 2) NULL,
	[InvoicedAmount] [decimal](18, 2) NOT NULL,
	[StatusId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[OrderItemNo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/29/2024 9:35:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[UnitId] [int] NOT NULL,
	[DefaultVatPercent] [nvarchar](max) NULL,
	[PurchasePrice] [decimal](18, 0) NULL,
	[CostPrice] [decimal](18, 0) NULL,
	[WholesalePrice] [decimal](18, 0) NULL,
	[MRP] [decimal](18, 0) NULL,
	[TradePrice] [decimal](18, 0) NULL,
	[InventoryType] [nvarchar](max) NULL,
	[IsQuantityMeasureable] [bit] NULL,
	[FixedAsset] [bit] NULL,
	[IsPurchaseable] [bit] NULL,
	[IsSaleable] [bit] NULL,
	[IsConsumable] [bit] NULL,
	[RawMaterials] [bit] NULL,
	[IsInventoryRequired] [bit] NULL,
	[WarehouseId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrders]    Script Date: 10/29/2024 9:35:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryPlane] [nvarchar](max) NOT NULL,
	[SalesOrderNo] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[OrderedDate] [datetime2](7) NOT NULL,
	[SalesOrderStatusId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_SalesOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Products_ProductId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_SalesOrders_SalesOrderId] FOREIGN KEY([SalesOrderId])
REFERENCES [dbo].[SalesOrders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_SalesOrders_SalesOrderId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Status_StatusId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Unit_UnitId] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Unit_UnitId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Category_CategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Companies_CompanyId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Warehouses_WarehouseId] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Warehouses_WarehouseId]
GO
ALTER TABLE [dbo].[SalesOrders]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[SalesOrders] CHECK CONSTRAINT [FK_SalesOrders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[SalesOrders]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrders_SalesOrderStatuses_SalesOrderStatusId] FOREIGN KEY([SalesOrderStatusId])
REFERENCES [dbo].[SalesOrderStatuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesOrders] CHECK CONSTRAINT [FK_SalesOrders_SalesOrderStatuses_SalesOrderStatusId]
GO
/****** Object:  StoredProcedure [dbo].[spGetCustomerOrderDetails]    Script Date: 10/29/2024 9:35:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[spGetCustomerOrderDetails]
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
    Customers.Id =@CustomerId AND
    InvoiceItem.InvoiceQuantity > 0 AND 
    OrderItems.Quantity > 0
ORDER BY 
    SalesOrders.SalesOrderNo, 
    Invoices.InvoiceNo, 
    OrderItems.Id, 
    DeliveryOrders.DeliveryOrderNo, 
    DispatchOrders.DispatcheNo;

END;
GO
/****** Object:  StoredProcedure [dbo].[spGetDeliveryOrderById]    Script Date: 10/29/2024 9:35:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetDeliveryOrderById]
    @DeliveryOrderId INT
AS
BEGIN
SELECT  SalesOrders.SalesOrderNo, Customers.Name AS CustomerName, Products.Name AS ProductName, DeliveryOrders.DeliveryOrderNo, Invoices.InvoiceNo, Unit.Name AS UnitName, OrderItems.Price, 
                         DeliveryOrderItem.DeliveryQuantity, DeliveryOrderItem.BalanceAmount, DeliveryOrderItem.BalanceQuantity, DeliveryOrderItem.DeliveryAmount
FROM            DeliveryOrders 
				LEFT OUTER JOIN  DeliveryOrderItem ON DeliveryOrders.Id = DeliveryOrderItem.DeliveryOrderId 
				LEFT OUTER JOIN  Invoices ON DeliveryOrders.InvoiceId = Invoices.Id 
				LEFT OUTER JOIN  OrderItems ON DeliveryOrderItem.OrderItemId=OrderItems.Id
				LEFT OUTER JOIN  Unit ON OrderItems.UnitId = Unit.Id 
				LEFT OUTER JOIN  Products ON OrderItems.ProductId = Products.Id 
				LEFT OUTER JOIN  SalesOrders ON DeliveryOrders.SalesOrderId = SalesOrders.Id AND Invoices.SalesOrderId = SalesOrders.Id AND OrderItems.SalesOrderId = SalesOrders.Id LEFT OUTER JOIN
                         Customers ON SalesOrders.CustomerId = Customers.Id
 
 WHERE (DeliveryOrders.Id =@DeliveryOrderId)
END
 
/****** Object:  StoredProcedure [dbo].[spGetOrderItemsBySalesOrderId]    Script Date: 9/30/2024 4:35:34 PM ******/
SET ANSI_NULLS ON

SELECT * FROM OrderItems WHERE OrderItems.SalesOrderId=42
GO
/****** Object:  StoredProcedure [dbo].[spGetInvoiceBySalesOrderId]    Script Date: 10/29/2024 9:35:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetInvoiceBySalesOrderId]
    @InvoiceId INT
AS
BEGIN
SELECT        InvoiceItem.InvoiceQuantity, 
 CAST(InvoiceItem.InvoiceQuantity * OrderItems.Price AS DECIMAL(18, 2)) AS InvoiceAmount, 
Invoices.InvoiceNo, OrderItems.Price, SalesOrders.SalesOrderNo, Customers.Name AS CustomerName, 
                         Products.Name AS ProductName, SalesOrders.DeliveryPlane, SalesOrders.OrderedDate
FROM            Invoices INNER JOIN
                         InvoiceItem ON Invoices.Id = InvoiceItem.InvoiceId INNER JOIN
                         OrderItems ON InvoiceItem.OrderItemId = OrderItems.Id INNER JOIN
                         SalesOrders ON Invoices.SalesOrderId = SalesOrders.Id AND OrderItems.SalesOrderId = SalesOrders.Id INNER JOIN
                         Customers ON SalesOrders.CustomerId = Customers.Id INNER JOIN
                         Products ON OrderItems.ProductId = Products.Id INNER JOIN
                         Unit ON OrderItems.UnitId = Unit.Id
WHERE (Invoices.Id = @InvoiceId) AND InvoiceItem.InvoiceQuantity>0
END

 
/****** Object:  StoredProcedure [dbo].[spGetDeliveryOrderById]    Script Date: 9/30/2024 4:35:37 PM ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[spGetOrderItemsBySalesOrderId]    Script Date: 10/29/2024 9:35:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spGetOrderItemsBySalesOrderId]
	  @SalesOrderId INT
AS
BEGIN
SELECT SalesOrders.Id, SalesOrders.SalesOrderNo, SalesOrders.OrderedDate, Customers.Name AS CustomerName, OrderItems.Id AS ItemId, OrderItems.Price, OrderItems.Quantity, Products.Name AS ProductName, Unit.Name, OrderItems.NetAmount, OrderItems.DiscountPercent
FROM   SalesOrders INNER JOIN
             OrderItems ON SalesOrders.Id = OrderItems.SalesOrderId INNER JOIN
             Products ON OrderItems.ProductId = Products.Id INNER JOIN
             Customers ON SalesOrders.CustomerId = Customers.Id INNER JOIN
             Unit ON OrderItems.UnitId = Unit.Id WHERE dbo.SalesOrders.Id=@SalesOrderId;
END
GO
