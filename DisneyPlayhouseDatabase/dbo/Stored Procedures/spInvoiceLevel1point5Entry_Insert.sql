CREATE PROCEDURE [dbo].[spInvoiceLevel1point5Entry_Insert]
    @InvoiceId NVARCHAR(MAX), 
    @PageName NVARCHAR(50), 
    @DrawDate DATETIME2,
    @TotalBig DECIMAL(10, 2), 
    @TotalSmall INT, 
    @CommsPercentage DECIMAL(10, 2),
    @TotalAmount DECIMAL(13, 3), 
    @StrikeAmount DECIMAL(13, 3), 
    @PurchasedById NVARCHAR(20), 
    @PurchasedForId NVARCHAR(20), 
    @PurchasedDate DATETIME2, 
    @LastUpdatedOn DATETIME2
AS
BEGIN
SET NOCOUNT ON;

INSERT into [dbo].[4DInvoiceLevel1point5] (InvoiceId, PageName, DrawDate, TotalBig, TotalSmall, CommsPercentage, TotalAmount, StrikeAmount, PurchasedById, PurchasedForId, PurchasedDate, LastUpdatedOn)
VALUES (@InvoiceId, @PageName, @DrawDate, @TotalBig, @TotalSmall, @CommsPercentage, @TotalAmount, @StrikeAmount, @PurchasedById, @PurchasedForId, @PurchasedDate, @LastUpdatedOn)
END