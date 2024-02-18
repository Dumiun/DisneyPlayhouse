CREATE TABLE [dbo].[4DInvoiceLevel2]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvoiceId] NVARCHAR(50) NOT NULL, 
    [Number] NVARCHAR(4) NOT NULL, 
    [NoOfVariations] INT NOT NULL,
    [Big] DECIMAL(10, 2) NOT NULL, 
    [Small] INT NOT NULL, 
    [Day] INT NULL, 
    [Roll] NVARCHAR(4) NULL, 
    [ActualBig] DECIMAL(10, 2) NOT NULL, 
    [ActualSmall] INT NOT NULL, 
    [TotalCostForEntry] DECIMAL(10, 2) NOT NULL, 
    [DrawDate1] DATETIME2 NOT NULL, 
    [DrawDate2] DATETIME2 NULL, 
    [DrawDate3] DATETIME2 NULL
)
