USE [Menou]
GO

DECLARE @RestaurantId INT

--code
SELECT 
	[dbo].[Restaurant].[Id],
	[dbo].[Restaurant].[Name],
	[dbo].[Restaurant].[CreatedDate],
	[dbo].[Restaurant].[ModifiedDate]
FROM
	[dbo].[Restaurant]
WHERE
	[dbo].[Restaurant].[Id] = @RestaurantId
--/code