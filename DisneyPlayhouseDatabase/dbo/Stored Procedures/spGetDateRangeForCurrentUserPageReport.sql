CREATE PROCEDURE [dbo].[spGetDateRangeForCurrentUserPageReport]
    @PurchasedForId NVARCHAR(20),
    @FromDate DATETIME2,
    @ToDate DATETIME2
AS
BEGIN
    SELECT DISTINCT CAST(DrawDate AS DATE) AS DrawDate
    FROM dbo.[4DInvoiceLevel1point5]
    WHERE PurchasedForId = @PurchasedForId
        AND DrawDate >= DATEADD(DAY, DATEDIFF(DAY, 0, @FromDate), 0) -- Start of day for FromDate
        AND DrawDate <= DATEADD(DAY, DATEDIFF(DAY, 0, @ToDate) + 1, 0) - 1 -- End of day for ToDate
END