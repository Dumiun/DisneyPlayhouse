CREATE PROCEDURE [dbo].[spMemberAutoCredit_Search]
@LoginId NVARCHAR(20)
as
BEGIN
SELECT AutoCredit FROM dbo.Member WHERE LoginId = @LoginId
END