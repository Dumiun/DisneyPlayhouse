CREATE TABLE [dbo].[4DInvoiceLevel1_5]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvoiceId] NVARCHAR(MAX) NOT NULL, 
    [PageName] NVARCHAR(50) NULL, 
    [DrawDate] DATETIME2 NOT NULL,
    [TotalBig] DECIMAL(10, 2) NOT NULL, 
    [TotalSmall] INT NOT NULL, 
    [CommsPercentage] DECIMAL(10, 2) NOT NULL,
    [TotalAmount] DECIMAL(13, 3) NOT NULL, 
    [StrikeAmount] DECIMAL(13, 3) NOT NULL, 
    [PurchasedById] NVARCHAR(20) NOT NULL, 
    [PurchasedForId] NVARCHAR(20) NOT NULL, 
    [PurchasedDate] DATETIME2 NOT NULL, 
    [LastUpdatedOn] DATETIME2 NOT NULL
)
