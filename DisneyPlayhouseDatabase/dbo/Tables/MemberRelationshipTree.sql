CREATE TABLE [dbo].[MemberRelationshipTree]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ChildId] NVARCHAR(20) NOT NULL, 
    [ParentId] NVARCHAR(20) NOT NULL
)
