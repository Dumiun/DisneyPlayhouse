CREATE PROCEDURE [dbo].[spMemberTicketComms_Insert]
    @MemberId NVARCHAR(20), 
    @CommsPercentage DECIMAL(4, 2), 
    @LastUpdatedOn DATETIME2
AS
BEGIN
SET NOCOUNT ON;

INSERT into dbo.CommissionSettings (MemberId, CommsPercentage, LastUpdatedOn)
VALUES (@MemberId, @CommsPercentage, @LastUpdatedOn)
END