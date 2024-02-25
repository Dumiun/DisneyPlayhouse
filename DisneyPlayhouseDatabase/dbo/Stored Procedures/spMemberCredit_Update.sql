CREATE PROCEDURE [dbo].[spMemberCredit_Update]
@MemberId NVARCHAR(20),
@CreditAllowed DECIMAL(13, 3),
@LastUpdatedOn DATETIME2
AS
BEGIN
SET NOCOUNT ON;

UPDATE dbo.Member_Credit
SET CreditAllowed = @CreditAllowed, LastUpdatedOn = @LastUpdatedOn
WHERE MemberId = @MemberId
END