CREATE PROCEDURE [dbo].[spMemberTicketComms_Update]
@MemberId NVARCHAR(20),
@CommsPercentage DECIMAL(4, 2),
@LastUpdatedOn DATETIME2
AS
BEGIN
SET NOCOUNT ON;

UPDATE dbo.CommissionSettings
SET CommsPercentage = @CommsPercentage, LastUpdatedOn = @LastUpdatedOn
WHERE MemberId = @MemberId
END