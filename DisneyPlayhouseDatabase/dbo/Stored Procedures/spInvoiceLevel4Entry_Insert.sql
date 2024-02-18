CREATE PROCEDURE [dbo].[spInvoiceLevel4Entry_Insert]
    @InvoiceId NVARCHAR(50), 
    @NumberVariation NVARCHAR(4), 
    @PurchasedNumber NVARCHAR(4), 
    @PurchasedRoll NVARCHAR(4), 
    @Big DECIMAL(10, 2), 
    @Small INT, 
    @StrikeAmount DECIMAL(13, 3), 
    @DrawDate DATETIME2
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[4DInvoiceLevel4] (InvoiceId, NumberVariation, PurchasedNumber, PurchasedRoll, Big, Small, StrikeAmount, DrawDate)
    VALUES (@InvoiceId, @NumberVariation, @PurchasedNumber, @PurchasedRoll, @Big, @Small, @StrikeAmount, @DrawDate)
END