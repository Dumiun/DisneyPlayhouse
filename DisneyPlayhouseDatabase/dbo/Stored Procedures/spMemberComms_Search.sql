CREATE PROCEDURE [dbo].[spMemberComms_Search]
@MemberId NVARCHAR(20)
as
BEGIN
SELECT [CommsPercentage] FROM dbo.CommissionSettings WHERE MemberId = @MemberId
END