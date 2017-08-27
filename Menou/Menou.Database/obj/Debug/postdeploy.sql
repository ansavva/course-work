/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


/* Merge statement for Restaurants */

CREATE TABLE #Restaurant
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [ModifiedDate] DATETIME2 NOT NULL
)

SET IDENTITY_INSERT #Restaurant ON

INSERT INTO #Restaurant ([Id], [Name], [CreatedDate], [ModifiedDate])
VALUES (1, 'Andreas'' Itlian', GETDATE(), GETDATE())

MERGE [dbo].[Restaurant] AS T
USING #Restaurant AS S
ON (T.[Id] = S.[Id]) 
WHEN NOT MATCHED BY TARGET
    THEN INSERT([Name], [CreatedDate], [ModifiedDate])
	     VALUES(S.[Name], S.[CreatedDate], S.[ModifiedDate])
WHEN MATCHED 
    THEN UPDATE SET T.[Name] = S.[Name], T.[CreatedDate] = S.[CreatedDate],
	                T.[ModifiedDate] = S.[ModifiedDate]
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;

SET IDENTITY_INSERT #Restaurant OFF;

DROP TABLE #Restaurant;


/* Insert statement for MenuItems */

CREATE TABLE #MenuItem
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [RestaurantId] INT NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [ModifiedDate] DATETIME2 NOT NULL, 
)

SET IDENTITY_INSERT #MenuItem ON

INSERT INTO #MenuItem ([Id], [Title], [Description], [RestaurantId], [CreatedDate], [ModifiedDate])
VALUES (
	1,
	'Meatball Stuffed Pizza Fritta', 
	'Meatballs, mushrooms, onions, cheeses and marinara sauce wrapped in a golden fried pizza dough. Served with homemade alfredo and marinara sauces.', 
	1,
	GETDATE(), 
	GETDATE())

INSERT INTO #MenuItem ([Id], [Title], [Description], [RestaurantId], [CreatedDate], [ModifiedDate])
VALUES (
	2,
	'Spinach-Artichoke Dip', 
	'A blend of spinach, artichokes, and five cheeses served warm with breadstick crostini.', 
	1,
	GETDATE(), 
	GETDATE())

MERGE [dbo].[MenuItem] AS T
USING #MenuItem AS S
ON (T.[Id] = S.[Id]) 
WHEN NOT MATCHED BY TARGET
    THEN INSERT([Title], [Description], [RestaurantId], [CreatedDate], [ModifiedDate]) 
		 VALUES(S.[Title], S.[Description], [RestaurantId], [CreatedDate], [ModifiedDate])
WHEN MATCHED 
    THEN UPDATE SET T.[Title] = S.[Title], T.[Description] = S.[Description], T.[RestaurantId] = S.[RestaurantId],
	                T.[CreatedDate] = S.[CreatedDate], T.[ModifiedDate] = S.[ModifiedDate]
WHEN NOT MATCHED BY SOURCE
    THEN DELETE;

SET IDENTITY_INSERT #MenuItem OFF;

DROP TABLE #MenuItem;
GO
