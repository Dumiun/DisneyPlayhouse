CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[LoginId] NVARCHAR(20) UNIQUE NOT NULL, 
    [ParentLoginId] NVARCHAR(20) NOT NULL, 
    [AutoCredit] BIT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [LatestLoggedInDate] DATETIME2 NOT NULL,
)
