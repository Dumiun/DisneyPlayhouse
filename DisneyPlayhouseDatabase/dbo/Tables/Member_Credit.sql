CREATE TABLE [dbo].[Member_Credit]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MemberId] NVARCHAR(20) NOT NULL, 
    [CreditAllowed] DECIMAL(13, 3) NOT NULL, 
    [UsedCredit] DECIMAL(13, 3) NOT NULL, 
    [RemainingCredit] DECIMAL(13, 3) NOT NULL, 
    [LastUpdatedOn] DATETIME2 NOT NULL
)
