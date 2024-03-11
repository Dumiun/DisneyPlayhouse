CREATE PROCEDURE [dbo].[spGetPageRecordsForUserOnDrawDate]
@PurchasedForId NVARCHAR(20),
@DrawDate DATETIME2

AS
BEGIN
	SELECT [InvoiceId], [PageName], [DrawDate], [TotalBig], [TotalSmall],[CommsPercentage] [TotalAmount], [StrikeAmount], [PurchasedById], [PurchasedForId], [PurchasedDate], [LastUpdatedOn] FROM [dbo].[4DInvoiceLevel1point5] WHERE [PurchasedForId] = @PurchasedForId
	AND CAST([DrawDate] AS DATE) = CAST(@DrawDate AS DATE)
END