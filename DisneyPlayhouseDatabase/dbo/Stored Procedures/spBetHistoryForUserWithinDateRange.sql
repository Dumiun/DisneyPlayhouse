CREATE PROCEDURE [dbo].[spBetHistoryForUserWithinDateRange]
@PurchasedForId NVARCHAR(20),
@FromDate DATETIME2,
@ToDate DATETIME2

AS
BEGIN
SELECT * FROM dbo.[4DInvoiceLevel1]
WHERE PurchasedForId = @PurchasedForId
    AND PurchasedDate >= DATEADD(DAY, DATEDIFF(DAY, 0, @FromDate), 0) -- Start of day for FromDate
    AND PurchasedDate <= DATEADD(DAY, DATEDIFF(DAY, 0, @ToDate) + 1, 0) - 1 -- End of day for ToDate
END