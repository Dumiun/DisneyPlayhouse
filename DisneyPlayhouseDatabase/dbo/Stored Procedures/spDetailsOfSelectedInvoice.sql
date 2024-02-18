CREATE PROCEDURE [dbo].[spDetailsOfSelectedInvoice]
@InvoiceId NVARCHAR(MAX)

AS
BEGIN
SELECT * FROM dbo.[4DInvoiceLevel2]
WHERE InvoiceId = @InvoiceId
END