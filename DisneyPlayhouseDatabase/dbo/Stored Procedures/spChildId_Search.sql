CREATE PROCEDURE [dbo].[spChildId_Search]
@ParentId NVARCHAR(20)
AS
BEGIN
WITH RecursiveHierachy AS
(
SELECT ChildId, 1 AS depth
FROM dbo.MemberRelationshipTree
WHERE ParentId = @ParentId

UNION ALL

SELECT r.ChildId, rh.depth + 1
FROM dbo.MemberRelationshipTree r 
INNER JOIN RecursiveHierachy rh ON r.ParentId = rh.ChildId
WHERE rh.Depth <100 --Limit the depth to 100
)

SELECT DISTINCT ChildId
FROM RecursiveHierachy;
END;