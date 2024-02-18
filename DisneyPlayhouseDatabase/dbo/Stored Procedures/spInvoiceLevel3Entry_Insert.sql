CREATE PROCEDURE [dbo].[spInvoiceLevel3Entry_Insert]
    @InvoiceId NVARCHAR(50), 
    @Number NVARCHAR(4), 
    @Big decimal(10,2), 
    @Small INT, 
    @Roll NVARCHAR(4), 
    @DrawDate DATETIME2
        AS
    BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[4DInvoiceLevel3] (InvoiceId, Number, Big, Small, Roll, DrawDate)
    VALUES (@InvoiceId, @Number, @Big, @Small, @Roll, @DrawDate)
END