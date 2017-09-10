USE [Ecommerce]
GO

DECLARE @RestaurantId INT

--code
SELECT 
	[dbo].[MenuItem].[Id],
	[dbo].[MenuItem].[Title],
	[dbo].[MenuItem].[Description],
	[dbo].[MenuItem].[CreatedDate],
	[dbo].[MenuItem].[ModifiedDate]
FROM
	[dbo].[MenuItem]
WHERE
	[dbo].[MenuItem].[RestaurantId] = @RestaurantId
--/code