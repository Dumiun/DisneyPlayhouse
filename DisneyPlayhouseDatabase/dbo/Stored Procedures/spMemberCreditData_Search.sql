CREATE PROCEDURE [dbo].[spMemberCreditData_Search]
@MemberId NVARCHAR(20)
as
BEGIN
SELECT [CreditAllowed], [UsedCredit], [RemainingCredit] FROM dbo.Member_Credit WHERE MemberId = @MemberId
END