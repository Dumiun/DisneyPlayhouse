CREATE PROCEDURE [dbo].[spGetCurrentUserLevel1Invoices]
@PurchasedForId NVARCHAR(20),
@FromDate DATETIME2,
@ToDate DATETIME2
AS
BEGIN
SELECT * FROM dbo.[4DInvoiceLevel1]
WHERE PurchasedForId = @PurchasedForId
And PurchasedDate >= @FromDate
And PurchasedDate <= @ToDate
END