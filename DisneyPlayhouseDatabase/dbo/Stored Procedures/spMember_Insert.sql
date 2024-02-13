CREATE PROCEDURE [dbo].[spMember_Insert]
@LoginId NVARCHAR(20),
@ParentLoginId NVARCHAR(20),
@AutoCredit BIT,
@CreatedDate DATETIME2,
@LatestLoggedInDate DATETIME2
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO [dbo].[Member] (LoginId, ParentLoginId, AutoCredit, CreatedDate, LatestLoggedInDate)
VALUES (@LoginId, @ParentLoginId, @AutoCredit, @CreatedDate, @LatestLoggedInDate)
END