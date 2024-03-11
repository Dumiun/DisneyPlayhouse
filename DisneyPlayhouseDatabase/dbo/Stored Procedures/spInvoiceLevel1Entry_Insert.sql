CREATE PROCEDURE [dbo].[spInvoiceLevel1Entry_Insert]
    @InvoiceId NVARCHAR(MAX), 
    @PageName NVARCHAR(50), 
    @TotalBig DECIMAL(10, 2), 
    @TotalSmall INT, 
    @CommsPercentage DECIMAL(10, 2),
    @TotalAmount DECIMAL(13, 3), 
    @StrikeAmount DECIMAL(13, 3), 
    @PurchasedById NVARCHAR(20), 
    @PurchasedForId NVARCHAR(20), 
    @MediaType NVARCHAR(20), 
    @PurchasedDate DATETIME2, 
    @LastUpdatedOn DATETIME2
AS
BEGIN
SET NOCOUNT ON;

INSERT into [dbo].[4DInvoiceLevel1] (InvoiceId, PageName, TotalBig, TotalSmall, CommsPercentage, TotalAmount, StrikeAmount, PurchasedById, PurchasedForId, MediaType, PurchasedDate, LastUpdatedOn)
VALUES (@InvoiceId, @PageName, @TotalBig, @TotalSmall, @CommsPercentage, @TotalAmount, @StrikeAmount, @PurchasedById, @PurchasedForId, @MediaType, @PurchasedDate, @LastUpdatedOn)
END