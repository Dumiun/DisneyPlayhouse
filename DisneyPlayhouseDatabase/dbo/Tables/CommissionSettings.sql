CREATE TABLE [dbo].[CommissionSettings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MemberId] NVARCHAR(20) NOT NULL, 
    [CommsPercentage] DECIMAL(4, 2) NULL, 
    [LastUpdatedOn] DATETIME2 NOT NULL
)
