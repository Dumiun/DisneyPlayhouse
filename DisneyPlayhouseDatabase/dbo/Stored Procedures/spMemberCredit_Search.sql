CREATE PROCEDURE [dbo].[spMemberCredit_Search]
@MemberId NVARCHAR(20)

as
BEGIN
SELECT CreditAllowed FROM dbo.Member_Credit WHERE MemberId = @MemberId
END