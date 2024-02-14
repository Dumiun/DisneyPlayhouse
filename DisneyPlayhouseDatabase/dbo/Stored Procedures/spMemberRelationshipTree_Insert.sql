CREATE PROCEDURE [dbo].[spMemberRelationshipTree_Insert]
@ChildId NVARCHAR(20),
@ParentId NVARCHAR(20)
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO [dbo].[MemberRelationshipTree] ([ChildId], [ParentId]) VALUES (@ChildId, @ParentId);
END
