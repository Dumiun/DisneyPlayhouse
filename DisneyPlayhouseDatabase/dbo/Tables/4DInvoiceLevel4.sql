CREATE TABLE [dbo].[4DInvoiceLevel4]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvoiceId] NVARCHAR(50) NOT NULL, 
    [NumberVariation] NVARCHAR(4) NOT NULL, 
    [PurchasedNumber] NVARCHAR(4) NOT NULL, 
    [PurchasedRoll] NVARCHAR(4) NULL, 
    [Big] DECIMAL(10, 2) NULL, 
    [Small] INT NULL, 
    [StrikeAmount] DECIMAL(13, 3) NULL, 
    [DrawDate] DATETIME2 NOT NULL
)
