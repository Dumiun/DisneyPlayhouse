CREATE PROCEDURE [dbo].[spGetNumberVariationForSelectedNumberInInvoice]
@InvoiceId NVARCHAR(MAX),
@PurchasedNumber NVARCHAR(5)

AS
BEGIN
SELECT * FROM dbo.[4DInvoiceLevel4]
WHERE InvoiceId = @InvoiceId AND PurchasedNumber = @PurchasedNumber
END