CREATE PROCEDURE [dbo].[spMemberCredit_Insert]
    @MemberId NVARCHAR(20), 
    @CreditAllowed DECIMAL(13, 3), 
    @UsedCredit DECIMAL(13, 3), 
    @RemainingCredit DECIMAL(13, 3), 
    @LastUpdatedOn DATETIME2
AS
BEGIN
SET NOCOUNT ON;

INSERT into dbo.Member_Credit (MemberId, CreditAllowed, UsedCredit, RemainingCredit, LastUpdatedOn)
VALUES (@MemberId, @CreditAllowed, @UsedCredit, @RemainingCredit, @LastUpdatedOn)
END