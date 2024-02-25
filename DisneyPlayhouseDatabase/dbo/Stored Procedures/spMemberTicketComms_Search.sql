CREATE PROCEDURE [dbo].[spMemberTicketComms_Search]
@MemberId NVARCHAR(20)

as
BEGIN
SELECT CommsPercentage FROM dbo.CommissionSettings WHERE MemberId = @MemberId
END