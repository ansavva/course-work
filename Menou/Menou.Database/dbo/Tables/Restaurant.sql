CREATE TABLE [dbo].[Restaurant]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [ModifiedDate] DATETIME2 NOT NULL
)
