CREATE TABLE [dbo].[4DInvoiceLevel3]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvoiceId] NVARCHAR(50) NOT NULL, 
    [Number] NVARCHAR(4) NOT NULL, 
    [Big] decimal(10,2)  NOT NULL, 
    [Small] INT NOT NULL, 
    [Roll] NVARCHAR(4) NULL, 
    [DrawDate] DATETIME2 NOT NULL
)
