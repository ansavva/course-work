CREATE TABLE [dbo].[MenuItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [RestaurantId] INT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [ModifiedDate] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_MenuItem_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id])
)
