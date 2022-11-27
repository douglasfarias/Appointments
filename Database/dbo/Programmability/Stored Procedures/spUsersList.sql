CREATE PROCEDURE [dbo].[spUsersList]
	@Role int
AS
	select 
	[Id], 
	[CreatedAt], 
	[UpdatedAt], 
	[Deleted], 
	[Role], 
	[GivenName], 
	[Surename], 
	[Email], 
	[Phone] 
	from tbUsers
	where [Role] = @Role
