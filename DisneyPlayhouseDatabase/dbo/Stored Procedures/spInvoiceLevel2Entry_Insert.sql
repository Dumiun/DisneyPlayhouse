CREATE PROCEDURE [dbo].[spInvoiceLevel2Entry_Insert]
    @InvoiceId NVARCHAR(50), 
    @Number NVARCHAR(4), 
    @NoOfVariations INT,
    @Big DECIMAL(10, 2), 
    @Small INT, 
    @Day INT, 
    @Roll NVARCHAR(4), 
    @ActualBig DECIMAL(10, 2), 
    @ActualSmall INT, 
    @TotalCostForEntry DECIMAL(10, 2), 
    @DrawDate1 DATETIME2, 
    @DrawDate2 DATETIME2, 
    @DrawDate3 DATETIME2
    AS
    BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[4DInvoiceLevel2] (InvoiceId, Number, NoOfVariations, Big, Small, Day, Roll, ActualBig, ActualSmall, TotalCostForEntry, DrawDate1, DrawDate2, DrawDate3)
    VALUES (@InvoiceId, @Number, @NoOfVariations, @Big, @Small, @Day, @Roll, @ActualBig, @ActualSmall, @TotalCostForEntry, @DrawDate1, @DrawDate2, @DrawDate3)
	END