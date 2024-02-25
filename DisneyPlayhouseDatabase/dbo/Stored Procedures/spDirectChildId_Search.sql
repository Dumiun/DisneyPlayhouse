CREATE PROCEDURE [dbo].[spDirectChildId_Search]
@ParentId NVARCHAR(20)
AS
BEGIN
SELECT ChildId
FROM dbo.MemberRelationshipTree
WHERE ParentId = @ParentId
END